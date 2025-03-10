using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public Player player;


    private void OnTriggerStay2D(Collider2D collision) //перевіряє чи щось входить/дотокається в зону трігера 
    {
        player.isGrounded = true; //звертаємось до скріпта гравця (і до зміної isGrounded) і вказуємо тут нове значення змінної
    }

    private void OnTriggerExit2D(Collider2D collision) //перевіряє чи щось виходить з зони трігера 
    {
        player.isGrounded = false;
    }
}
