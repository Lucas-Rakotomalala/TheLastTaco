using UnityEngine;

public class CurrentSceneManager : MonoBehaviour
{
    public bool isPlayerPresentByDefault = false;
    public int tacoPickedUpInThisSceneCount;

    public static CurrentSceneManager instance;

   private void Awake()
   {
       if(instance != null)
       {
           Debug.LogWarning("Il n'y a plus d'une instance de CurrentSceneManager dans la scène");
           return;
       }

       instance = this; 
   }
}
