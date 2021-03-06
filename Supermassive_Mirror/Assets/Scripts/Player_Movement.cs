using UnityEngine;
using Mirror;

public class Player_Movement : NetworkBehaviour
{
    [SerializeField] float moveSpeed = 1f;

    private void Update()
    {
        if (isServer)
        {
            PlayerMovement();
        }
        else if (isClientOnly)
        {
            CmdClientMove();
        } 
    }

    private void PlayerMovement()
    {
        if (!hasAuthority) { return; }
        
        if (isLocalPlayer)
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");
            Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0);
            transform.position += movement * moveSpeed * Time.deltaTime;
        }
    }

    [Command]
    private void CmdClientMove()
    {
        //validate logic here
        RpcMove();
    }

    [ClientRpc]
    private void RpcMove()
    {
        if (isLocalPlayer)
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");
            Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0);
            transform.position += movement * moveSpeed * Time.deltaTime;
        }
    }

    public void SetMoveSpeed(float newSpeed){moveSpeed = newSpeed;}
    public float GetMoveSpeed(){return moveSpeed;}
}