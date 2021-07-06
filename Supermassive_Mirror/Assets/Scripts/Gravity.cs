using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
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
            float otherMass = collider.GetComponent<Mass>().GetMass();

            //if this mass is greater/equal to the colliding object's mass and the collider isnt null
            if ((collider.GetComponent<Mass>() != null) && (otherMass <= myMass.GetMass()))
            {
                // calculate direction from target to me
                Vector3 forceDirection = new Vector3();
                forceDirection = transform.position - collider.transform.position;

                // apply force on other object towards this object = ((mass1 * mass2)* gravity scaling) / 
                //                                                   ((distance^2) + 1(to never divide by 0)) * time.dealtatime
                collider.GetComponent<Rigidbody>().AddForce(forceDirection.normalized *
                                                            ((myMass.GetMass() * otherMass) * gravityScale /
                                                            (Mathf.Pow(Vector3.Distance(transform.position, collider.transform.position), 2) + 1)) *
                                                            Time.fixedDeltaTime);

                //make sure the object faces this object as it moves inward
                collider.gameObject.transform.LookAt(gameObject.transform);
            }
        }
    }
}
