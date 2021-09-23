using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SM_Network_Manager : NetworkManager
{
    public override void OnClientConnect(NetworkConnection conn)
    {
        //Run the base logic from the original NetworkManager class
        base.OnClientConnect(conn);
    }

    public override void OnServerAddPlayer(NetworkConnection conn)
    {
        //Run the base logic from the original NetworkManager class
        base.OnServerAddPlayer(conn);

        Debug.Log($"There are now {numPlayers} players connected");
    }
}