﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;
    
    public GameObject pauseMenuUI;

    public GameObject settingsWindow;
    
    void Update()
    {
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                if(gameIsPaused)
                {
                    Resume();
                }
                else
                {
                    Paused();
                }
            }
    }
    
    void Paused()
    {
        PlayerMouvement.instance.enabled = false;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        gameIsPaused = true;
    }
    
    public void Resume()
    {
        PlayerMouvement.instance.enabled = true;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        gameIsPaused = false;
    }
    
    public void LoadMainMenu()
    {
        Resume();
        SceneManager.LoadScene("MainMenu");
    }

     public void SettingsButton()
    {
        settingsWindow.SetActive(true);
    }
    
    
    public void CloseSettingsWindow()
    {
        settingsWindow.SetActive(false);
    }
}