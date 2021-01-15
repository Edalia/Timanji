using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goblinCombat : MonoBehaviour
{
    public goblinMovement goblin;
    public Transform goblin_attackPoint;
    public float goblin_attackRange = 0.4f;
    public LayerMask playerHitLayer;
    public int goblinMaxHealth = 100;
    public int damage_toPlayer = 50;
    public float delay = 2;
    public bool isDead = false;
    public int player_health;

    // Update is called once per frame
    void Start()
    {
            StartCoroutine("hitPlayer"); 
    } 

    void goblinattack()
    {
        if (isDead == false)
        {
            goblin.goblinAttack();

            //collision points for hitting player
            Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(goblin_attackPoint.position, goblin_attackRange, playerHitLayer);
            /*player.playertakeDamage(damage_toPlayer);*/

            foreach (Collider2D player in hitPlayer)
            {
                //inflict damage to player
                player.GetComponent<PlayerCombat>().playertakeDamage(damage_toPlayer);
            }
        }   
    }

    IEnumerator hitPlayer()
    {
         while (true)
          {
            yield return new WaitForSeconds(delay); // "pauses" for 2 seconds.. note, the actual game doesn't pause..
            goblinattack();
          }
    }

    public void goblintakeDamage(int damage)
    {
            if (isDead == false)
            {
                goblinMaxHealth -= damage;
                //goblinMaxHealth -= damage;
                //play damage anim
                GetComponent<goblinMovement>().goblinDamage();
                
            }


            if (goblinMaxHealth <= 0)
            {
                isDead = true;
                Debug.Log(goblinMaxHealth);
                GetComponent<goblinMovement>().goblinDie();
                this.enabled = false;
                
            }
    }
}
