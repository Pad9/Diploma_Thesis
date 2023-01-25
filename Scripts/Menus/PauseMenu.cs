using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false; //By default game is not paused

    public GameObject pauseMenuUI;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) //If we press the ESC button on our keyboard we want to pause the game or resume it if it is already paused
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void  Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f; //Normal time of the game
        GameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f; //Freeze the game
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0); //Load the Starting Menu (MainMenu)
    }

    public void QuitGame()
    {
        Application.Quit(); //Quit the game
    }
}
