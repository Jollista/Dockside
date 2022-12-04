/*** 
*file: CursorBehaviour.cs 
*Members: Juniper Watson, Andrew Sanford
*class: CS 4700 – Game Development 
*assignment: program 4
*date last modified: 12/4/2022 
* 
*purpose: This scripts handles cursor behavior, notably the appearance when 
*hovered over interactables and playing sound effects with certain actions. 
* 
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorBehaviour : MonoBehaviour
{
    public PlayerMovement movementScript;

    public Texture2D cursorDefault;
    public Texture2D cursorWater;
    //public Texture2D cursorNPC;

    public GameObject fishingSlider;
    public GameObject waterButtons;
    public AudioSource sound;

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

    /*public void OnCursorEnterNPC()
    {
        Cursor.SetCursor(cursorNPC, Vector2.zero, CursorMode.Auto);
    }*/

    public void OnCursorExitNPC()
    {
        Cursor.SetCursor(cursorDefault, Vector2.zero, CursorMode.Auto);
    }

    public void OnClickWater()
    {
        sound.Play();
        movementScript.canMove = false;
        Cursor.visible = false;
        waterButtons.SetActive(false);
        fishingSlider.SetActive(true);
    }
}
