using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControl : MonoBehaviour
{
    private bool MoveLeft, MoveRight;
    public float runSpeed = 10;
    public float jumpSpeed = 1;
    private float horizontalMove;

    private Rigidbody2D _rigidBody2D;
    private Animator anim;

    void Start()
    {
        _rigidBody2D = GetComponent<Rigidbody2D>();

        StopMoving();
    }

    public void PointerDownLeft()
    {
        MoveLeft = true;
    }

    public void PointerUpLeft()
    {
        MoveLeft = false;
    }

    public void PointerDownRight()
    {
        MoveRight = true;
    }

    public void PointerUpRight()
    {
        MoveRight = false;
    }

    public void setMoveLeft(bool left)
    {
        MoveLeft = left;
        MoveRight = !left;
    }

    public void StopMoving()
    {
        MoveLeft = false;
        MoveRight = false;
    }

    void Update()
    {
        PlayerJoyStick();

        //anim.SetFloat("Speed", horizontalMove);
    }

    void PlayerJoyStick()
    {
        if (MoveLeft)
        {
            horizontalMove = -runSpeed;
        }
        else if (MoveRight)
        {
            horizontalMove = runSpeed;
        }
        else
        {
            horizontalMove = 0;
        }
    }

    public void DoTheJumping()
    {
        if (Mathf.Abs(_rigidBody2D.velocity.y) < 0.001f)
            _rigidBody2D.velocity = Vector2.up * jumpSpeed;
    }

    void FixedUpdate()
    {
        _rigidBody2D.velocity = new Vector2(horizontalMove, _rigidBody2D.velocity.y);
    }
}
