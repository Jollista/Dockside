/*** 
*file: SceneManagerScript.cs 
*Members: Juniper Watson, Andrew Sanford, Neil Patrick Reyes
*class: CS 4700 – Game Development 
*assignment: program 4
*date last modified: 11/30/2022 
* 
*purpose: When fishing, this script determines the chances of 
*successfully reeling a fish in and all associated changes in the inventory.
* 
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManagerScript : MonoBehaviour
{
    private ManagerScript gameManager;
    public FishingarrowController fishingArrowScript;
    public FishCaughtDisplayBehaviour fishDisplayScript;

    public GameObject fishCaughtDisplay;
    private GameObject gameManagerObject;

    public string fishName = "";

    public int successGrey = 0;
    public int successRed = 0;
    public int successYellow = 0;
    public int successGreen = 0;
    public int success = 0;

    private void Start()
    {
        gameManagerObject = GameObject.Find("GameManager");
        gameManager = gameManagerObject.GetComponent<ManagerScript>();
        gameManager.hasEnteredDock = true;
    }

    public void catchSuccess(string successColor)
    {
        success = Random.Range(0, 101);

        switch (successColor)
        {
            case "Grey":
                success += successGrey;
                break;
            case "Red":
                success += successRed;
                break;
            case "Yellow":
                success += successYellow;
                break;
            case "Green":
                success += successGreen;
                break;
        }

        if (success >= 90)
        {
            catchFish(true);
        }
        else
        {
            catchFish(false);
        }
    }

    void catchFish(bool isSuccess)
    {
        if (isSuccess)
        {
            int fishType = Random.Range(1, 4);

            switch (fishType)
            {
                case 1:
                    gameManager.mahimahi++;
                    fishName = "a Mahi-Mahi!";
                    break;
                case 2:
                    gameManager.salmon++;
                    fishName = "a Salmon!";
                    break;
                case 3:
                    gameManager.tilapia++;
                    fishName = "a Tilapia!";
                    break;
            }
        }

        else
        {
            fishName = "nothing.";
        }

        fishCaughtDisplay.SetActive(true);
        fishDisplayScript.displayCatchInfo();
    }
}
