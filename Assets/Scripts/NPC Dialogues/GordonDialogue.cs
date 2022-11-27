using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GordonDialogue : NPCDialogue
{
    //Components for handling dialogue triggering
    [Header ("Generic NPC Dialogue Components")]
    DialogueTrigger dialogueTrigger; //reference to this NPC's dialogueTrigger
    PlayerMovement player; //reference to playermovement script
    ManagerScript manager; //reference to Game Manager's ManagerScript to check player inventory

    //Components for choosing which dialogue triggers
    //Meaning, you can mess with this bit all you like
    [Header ("Individualized Components")]
    public int timesTalkedTo;
    public Dialogue ifTalkedToAndNoLeaveForDocks;
    public Dialogue ifTalkedToAndNoTilapia;
    public Dialogue ifTalkedToAndHasTilapia;
    void Start()
    {
        dialogueTrigger = GetComponent<DialogueTrigger>();
        player = FindObjectOfType<PlayerMovement>();
        manager = FindObjectOfType<ManagerScript>();

        timesTalkedTo = 0;
    }
    void OnMouseDown()
    {
        //if player can't move (i.e. is in dialogue or something else)
        //don't trigger dialogue
        if (!player.canMove)
            return;
        
        //else
        //this is the area that actually chooses what dialogue triggers
        if (timesTalkedTo == 0) //default dialogue, what's written in the DialogueTrigger component
            dialogueTrigger.TriggerDialogue();
        else if (manager == null)
            dialogueTrigger.TriggerDialogue(ifTalkedToAndNoLeaveForDocks);
        else if (timesTalkedTo == 1 && manager.tilapia == 0)
            dialogueTrigger.TriggerDialogue(ifTalkedToAndNoTilapia);
        else if (timesTalkedTo == 1 && manager.tilapia == 1)
            dialogueTrigger.TriggerDialogue(ifTalkedToAndHasTilapia);
        
        timesTalkedTo += 1;
    }
}
