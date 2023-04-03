Shader "Custom/Outline"
{
    Properties
    {
        _MainTex("Main Texture", 2D) = "white" {}
        _BumpTex("Normal Map", 2D) = "white" {}
        _mySlider("Bump Amount", Range(0,15)) = 1

        _OutlineColor("Outline Color", Color) = (0,0,0,1)
        _Outline("Outline Width", Range(0, 0.07)) = 0.005

        _RampTex("Ramp Texture", 2D) = "white" {}

        _RimColor("Rim Color", Color) = (0, 0.5, 0.5, 0.0)
        _RimPower("Rim Power", Range(0.5, 8.0)) = 3.0
    }
        SubShader
        {
            ZWrite Off
            CGPROGRAM
            #pragma surface surf Lambert vertex:vert

        struct Input
        {
            float2 uv_MainTex;

        };
        sampler2D _MainTex;

        float _Outline;
        float4 _OutlineColor;


        void vert(inout appdata_full v)
        {
            v.vertex.xyz += v.normal * _Outline;
        }

        void surf(Input IN, inout SurfaceOutput o)
        {
            o.Emission = _OutlineColor.rgb;
        }
        ENDCG

            ZWrite On
            CGPROGRAM
            #pragma surface surf ToonRamp

            sampler2D _RampTex;

        float4 LightingToonRamp(SurfaceOutput s, fixed3 lightDir, fixed atten)
        {
            float diff = dot(s.Normal, lightDir);
            float h = diff * 0.5 + 0.5;
            float2 rh = h;
            float3 ramp = tex2D(_RampTex, rh).rgb;

            float4 c;
            c.rgb = s.Albedo * _LightColor0.rgb * (ramp);
            c.a = s.Alpha;
            return c;

        }

            struct Input
        {
            float2 uv_MainTex;
            float2 uv_BumpTex;
            float3 viewDir;
        };
        sampler2D _MainTex;
        sampler2D _BumpTex;
        half _mySlider;
        float4 _RimColor;
        float _RimPower;

        void surf(Input IN, inout SurfaceOutput o)
        {
            o.Albedo = tex2D(_MainTex, IN.uv_MainTex);
            o.Normal = UnpackNormal(tex2D(_BumpTex, IN.uv_BumpTex)); //rgb to xyz
            o.Normal *= float3(_mySlider, _mySlider, 1);

            half rim = 1.0 - saturate(dot(normalize(IN.viewDir), o.Normal));
            o.Emission = _RimColor.rgb * pow(rim, _RimPower);
        }
        ENDCG
        }
            FallBack "Diffuse"
}
