using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mass : NetworkBehaviour
{
    private float currentMass;
    private float incomingMass;
    private HUD_Manager HUD;
    private Mass myMass;

    private void Start()
    {
        HUD = GameObject.Find("Canvas").GetComponent<HUD_Manager>();
        myMass = gameObject.GetComponent<Mass>();

        if (gameObject.name.Contains("Player"))
        {
            currentMass = 1.2f;
            incomingMass = currentMass;
            transform.localScale = new Vector3(currentMass, currentMass, currentMass);
        }
        if (gameObject.name.Contains("Star"))
        {
            currentMass = Random.Range(.003f, .2f);
            incomingMass = currentMass;
            transform.localScale = new Vector3(currentMass, currentMass, currentMass);
        }
        if (gameObject.name.Contains("Antimatter"))
        {
            currentMass = -1f;
            incomingMass = currentMass;
            transform.localScale = Vector3.one;
        }
    }

    private void Update()
    {
        if (gameObject.name.Contains("Player") && (currentMass < incomingMass))
        {
            SmoothSizeIncrease();
        }
    }

    void SmoothSizeIncrease()
    {
        Vector3 targetMass = new Vector3(incomingMass, incomingMass, incomingMass);
        Vector3 smoothedMass = Vector3.Lerp(transform.localScale, targetMass * .5f, .01f * Time.deltaTime);
        currentMass += .7f * Time.deltaTime;
        transform.localScale = smoothedMass;
        HUD.SetUICurrentMassText(myMass);
        HUD.SetUIIncomingMassText(myMass);
    }

    public float GetMass()
    {
        return currentMass;
    }

    public void SetMass(float mass)
    {
        currentMass += mass;
    }

    public float GetIncomingMass()
    {
        return incomingMass;
    }

    public void SetIncomingMass(float incMass)
    {
        incomingMass += incMass;
    }
}
