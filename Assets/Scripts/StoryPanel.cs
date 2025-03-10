using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StoryPanel : MonoBehaviour
{
    public GameObject panel; // Посилання на панель

    void Start()
    {
        panel.SetActive(true); // Показуваємо панель при старті гри
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // Якщо гравець натиснув пробіл
        {
            panel.SetActive(false); // Скриваємо панель
        }
    }
}
