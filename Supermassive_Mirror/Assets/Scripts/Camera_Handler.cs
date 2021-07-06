using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Handler : MonoBehaviour
{
    [SerializeField] float skyboxRotationSpeed = 1.5f;
    [SerializeField] Transform target;
    private Vector3 cameraOffset;

    private void Start()
    {
        cameraOffset = new Vector3(0, 0, -10);
    }

    void Update()
    {
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * skyboxRotationSpeed);
        CameraTargetFollow();
    }

    void CameraTargetFollow()
    {
        transform.position = target.position + cameraOffset;
    }
    public void SetCameraTarget(Transform currentTarget){target = currentTarget;}
}
