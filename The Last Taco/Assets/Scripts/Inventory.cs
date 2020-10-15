using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
   public int tacoCount;
   public Text tacosCountText;

   public static Inventory instance;

   private void Awake()
   {
       if(instance != null)
       {
           Debug.LogWarning("Il n'y a plus d'une instance de Inventory dans la scène");
           return;
       }

       instance = this; 
   }

   public void AddTacos(int count)
   {
       tacoCount += count;
       tacosCountText.text = tacoCount.ToString();
   }
}
