using Mirror;
using UnityEngine;

public class Player_Init : NetworkBehaviour
{
    [SerializeField] Material playerMaterial;
    private Vector3 offset;

    void Start()
    {
        offset = new Vector3(0, 0, 10f);

        if (isLocalPlayer)
        {
            gameObject.GetComponent<Renderer>().material = playerMaterial;

            Camera.main.transform.position = this.transform.position - offset;
            Camera.main.transform.LookAt(this.transform.position);
            Camera.main.transform.parent = this.transform;
        }
    }
}