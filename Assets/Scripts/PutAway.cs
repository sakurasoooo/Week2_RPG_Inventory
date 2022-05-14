using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/******* JTL PutAway
 * New script to support player putting away the sword
 * 
 * 
 * IMPORTANT: The creator of this original tutorial implemented the sword THREE ways: as the pickup object, as the inventory button, and then as the weapon actually attached to the character. So, this script is attached to prefab Weapon (found in the "Other" folder) as opposed to Sword. This definitely could be optimised / simplified in the future!
 */

public class PutAway : MonoBehaviour
{
    private Inventory inventory;
    public GameObject itemButton;

    // Start is called before the first frame update
    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    /******* JTL PutAwaySword()
     * Technically this script can "put away" anything, since all it is doing is removing the item that the script is on (gameObject), so it would probably be better to not specifically call the method PutAwaySword(), but this is for now a good reminder of how this is being used.
     * 
     * This code is almost entirey copied from Pickup.cs, but I added a pair of return statements to indicate whether or not there was room in inventory for the weapon. This means that the PlayerController script (which handles the actual X keypress to put away the sword) can then "decide" whether or not to change the player's holdingWeapon status to false as a result of what happens in this function.
     */

    public bool PutAwaySword()
    {
        for (int i = 0; i < inventory.items.Length; i++)
        {
            if (inventory.items[i] == 0)
            { // check whether the slot is EMPTY
                inventory.items[i] = 1; // makes sure that the slot is now considered FULL
                Instantiate(itemButton, inventory.slots[i].transform, false); // spawn the button so that the player can interact with it
                Destroy(gameObject);
                return true;
            }
        }
        return false;
    }
}