using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class saveObject : MonoBehaviour
{
    public static saveObject instance;
    public Vector3 lastCheckPointPos;

    void Start()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
        //DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        
    }
}
