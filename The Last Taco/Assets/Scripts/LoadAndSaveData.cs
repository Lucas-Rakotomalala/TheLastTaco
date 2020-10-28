using UnityEngine;

public class LoadAndSaveData : MonoBehaviour
{
     public static LoadAndSaveData instance;

   private void Awake()
   {
       if(instance != null)
       {
           Debug.LogWarning("Il n'y a plus d'une instance de LoadAndSaveData dans la scène");
           return;
       }

       instance = this; 
   }
   
    void Start()
    {
        Inventory.instance.tacoCount = PlayerPrefs.GetInt("TacosCount",0);
        Inventory.instance.UpdateTextUI();

        /*int currentHealth = PlayerPrefs.GetInt("PlayerHealth", PlayerHealth.instance.maxHealth);
        PlayerHealth.instance.currentHealth = currentHealth;
        PlayerHealth.instance.healthBar.SetHealth(currentHealth);*/
    }

    public void SaveData()
    {
        PlayerPrefs.SetInt("TacosCount", Inventory.instance.tacoCount);
        PlayerPrefs.SetInt("levelReached",CurrentSceneManager.instance.levelToUnlock);

        if (CurrentSceneManager.instance.levelToUnlock > PlayerPrefs.GetInt("levelReached", 1))
        {
            PlayerPrefs.SetInt("levelReached", CurrentSceneManager.instance.levelToUnlock);
        }

        //PlayerPrefs.SetInt("PlayerHealth", PlayerHealth.instance.currentHealth);
    }

}
