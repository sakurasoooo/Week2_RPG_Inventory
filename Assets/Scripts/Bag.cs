using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/******* JTL comment
 * Controls visibility of Bag_Contents GameObject (loaded into variable bag here)
 * Tracks state of bag (closed vs. open) via Boolean isClosed
 */

public class Bag : MonoBehaviour
{

    bool isClosed;
    public GameObject bag;

    public GameObject InventoryPlaceholder;
    public void OpenCloseBag()
    {
        if (isClosed == true)
        {
            bag.SetActive(true);
            isClosed = false;
        }
        else
        {
            bag.SetActive(false);
            isClosed = true;
        }
    }

    public GameObject AddInventory(int index){
        GameObject newBagPlace =  Instantiate(InventoryPlaceholder,bag.transform, false);
        newBagPlace.transform.localPosition = new Vector3 (150.0f + index * 120.0f,0.0f,0.0f);
        newBagPlace.transform.GetChild(0).GetComponent<Slot>().index = index;

        return newBagPlace.transform.GetChild(0).gameObject;
    }

    public void RemoveInventory(int index) {
        GameObject oldBagPlace =  bag.transform.GetChild(index).gameObject;
        oldBagPlace.transform.GetChild(0).gameObject.GetComponent<Slot>().Drop();
        Destroy(oldBagPlace);
    }

}
