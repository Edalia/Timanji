using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossMovement : MonoBehaviour
{
    public GameObject bossBody;
    public GameObject playerObj;
    public Animator bossAnimator;
    public static float runSpeed = 2f;
    public Transform groundDetector;
    public bool movingRight = true;
    public bool isGrounded;
    public float rayDistance;
    public Vector2 bossPosition;
    public Vector2 playerPosition;
    public float bossXposition;
    public float playerXposition;
    public float playerBossDistance;


    // Update is called once per frame
    public void Start()
    {
        bossBody = GetComponent<GameObject>();
        bossAnimator = GetComponent<Animator>();
    }

    public void Update()
    {
        bossChasePlayer();
    }

    public void bossMove()
    {
        //animation
        bossAnimator.SetFloat("bossMovement", Mathf.Abs(runSpeed));

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

                //move right
                
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }
    }



    public void bossChasePlayer()
    {
        //get boss' position
        bossPosition = gameObject.transform.position;
        bossXposition = bossPosition.x;

        //get player's position
        playerPosition = playerObj.transform.position;
        playerXposition = playerPosition.x;

        playerBossDistance = Vector2.Distance(playerPosition, bossPosition);

        if (playerBossDistance < 10)
        {
            Vector2.MoveTowards(bossPosition, playerPosition, runSpeed);
            if (playerXposition < bossXposition)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
            }
        }
        else
        {
            bossMove();
        }
    }


    public void bossAttack()
    {
        bossAnimator.SetTrigger("bossAttackTrigger");
    }

    public void bossDamage()
    {
        bossAnimator.SetTrigger("bossDamageTrigger");
    }

    public void bossDie()
    {
        bossAnimator.SetBool("bossDead", true);
        this.enabled = false;
    }
}
