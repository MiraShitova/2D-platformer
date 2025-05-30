using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    private int collectedItems = 0;
    private HomeTrigger homeTrigger;

    void Start()
    {
        homeTrigger = FindObjectOfType<HomeTrigger>(); 
    }

    public void CollectItem(int itemValue) 
    {
        collectedItems += itemValue; 
        homeTrigger.UpdateCollectedItems(collectedItems);  
    }
}


