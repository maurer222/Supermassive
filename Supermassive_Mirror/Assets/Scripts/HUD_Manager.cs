using UnityEngine;
using UnityEngine.UI;

public class HUD_Manager : MonoBehaviour
{
    private float currentMass;
    private float incomingMass;
    private int remainingStars;
    private GameObject starSpawner;
    private Text currentMassText;
    private Text incomingMassText;
    private Text remainingStarsText;
    private Mass mass;

    private void Start()
    {
        starSpawner = GameObject.Find("Star Spawner");
        currentMassText = GameObject.Find("Current Mass").GetComponent<Text>();
        incomingMassText = GameObject.Find("Incoming Mass").GetComponent<Text>();
        remainingStarsText = GameObject.Find("Remaining Stars").GetComponent<Text>();
    }

    public void SetMassReference(Mass mass)
    {
        mass.OnMassChanged += Mass_OnMassChanged;
        this.mass = mass;
    }

    private void Mass_OnMassChanged(object sender, System.EventArgs e)
    {
        SetUICurrentMassText();
        SetUIIncomingMassText();
    }

    private void Update(){ SetUIRemainingStarsText();}

    public void SetUICurrentMassText()
    {
        currentMass = ((int)(mass.GetMass() * 100))/100.0f;
        currentMassText.text = "Current Mass: " + currentMass.ToString();
    }

    public void SetUIIncomingMassText()
    {
        incomingMass = ((int)(mass.GetIncomingMass() * 100)) / 100.0f;
        incomingMassText.text = "Incoming Mass: " + incomingMass.ToString();
    }

    public void SetUIRemainingStarsText()
    {
        remainingStars = starSpawner.transform.childCount;
        remainingStarsText.text = "Remaining Stars: " + remainingStars.ToString();
    }
    private void OnDestroy() { if(mass != null) mass.OnMassChanged -= Mass_OnMassChanged; }
}