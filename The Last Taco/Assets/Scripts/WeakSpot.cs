using UnityEngine;

public class WeakSpot : MonoBehaviour
{
    public GameObject objectToDestroy;
    public Animator animator;

    private bool isAttacking;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && isAttacking)
        {
            Destroy(objectToDestroy);
        }

        ResetValues();
    }

     void Update() 
    {
        InputButton();
    }

    void InputButton()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            isAttacking = true;
        }
    }

     private void ResetValues()
    {
        isAttacking = false;
    }
}
