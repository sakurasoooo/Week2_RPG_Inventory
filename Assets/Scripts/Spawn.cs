using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/******* JTL comment
 * This script instantiates the specified item in front of the player. We could potentially add other methods to this class that could do things like spawn enemies a certain distance from the player (or at a certain location unrelated to the player).
 * 
 * Note that this script uses an empty GameObject called PlayerPos to determine where to drop objects. It would be far better to actually drop objects relative to the player's position and current facing direction (so object is always dropped "in front of" player), but this is a simplified tutorial.
 * 
 * Be sure to check out how the PlayerPos object is made visible in the Unity editor, if you are unfamiliar with this technique!
 */

public class Spawn : MonoBehaviour
{

    private Transform playerPos;
    public GameObject item;

    private void Start() => playerPos = GameObject.FindGameObjectWithTag("PlayerPos").GetComponent<Transform>();


    /******* JTL comment
     * This function might be better called SpawnDroppedItem, since it very specifically drops
     * the specified item in front of the player.
     */

    public void SpawnItem() => Instantiate(item, playerPos.position, Quaternion.identity);
}
