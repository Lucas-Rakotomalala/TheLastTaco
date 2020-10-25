using UnityEngine;

public class HeadPowerUp : MonoBehaviour
{
    public  int healdPoints;
    public AudioClip pickupSound;


   private void OnTriggerEnter2D(Collider2D collision) 
   {
       if (collision.CompareTag("Player"))
       {
           if (PlayerHealth.instance.currentHealth != PlayerHealth.instance.maxHealth)
           {
               AudioManager.instance.PlayClipAt(pickupSound, transform.position);
               PlayerHealth.instance.HealPlayer(healdPoints);
               Destroy(gameObject);
           }
       }
   }
}
