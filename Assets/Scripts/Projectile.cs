using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public float speed;
    public float distance;
    public int damage;

    public LayerMask whatIsSolid;

    void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.right, distance);
        if (hitInfo.collider != null)
        {
            if (hitInfo.collider.CompareTag("Enemy"))
            {
                Debug.Log("Enemy hit!!");
                hitInfo.collider.GetComponent<Enemy>().TakeDamage(damage); 
                Destroy(gameObject);
            }

        }

        transform.Translate(transform.right * speed * Time.deltaTime);
    }
}
