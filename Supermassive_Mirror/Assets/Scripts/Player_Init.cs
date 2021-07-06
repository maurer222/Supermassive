using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Init : MonoBehaviour
{
    [SerializeField] Material playerMaterial;

    private void Start()
    {
        Camera.main.GetComponent<Camera_Handler>().SetCameraTarget(gameObject.transform);
        gameObject.GetComponent<Renderer>().material = playerMaterial;

        //TODO Allow player to choose a skin and set it on their player object
    }
}
