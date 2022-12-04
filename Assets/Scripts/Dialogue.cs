/*** 
*file: SceneTransition.cs 
*Members: Juniper Watson
*class: CS 4700 – Game Development 
*assignment: program 4
*date last modified: 11/20/2022 
* 
*purpose: This scripts represents and handles the text area where dialogue is displayed 
*within the actual dialogue box on screen. 
* 
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    public string name; //NPC or other dialogue trigger's name to be displayed

    [TextArea(3, 10)] //for better display in inspector panel
    public string[] sentences; //actual dialogue
}
