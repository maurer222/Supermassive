using UnityEngine;
using Mirror;

public class Boundry_Handler : NetworkBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("We made it!");
        if(collision.gameObject.name == "Star")
        {
            
        }
        else if(collision.gameObject.name.Contains("Player"))
        {
            collision.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }

    [Command]
    void CmdDestroyStar(GameObject collisionObject)
    {
        //RPCDestroyStar
    }
}
