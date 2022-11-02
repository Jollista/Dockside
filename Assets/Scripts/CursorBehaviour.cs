using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorBehaviour : MonoBehaviour
{
    public Texture2D cursorDefault;
    public Texture2D cursorWater;

    public GameObject fishingSlider;

    private void Start()
    {
        Cursor.SetCursor(cursorDefault, Vector2.zero, CursorMode.Auto);
    }

    public void OnCursorEnterWater()
    {
        Cursor.SetCursor(cursorWater, Vector2.zero, CursorMode.Auto);
    }

    public void OnCursorExitWater()
    {
        Cursor.SetCursor(cursorDefault, Vector2.zero, CursorMode.Auto);
    }

    public void OnClickWater()
    {
        Cursor.visible = false;
        fishingSlider.SetActive(true);
    }
}
