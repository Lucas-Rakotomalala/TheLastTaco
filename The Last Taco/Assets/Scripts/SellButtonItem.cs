using UnityEngine;
using UnityEngine.UI;

public class SellButtonItem : MonoBehaviour
{
   public Text itemName;
   public Image itemImage;
   public Text itemPrice;

   public Item item;

   public void BuyItem()
   {
      Inventory inventory = Inventory.instance;

      if (Inventory.instance.tacoCount >= item.price)
      {
         inventory.content.Add(item);
         inventory.UpdateInventoryUI();
         inventory.tacoCount -= item.price;
         inventory.UpdateTextUI();
      }
   }
}
