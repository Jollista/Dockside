using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingContiueButtonBehaviour : MonoBehaviour
{
    public FishingarrowController sliderArrowScript;

    public FishCaughtDisplayBehaviour fishCaughtScript;

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
    }
}
