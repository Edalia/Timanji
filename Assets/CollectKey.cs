using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectKey : MonoBehaviour
{
    // Start is called before the first frame update
    public bool playerHasKey;
    void Start()
    {
        playerHasKey = false;
    }

    private void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.CompareTag("Player")){
            playerHasKey = true;
            SoundManager.PlaySound("ambience");
            gameObject.SetActive(false);
            
        }
    }
}
