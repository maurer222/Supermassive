using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Handler : MonoBehaviour
{
    [SerializeField] float skyboxRotationSpeed = 1.5f;
    private Transform target;

    void Update()
    {
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * skyboxRotationSpeed);
    }

    public void SetCameraTarget(Transform currentTarget)
    {
        target = currentTarget;
    }
}
