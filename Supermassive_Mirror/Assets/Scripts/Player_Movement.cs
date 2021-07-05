using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Player_Movement : NetworkBehaviour
{
    [SerializeField] float moveSpeed = 1;

    private void Update()
    {
        PlayerMovement();
    }

    void PlayerMovement()
    {
        if(isLocalPlayer)
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical   = Input.GetAxis("Vertical");
            Vector3 movement     = new Vector3(moveHorizontal, moveVertical, 0);
            transform.position  += movement * moveSpeed;
        }
    }
}