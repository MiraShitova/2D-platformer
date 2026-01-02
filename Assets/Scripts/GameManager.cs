using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Підключаємо бібліотеку для тексту

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // Робимо "Одинака", щоб мати доступ звідусіль

    public TextMeshProUGUI deathText; // Сюди перетягнеш текст UI
    private int deathCount = 0; // Змінна лічильника

    private void Awake()
    {
        // Стандартна перевірка Singleton
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Метод, який ми викличемо з Player.cs
    public void AddDeath()
    {
        deathCount++; // Збільшуємо лічильник
        UpdateUI();   // Оновлюємо текст
    }

    private void UpdateUI()
    {
        if (deathText != null)
        {
            deathText.text = "Кількість смертей: " + deathCount.ToString();
        }
    }
}
