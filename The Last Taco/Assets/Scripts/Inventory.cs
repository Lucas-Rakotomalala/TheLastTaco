using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
   public int tacoCount;
   public Text tacosCountText;

   public List<Item> content = new List<Item>();
   private int contentCurrentIndex = 0;
   public Image itemImageUI;
   public Text itemNameUI;
   public Sprite emptyItemImage;

   public PlayerEffects playereffects;

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

   private void Start()
   {
       UpdateInventoryUI();
   }


   public void ConsumeItem()
   {
       if (content.Count == 0)
       {
           return;
       }

       Item currenItem = content[0];
       PlayerHealth.instance.HealPlayer(currenItem.hpGiven);
       playereffects.AddSpedd(currenItem.speedGiven, currenItem.speedDuration);
       content.Remove(currenItem);
       GetNextItem();
       UpdateInventoryUI();
   }

   public void GetNextItem()
   {
       if (content.Count == 0)
       {
           return;
       }

       contentCurrentIndex++;
       if (contentCurrentIndex > content.Count - 1)
       {
           contentCurrentIndex = 0;
       }
       UpdateInventoryUI();
   }

   public void GetPreviousItem()
   {
       if (content.Count == 0)
       {
           return;
       }

       contentCurrentIndex--;
       if (contentCurrentIndex < 0)
       {
           contentCurrentIndex = content.Count - 1;
       }
       UpdateInventoryUI();
   }

   public void UpdateInventoryUI()
   {
       if (content.Count > 0)
       {
           itemImageUI.sprite = content[contentCurrentIndex].image;
           itemNameUI.text = content[contentCurrentIndex].name;
       }
       else
       {
           itemImageUI.sprite = emptyItemImage;
           itemNameUI.text = "";
       }
   }

   public void AddTacos(int count)
   {
       tacoCount += count;
       UpdateTextUI();
   }

   public void UpdateTextUI()
   {
       tacosCountText.text = tacoCount.ToString();
   }

   public void RemoveTacos(int count)
   {
        tacoCount -= count;
       tacosCountText.text = tacoCount.ToString();
   }
}
