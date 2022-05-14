using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/******* JTL comment
 * script attached to "button" version of in-game items (the version that appears in Inventory)
 * Adds amount healthBoost to player.health
 * Instantiates a health "special effect"
 * Destroys consumed item (lowercase gameObject means "the object this script is on",
 * while uppercase GameObject is the object type or class (see healthEffect variable declaration and player variable assignment)
 */

public class HealthItem : MonoBehaviour {

    private PlayerController player;
    public GameObject healthEffect;
    public int healthBoost;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    public void Use() {
        Instantiate(healthEffect, player.transform.position, Quaternion.identity);
        player.health += healthBoost;
        Destroy(gameObject);
    }
}
