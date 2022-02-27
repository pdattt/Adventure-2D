using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundSound : MonoBehaviour
{
    AudioSource audioSrc;

    void Start()
    {
        audioSrc = gameObject.GetComponent<AudioSource>();
        audioSrc.Play();
    }
}
