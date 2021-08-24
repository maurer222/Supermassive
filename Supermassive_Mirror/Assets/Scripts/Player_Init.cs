using Mirror;
using UnityEngine;

public class Player_Init : NetworkBehaviour
{
    [SerializeField] Material playerMaterial;

    private void Start()
    {
        if (isLocalPlayer)
        {
            GetComponentInChildren<Camera>().enabled = true;
            gameObject.GetComponent<Renderer>().material = playerMaterial;
        }
    }
}
