using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkinSelector : MonoBehaviour
{
    public void SelectGreenSkin()
    {
        PlayerPrefs.SetString("SelectedSkin", "Green");
    }

    public void SelectPinkSkin()
    {
        PlayerPrefs.SetString("SelectedSkin", "Pink");
    }

    public void SelectBlueSkin()
    {
        PlayerPrefs.SetString("SelectedSkin", "Blue");
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1); 
    }

    public void ClosePanel(GameObject panel)
    {
        panel.SetActive(false);
    }

    public void OpenPanel(GameObject panel)
    {
        panel.SetActive(true);
    }
}
