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
    public Dialogue ifTalkedToAndNoLeaveForDocks;
    public Dialogue ifTalkedToAndNoTilapia;
    public Dialogue ifTalkedToAndHasTilapia;
    public Dialogue ifTalkedToMoreThanOnce;

    void Start()
    {
        dialogueTrigger = GetComponent<DialogueTrigger>();
        player = FindObjectOfType<PlayerMovement>();
        manager = FindObjectOfType<ManagerScript>();
    }

    void OnMouseDown()
    {
        //if player can't move (i.e. is in dialogue or something else)
        //don't trigger dialogue
        if (!player.canMove)
            return;

        //else
        //this is the area that actually chooses what dialogue triggers
        if (manager.timesTalkedToGordon == 0) //default dialogue, what's written in the DialogueTrigger component
        { 
            manager.activeSellButton = false;
            dialogueTrigger.TriggerDialogue();
        }
        else if (manager.hasEnteredDock == false)
        {
            manager.activeSellButton = false;
            dialogueTrigger.TriggerDialogue(ifTalkedToAndNoLeaveForDocks);
            goto SkipIncrement;
        }
        else if (manager.timesTalkedToGordon == 1 && manager.tilapia == 0)
        {
            manager.activeSellButton = false;
            dialogueTrigger.TriggerDialogue(ifTalkedToAndNoTilapia);
            goto SkipIncrement;
        }
        else if (manager.timesTalkedToGordon == 1 && manager.tilapia >= 1)
        {
            manager.activeSellButton = true;
            dialogueTrigger.TriggerDialogue(ifTalkedToAndHasTilapia);
        }
        else
        {
            manager.activeSellButton = true;
            dialogueTrigger.TriggerDialogue(ifTalkedToMoreThanOnce);
        }
        
        manager.timesTalkedToGordon += 1;
        SkipIncrement:
            return;
    }
}
