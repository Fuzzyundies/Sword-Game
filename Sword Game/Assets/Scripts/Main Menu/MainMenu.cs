using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        // Game Scene Hardcoded as one. Set in Build settings.
        /*
         * Eventually need to make it load a waiting screen, and add the game screen additeve
         */

        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
