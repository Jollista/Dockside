using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text nameText; //name displayed in dialogue box
    public Text dialogueText; //dialogue displayed in dialogue box

    public Animator animator; //reference to animator to handle dialogue box animation

    private Queue<string> sentences; //queue of sentences in the dialogue
    private PlayerMovement player;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        player = FindObjectOfType<PlayerMovement>();
    }

    public void StartDialogue (Dialogue dialogue)
    {
        //turn off player movement when dialogue starts
        player.canMove = false;
        //animate DialogueBox_Open, pulls dialogue box onto screen
        animator.SetBool("IsOpen", true);
        //set nameText to dialogue trigger's name
        nameText.text = dialogue.name;
        
        sentences.Clear(); //ensure queue is empty before starting new dialogue

        foreach (string sentence in dialogue.sentences)
            sentences.Enqueue(sentence);
        
        DisplayNextSentence();
    }

    public void DisplayNextSentence ()
    {
        //check if queue is empty
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        //else, get next sentence
        string sentence = sentences.Dequeue();
        StopAllCoroutines(); //ensure previous sentence is finished animating
        StartCoroutine(TypeSentence(sentence)); //animate sentence
    }

    //animate sentence by adding one letter at a time
    IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.01f);
        }
    }

    //Pulls dialogue box off of screen
    private void EndDialogue()
    {
        //animate DialogueBox_Close
        animator.SetBool("IsOpen", false);
        //allow player to move once dialogue is closed
        player.canMove = true;
    }
}

