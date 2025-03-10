using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene(1); //запускаємо сцену 1
    }

    public void Exit()
    {
        Application.Quit(); //вийти з гри 
    }

}
