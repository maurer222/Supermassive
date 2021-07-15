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
        gameObject.GetComponent<Camera>().enabled = true;
        myMass = gameObject.GetComponent<Mass>();
        HUD = GameObject.Find("Canvas").GetComponent<HUD_Manager>();
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
