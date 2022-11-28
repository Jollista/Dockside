using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    public void startClick()
    {
        SceneManager.LoadScene("RestaurantScene");
    }

    public void exitClick()
    {
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
