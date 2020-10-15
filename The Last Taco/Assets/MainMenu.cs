using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //public string levelToLoad="Scenes/SampleScene";
    
    public GameObject settingsWindow;
    
    public void StartGame()
    {
        SceneManager.LoadScene("Scenes/SampleScene");
    }
    
    public void SettingsButton()
    {
        settingsWindow.SetActive(true);
    }
    
    public void CloseSettingsWindow()
    {
        settingsWindow.SetActive(false);
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }
}
