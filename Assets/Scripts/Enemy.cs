using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    gameManager GameManager;
    public GameObject onDeadAnimation;

    public int health;

    void Start()
    {
        GameObject gameController = GameObject.FindGameObjectWithTag("GameController");
        GameManager = gameController.GetComponent<gameManager>();
    }

    void Update()
    {
        if (health <= 0)
        {
            soundManager.PlaySound("poof");
            Destroy(Instantiate(onDeadAnimation, transform.position, Quaternion.identity), (float)0.5);
            Destroy(gameObject);
        }

        transform.Translate(GameManager.moveVector * GameManager.enemyFlySpeed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EndWall"))
            Destroy(gameObject);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }
}
