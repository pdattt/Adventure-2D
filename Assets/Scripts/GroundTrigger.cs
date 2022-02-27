using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTrigger : MonoBehaviour
{
    public Rigidbody2D hero;
    public BoxCollider2D Ground;

    void Start()
    {
        Ground = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        Debug.Log(Ground.isTrigger);
        //if (hero.velocity.y > 0)
        //    Ground.isTrigger == true;
        //else
        //    Ground.isTrigger == false;
    }
}
