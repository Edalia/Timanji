using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goblinMovement : MonoBehaviour
{
    public GameObject goblinBody;
    public Animator goblinAnimator;
    public static float runSpeed = 2f;
    public Transform groundDetector;
    public bool movingRight = true;
    public bool isGrounded;
    public float rayDistance;

    // Update is called once per frame
    public void Start()
    {
        goblinBody = GetComponent<GameObject>();
        goblinAnimator = GetComponent<Animator>();
    }

    public void Update()  
    {
        goblinMove();
    }

    public void goblinMove()
    {
            //animation
            goblinAnimator.SetFloat("goblinMovement", Mathf.Abs(runSpeed));

            transform.Translate(Vector2.right * runSpeed * Time.deltaTime);
            RaycastHit2D groundCheck = Physics2D.Raycast(groundDetector.position, Vector2.down, rayDistance);

            if (groundCheck.collider == false)
            {
                if (movingRight)
                {
                    //rotate player to left
                    transform.eulerAngles = new Vector3(0, -180, 0);
                    movingRight = false;
                }
                else
                {
                    transform.eulerAngles = new Vector3(0, 0, 0);
                    movingRight = true;
                }
            } 
    }

    public void goblinAttack()
    {
            goblinAnimator.SetTrigger("goblinAttackTrigger");
    }

    public void goblinDamage()
    {
        goblinAnimator.SetTrigger("goblinDamageTrigger");      
    }

    public void goblinDie()
    {
        goblinAnimator.SetBool("isDead", true);
        this.enabled = false;
    }
}
