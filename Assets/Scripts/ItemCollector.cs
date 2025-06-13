using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemCollector : MonoBehaviour
{
    private int collectedItems = 0;

    public TextMeshProUGUI itemsText;  

    private HomeTrigger homeTrigger;

    void Start()
    {
        homeTrigger = FindObjectOfType<HomeTrigger>();
        UpdateUI();
    }

    public void CollectItem(int itemValue)
    {
        collectedItems += itemValue;
        UpdateUI();

        if (homeTrigger != null)
        {
            homeTrigger.UpdateCollectedItems(collectedItems);
        }
    }

    private void UpdateUI()
    {
        if (itemsText != null)
        {
            itemsText.text = $"Зібрано предметів: {collectedItems} / 7";
        }
    }
}



