using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {


    public float health;
    public Text healthDisplay;

    public float speed;

    public GameObject deathEffect;
    private Rigidbody2D rb;
    private Animator anim;
    private Vector2 moveVelocity;

    /* new variables for JTL's tutorial */
    public bool holdingWeapon; // Does the player have a weapon?
    public GameObject weaponTarget; // Is the player close enough to a "hittable" item?
    public GameObject wielding; // What weapon does the player have? (Just the sword for now)

    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        holdingWeapon = false;
        weaponTarget = null;
    }

    private void Update()
    {

        healthDisplay.text = health.ToString();

        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput.normalized * speed;

        if (moveInput != Vector2.zero)
        {
            anim.SetBool("isRunning", true);
        }
        else {
            anim.SetBool("isRunning", false);
        }

        // JTL new code to handle attacks via sword

        if (Input.GetKeyDown(KeyCode.Space) && this.holdingWeapon)
        {
            Debug.Log("Attack!");
            StartCoroutine(SwingThatSword());
        }

        // JTL new code to handle sheathing (putting away) sword
        // if an inventory slot is available

        if (Input.GetKeyDown(KeyCode.X) && this.holdingWeapon)
        {
            Debug.Log("Put Away Weapon?");
            var result = wielding.GetComponent<PutAway>().PutAwaySword();
            if (!result) {
                Debug.Log("Inventory Full!");
            } else
            {
                holdingWeapon = false;
                Debug.Log("Weapon Sheathed!");
            }
        }
    }

    /******* JTL SwingThatSword()
     * 
     * Co-routine to animate sword, wait for animation to complete, then process what was hit.
     * 
     * I was unable to access the swinging animation via GetCurrentAnimatorClipInfo or via GetCurrentAnimatorStateInfo and always got the "Idle" animation instead, so for now, I hard-coded the value 0.25, which is the length of my animation. This is not a good practice long-term, as I might forget about this hard-coded value when I change my animation, but for "survival coding" it is OK.
     * 
     * Because we are actually exiting this code for 1/4 of a second and resuming regular updates, there is a chance that the player could have moved away from the weapon target before the animation finishes.
     * 
     * I could have added a variable to "remember" the target (var myTarget = this.weaponTarget) during the animation, but instead I decided to test if the target is still in position when the sword swing is done, as this is more like what would happen in an action RPG -- i.e., the bad guy could move out of range during the sword swing! This is an example of where your design choices can affect your code.
     * 
     * Finally, if the weaponTarget is tagged "Hittable", then we assume that it has the Transmogrify script on it. We would more ideally check if the script exists before trying to call ReplaceMe() on it, but for "rough draft" coding this is fine.
     */

    private IEnumerator SwingThatSword()
    {
        var swingAnim = wielding.GetComponent<Animator>();
        Debug.Log("Swinging!");
        swingAnim.SetTrigger("isSwinging");
        yield return new WaitForSecondsRealtime(0.25f);

        swingAnim.SetBool("isSwinging", false);

        if (this.weaponTarget != null)
        {
            Debug.Log("I hit " + weaponTarget.name);
            if (weaponTarget.tag == "Hittable")
            {
                weaponTarget.GetComponent<Transmogrify>().ReplaceMe();
            }
        }
    }    

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
    }

    void IAmInjured (int damage) {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        if(health > 1 ) {
            health -= damage;
        }
        else{
            health -= damage;
            Debug.Log("I'm dead!");
            healthDisplay.text = health.ToString();
            Destroy(gameObject);
        }
    }


}
