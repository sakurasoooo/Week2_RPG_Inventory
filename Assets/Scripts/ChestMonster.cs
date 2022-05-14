using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestMonster : MonoBehaviour
{

    private bool canAttack = true;
    private PlayerController player;

    public bool CanAttack { get => canAttack; set => canAttack = value; }

    // Start is called before the first frame update
    void Start()
    {
        CanAttack = true;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player" && CanAttack)
        {
            CanAttack = false;
            StartCoroutine(WaitOneSecond());
            if (player != null)
            {
                player.SendMessage("IAmInjured", 1);
            }
        }
    }

    IEnumerator WaitOneSecond()
    {
        yield return new WaitForSeconds(1.0f);
        canAttack = true;
    }

}
