using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyWallFollower : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Enemy clear!!");
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Enemy clear!!");
            Destroy(collision.gameObject);
            //collision.GetComponent<Enemy>().TakeDamage(999);
        }

    }
}
