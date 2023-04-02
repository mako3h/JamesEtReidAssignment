using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenCameraShader : MonoBehaviour
{
    public Material m_renderMaterial1;
    public Material m_renderMaterial2;
    public Material m_renderMaterial3;

    private Material m_currentMaterial;
    private Material m_previousMaterial;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            m_previousMaterial = m_currentMaterial;
            m_currentMaterial = m_renderMaterial1;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            m_previousMaterial = m_currentMaterial;
            m_currentMaterial = m_renderMaterial2;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            m_previousMaterial = m_currentMaterial;
            m_currentMaterial = m_renderMaterial3;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            m_currentMaterial = m_previousMaterial;
        }
    }

    void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        if (m_currentMaterial != null)
        {
            Graphics.Blit(source, destination, m_currentMaterial);
        }
        else
        {
            Graphics.Blit(source, destination);
        }
    }
}