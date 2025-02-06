using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    Scene currentScene;
    public void LoadSceneFight() => SceneManager.LoadScene(2);

    public void Menu() => SceneManager.LoadScene(1);

    public void Quit() => Application.Quit();
  

    void Start()
    {

         currentScene = SceneManager.GetActiveScene();


        string sceneName = currentScene.name;
        Time.timeScale = 1;
        //if (sceneName == "MainMenu")
        //{
        //    Cursor.visible = true;
        //}
        //else
        //{
        //    Cursor.visible = false;
        //}


    }
    
    public void NextLevel() => SceneManager.LoadScene(currentScene.buildIndex + 1);
    public void PlayAgain() => SceneManager.LoadScene(currentScene.buildIndex);

   public void Pause()
    {
        Time.timeScale = 0;

    }
    public void Resume()
    {
        Time.timeScale = 1;
    }
}
