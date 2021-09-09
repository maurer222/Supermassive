using UnityEngine;
using Mirror;

public class Player_Abilities : NetworkBehaviour
{
    private Mass myMass;
    private int abilityLevel;
    [SerializeField] float breakpoint1 = 15;
    [SerializeField] float breakpoint2 = 30;
    [SerializeField] float breakpoint3 = 50;
    [SerializeField] float breakpoint4 = 100;

    [SerializeField] 

    private void Start()
    {
        if (isLocalPlayer) { myMass = GetComponent<Mass>(); }
        myMass.OnMassChanged += MyMass_OnMassChanged;
    }

    private void MyMass_OnMassChanged(object sender, System.EventArgs e)
    {
        if(myMass.GetMass() <= breakpoint1)
        {
            abilityLevel = 0;
            Debug.Log("Ability Level: 0");
        }
        if (myMass.GetMass() <= breakpoint2)
        {
            abilityLevel = 1;
            Debug.Log("Ability Level: 1");
        }
        if (myMass.GetMass() <= breakpoint3)
        {
            abilityLevel = 2;
            Debug.Log("Ability Level: 2");
        }
        if (myMass.GetMass() <= breakpoint4)
        {
            abilityLevel = 3;
            Debug.Log("Ability Level: 3");
        }
    }

    public int GetAbilityLevel()
    {
        return abilityLevel;
    }
}
