using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heroAttack : MonoBehaviour
{
    public Animator animator;
    private float timeBtwAttack;
    public float startTimeAttack;

    private float timeBtwCast;
    public float startTimeCast;

    public Transform attackPos;
    public LayerMask whatIsEnemies;
    public float attackRange;
    public int attackDamage;

    public static bool isPaused = false;

    public GameObject spell;

    void Update()
    {
        if (!isPaused)
        {
            Attack();
            CastSpell();
        }        
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }

    void Attack()
    {
        if (timeBtwAttack <= 0)
        {
            if (Input.GetMouseButton(0))
            {
                soundManager.PlaySound("playerAttack");
                animator.SetTrigger("Attack");
                animator.SetTrigger("DrawSword");

                //Instantiate(slash, attackPos.position, Quaternion.identity);

                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    if (enemiesToDamage[i].CompareTag("Enemy"))
                    {
                        enemiesToDamage[i].GetComponent<Enemy>().TakeDamage(attackDamage);
                    }

                    if (enemiesToDamage[i].CompareTag("GroundEnemy"))
                    {
                        enemiesToDamage[i].GetComponent<groundEnemy>().TakeDamage(attackDamage);
                    }

                    if (enemiesToDamage[i].CompareTag("Kana"))
                    {
                        enemiesToDamage[i].GetComponent<kana>().TakeDamage(attackDamage);
                    }

                    Debug.Log("Hit!");
                }

                timeBtwAttack = startTimeAttack;
            }
        }
        else
        {
            timeBtwAttack -= Time.deltaTime;
        }
    }

    void CastSpell()
    {
        if (timeBtwCast <= 0)
        {
            if (Input.GetMouseButton(1))
            {
                soundManager.PlaySound("fireball");
                animator.SetTrigger("CastSpell");
                animator.SetTrigger("DrawSword");
                //Instantiate(slash, attackPos.position, Quaternion.identity);
                
                Destroy(Instantiate(spell, transform.position, Quaternion.identity), 1.5f);

                timeBtwCast = startTimeCast;
            }
        }
        else
        {
            timeBtwCast -= Time.deltaTime;
        }
    }
}
