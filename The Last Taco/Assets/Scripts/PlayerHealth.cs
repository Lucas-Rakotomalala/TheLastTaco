using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public float invicibilityTimeAfterHit = 1.5f;
    public float invicibilityFlashDelay = 0.3f;
    public bool isInvincible = false;

    public SpriteRenderer graphics;
    public HealthBar healthBar;

    public AudioClip hitSound;

    public static PlayerHealth instance;

   private void Awake()
   {
       if(instance != null)
       {
           Debug.LogWarning("Il n'y a plus d'une instance de PlayerHealth dans la scène");
           return;
       }

       instance = this; 
   }

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.H))
        {
            TakeDamage(60);
        }
    }

    public void HealPlayer(int amout)
    {
        if ((currentHealth + amout) > maxHealth)
        {
            currentHealth = maxHealth;
            
        }
        else
        {
            currentHealth += amout;
        }
        healthBar.SetHealth(currentHealth);
    }

     public void TakeDamage(int damage)
    {
        if(!isInvincible)
        {

            AudioManager.instance.PlayClipAt(hitSound, transform.position);
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);

            //vérifier si ninja toujours vivant
            if (currentHealth <= 0)
            {
                Die();
                return;
            }

            isInvincible = true;
            StartCoroutine(InvincibilistyFlash());
            StartCoroutine(HandleInvicibilityDelay());
        }
    }

    public void Die()
    {
        Debug.Log("Le joueur est éliminé");
        PlayerMouvement.instance.enabled = false;
        PlayerMouvement.instance.animator.SetTrigger("Die");
        PlayerMouvement.instance.rb.bodyType= RigidbodyType2D.Kinematic;
        PlayerMouvement.instance.rb.velocity = Vector3.zero;
        PlayerMouvement.instance.playerCollider.enabled = false;
        GameOverManager.instance.OnPlayerDeath();
    }

    public void Respawn()
    {
        PlayerMouvement.instance.enabled = true;
        PlayerMouvement.instance.animator.SetTrigger("Respawn");
        PlayerMouvement.instance.rb.bodyType= RigidbodyType2D.Dynamic;
        PlayerMouvement.instance.playerCollider.enabled = true;
        currentHealth = maxHealth;
        healthBar.SetHealth(currentHealth);
    }

    public IEnumerator InvincibilistyFlash()
    {
        while(isInvincible)
        {
            graphics.color = new Color(1f,1f,1f,0f);
            yield return new WaitForSeconds(invicibilityFlashDelay);
            graphics.color = new Color(1f,1f,1f,1f);
            yield return new WaitForSeconds(invicibilityFlashDelay);
        }
    }

    public IEnumerator HandleInvicibilityDelay()
    {
        yield return new WaitForSeconds(invicibilityTimeAfterHit);
        isInvincible = false;
    }
}
