/*** 
*file: SceneTransition.cs 
*Members: Juniper Watson
*class: CS 4700 – Game Development 
*assignment: program 4
*date last modified: 11/20/2022 
* 
*purpose: This scripts loads another scene when the player collides with the 
*appropriate collision box. 
* 
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public string sceneToLoad;
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
            SceneManager.LoadScene(sceneToLoad);
    }
}
