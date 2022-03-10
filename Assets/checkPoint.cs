using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkPoint : MonoBehaviour
{
    private saveObject GM;
    private bool isChecked = false;

    void Start()
    {
        GM = GameObject.Find("GameMaster").GetComponent<saveObject>();
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other)
    {
        if(!isChecked)
            if(other.tag == "Player")
            {
                GM.lastCheckPointPos = transform.position;
                soundManager.PlaySound("campfire");
                transform.GetChild(0).GetComponentInChildren<ParticleSystem>().Play();
                transform.GetChild(1).GetComponentInChildren<ParticleSystem>().Play();
                transform.GetChild(2).GetComponentInChildren<ParticleSystem>().Play();
                isChecked = true;
            }
    }
}
