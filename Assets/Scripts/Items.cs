using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    public int itemValue = 1; // Кількість предметів, яку дає цей предмет

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Отримуємо доступ до ItemCollector на гравці і збільшуємо кількість зібраних предметів
            other.gameObject.GetComponent<ItemCollector>().CollectItem(itemValue);

            Destroy(gameObject); // Видаляємо предмет після збору
        }
    }
}



//{
//    public int count;

//    private void OnTriggerEnter2D(Collider2D collision) 
//    {
//        if (collision.gameObject.CompareTag("Player")) //якщо гравець заходить в зону трігера 
//        {
//            collision.gameObject.GetComponent<Player>().AddItem(count); //додаємо до кількості зібраних предметів +1
//            Destroy(gameObject); // знищуємо модельку монетки (звертаємось до своїх об'єктів, тому з маленької) 
//        }
//    }
//}
