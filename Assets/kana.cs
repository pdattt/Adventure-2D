using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kana : MonoBehaviour
{
    static AudioSource audioSrc;
    public static AudioClip kanaAttack, kanaHit;

    kanaMovement Movement;
    kanaAttack Attack;

    private Animator animator;
    public static int health = 50;
    public static bool isInvisible = false, isFacingRight = false, isOnHit = false;

    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        kanaAttack = Resources.Load<AudioClip>("dagger");
        Movement = GetComponent<kanaMovement>();
        Attack = GetComponent<kanaAttack>();
        
        audioSrc = GetComponent<AudioSource>();
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "attack":
                audioSrc.volume = 0.4f;
                audioSrc.PlayOneShot(kanaAttack);
                break;
        }
        
    }

    public void TakeDamage(int damage)
    {
        if (isInvisible == false)
        {
            StartCoroutine(OnHit());
            animator.SetTrigger("Hit");
            isInvisible = true;
            kanaMovement.isFlinch = true;
            GetComponent<kanaMovement>().Flinching();
            //StartCoroutine(turnInvisible(1f)); 
            health -= damage;
        }
    }

    IEnumerator OnHit()
    {
        isOnHit = true; 
        soundManager.PlaySound("cut");
        yield return new WaitForSeconds(1.5f);
        isOnHit = false;
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

    void Update()
    {
        animator.SetInteger("Health", health);

        if(health <= 0)
        {
            Movement.enabled = false;
            Attack.enabled = false;
        }
    }
}
