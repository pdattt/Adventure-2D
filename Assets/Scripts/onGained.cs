using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onGained : MonoBehaviour
{
    public int value = 1;
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            soundManager.PlaySound("coin");
            gameManager.score += value;
            animator.SetTrigger("Gain");

            Destroy(gameObject, 0.3f);
        }
    }
}
