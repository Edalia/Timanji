using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossCombat : MonoBehaviour
{
    public bossMovement boss;
    public Transform boss_attackPoint;
    public float boss_attackRange = 0.9f;
    public LayerMask playerHitLayer;
    public int bossMaxHealth = 100;
    public int damage_toPlayer = 60;
    public float delay = 2;
    public bool isDead = false;
    public int player_health;

    // Update is called once per frame
    void Start()
    {
        StartCoroutine("hitPlayer");
    }

    void bossattack()
    {
        if (isDead == false)
        {
            boss.bossAttack();

            //collision points for hitting player
            Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(boss_attackPoint.position, boss_attackRange, playerHitLayer);
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
            bossattack();
        }
    }

    public void bosstakeDamage(int damage)
    {
        if (isDead == false)
        {
            bossMaxHealth -= damage;
            //bossMaxHealth -= damage;
            //play damage anim
            GetComponent<bossMovement>().bossDamage();
        }

        if (bossMaxHealth <= 0)
        {
            isDead = true;
            Debug.Log(bossMaxHealth);
            GetComponent<bossMovement>().bossDie();
            this.enabled = false;
        }
    }


    private void OnDrawGizmosSelected()
     {
         if (boss_attackPoint == null)
             return;

             Gizmos.DrawWireSphere(boss_attackPoint.position, boss_attackRange);

     }

}
