﻿using UnityEngine;

public class WeakSpot : MonoBehaviour
{
    public GameObject objectToDestroy;
    public Animator animator;

    private bool isAttacking2;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && isAttacking2)
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
            isAttacking2 = true;
        }
    }

     private void ResetValues()
    {
        isAttacking2 = false;
    }
}
