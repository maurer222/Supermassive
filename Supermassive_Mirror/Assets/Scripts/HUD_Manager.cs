using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD_Manager : MonoBehaviour
{
    private float currentMass;
    private float incomingMass;
    private int remainingStars;

    private void Update()
    {
        SetUIRemainingStarsText();
    }

    public void SetUICurrentMassText(Mass mass)
    {
        currentMass = mass.GetMass();
        GetComponentInChildren<Text>().text = currentMass.ToString();
    }

    public void SetUIIncomingMassText(Mass mass)
    {
        incomingMass = mass.GetIncomingMass();
        GetComponentInChildren<Text>().text = incomingMass.ToString();
    }

    public void SetUIRemainingStarsText()
    {
        remainingStars = FindObjectOfType<Star_Spawner>().transform.childCount;
        GetComponentInChildren<Text>().text = remainingStars.ToString();
    }
}
