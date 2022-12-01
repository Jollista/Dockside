using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaqueriaDialogue : NPCDialogue
{
    [Header("Generic NPC Dialogue Components")]
    DialogueTrigger dialogueTrigger; //reference to this NPC's dialogueTrigger
    PlayerMovement player; //reference to playermovement script
    ManagerScript manager; //reference to Game Manager's ManagerScript to check player inventory

    //Components for choosing which dialogue triggers
    //Meaning, you can mess with this bit all you like
    [Header("Individualized Components")]
    public Dialogue ifTalkedToAndNoLeaveForDocks;
    public Dialogue ifTalkedToAndNoMahimahi;
    public Dialogue ifTalkedToAndHasMahimahi;
    public Dialogue ifTalkedToMoreThanOnce;
    public Dialogue ifSoldAllMahimahi;

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
        if (manager.timesTalkedToTaqueriaChef == 0) //default dialogue, what's written in the DialogueTrigger component
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
        else if (manager.timesTalkedToGordon == 1 && manager.mahimahi == 0)
        {
            manager.activeSellButton = false;
            dialogueTrigger.TriggerDialogue(ifTalkedToAndNoMahimahi);
            goto SkipIncrement;
        }
        else if (manager.timesTalkedToGordon == 1 && manager.mahimahi >= 1)
        {
            manager.activeSellButton = true;
            dialogueTrigger.TriggerDialogue(ifTalkedToAndHasMahimahi);
        }
        else if (manager.mahimahiSold < 20)
        {
            manager.activeSellButton = true;
            dialogueTrigger.TriggerDialogue(ifTalkedToMoreThanOnce);
        }
        else
        {
            manager.activeSellButton = false;
            dialogueTrigger.TriggerDialogue(ifSoldAllMahimahi);
        }

        manager.timesTalkedToTaqueriaChef += 1;

        SkipIncrement:
            return;
    }
}
