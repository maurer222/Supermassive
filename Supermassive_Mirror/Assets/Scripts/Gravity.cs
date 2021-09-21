using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Gravity : NetworkBehaviour
{
    Mass myMass;
    [SerializeField] float gravityRangeMultiplier = 2;
    [SerializeField] int gravityScale = 500;

    private void Start()
    {
        myMass = GetComponent<Mass>();
    }

    private void FixedUpdate()
    {
        if(isClient)
        {
            CmdGravity();
        }
    }

    [ClientRpc]
    void RPCGravity()
    {
        GravityEffect();
    }

    [Command]
    void CmdGravity()
    {
        RPCGravity();
    }

    public void GravityEffect()
    {
        int layerMask = 1 << 10;

        //check for other colliders in a radius around the game object
        Collider[] hitColliders = Physics.OverlapSphere(transform.position,
                                                        myMass.GetMass() * gravityRangeMultiplier,
                                                        layerMask);

        foreach (Collider collider in hitColliders)
        {
            //get the mass of the object in range
            Mass otherMass = collider.GetComponent<Mass>();

            //if this mass is greater/equal to the colliding object's mass and the collider isnt null
            if ((otherMass != null) && (otherMass.GetMass() <= myMass.GetMass()))
            {
                // calculate direction from target to me
                Vector3 forceDirection = new Vector3();
                forceDirection = transform.position - collider.transform.position;

                // apply force on other object towards this object = ((mass1 * mass2)* gravity scaling) / 
                //                                                   ((distance^2) + 1(to never divide by 0))
                //                                                   * time.dealtatime
                collider.GetComponent<Rigidbody>().AddForce(forceDirection.normalized *
                                ((myMass.GetMass() * otherMass.GetMass()) * gravityScale /
                                (Mathf.Pow(Vector3.Distance(transform.position, collider.transform.position), 2) + 1)) *
                                Time.fixedDeltaTime);

                //make sure the object faces this object as it moves inward
                collider.gameObject.transform.LookAt(gameObject.transform);
            }
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        Mass otherMass = collision.GetComponent<Mass>();

        if (collision.gameObject.name.Contains("Star"))
        {
            myMass.SetIncomingMass(otherMass.GetMass());
            Destroy(collision.gameObject);
        }
    }

    [Command]
    void CmdDestroyStar(GameObject star)
    {
        RPCDestroyStar(star);
    }

    [ClientRpc]
    void RPCDestroyStar(GameObject star)
    {
        NetworkServer.Destroy(star.gameObject);
    }

    public void ResetGravityScale()
    {
        gravityScale = 500;
    }

    public void SetGravityScale(int newScale)
    {
        gravityScale = newScale;
    }
}
