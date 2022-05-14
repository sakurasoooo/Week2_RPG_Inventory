using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/******* JTL comment
 * This script is entirely for holding data used elsewhere. This could be part of the PlayerController, but this way, our Inventory is sort of its own "object" (accessible via GetComponent<Inventory>() on whatever object the Inventory is attached to -- the player, for now).
 * 
 * If we were to change this to a game with several NPCs (non-player characters controlled by the computer), each with their own inventories, we could add this Inventory class to each NPC and modify each instance of Inventory separately, depending on which character is doing something.
 * 
 * By declaring these arrays without a specific number of slots, and as public, we are able to configure how many items should be holdable via the Unity editor.
 */

public class Inventory : MonoBehaviour
{

    public int slotNum = 2;
    public int[] items;
    public GameObject[] slots;

    public GameObject bag;

    private GameObject bagPlaceholder;



    private void Awake()
    {
        items = new int[slotNum];
        slots = new GameObject[slotNum];

        bagPlaceholder = bag.GetComponent<Bag>().bag;

        for (int i = 0; i < slotNum; i++)
        {
            slots[i] = bag.GetComponent<Bag>().AddInventory(i);
            items[i] = 0;
        }
    }

    public void AddSlot()
    {
        if (slotNum <= 10)
        {
            slotNum++;
            System.Array.Resize(ref items, slotNum);
            System.Array.Resize(ref slots, slotNum);
            int index = slotNum - 1;
            slots[index] = bag.GetComponent<Bag>().AddInventory(index);
            items[index] = 0;
        }
        else
        {
            Debug.Log("Bag size is full");
        }
    }

    public void RemoveSlot()
    {
        if (slotNum > 1)
        {
            int index = slotNum - 1;
            
            bag.GetComponent<Bag>().RemoveInventory(index);
            slotNum--;
            System.Array.Resize(ref items, slotNum);
            System.Array.Resize(ref slots, slotNum);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            AddSlot();
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            RemoveSlot();
        }
    }

}
