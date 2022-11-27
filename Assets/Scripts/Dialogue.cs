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
