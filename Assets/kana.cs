using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kana : MonoBehaviour
{
    public int health;
    public bool isInvisible = true;

    public void TakeDamage(int damage)
    {
        if (!isInvisible)
        {
            StartCoroutine(turnInvisible());
            health -= damage;
        }
    }

    IEnumerator turnInvisible()
    {
        isInvisible = true;
        yield return new WaitForSeconds(1f);
        isInvisible = false;
    }
}
