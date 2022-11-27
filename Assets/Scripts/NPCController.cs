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
