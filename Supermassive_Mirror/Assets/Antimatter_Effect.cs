using UnityEngine;
using Mirror;

public class Antimatter_Effect : NetworkBehaviour
{
    [SerializeField] float antimatterFlatDamage = .5f;
    [SerializeField] float antimatterPercentDamage = .01f;

    private void OnTriggerEnter(Collider other)
    {
        if(other.name.Contains("Player"))
        {
            Mass otherMass = other.GetComponent<Mass>();

            otherMass.SetIncomingMass(-(antimatterFlatDamage + otherMass.GetMass() * antimatterPercentDamage));
            otherMass.SetMass        (-(antimatterFlatDamage + otherMass.GetMass() * antimatterPercentDamage));
            Destroy(this.gameObject);
        }
    }
}
