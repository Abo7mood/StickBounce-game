using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
public class SoundScripts : MonoBehaviour
{
    public AudioMixer soundmixer;
    public AudioMixer musicmixer;
 
    private void Start()
    {
        
    }
    public void SetSound(float Sound)
    {
        soundmixer.SetFloat("Sound", Sound);
        PlayerPrefs.SetFloat("Sound", Sound);
        PlayerPrefs.GetFloat("Sound", Sound);
    }
    public void SetMusic(float Music)
    {
        PlayerPrefs.SetFloat("Music", Music);
        musicmixer.SetFloat("Music", Music);
        PlayerPrefs.GetFloat("Music", Music);
    }
    

   
}
