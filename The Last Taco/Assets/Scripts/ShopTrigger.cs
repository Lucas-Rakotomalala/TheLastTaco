using UnityEngine;
using UnityEngine.UI;

public class ShopTrigger : MonoBehaviour
{
   private bool isInRange;

    private Text interractUI;

    public string pngName;
    public Item[] itemsToSell;

    private void Awake() 
    {
            interractUI = GameObject.FindGameObjectWithTag("InterractUI").GetComponent<Text>();
            interractUI.enabled = false;
    }
    void Update()
    {
        if (isInRange && Input.GetKeyDown(KeyCode.E))
        {          
            ShopManager.instance.OpenShop(itemsToSell,pngName);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInRange = true;
            interractUI.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInRange = false;
            interractUI.enabled = false;
            ShopManager.instance.CloseShop();
        }
    }
}
