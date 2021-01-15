using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject characterBody;
    public Animator animator;
    public float horisontalSpeed = 0f;
    public static float runSpeed = 15f;
    public static float jumpForce = 250f;
    public bool isJumping = false;
    public Transform grounddetector;
    public float rayDistance;
    public bool grounded;
    public AudioSource audioSource;
    public AudioClip swoosh;

    // Update is called once per frame

    public void Start()
    {
        //add an audio source component
        audioSource = gameObject.AddComponent<AudioSource>();
    }


    public void Update()
    {
        playerNavigation();
    }


    public void playerNavigation()
    {
        horisontalSpeed = Input.GetAxis("Horizontal");


        /*Set animator values from direction keys.
         * Uses Mathf.Abs to make values
        positive regardless of direction - allows animator to use values in opposite direction
         */

        animator.SetFloat("PlayerMovement", Mathf.Abs(horisontalSpeed));

        //move the character forward
        transform.Translate(Input.GetAxis("Horizontal") * runSpeed * Time.deltaTime, 0f, 0f);

        //flip character 
        Vector3 characterScale = transform.localScale;

        if (Input.GetAxis("Horizontal") < 0)
        {
            characterScale.x = -8;
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            characterScale.x = 8;
        }

        transform.localScale = characterScale;

        //jumping animation
        if (Input.GetKeyDown(KeyCode.J))
        {
            startjump();
        }
    }


    //trigger attack animation
    public void attackAnimation()
    {
        animator.SetTrigger("attackTrigger");
        audioSource.clip = swoosh;
        audioSource.Play();
    }
    public void playerDie()
    {
        //disables player
        animator.SetBool("playerDead", true);
        this.enabled = false;
    }

    public void damageAnimation()
    {
        animator.SetTrigger("damageTrigger");
    }


    //start jumping function
    public void startjump()
    {
        if (grounded==true)
        {
            isJumping = true;
            animator.SetBool("isJumping", true);
            // characterBody.AddForce(new Vector2(0f, jumpForce));


            //New Jump code
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);

        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        grounded = true;
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        grounded = false;
    }

    public void OnCollisionStay2D(Collision2D collision)
    {
        grounded = true;
    }


    //stop jumping function
    public void stopJump()
    {
        animator.SetBool("isJumping", false);
    }

    public void FixedUpdate() {

        //end jumping animation
        stopJump();
    }

    //Coin Destroy
    private void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.CompareTag("Coins")){
            Destroy(other.gameObject);
        }
    }
    
}
