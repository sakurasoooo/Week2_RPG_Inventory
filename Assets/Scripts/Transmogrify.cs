using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/******* JTL class Transmogrify
 *  Simple class to swap one object for another. Used so far to replace trees with log piles, but could easily be used to turn anything into anything else!
 */


public class Transmogrify : MonoBehaviour {

    private Transform myPos;
    public GameObject item;
    public GameObject effect;

    private void Start()
    {
        myPos = this.gameObject.transform;
    }

    public void ReplaceMe() {
        Debug.Log("Transforming!!!");
        Instantiate(effect, myPos.position, Quaternion.identity);
        // put my new item at this position
        Instantiate(item, myPos.position, Quaternion.identity);
        // delete my original item
        Destroy(gameObject);
    }
}
