using Mirror;
using UnityEngine;

public class SM_Network_Manager : NetworkManager
{
    [SerializeField] Material playerSkin;
    public override void OnClientConnect(NetworkConnection conn)
    {
        //Run the base logic from the original NetworkManager class
        base.OnClientConnect(conn);
    }

    public override void OnServerAddPlayer(NetworkConnection conn)
    {
        //Run the base logic from the original NetworkManager class
        base.OnServerAddPlayer(conn);

        //Create a scriptable object to transfer data the player selected from the Lobby to the Gameplay scene
        conn.identity.GetComponentInChildren<Player_Init>().SetPlayerName($"Player {numPlayers}");
        //conn.identity.GetComponentInChildren<Player_Init>().SetPlayerSkin(playerSkin);

        Debug.Log($"There are now {numPlayers} players connected");
    }
} 