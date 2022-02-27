using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public heroMovement hero;
    public GameObject Enemy;
    float randY;
    Vector2 whereToSpawn;

    public float spawnRate = 2f;
    float nextSpawn = 0.0f;
    public float setDistance;

    gameManager GameManager;

    void Start()
    {
        GameObject gameController = GameObject.FindGameObjectWithTag("GameController");
        GameManager = gameController.GetComponent<gameManager>();
    }

    void Update()
    {
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            randY = Random.Range(-3.50f, 0.9f);
            whereToSpawn = new Vector3(transform.position.x, randY);

            Instantiate(Enemy, whereToSpawn, Quaternion.identity);
        }
    }
     void LateUpdate()
    {
        if (hero != null)
        {
            float distance = Vector2.Distance(transform.position, hero.transform.position);

            if (hero.horizontalMove > 0 && distance < setDistance)
            {
                transform.position += transform.right * Time.deltaTime * GameManager.spawnMoveSpeed;
            }
        }
    }
}
