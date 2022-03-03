using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kana : MonoBehaviour
{
    private Animator animator;
    public int health;
    public static bool isInvisible = false, isFacingRight = false, isMakingAction = false;

    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    public void TakeDamage(int damage)
    {
        if (isInvisible == false)
        {
            animator.SetTrigger("Hit");
            isInvisible = true;
            kanaMovement.isFlinch = true;
            GetComponent<kanaMovement>().Flinching();
            //StartCoroutine(turnInvisible(1f)); 
            health -= damage;
        }
    }

    IEnumerator turnInvisible(float delayTime)
    {
        isInvisible = true;
        yield return new WaitForSeconds(delayTime);
        isInvisible = false;
    }

    public void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector2 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), collision.gameObject.GetComponent<Collider2D>());  
    }
}
