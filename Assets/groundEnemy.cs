using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundEnemy : MonoBehaviour
{
    gameManager GameManager;
    goblinSound sound;


    private Rigidbody2D _rigidBody2D;
    public heroMovement hero;

    public bool isFacingRight;

    public bool isEnemyInRange = false, isEnemyDetected = false;
    public float health;
    public float speed = 3;
    private float timeBtnAttack;
    private int moveVector;

    public Animator anim;

    void Start()
    {
        _rigidBody2D = gameObject.GetComponent<Rigidbody2D>();
        GameObject gameController = GameObject.FindGameObjectWithTag("GameController");
        GameManager = gameController.GetComponent<gameManager>();

        sound = gameObject.GetComponent<goblinSound>();

        do
        {
            moveVector = Random.Range(-1, 1);
        } while (moveVector == 0);        
    }

    void Update()
    {
        if (isEnemyDetected)
            Attack();

        anim.SetFloat("Speed", speed);

        //DoDelayMovement(4f);

        transform.position += new Vector3(moveVector, 0, 0) * speed * Time.deltaTime;
    }

    void FixedUpdate()
    {
        if (moveVector > 0 && !isFacingRight)
        {
            Flip();
        }
        else if (moveVector < 0 && isFacingRight)
        {
            Flip();
        }

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EndWall"))
            Destroy(gameObject);

        if(gameObject.CompareTag("GroundEnemy"))
        if (collision.CompareTag("EndPoint"))
            moveVector = -moveVector;
            
    }

    public void TakeDamage(int damage)
    {
        if (health <= 0)
        {
            speed = 0;
            anim.SetBool("Dead", true);
            Destroy(gameObject, 1);
        }

        anim.SetTrigger("Hit");
        Flinch();
        health -= damage;
    }

    void Flinch()
    {
        FlinchDelay(0.4f);
    }

    IEnumerator FlinchDelay(float delayTime)
    {
        speed = 0;

        yield return new WaitForSeconds(delayTime);

        speed = 3;
    }

    void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector2 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void Attack()
    {
        int temp = moveVector;

        if (timeBtnAttack <= 0)
        {
            anim.SetTrigger("Attack");
            
            DoDelayAttack(0.5f);

            sound.PlayAttack();
            timeBtnAttack = GameManager.goblinAttackRate;
        }
        else
            timeBtnAttack -= Time.deltaTime;

        moveVector = temp;
    }

    void DoDelayAttack(float delayTime)
    {
        StartCoroutine(DelayAttack(delayTime));
    }

    IEnumerator DelayAttack(float delayTime)
    {
        speed = 0;

        yield return new WaitForSeconds(delayTime);

        if (isEnemyInRange)
            hero.TakeDamage(GameManager.goblinAttackDamage);

        speed = 3;
    }

    //void DoDelayMovement(float delayTime)
    //{
    //    StartCoroutine(DelayMovement(delayTime));
    //}

    //IEnumerator DelayMovement(float delayTime)
    //{

    //    transform.position += new Vector3(moveVector, 0, 0) * GameManager.goblinSpeed * Time.deltaTime;

    //    yield return new WaitForSeconds(delayTime);
    //}

    //void Moving()
    //{
    //    float x = Random.Range(-10, 10);

    //    Debug.Log(GameManager.goblinSpeed);

    //    transform.position += new Vector3(x, 0, 0) * GameManager.goblinSpeed * Time.deltaTime;
    //}
}
