# JamesEtReidAssignment

Integrations: <br>
<br>
Normal Mapping/Texturing: <br>
Normal Maps contain info about the normal at that UV coordinate, normals are then used by the fragment shader. We use colour, main texture, bump texture and bump slider properties. Uses the lambert lighting model. We input our main texture and normal map texture. Our albedo is equal to our main texture multiplied by our colour property. Normal is unpacked, converting the rgb values of the normal map to xyz coordinates, and is then multiplied by the slider value. <br>
<br>
As for our implementations, we utilized normal mapping in many aspects of our game. For example, the beach theme is created through the use of sand and water textures. Pairing this with the other textures applied to other gameobjects, the scene becomes much more unique and visually appealing. <br>
<br>
Toon Shading: <br>
Toon shading, or cel shading, is a type of rendering design to make 3D graphics appear flat, this is done by using less shading colour, instead of a gradient. Instead of a gradual linear transition, toon shading switches colours at the extremes. Requires an image of bands, with separate shading levels, the toon ramp. In our cel shading shader, we use the ToonRamp lighting model, to help apply the toon effect. We then have our LightingToonRamp function to calculate the toonshading itself. We perform calculations such as dotting the normal and light direction to acquire our diff value. We then add our Ramp Texture with our diff value to set our ramp value. Lastly we multiply our albedo by the colour of our light by our ramp value. We then return c, our toon shading value. Lastly in our surf function, we add a colour property to our albedo. <br>
<br>


<br>
Colour Grading: <br>
Alters and enhances the colour of an image by changing the colour of a pixel to another colour. Done through the use of LUTs/Lookup Tables. Our properties include a main texture, LUT texture and Contribution Range or, the intensity of the grade. We then ensure there is no culling or depth so that we can see the effects taking place, and we create a vertex and fragment shader. In our appdata, we have our position, aswell as uv coordinates. In our v2f function, we have the same; position and uv coordinates. Our vertex shader transforms our object from object space to clip space. In our fragment shader, our colour is saturated (0<value<1), we add precision to our sampling so we cannot go beyond the limits of the LUT and we calculate the offset to map the image to the LUT. <br>
<br>
In terms of the applications of our own implemented colour grades, we designed our LUTs to represent two settings to fit the beach theme of our game. The first, the cool LUT, is to represent a colder nighttime atmosphere. The second, the warm LUT, is to represent a bright and sunny daytime summer atmosphere. <br>
