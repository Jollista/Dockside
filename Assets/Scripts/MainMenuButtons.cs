/*** 
*file: MainMenuButtons.cs 
*Members: Andrew Sanford
*class: CS 4700 – Game Development 
*assignment: program 4
*date last modified: 11/28/2022 
* 
*purpose: This scripts ensures the buttons on the main menu 
*while perform the correct action when clicked.
* 
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class MainMenuButtons : MonoBehaviour
{
    public void startClick()
    {
        SceneManager.LoadScene("RestaurantScene");
    }

    public void exitClick()
    {
        Application.Quit();
        //UnityEditor.EditorApplication.isPlaying = false;
    }
}
