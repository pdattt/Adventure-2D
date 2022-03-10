using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkInRange : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
            kanaAttack.isEnemyInRange = true;
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
            kanaAttack.isEnemyInRange = false;
    }
}
