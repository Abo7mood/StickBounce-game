using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class HIO : MonoBehaviour
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

        if (Input.anyKey)
        {
            SceneManager.LoadScene(1);
        }

    }

}
