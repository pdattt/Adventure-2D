using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform playerTransform;

    public float offset;

    void LateUpdate()
    {
        if(playerTransform != null)
        {
            Vector3 temp = transform.position;

            temp.x = playerTransform.position.x;

            temp.x += offset;

            transform.position = temp;
        }
    }
}
