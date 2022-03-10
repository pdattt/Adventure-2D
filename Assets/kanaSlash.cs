using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kanaSlash : MonoBehaviour
{
    public int skillDamage = 1;
    public GameObject hero;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
            if (kanaAttack.isUsingSkill)
            {
                hero.GetComponent<heroMovement>().TakeDamage(skillDamage);
            }
    }
}
