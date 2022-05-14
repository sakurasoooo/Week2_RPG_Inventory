using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bagItem : MonoBehaviour
{
    public GameObject effect;
    private Transform player;
    private Inventory inventory;
    // Start is called before the first frame update
    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void Use()
    {
        inventory.AddSlot();
        Instantiate(effect, player.transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
