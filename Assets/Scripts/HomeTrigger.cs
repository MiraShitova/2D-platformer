using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class HomeTrigger : MonoBehaviour
{
    public TextMeshProUGUI itemText; // Текст для показу кількості зібраних предметів

    public GameObject messagePanel;
    public TextMeshProUGUI messageText;
    public Button continueButton;
    public Button exitButton;

    public int totalItems = 7; // всього треба зібрати 
    public int collectedItems = 0; // вже зібрано предметів

    void Start()
    {
        messagePanel.SetActive(false); // скриваємо панель при старті
        continueButton.onClick.AddListener(ContinueGame);
        exitButton.onClick.AddListener(ExitGame);

       
        if (itemText != null)  // Перевірка на null для itemText
        {
            UpdateUI(); // Оновлюємо UI при старті
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Перевіряємо, доторкнувся гравець чи ні
        {
            ShowMessage();
        }
    }

    void ShowMessage()
    {
        messagePanel.SetActive(true);

        if (collectedItems >= totalItems)
        {
            messageText.text = "Вітаю! Клаус успішно дістався додому та знайшов усі свої загублені речі!";
            continueButton.gameObject.SetActive(false); // Прибираємо кнопку "Продовжити"
        }
        else
        {
            int remainingItems = totalItems - collectedItems;
            messageText.text = $"Вітаю! Клаус успішно дістався своєї домівки, але, на жаль, знайшов не всі свої загублені речі. \r\nВи можете продовжити гру і допомогти Клаусу знайти решту своїх речей або вийти з гри на цьому етапі. Залишилось знайти {remainingItems} предметів.";
            continueButton.gameObject.SetActive(true);
        }
    }

    void ContinueGame()
    {
        messagePanel.SetActive(false); // закриваємо вікно і продовжуємо гру 
    }

    void ExitGame()
    {
        SceneManager.LoadScene(0); // Завантажуємо сцену з меню
    }

    public void UpdateCollectedItems(int count)
    {
        collectedItems = count; // оновлюємо кількість зібраних предметів 
        Debug.Log($"Collected Items: {collectedItems}");  // Для дебага, щоб побачити в консолі

        // Перевірка на null перед оновленням UI
        if (itemText != null)
        {
            UpdateUI(); // Оновлюємо UI при кожній зміні лічильника
        }
    }


    public void UpdateUI()  // Оновлення тексту UI для кількості зібраних предметів
    {
        if (itemText != null)
        {
            itemText.text = $"Зібрано предметів: {collectedItems} / {totalItems}";
        }
    }
}



