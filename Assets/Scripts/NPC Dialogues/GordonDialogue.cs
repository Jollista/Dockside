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
    AudioSource audioSource; //AudioSource to play sounds
    public AudioClip[] sounds; //sounds to be played on dialogue start

    //Components for choosing which dialogue triggers
    //Meaning, you can mess with this bit all you like
    [Header ("Individualized Components")]
    public Dialogue ifTalkedToAndNoLeaveForDocks;
    public Dialogue ifTalkedToAndNoTilapia;
    public Dialogue ifTalkedToAndHasTilapia;
    public Dialogue ifTalkedToMoreThanOnce;
    public Dialogue ifSoldAllTilapia;
    public Dialogue ifGameComplete;

    void Start()
    {
        dialogueTrigger = GetComponent<DialogueTrigger>();
        player = FindObjectOfType<PlayerMovement>();
        manager = FindObjectOfType<ManagerScript>();
        audioSource = FindObjectOfType<AudioSource>();
    }

    void OnMouseDown()
    {
        //if player can't move (i.e. is in dialogue or something else)
        //don't trigger dialogue
        if (!player.canMove)
            return;

        //else
        //play random voice clip
        audioSource.PlayOneShot(sounds[Random.Range(0, sounds.Length)]);

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
        else if (manager.timesTalkedToGordon == 1 && manager.tilapia == 0 && manager.tilapiaSold == 0)
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
        else if (manager.tilapiaSold < 20)
        {
            manager.activeSellButton = true;
            dialogueTrigger.TriggerDialogue(ifTalkedToMoreThanOnce);
        }
        else if (manager.gameComplete)
        {
            manager.activeSellButton = false;
            dialogueTrigger.TriggerDialogue(ifGameComplete);
        }
        else
        {
            manager.activeSellButton = false;
            dialogueTrigger.TriggerDialogue(ifSoldAllTilapia);
        }
        
        manager.timesTalkedToGordon += 1;
        SkipIncrement:
            return;
    }
}