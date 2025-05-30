using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StoryPanel : MonoBehaviour
{
    public GameObject panel; 
    void Start()
    {
        panel.SetActive(true); 
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            panel.SetActive(false); 
        }
    }
}
