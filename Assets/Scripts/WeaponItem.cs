using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponItem : MonoBehaviour {

    private Transform playerPos;
    public GameObject sword;

    private void Start() =>playerPos = GameObject.FindGameObjectWithTag("Player").transform;
    

    /******* JTL modification
     * This method works the same as in the tutorial, but I added code to set variables on the PlayerController.
     * 
     * Because Instantiate() returns the GameObject that was created, we can just assign the returned value directly to pc.wielding (our variable that tracks which weapon the player currently has).
     * 
     * We could potentially add more weapons this way!
     */

    public void Use() {
        var pc = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        pc.holdingWeapon = true;
        pc.wielding = Instantiate(sword, playerPos.position, sword.transform.rotation, playerPos.transform);
        Destroy(gameObject);
    }
}
