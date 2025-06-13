using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro; 

public class SkinSelector : MonoBehaviour
{
    public Button greenButton;
    public Button pinkButton;
    public Button blueButton;

    public TextMeshProUGUI greenText;
    public TextMeshProUGUI pinkText;
    public TextMeshProUGUI blueText;

    public Color selectedColor = Color.green;
    public Color defaultColor = Color.gray;

    public GameObject hide_panel;

    private void Start()
    {
        string selectedSkin = PlayerPrefs.GetString("SelectedSkin", "");
        UpdateUI(selectedSkin);
    }

    public void SelectGreenSkin()
    {
        PlayerPrefs.SetString("SelectedSkin", "Green");
        UpdateUI("Green");
    }

    public void SelectPinkSkin()
    {
        PlayerPrefs.SetString("SelectedSkin", "Pink");
        UpdateUI("Pink");
    }

    public void SelectBlueSkin()
    {
        PlayerPrefs.SetString("SelectedSkin", "Blue");
        UpdateUI    ("Blue");
    }

    private void UpdateUI(string selected)
    {
        greenText.text = selected == "Green" ? "Обрано" : "Обрати";
        pinkText.text = selected == "Pink" ? "Обрано" : "Обрати";
        blueText.text = selected == "Blue" ? "Обрано" : "Обрати";

        greenButton.image.color = selected == "Green" ? selectedColor : defaultColor;
        pinkButton.image.color = selected == "Pink" ? selectedColor : defaultColor;
        blueButton.image.color = selected == "Blue" ? selectedColor : defaultColor;
    }

    public void ClosePanel(GameObject panel)
    {
        panel.SetActive(false);
        hide_panel.SetActive(true);    
    }

    public void OpenPanel(GameObject panel)
    {
        panel.SetActive(true);
        hide_panel.SetActive(false);
    }
}
