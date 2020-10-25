using UnityEngine;
using UnityEngine.SceneManagement;

public class PickUpObject : MonoBehaviour
{
    public AudioClip sound;

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.CompareTag("Player"))
        {
            AudioManager.instance.PlayClipAt(sound, transform.position);
            Inventory.instance.AddTacos(1);
            CurrentSceneManager.instance.tacoPickedUpInThisSceneCount++;
            Destroy(gameObject);
        }
    }
}
