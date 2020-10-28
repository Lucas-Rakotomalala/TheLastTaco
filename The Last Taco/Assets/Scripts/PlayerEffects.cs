﻿using UnityEngine;
using System.Collections;

public class PlayerEffects : MonoBehaviour
{
  public void AddSpedd(int speedGiven, float speedDuration)
  {
    PlayerMouvement.instance.moveSpeed += speedGiven;
    StartCoroutine(RemoveSpeed(speedGiven, speedDuration));
  }

  private IEnumerator RemoveSpeed(int speedGiven, float speedDuration)
  {
      yield return new WaitForSeconds(speedDuration);
      PlayerMouvement.instance.moveSpeed -= speedGiven;
  }
}
