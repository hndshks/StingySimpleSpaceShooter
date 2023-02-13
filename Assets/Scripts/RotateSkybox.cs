using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSkybox : MonoBehaviour
{
    [SerializeField] private float m_rotationSpeed = 1f;

    private void FixedUpdate()
    {
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * m_rotationSpeed);
    }
}
