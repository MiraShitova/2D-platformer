using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public Player player;


    private void OnTriggerStay2D(Collider2D collision) 
    {
        player.isGrounded = true; 
    }

    private void OnTriggerExit2D(Collider2D collision) 
    {
        player.isGrounded = false;
    }
}
