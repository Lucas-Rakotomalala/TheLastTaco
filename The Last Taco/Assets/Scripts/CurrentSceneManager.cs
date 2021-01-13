﻿using UnityEngine;

public class CurrentSceneManager : MonoBehaviour
{
    public int tacoPickedUpInThisSceneCount;
    public Vector3 respawnPoint;
    public int levelToUnlock;

    public static CurrentSceneManager instance;

    //Singleton
   private void Awake()
   {
       if(instance != null)
       {
           Debug.LogWarning("Il n'y a plus d'une instance de CurrentSceneManager dans la scène");
           return;
       }

       instance = this; 

       respawnPoint = GameObject.FindGameObjectWithTag("Player").transform.position;
   }
}
