using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class PlayerCoinCollector : MonoBehaviour
{
    //On loading change the value
    public int collectedCoins = 0;
    [SerializeField] PlayerRotate playerRotator;
    [SerializeField] PlayerState state;
    [SerializeField] TextMeshProUGUI coinstext;
  
    public GameObject particle;
  
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Checking if everything is valid.
        if (collision.gameObject.layer == LayerMask.NameToLayer("RewardCoin"))
        {
            if (playerRotator.boostRotation != 0f)
            {
                SoundManager.instance.coinsSound();
                if(collision.CompareTag("StaticCoin"))
                collectedCoins+=50;
                else
                    collectedCoins += 100;
                Destroy(collision.gameObject);
                GameObject ins = Instantiate(particle, collision.transform.position, Quaternion.identity);
                coinstext.text = collectedCoins.ToString();
            }
        } 
    }
}
