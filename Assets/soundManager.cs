using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundManager : MonoBehaviour
{
    public static AudioClip playerAttack, fireball, poof, step, blood_explode, coin;
    static AudioSource audioSrc;

    void Start()
    {
        playerAttack = Resources.Load<AudioClip>("playerAttack");
        fireball = Resources.Load<AudioClip>("fireball");
        poof = Resources.Load<AudioClip>("poof");
        step = Resources.Load<AudioClip>("step");
        blood_explode = Resources.Load<AudioClip>("blood_explosion");
        coin = Resources.Load<AudioClip>("coin");

        audioSrc = GetComponent<AudioSource>();
    }

    public static void PlaySound (string clip)
    {
        switch (clip)
        {
            case "playerAttack":
                audioSrc.volume = 0.1f;
                audioSrc.PlayOneShot(playerAttack);
                break;
            case "fireball":
                audioSrc.volume = 0.5f;
                audioSrc.PlayOneShot(fireball);
                break;
            case "poof":
                audioSrc.volume = 1f;
                audioSrc.PlayOneShot(poof);
                break;
            case "blood_explode":
                audioSrc.volume = 0.5f;
                audioSrc.PlayOneShot(blood_explode);
                break;
            case "coin":
                audioSrc.volume = 0.6f;
                audioSrc.PlayOneShot(coin);
                break;
        }
    }

    public void PlayStep()
    {
        StartCoroutine(WaitForSound());
    }

    IEnumerator WaitForSound()
    {
        audioSrc.PlayOneShot(step);
        yield return new WaitForSeconds(0.3f);
    }
}
