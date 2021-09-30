using Mirror;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Player_Init : NetworkBehaviour
{
    [SerializeField] Material playerMaterial;
    private Vector3 offset;

    [SyncVar]
    private string playerName = "Missing Name";

    void Start()
    {
        offset = new Vector3(0, 0, 15f);

        if (isLocalPlayer)
        {
            gameObject.GetComponent<Renderer>().material = playerMaterial;

            Camera.main.transform.position = this.transform.position - offset;
            Camera.main.transform.LookAt(this.transform.position);
            Camera.main.transform.parent = this.transform;
        }
    }

    [Server]
    public void SetPlayerName(string name)
    {
        playerName = name;
        GetComponentInChildren<TMP_Text>().text = playerName;
    }

    [Server]
    public void SetPlayerSkin(Material newPlayerMaterial)
    {
        playerMaterial = newPlayerMaterial;
    }
}