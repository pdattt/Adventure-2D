using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireBall : MonoBehaviour
{
    GameObject hero;
    public Animator spellExplosion;
    public Vector2 moveVector = new Vector2(1, 0);

    public int damage;
    public float spellSpeed;
    public bool isFacingRight = true;

    void Start()
    {
        Destroy(Instantiate(spellExplosion, transform.position, Quaternion.identity), 2);
        hero = GameObject.FindGameObjectWithTag("Player");

        if (hero.GetComponent<heroMovement>().isFacingRight && !isFacingRight)
        {
            moveVector = new Vector2(1, 0);
            Flip();
        }
        else if (!hero.GetComponent<heroMovement>().isFacingRight && isFacingRight)
        {
            moveVector = new Vector2(-1, 0);
            Flip();
        }    
    }

    void Update()
    {
        transform.Translate(moveVector * spellSpeed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Enemy"))
        {
            collider.GetComponent<Enemy>().TakeDamage(damage);
        }

        if (collider.CompareTag("GroundEnemy"))
        {
            collider.GetComponent<groundEnemy>().TakeDamage(damage);
        }
    }

    void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector2 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
