using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class HomeTrigger : MonoBehaviour
{
    public TextMeshProUGUI itemText; 

    public GameObject messagePanel;
    public TextMeshProUGUI messageText;
    public Button continueButton;
    public Button exitButton;

    public int totalItems = 7; 
    public int collectedItems = 0; 

    void Start()
    {
        messagePanel.SetActive(false); 
        continueButton.onClick.AddListener(ContinueGame);
        exitButton.onClick.AddListener(ExitGame);


        UpdateUI();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ShowMessage();
        }
    }

    public void UpdateCollectedItems(int count)
    {
        collectedItems = count;
        Debug.Log($"Collected Items LOG: {collectedItems}");
        UpdateUI();
    }

    private void UpdateUI()
    {
        if (itemText != null)
        {
            itemText.text = $"Зібрано предметів: {collectedItems} / {totalItems}";
        }
    }

    void ShowMessage()
    {
        messagePanel.SetActive(true);

        if (collectedItems >= totalItems)
        {
            messageText.text = "Вітаю! Клаус успішно дістався додому та знайшов усі свої загублені речі!";
            continueButton.gameObject.SetActive(false); 
        }
        else
        {
            int remainingItems = totalItems - collectedItems;
            messageText.text = $"Вітаю! Клаус успішно дістався своєї домівки, але, на жаль, знайшов не всі свої загублені речі. " +
                $"\r\nВи можете продовжити гру і допомогти Клаусу знайти решту своїх речей або вийти з гри на цьому етапі." +
                $" Залишилось знайти {remainingItems} з 7 предметів.";
            continueButton.gameObject.SetActive(true);
        }
    }

    void ContinueGame()
    {
        messagePanel.SetActive(false); 
    }

    void ExitGame()
    {
        SceneManager.LoadScene(0); 
    }

    }




