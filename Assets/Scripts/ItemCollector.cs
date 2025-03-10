using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    private int collectedItems = 0;
    private HomeTrigger homeTrigger;

    void Start()
    {
        homeTrigger = FindObjectOfType<HomeTrigger>(); // Отримуємо доступ до HomeTrigger
    }

    public void CollectItem(int itemValue) // Метод для додавання предметів
    {
        collectedItems += itemValue; // Збільшуємо кількість зібраних предметів
        homeTrigger.UpdateCollectedItems(collectedItems);  // Оновлюємо лічильник в HomeTrigger
    }
}


