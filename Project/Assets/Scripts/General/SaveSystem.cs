using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SaveSystem : MonoBehaviour
{
    string sceneName;
    Scene currentScene;
    private void Start()
    {
        currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
    }
    private void Update()
    {

        if (Input.anyKey&& sceneName=="Main")
        {
            SceneManager.LoadScene(1);
        }
      
    }
    
}
