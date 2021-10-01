using Mirror;
using UnityEngine;
using TMPro;

public class Player_Init : NetworkBehaviour
{
    [SerializeField] Material playerMaterial;
    [SerializeField] Player_Scriptable playerScriptable;
    [SerializeField] Vector3 cameraOffset;
    [SyncVar] private string playerName;

    void Start()
    {
        if (isLocalPlayer)
        {
            SetPlayerSkin(playerScriptable.playerSkin);
            SetPlayerName(playerScriptable.playerName);
            gameObject.GetComponent<Renderer>().material = playerMaterial;

            Camera.main.transform.position = this.transform.position - cameraOffset;
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