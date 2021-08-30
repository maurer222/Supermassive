using Mirror;
using System;
using UnityEngine;

public class Mass : NetworkBehaviour
{
    private float currentMass;
    private float incomingMass;
    public event EventHandler OnMassChanged;

    private void Start()
    {
        if (gameObject.name.Contains("Player"))
        {
            currentMass = 1.2f;
            incomingMass = currentMass;
            transform.localScale = new Vector3(currentMass, currentMass, currentMass);
        }
        if (gameObject.name.Contains("Star"))
        {
            currentMass = UnityEngine.Random.Range(.003f, .2f);
            incomingMass = currentMass;
            transform.localScale = new Vector3(currentMass, currentMass, currentMass);
        }
        if (gameObject.name.Contains("Antimatter"))
        {
            currentMass = -1f;
            incomingMass = currentMass;
            transform.localScale = Vector3.one;
        }
        if(isLocalPlayer){ FindObjectOfType<HUD_Manager>().SetMassReference(this); }
    }

    private void Update()
    {
        if (gameObject.name.Contains("Player") && (currentMass < incomingMass) && isLocalPlayer)
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
        OnMassChanged?.Invoke(this, EventArgs.Empty);
    }

    public float GetMass()
    {
        return currentMass;
    }

    public void SetMass(float mass)
    {
        currentMass += mass;
        OnMassChanged?.Invoke(this, EventArgs.Empty);
    }

    public float GetIncomingMass()
    {
        return incomingMass;
    }

    public void SetIncomingMass(float incMass)
    {
        incomingMass += incMass;
        OnMassChanged?.Invoke(this, EventArgs.Empty);
    }
}
