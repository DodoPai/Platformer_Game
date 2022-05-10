using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Next : MonoBehaviour
{

    public void LoadNextScene()
    {
      
        SceneManager.LoadScene("level 1");

    }
    public void LoadStartScene()
    {
        SceneManager.LoadScene(0);

    }
    public void QuitGame()
    {
        Application.Quit();
    }
    
}
