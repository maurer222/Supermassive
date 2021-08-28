using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Handler : NetworkBehaviour
{
    [SerializeField] float skyboxRotationSpeed = 1.5f;
    [SerializeField] Transform target;
    private Vector3 cameraOffset;

    private void Start()
    {
        GameObject.Find("Opening Camera").SetActive(false);
        SetCameraTarget(target);
        cameraOffset = new Vector3(0, 0, -10);
    }

    void Update()
    {
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * skyboxRotationSpeed);
    }

    public void SetCameraTarget(Transform currentTarget){target = currentTarget;}
}
