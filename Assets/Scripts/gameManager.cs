using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    // Bat Spawner
    public float enemyFlySpeed = 1;
    public float spawnMoveSpeed = 5;
    public Vector3 moveVector;

    // Hero - Player
    public float runSpeed = 5;
    public float JumpForce = 15;

    // End wall
    public float wallSpeed = 5;

    //Goblin
    public float goblinAttackRate = 2;
    public int goblinAttackDamage = 1;

    public heroMovement hero;
    public GameObject healthBar;
    public float fullHealth;

    public GameObject scoreText;
    public static int score = 0;

    void Start()
    {
        fullHealth = hero.health;
    }

    void Update()
    {
        if (healthBar.GetComponent<UnityEngine.UI.Image>().fillAmount == 0)
            Debug.Log("End game");

        if (hero)
        {
            healthBar.GetComponent<UnityEngine.UI.Image>().fillAmount = hero.health / fullHealth;
        }

        scoreText.GetComponent<TMPro.TextMeshProUGUI>().text = "x " + " " + score.ToString();
    }
}
