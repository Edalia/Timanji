using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip collectCoin , enemyHit;
    static AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        collectCoin = Resources.Load<AudioClip>("Coin");
        enemyHit = Resources.Load<AudioClip>("ambience");

        audioSource =   GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static void PlaySound(string clip){
        switch(clip){
            case "Coin" :
            audioSource.PlayOneShot(collectCoin);
            break;
            switch(clip){
            case "ambience" :
            audioSource.PlayOneShot(enemyHit);
            break;
        }
        }
    }
}
