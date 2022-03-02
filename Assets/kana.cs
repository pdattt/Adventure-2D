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
            health -= damage;
        }
    }

    IEnumerator turnInvisible()
    {
        yield return new WaitForSeconds(2f);
        isInvisible = true;
        yield return new WaitForSeconds(2f);
        isInvisible = false;
    }
}
