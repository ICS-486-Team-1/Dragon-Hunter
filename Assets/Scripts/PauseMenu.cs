using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
  

    
    public void ActiveMenu()
    {
        Time.timeScale = 0;
        AudioListener.pause = true;
    }

    public void DeactiveMenu()
    {
        Time.timeScale = 1;
        AudioListener.pause = false;

    }

    public void RestartGame()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
