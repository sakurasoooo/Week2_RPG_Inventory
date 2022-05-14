using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour {

    /****** JTL comment
     * Other than changing the badly named Cross() to Drop() (see note below), this is the same code provided in the original tutorial.
     * 
     * This is really not very good code because it checks EVERY FRAME whether or not the inventory slot has any children. Instead, when an item is dropped, inventory.items for this item should be set to 0.
     * 
     * Similarly, this code currently loops through ALL children of the Slot, but the way this game is set up, there only is ever ONE child -- the item we are dropping.
     */

    private Inventory inventory;
    public int index;

    private void Start()
    {
        
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    private void Update()
    {
        if (transform.childCount <= 0) {
            inventory.items[index] = 0;
        }
    }

    // JTL - renamed this routine to reflect what it DOES instead of what it LOOKS LIKE
    public void Drop() {

        foreach (Transform child in transform) {
            child.GetComponent<Spawn>().SpawnItem();
            GameObject.Destroy(child.gameObject);
        }
    }

}
