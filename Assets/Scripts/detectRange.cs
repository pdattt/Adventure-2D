using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detectRange : MonoBehaviour
{
    public groundEnemy enemy;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            enemy.isEnemyDetected = true;
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            enemy.isEnemyDetected = false;
        }
    }
}
