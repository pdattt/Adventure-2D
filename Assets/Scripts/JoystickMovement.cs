using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class JoystickMovement : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    private playerControl player;

    float directionX;
    //Rigidbody2D rb;

    void Awake()
    {
        player = GameObject.Find("hero").GetComponent<playerControl>();
    }

    public void OnPointerUp(PointerEventData data)
    {
        player.StopMoving();
    }

    public void OnPointerDown(PointerEventData data)
    {
        if (gameObject.name == "button_left")
        {
            Debug.Log("Left");
        }

        if (gameObject.name == "button_right")
        {
            Debug.Log("Right");
        }
    }

    void Start()
    {
        //rb.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //directionX = CrossPlatformInputManager.GetAxis("Horizontal");
    }
}
