using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character2DController : MonoBehaviour
{
    public float runSpeed = 40;
    public float JumpForce = 1;
    float horizontalMove = 0f;

    public GameObject projectile;
    public Transform shotPoint;

    private float timeBtwShots;
    public float startTimeBtwShots;

    private Rigidbody2D _rigidBody2D;
    // Start is called before the first frame update
    void Start()
    {
        _rigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal");

        transform.position += new Vector3(horizontalMove, 0, 0) * runSpeed * Time.deltaTime;

        if (Input.GetKey("w") && Mathf.Abs(_rigidBody2D.velocity.y) < 0.001f)
        {
            _rigidBody2D.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
        }

        if (timeBtwShots <= 0)
        { 
            if (Input.GetKey("space"))
            {
                Instantiate(projectile, shotPoint.position, transform.rotation);
                timeBtwShots = startTimeBtwShots;
            }
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }
}
