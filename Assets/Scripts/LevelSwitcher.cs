using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSwitcher : MonoBehaviour
{
    public string levelName;
    public GameObject Key;
    public GameObject Coins;
    void OnTriggerEnter2D(Collider2D other){
        if(Key.GetComponent<CollectKey>().playerHasKey){
            SceneManager.LoadScene(levelName);
        }
    }
}
