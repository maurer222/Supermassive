using UnityEngine;
using System;
using Mirror;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class Player_Abilities : NetworkBehaviour
{
    private Mass myMass;
    private int abilityLevel = 1;
    [SerializeField] GameObject antimatterPrefab;

    [Header("Ability Tuning")]
    [SerializeField] int projectileSpeed = 500;
    [SerializeField] float antimatterProjectileExpiration = 10f;
    [SerializeField] int ability3ScaleAmount = 3000;

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
    //private          float ability1CooldownTimeRemaining = 0;
    [SerializeField] float ability2CooldownTimeMax = 20.0f;
    //private          float ability2CooldownTimeRemaining = 0;
    [SerializeField] float ability3CooldownTimeMax = 45.0f;
    //private          float ability3CooldownTimeRemaining = 0;
    [SerializeField] float ability4CooldownTimeMax = 60.0f;
    //private          float ability4CooldownTimeRemaining = 0;

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
    private void Update() { CheckPlayerInput(); }

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
                break;
            case 2:
                PlayerAbility2();
                break;
            case 3:
                PlayerAbility3();
                break;
            case 4:
                PlayerAbility4();
                break;
            default:
                Debug.Log("Player Ability not found.");
                break;
        }
    }

    private void PlayerAbility1()
    {
        GameObject projectile = SpawnAntimatterProjectile();
        MoveAnitmatterProjectile(projectile);
        StartCoroutine(DestroyProjectileAfterTimer(projectile));
        StartCoroutine(PutAbilityButtonOnCooldown(ability1CooldownTimeMax, abilityButton1));
    }

    private void PlayerAbility2()
    {
        Collider collider = this.gameObject.GetComponent<Collider>();
        ReducePlayerModelAlpha();
        collider.enabled = false;
        StartCoroutine(EnableColliderAfterTimer(collider));
        StartCoroutine(PutAbilityButtonOnCooldown(ability2CooldownTimeMax, abilityButton2));
    }
    
    private void PlayerAbility3()
    {
        IncreasePlayerGravityScale();
        StartCoroutine(ResetGravityScaleAfterTimer());
        StartCoroutine(PutAbilityButtonOnCooldown(ability3CooldownTimeMax, abilityButton3));
    }

    private void PlayerAbility4()
    {
        StartCoroutine(PutAbilityButtonOnCooldown(ability1CooldownTimeMax, abilityButton4));
        //passively your gravity affects enemy players
        //Consume enemy player's mass over time
        //bigger you are the faster you eat
    }

    //*************************| Ability 1 |*************************//
    public GameObject SpawnAntimatterProjectile()
    {
        //the server needs to spawn the object
        GameObject antimatterProjectile = Instantiate(antimatterPrefab,
                                           gameObject.transform.position + new Vector3(0, 1, 0),
                                           Quaternion.identity) as GameObject;
        antimatterProjectile.transform.parent = GameObject.Find("Antimatter Projectile Parent").transform;
        NetworkServer.Spawn(antimatterProjectile);

        return antimatterProjectile;
    }

    private void MoveAnitmatterProjectile(GameObject antimatterProjectile)
    {
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10);
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        antimatterProjectile.transform.LookAt(mousePosition);
        antimatterProjectile.GetComponent<Rigidbody>().AddForce(antimatterProjectile.transform.forward * projectileSpeed);
    }

    IEnumerator DestroyProjectileAfterTimer(GameObject projectile)
    {

        yield return new WaitForSeconds(antimatterProjectileExpiration);
        NetworkServer.Destroy(projectile);
    }

    //*************************| Ability 2 |*************************//
    private void ReducePlayerModelAlpha()
    {
        Renderer rend = GetComponent<Renderer>();
        Color color = rend.material.color;

        color.a = Mathf.Lerp(1f, 0f, 10);
        rend.material.color = color;
    }

    IEnumerator EnableColliderAfterTimer(Collider collider)
    {
        yield return new WaitForSeconds(ability2CooldownTimeMax);
        collider.enabled = true;
    }

    //*************************| Ability 3 |*************************//

    private void IncreasePlayerGravityScale()
    {
        gameObject.GetComponent<Gravity>().SetGravityScale(ability3ScaleAmount);
    }

    IEnumerator ResetGravityScaleAfterTimer()
    {
        yield return new WaitForSeconds(ability3CooldownTimeMax);
        gameObject.GetComponent<Gravity>().ResetGravityScale();
    }

    //***************************| Misc |****************  ************//
    public int GetAbilityLevel() { return abilityLevel; }

    IEnumerator PutAbilityButtonOnCooldown(float abilityCooldownTimer, Button abilityButton)
    {
        abilityButton.enabled = false;
        yield return new WaitForSeconds(abilityCooldownTimer);
        abilityButton.enabled = true;
    }

    private void OnDestroy() { myMass.OnMassChanged -= MyMass_OnMassChanged; }
}