using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunItem : MonoBehaviour
{

    private Transform player;
    public GameObject explosionEffect;
    public GameObject campfire;
    private Inventory inventory;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }


    public void Use()
    {
        GameObject[] slots = inventory.slots;

        for (int i = 0; i < slots.Length; i++)
        {
            Transform slotTransform = slots[i].transform;
            foreach (Transform child in slotTransform)
            {
                if (child.CompareTag("Burnable"))
                {
                    Instantiate(campfire, player.transform.position, Quaternion.identity);
                    Instantiate(explosionEffect, player.transform.position, Quaternion.identity);
                    Destroy(child.gameObject);
                    Destroy(gameObject);
                    return;
                }
            }
        }



    }

}
