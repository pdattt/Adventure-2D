using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onGained : MonoBehaviour
{
    public int value;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            soundManager.PlaySound("coin");
            Destroy(gameObject);
        }
    }
}
