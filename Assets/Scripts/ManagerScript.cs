/*** 
*file: SceneTransition.cs 
*Members: Juniper Watson, Andrew Sanford
*class: CS 4700 – Game Development 
*assignment: program 4
*date last modified: 12/3/2022 
* 
*purpose: This scripts holds the player's inventory, tracks their progress, 
*tracks flags of the current game state, tracks how many times they've spoken to 
*an NPC, and retains all that data between scenes.
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerScript : MonoBehaviour
{
    public static ManagerScript Instance;

    public int mahimahi = 0;
    public int salmon = 0;
    public int tilapia = 0;
    public int mahimahiSold = 0;
    public int salmonSold = 0;
    public int tilapiaSold = 0;

    public bool activeSellButton = false;
    public bool gameComplete = false;

    public int timesTalkedToGordon = 0;
    public int timesTalkedToTaqueriaChef = 0;
    public int timeTalkedToSushiChef = 0;

    public bool hasEnteredDock = false;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        if(mahimahiSold >= 20 && salmonSold >= 20 && tilapiaSold >= 20)
        {
            gameComplete = true;
        }
    }
}
