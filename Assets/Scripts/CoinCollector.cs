using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinCollector : MonoBehaviour
{
    // Start is called before the first frame update
    public float coin = 0;
    public TextMeshProUGUI coinText;
    

    //Coin Destroy
    
    private void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.CompareTag("Coins")){
            SoundManager.PlaySound("Coin");
            coin++;
            coinText.text = coin.ToString();
            other.gameObject.SetActive(false);
            
        }
    }
}
