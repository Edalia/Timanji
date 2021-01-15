using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spikes : MonoBehaviour
{
    public string LevelName;
    private void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.CompareTag("Player")){
            SoundManager.PlaySound("ambience");
            SceneManager.LoadScene(LevelName);
        }
    }
}
