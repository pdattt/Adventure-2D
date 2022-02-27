using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goblinSound : MonoBehaviour
{
    public AudioSource audioGoblin;
    public AudioClip attack;

    public void PlayAttack()
    {
        audioGoblin.PlayOneShot(attack);
    }
}
