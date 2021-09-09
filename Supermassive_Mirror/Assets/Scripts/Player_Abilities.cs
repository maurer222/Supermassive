using UnityEngine;
using System;
using Mirror;
using UnityEngine.UI;

public class Player_Abilities : NetworkBehaviour
{
    private Mass myMass;
    private int abilityLevel = 1;

    [Header("Mass Breakpoints")]
    [SerializeField] float breakpoint1 = 15;
    [SerializeField] float breakpoint2 = 30;
    [SerializeField] float breakpoint3 = 50;
    [SerializeField] float breakpoint4 = 100;

    private Button abilityButton1;
    private Button abilityButton2;
    private Button abilityButton3;
    private Button abilityButton4;

    [Header("Ability Key Bindings")]
    [SerializeField] KeyCode abilityKey1;
    [SerializeField] KeyCode abilityKey2;
    [SerializeField] KeyCode abilityKey3;
    [SerializeField] KeyCode abilityKey4;

    [Header("Ability Cooldown Timers")]
    [SerializeField] float ability1CooldownTimeMax = 2.0f;
    private          float ability1CooldownTimeRemaining = 0;
    [SerializeField] float ability2CooldownTimeMax = 20.0f;
    private          float ability2CooldownTimeRemaining = 0;
    [SerializeField] float ability3CooldownTimeMax = 45.0f;
    private          float ability3CooldownTimeRemaining = 0;
    [SerializeField] float ability4CooldownTimeMax = 60.0f;
    private          float ability4CooldownTimeRemaining = 0;

    public event EventHandler OnAbilityLevelChanged;

    private void Start()
    {
        if (isLocalPlayer) { myMass = GetComponent<Mass>(); }
        myMass.OnMassChanged += MyMass_OnMassChanged;
        abilityButton1 = GameObject.Find("Ability 1 Button").GetComponent<Button>();
        abilityButton2 = GameObject.Find("Ability 2 Button").GetComponent<Button>();
        abilityButton3 = GameObject.Find("Ability 3 Button").GetComponent<Button>();
        abilityButton4 = GameObject.Find("Ability 4 Button").GetComponent<Button>();
    }
    private void Update()
    {
        CheckPlayerInput();
    }

    private void CheckPlayerInput()
    {
        if (Input.GetKeyDown(abilityKey1) && abilityLevel >= 1)
        {
            UsePlayerAbility(1);
        }
        if (Input.GetKeyDown(abilityKey2) && abilityLevel >= 2)
        {
            UsePlayerAbility(2);
        }
        if (Input.GetKeyDown(abilityKey3) && abilityLevel >= 3)
        {
            UsePlayerAbility(3);
        }
        if (Input.GetKeyDown(abilityKey4) && abilityLevel >= 4)
        {
            UsePlayerAbility(4);
        }
    }

    private void MyMass_OnMassChanged(object sender, System.EventArgs e)
    {
        SetPlayerAbilityLevel();
        SetPlayerAbilityAccess();
        //update HUD
    }
    private void SetPlayerAbilityLevel()
    {
        if(myMass.GetMass() <= breakpoint1)
        {
            abilityLevel = 1;
            OnAbilityLevelChanged?.Invoke(this, EventArgs.Empty);
        }
        else if (myMass.GetMass() >= breakpoint1 && myMass.GetMass() <= breakpoint2)
        {
            abilityLevel = 2;
            OnAbilityLevelChanged?.Invoke(this, EventArgs.Empty);
        }
        else if (myMass.GetMass() >= breakpoint2 && myMass.GetMass() <= breakpoint3)
        {
            abilityLevel = 3;
            OnAbilityLevelChanged?.Invoke(this, EventArgs.Empty);
        }
        else if (myMass.GetMass() >= breakpoint3 && myMass.GetMass() <= breakpoint4)
        {
            abilityLevel = 4;
            OnAbilityLevelChanged?.Invoke(this, EventArgs.Empty);
        }
    }

    private void SetPlayerAbilityAccess()
    {
        if(abilityLevel == 1 && abilityButton1.interactable == false)
        {
            abilityButton1.interactable = true;
        }
        if (abilityLevel == 2 && abilityButton2.interactable == false)
        {
            abilityButton2.interactable = true;
        }
        if (abilityLevel == 3 && abilityButton3.interactable == false)
        {
            abilityButton3.interactable = true;
        }
        if (abilityLevel == 4 && abilityButton4.interactable == false)
        {
            abilityButton4.interactable = true;
        }
    }

    public void UsePlayerAbility(int abilityNumber)
    {
        //Use appropiate player ability
        //set the timer for cooldown
        switch(abilityNumber)
        {
            case 1:
                PlayerAbility1();
                Debug.Log("Ability 1 used!");
                break;
            case 2:
                //use ability 2
                Debug.Log("Ability 2 used!");
                break;
            case 3:
                //use ability 3
                Debug.Log("Ability 3 used!");
                break;
            case 4:
                //use ability 4
                Debug.Log("Ability 4 used!");
                break;
            default:
                Debug.Log("Player Ability not found.");
                break;
        }
    }

    private void PlayerAbility1()
    {
        
    }

    private void PlayerAbility2()
    {
        
    }

    private void PlayerAbility3()
    {
        
    }

    private void PlayerAbility4()
    {
        
    }

    public int GetAbilityLevel()
    {
        return abilityLevel;
    }
}
