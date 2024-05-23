using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Target : MonoBehaviour
{
    public float health = 50f;

/*    private void Start()
    {
        PlayerPrefs.SetString("Score: ", "0");
    }*/
    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        PointsManager.points += 1;
      //  PlayerPrefs.SetString("Score: ", PointsManager.points.ToString());
        Destroy(gameObject);
    }
}
