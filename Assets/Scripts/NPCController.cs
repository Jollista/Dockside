/*** 
*file: NPCController.cs 
*Members: Juniper Watson
*class: CS 4700 – Game Development 
*assignment: program 4
*date last modified: 11/20/2022 
* 
*purpose: This scripts controls the NPC behavior, ensuring the cursor changes
*to indicate that the player can speak to the NPC, and triggers dialogue when clicked. 
* 
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

    DialogueTrigger dialogueTrigger;
    PlayerMovement player;
    void Start() 
    {
        dialogueTrigger = GetComponent<DialogueTrigger>();
        player = FindObjectOfType<PlayerMovement>();
    }

    void OnMouseDown()
    {
        //if there is already a dialogue script for this NPC
        if (GetComponent<NPCDialogue>() != null)
            return; //return
        
        //else
        if (player.canMove)
            dialogueTrigger.TriggerDialogue();
    }
    void OnMouseEnter()
    {
        Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
    }
    void OnMouseExit()
    {
        Cursor.SetCursor(null, Vector2.zero, cursorMode);
    }
}
