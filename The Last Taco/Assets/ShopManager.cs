using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public Text pngNameText;
    public Animator animator;

    public GameObject sellButtonPrefab;
    public Transform sellButtonParents;
    public static ShopManager instance;

   private void Awake()
   {
       if(instance != null)
       {
           Debug.LogWarning("Il n'y a plus d'une instance de ShopManager dans la scène");
           return;
       }

       instance = this; 
   }

   public void OpenShop(Item[] items, string pngName)
   {
       pngNameText.text = pngName;
       UpdateItemsTosell(items);
       animator.SetBool("isOpen",true);
   }

   void UpdateItemsTosell(Item[] items)
   {
       for (int i = 0; i < items.Length; i++)
       {
           Instantiate(sellButtonPrefab, sellButtonParents);
       }
   }

   public void CloseShop()
   {
       animator.SetBool("isOpen",false);
   }
}
