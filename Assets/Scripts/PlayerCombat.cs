using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCombat : MonoBehaviour
{
    public PlayerMovementScript player;
    public Transform player_attackPoint;
    public float player_attackRange = 0.4f;
    public LayerMask goblinHitLayer;
    public LayerMask bossLayer;
    public int playerMaxHealth = 100;
    public int damage_toGoblin= 50;
    public int damage_toBoss = 20;
    public bool isDead = false;
    public string levelName;



    // Update is called once per frame
    public void Update()
    {
        if (Input.GetKeyDown("t"))
        {
            if (isDead == false)
            {
                attack();
            }
        }
    }

    void attack()
    {
        // execute attack animation
        player.attackAnimation();
        SoundManager.PlaySound("EnemyHit");

        //collision points for hitting goblins
        Collider2D[] hitgoblins = Physics2D.OverlapCircleAll(player_attackPoint.position, player_attackRange, goblinHitLayer);

        //collision points for hitting hit boss
        Collider2D[] hitboss = Physics2D.OverlapCircleAll(player_attackPoint.position, player_attackRange, bossLayer);

        //Damage goblins
        foreach (Collider2D goblin in hitgoblins)
        {
            //inflict damage to goblin
            goblin.GetComponent<goblinCombat>().goblintakeDamage(damage_toGoblin);

        }

        //Damage final boss
        foreach (Collider2D boss in hitboss)
        {
            Debug.Log(boss.name);
            boss.GetComponent<bossCombat>().bosstakeDamage(damage_toBoss);
        }
    }

    public void playertakeDamage(int damage)
    {
        if (isDead == false)
        {
            playerMaxHealth -= damage;
            //goblinMaxHealth -= damage;
            //play damage anim
            GetComponent<PlayerMovementScript>().damageAnimation();
        }
       
        if (playerMaxHealth <= 0)
        {
            isDead = true;
            //Debug.Log("ded");
            GetComponent<PlayerMovementScript>().playerDie();
            this.enabled = false;
            SceneManager.LoadScene(levelName);
        }
    }
}
