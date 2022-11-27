using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestNPCDialogue : NPCDialogue
{
    //Components for handling dialogue triggering
    [Header ("Generic NPC Dialogue Components")]
    DialogueTrigger dialogueTrigger;
    PlayerMovement player;

    //Components for choosing which dialogue triggers
    //Meaning, you can mess with this bit all you like
    [Header ("Individualized Components")]
    public int timesTalkedTo;
    public Dialogue ifTalkedTo;
    public bool hasMahi;
    public Dialogue ifNoMahi;
    public Dialogue ifHasMahi;
    void Start()
    {
        dialogueTrigger = GetComponent<DialogueTrigger>();
        player = FindObjectOfType<PlayerMovement>();

        timesTalkedTo = 0;
        hasMahi = false;
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
        else if (timesTalkedTo == 1) //and the rest of these trigger specific dialogues based on the individualized components
            dialogueTrigger.TriggerDialogue(ifTalkedTo);
        else if (!hasMahi)
            dialogueTrigger.TriggerDialogue(ifNoMahi);
        else if (hasMahi)
            dialogueTrigger.TriggerDialogue(ifHasMahi);
        timesTalkedTo += 1;
    }
}
