using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    private bool canAttack = true;
    private GameObject player;

    // public bool CanAttack { get => canAttack; set => canAttack = value; }

    private Animator animator;

    private WaitForSeconds attackAnimationDuration;

    private WaitForSeconds remainingAnimationDuration;

    // Start is called before the first frame update
    void Start()
    {
        canAttack  = true;
        player = GameObject.FindGameObjectWithTag("Player");
        animator = GetComponent<Animator>();
        attackAnimationDuration = new WaitForSeconds(1.0f);
        remainingAnimationDuration = new WaitForSeconds( 1.0f - 0.33f);
    }

    // Update is called once per frame
    private void OnTriggerStay2D(Collider2D other)
    {

        if (other.CompareTag("Player") && canAttack )
        {
            Debug.Log("ATTACK!!");
            canAttack  = false;
            animator.SetBool("attack", true);
        }
    }

    public void Attack() {
        if (player != null)
            {
                player.SendMessage("IAmInjured", 1);
            }
    }

    public void StopAttack() {
        animator.SetBool("attack", false);
        canAttack = true;
        Debug.Log("I am tired!!");
    }
}
