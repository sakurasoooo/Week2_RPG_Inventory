using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/******* JTL class SetTarget
 * 
 * Any object that has a Collider2D set up as a Trigger on it can use this script to determine
 * if the player is touching the object. If the player is inside the Trigger zone, then that object
 * becomes the player's weaponTarget.
 * 
 * This script is currently limited to the player only targeting ONE object at a time, but as soon as one object is "killed", if there's another one in range, it will become the target. 
 * 
 * A more advanced solution would add and remove objects from a LIST of current player weaponTargets. Can you imagine how this might be done?
 */

public class SetTarget : MonoBehaviour {

    private PlayerController player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) {
            player.weaponTarget = this.gameObject;
        }
        Debug.Log("I was targeted!");
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && player.weaponTarget == this.gameObject)
        {
            player.weaponTarget = null;
        }
        Debug.Log("I am no longer targeted!");
    }
}
