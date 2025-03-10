using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public Player player;

    public bool isActive = true;
    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.CompareTag("Player") && isActive ) //якщо гравець заходить у трігер і чекпоінт активний, 
        {
            player.SpawnPosition = transform.position;  
            isActive = false; //то у гравця тепер нова позиція для респавну
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        player.isGrounded = true;
    }

}

