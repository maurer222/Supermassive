using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Init : NetworkBehaviour
{
    [SerializeField] Material playerMaterial;
    Mass myMass;
    HUD_Manager HUD;

    private void Start()
    {
        myMass = gameObject.GetComponent<Mass>();
        HUD = GameObject.Find("Canvas").GetComponent<HUD_Manager>();
        Camera.main.GetComponent<Camera_Handler>().SetCameraTarget(gameObject.transform);
        gameObject.GetComponent<Renderer>().material = playerMaterial;
        HUD.SetUICurrentMassText(myMass);
        HUD.SetUIIncomingMassText(myMass);

        //TODO Allow player to choose a skin and set it on their player object
    }

    private void Update()
    {
        HUD.SetUICurrentMassText(myMass);
        HUD.SetUIIncomingMassText(myMass);
    }
}
