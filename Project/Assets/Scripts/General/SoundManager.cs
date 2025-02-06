using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
  public static  SoundManager instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            if (instance != this)
            {
                Destroy(instance.gameObject);
                instance = this;
            }
        }
        
    }
    enum sounds { jump, hit, blip, die, coins, Win,spin,boost }
    [SerializeField] AudioSource SoundSource;
    [SerializeField] AudioClip[] sound;
    public void jumpSound() { if(SoundSource.clip!= sound[(int)sounds.jump]) SoundSource.PlayOneShot(sound[(int)sounds.jump], 1f);  }
    public void hitSound() { if (SoundSource.clip != sound[(int)sounds.hit]) SoundSource.PlayOneShot(sound[(int)sounds.hit], 1f); }
    public void dieSound() { if (SoundSource.clip != sound[(int)sounds.die]) SoundSource.PlayOneShot(sound[(int)sounds.die], 1f); }
    public void coinsSound() { if (SoundSource.clip != sound[(int)sounds.coins]) SoundSource.PlayOneShot(sound[(int)sounds.coins], 1f); }
    public void WinSound() { if (SoundSource.clip != sound[(int)sounds.Win]) SoundSource.PlayOneShot(sound[(int)sounds.Win], 1f); }
    public void spinSound() { if (SoundSource.clip != sound[(int)sounds.spin]) SoundSource.PlayOneShot(sound[(int)sounds.spin], 1f); }
    public void boostSound() { if (SoundSource.clip != sound[(int)sounds.boost]) SoundSource.PlayOneShot(sound[(int)sounds.boost], 1f); }
}
