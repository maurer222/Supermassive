using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Init : MonoBehaviour
{
    [SerializeField] Material playerMaterial;

    private void Start()
    {
        Camera.main.GetComponent<Camera_Handler>().SetCameraTarget(gameObject.transform);

        //TODO Set the players skin if it is not the default
        gameObject.GetComponent<Renderer>().material = playerMaterial;
    }
}
