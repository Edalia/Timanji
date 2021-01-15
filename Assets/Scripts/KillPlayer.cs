using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillPlayer : MonoBehaviour
{
    public string levelName;
    // [SerializeField]
    // Transform spawnPoint;
    void  OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.CompareTag("Player")){
            SceneManager.LoadScene(levelName);
        }
        else{
            if(col.gameObject.CompareTag("Enemy")){
            col.gameObject.SetActive(false);
            }
        }
    }

}
