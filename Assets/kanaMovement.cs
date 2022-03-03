using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kanaMovement : MonoBehaviour
{
    Animator animator;
    public static float speed = 5;
    public GameObject hero;
    public Rigidbody2D rigidBody;
    public float jumpForce;

    private float timePerAction;
    public float startTimeAction;
    public bool isMakingAction = false, isJumping = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody2D>();

        Stand();
    }

    void Update()
    {
        animator.SetFloat("Speed", speed);

        if (rigidBody.velocity.y != 0)
            isJumping = true;
        else
            isJumping = false;

        Move(hero.transform.position);
        //Jumping();
        //Action();
    }

    //void Action()
    //{
    //    if (timePerAction <= 0)
    //    {
    //        int action = Random.Range(1, 3);
    //        Debug.Log(action);

    //        switch (action)
    //        {
    //            case 1:
    //                Stand();
    //                break;
    //            case 2:
    //                Move(hero.transform.position);
    //                break;
    //        }
    //        timePerAction = startTimeAction;
    //    }
    //    else
    //    {
    //        timePerAction -= Time.deltaTime;
    //    }
    //}

    void Jumping()
    {
        if (!isJumping)
        {
            rigidBody.velocity = Vector2.up * jumpForce;
        }
    }

    IEnumerator MakeAction()
    {
        int action = Random.Range(1, 3);
        yield return new WaitForSeconds(2f);
        Debug.Log(action);

        switch (action)
        {
            case 1:
                Stand();
                yield return new WaitForSeconds(2f);
                break;
            case 2:
                Move(hero.transform.position);
                yield return new WaitForSeconds(1f);
                break;
        }
    }

    void Stand()
    {
        speed = 0;
    }

    IEnumerator StandWait(float delayTime)
    {
        speed = 0;
        yield return new WaitForSeconds(delayTime);
    }

    void Move(Vector3 position)
    {
        int horizontalMove;

        float distance = Vector2.Distance(transform.position, hero.transform.position);

        if(Mathf.Abs(transform.position.y - position.y) <= 2 || transform.position.y > position.y)
        {
            if (distance > 1)
            {
                speed = 5;

                if (transform.position.x < position.x)
                {
                    horizontalMove = 1;

                    if (!kana.isFacingRight)
                        gameObject.GetComponent<kana>().Flip();
                }
                else
                {
                    horizontalMove = -1;
                    if (kana.isFacingRight)
                        gameObject.GetComponent<kana>().Flip();
                }

                transform.position += new Vector3(horizontalMove, 0, 0) * speed * Time.deltaTime;
            }
            else
                speed = 0;
        }
        else
            speed = 0;
    }
}
