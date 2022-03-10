using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform playerTransform;

    bool isLock = false;

    public float offset;

    void LateUpdate()
    {
        if (!isLock)
        {
            if (playerTransform != null)
            {
                Vector3 temp = transform.position;

                temp.x = playerTransform.position.x;

                temp.x += offset;

                transform.position = temp;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "CameraLock")
        {
            isLock = true;
            transform.position = collider.gameObject.transform.position;
        }
    }
}
