/*** 
*file: ButtonSFX.cs 
*Members: Juniper Watson
*class: CS 4700 – Game Development 
*assignment: program 4
*date last modified: 12/3/2022 
* 
*purpose: This script plays the sound effects of buttons as they are clicked.
* 
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSFX : MonoBehaviour
{
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void playSound()
    {
        AudioClip clip = audioSource.clip;
        audioSource.PlayOneShot(clip);
    }
}
