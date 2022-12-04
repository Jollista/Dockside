/*** 
*file: SceneTransition.cs 
*Members: Juniper Watson
*class: CS 4700 – Game Development 
*assignment: program 4
*date last modified: 11/20/2022 
* 
*purpose: This scripts will trigger dialogue and load dialogue into the dialogue box. 
* 
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    public void TriggerDialogue()
    {
        TriggerDialogue(dialogue);
    }

    public void TriggerDialogue(Dialogue dialogue)
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}
