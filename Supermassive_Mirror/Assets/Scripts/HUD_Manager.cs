using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD_Manager : MonoBehaviour
{
    private float currentMass;
    private float incomingMass;
    private int remainingStars;
    private Text currentMassText;
    private Text incomingMassText;
    private Text remainingStarsText;
    private void Start()
    {
        currentMassText = GameObject.Find("Current Mass").GetComponent<Text>();
        incomingMassText = GameObject.Find("Incoming Mass").GetComponent<Text>();
        remainingStarsText = GameObject.Find("Remaining Stars").GetComponent<Text>();
    }

    private void Update()
    {
        SetUIRemainingStarsText();
    }

    public void SetUICurrentMassText(Mass mass)
    {
        currentMass = ((int)(mass.GetMass() * 100))/100.0f;
        currentMassText.text = "Current Mass: " + currentMass.ToString();
    }

    public void SetUIIncomingMassText(Mass mass)
    {
        incomingMass = ((int)(mass.GetIncomingMass() * 100)) / 100.0f;
        incomingMassText.text = "Incoming Mass: " + incomingMass.ToString();
    }

    public void SetUIRemainingStarsText()
    {
        remainingStars = FindObjectOfType<Star_Spawner>().transform.childCount;
       remainingStarsText.text = "Remaining Stars: " + remainingStars.ToString();
    }
}
