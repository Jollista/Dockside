using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SushiDialogue : NPCDialogue
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
    public Dialogue ifTalkedToAndNoSalmon;
    public Dialogue ifTalkedToAndHasSalmon;
    public Dialogue ifTalkedToMoreThanOnce;
    public Dialogue ifSoldAllSalmon;

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
        if (manager.timeTalkedToSushiChef == 0) //default dialogue, what's written in the DialogueTrigger component
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
        else if (manager.timeTalkedToSushiChef == 1 && manager.salmon == 0 && manager.salmonSold == 0)
        {
            manager.activeSellButton = false;
            dialogueTrigger.TriggerDialogue(ifTalkedToAndNoSalmon);
            goto SkipIncrement;
        }
        else if (manager.timeTalkedToSushiChef == 1 && manager.salmon >= 1)
        {
            manager.activeSellButton = true;
            dialogueTrigger.TriggerDialogue(ifTalkedToAndHasSalmon);
        }
        else if (manager.salmonSold < 20)
        {
            manager.activeSellButton = true;
            dialogueTrigger.TriggerDialogue(ifTalkedToMoreThanOnce);
        }
        else
        {
            manager.activeSellButton = false;
            dialogueTrigger.TriggerDialogue(ifSoldAllSalmon);
        }
        
        manager.timeTalkedToSushiChef += 1;
        SkipIncrement:
            return;
    }
}