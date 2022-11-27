using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingarrowController : MonoBehaviour
{
    public SceneManagerScript managerScript;
    public float sliderSpeed = 0f;
    public Texture2D cursorDefault;
    public FishingarrowController thisScript;
    public string sliderColor = "";
    public RectTransform sliderRectTransform;

    private bool goLeft = false;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            stopSlider();
        }

        moveSlider();

        setSliderColor();
    }

    void stopSlider()
    {
        Cursor.SetCursor(cursorDefault, Vector2.zero, CursorMode.Auto);
        Cursor.visible = true;
        managerScript.catchSuccess(sliderColor);
        thisScript.enabled = false;
    }

    void moveSlider()
    {
        if (sliderRectTransform.anchoredPosition.x <= -96)
        {
            goLeft = false;
        }

        if (sliderRectTransform.anchoredPosition.x >= 120)
        {
            goLeft = true;
        }

        if (goLeft == false)
        {
            sliderRectTransform.anchoredPosition += (Vector2.right * sliderSpeed * Time.deltaTime);
        }
        else
        {
            sliderRectTransform.anchoredPosition += (-Vector2.right * sliderSpeed * Time.deltaTime);
        }
    }

    void setSliderColor()
    {
        if((sliderRectTransform.anchoredPosition.x >= -96 && sliderRectTransform.anchoredPosition.x < -46) || (sliderRectTransform.anchoredPosition.x >= 95.5 && sliderRectTransform.anchoredPosition.x <= 120))
        {
            sliderColor = "Grey";
        }
        else if(sliderRectTransform.anchoredPosition.x >= -46 && sliderRectTransform.anchoredPosition.x < 13.5)
        {
            sliderColor = "Red";
        }
        else if(sliderRectTransform.anchoredPosition.x >= 13.5 && sliderRectTransform.anchoredPosition.x < 60)
        {
            sliderColor = "Yellow";
        }
        else
        {
            sliderColor = "Green";
        }
    }

}
