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
       for (int i= 0; i < sellButtonParents.childCount;i++)
       {
           Destroy(sellButtonParents.GetChild(i).gameObject);
       }

       for (int i = 0; i < items.Length; i++)
       {
           GameObject button = Instantiate(sellButtonPrefab, sellButtonParents);
           SellButtonItem buttonScript = button.GetComponent<SellButtonItem>();
           buttonScript.itemName.text = items[i].name;
           buttonScript.itemImage.sprite = items[i].image;
           buttonScript.itemPrice.text = items[i].price.ToString();

           buttonScript.item = items[i];
           button.GetComponent<Button>().onClick.AddListener(delegate{ buttonScript.BuyItem(); });

       }
   }

   public void CloseShop()
   {
       animator.SetBool("isOpen",false);
   }
}
