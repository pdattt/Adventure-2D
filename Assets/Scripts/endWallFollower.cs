using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endWallFollower : MonoBehaviour
{
    public heroMovement hero;
    gameManager GameManager;

    public float setDistance;

    void Start()
    {
        GameObject gameController = GameObject.FindGameObjectWithTag("GameController");
        GameManager = gameController.GetComponent<gameManager>();
    }

    void LateUpdate()
    {
        if (hero != null)
        {
            float distance = Vector2.Distance(transform.position, hero.transform.position);

            if (hero.horizontalMove > 0 && distance > setDistance)
            {
                transform.position += transform.right * Time.deltaTime * GameManager.wallSpeed;
            }
        }
    }
}
