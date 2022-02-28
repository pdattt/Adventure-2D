using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heroMovement : MonoBehaviour
{
    public float horizontalMove = 0f;

    gameManager GameManager;

    public Animator animator;
    public bool isFacingRight = true;

    private Rigidbody2D _rigidBody2D;
    public GameObject explosion;
    private int countJump;

    public int health = 3;

    void Start()
    {
        _rigidBody2D = GetComponent<Rigidbody2D>();
        GameObject gameController = GameObject.FindGameObjectWithTag("GameController");
        GameManager = gameController.GetComponent<gameManager>();

        countJump = 2;
    }

    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal");


        transform.position += new Vector3(horizontalMove, 0, 0) * GameManager.runSpeed * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.W) && countJump > 0)
        {
            //_rigidBody2D.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
            //Debug.Log(ForceMode2D.Impulse);
            _rigidBody2D.velocity = Vector2.up * GameManager.JumpForce;
            countJump--;
        }

        if (_rigidBody2D.velocity.y != 0)
        {
            animator.SetBool("IsJumping", true);
        }
        else
        {
            countJump = 2;
            animator.SetBool("IsJumping", false);
        }

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

    }

    void FixedUpdate()
    {
        if (health <= 0)
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

        float h = Input.GetAxis("Horizontal");
        if (h > 0 && !isFacingRight)
        {
            Flip();
        }
        else if (h < 0 && isFacingRight)
        {
            Flip();

        }
    }

    void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector2 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            soundManager.PlaySound("blood_explode");
            Destroy(gameObject);
        }

        //if (collision.CompareTag("Ally"))
        //{
        //    health = 5;
        //    Debug.Log("Heal");
        //}
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        animator.SetTrigger("Hit");
    }
}