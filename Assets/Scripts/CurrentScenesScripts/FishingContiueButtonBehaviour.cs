/*** 
*file: FishingContiueButtonBehaviour.cs 
*Members: Juniper Watson, Andrew Sanford
*class: CS 4700 – Game Development 
*assignment: program 4
*date last modified: 11/28/2022 
* 
*purpose: This scripts handles reseting the popup caught fish menu when the player
*clicks continue to close it. 
* 
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingContiueButtonBehaviour : MonoBehaviour
{
    public FishingarrowController sliderArrowScript;
    public FishCaughtDisplayBehaviour fishCaughtScript;
    public PlayerMovement movementScript;

    public GameObject waterButtons;
    public GameObject fishingDisplay;
    public GameObject fishingSlider;
    public GameObject sliderArrow;
    public GameObject fishCaughtDisplay;

    public void resetFishingDisplay()
    {
        fishCaughtDisplay.SetActive(false);
        fishingSlider.SetActive(true);
        sliderArrow.SetActive(true);
        fishingDisplay.SetActive(false);
        waterButtons.SetActive(true);
        sliderArrowScript.enabled = true;
        fishCaughtScript.enabled = false;
        movementScript.canMove = true;
    }
}
