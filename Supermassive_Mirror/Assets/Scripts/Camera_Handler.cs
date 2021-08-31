using UnityEngine;

public class Camera_Handler : MonoBehaviour
{
    [SerializeField] float skyboxRotationSpeed = 1.5f;

    void Update()
    {
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * skyboxRotationSpeed);
    }
}