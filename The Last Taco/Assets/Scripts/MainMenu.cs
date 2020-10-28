using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string levelToLoad;
    
    public GameObject settingsWindow;
    //public GameObject RulesWindow;
    
    public void StartGame()
    {
        SceneManager.LoadScene(levelToLoad);
    }
    
    /*public void RulesButton()
    {
        RulesWindow.SetActive(true);
    }*/
    
    public void SettingsButton()
    {
        settingsWindow.SetActive(true);
    }
    
    /*public void CloseRulesWindow()
    {
        RulesWindow.SetActive(false);
    }*/
    
    public void CloseSettingsWindow()
    {
        settingsWindow.SetActive(false);
    }

    public void LoadCreditsScene()
    {
        SceneManager.LoadScene("Credits");
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }
    
}