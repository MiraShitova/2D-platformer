using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bust : MonoBehaviour
{
    public float bounceMultiplier = 8.0f; // Множник підсилення стрибка


    private void OnCollisionEnter2D(Collision2D collision)
    {
    
        if (collision.gameObject.CompareTag("Player")) // Перевіряємо, чи гравець зіткнувся з батутом
        { 
            collision.rigidbody.AddForce(Vector2.up * bounceMultiplier, ForceMode2D.Impulse); // Додаємо підсилений імпульс вгору
        }
    }
  
}
