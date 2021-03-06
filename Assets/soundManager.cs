using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundManager : MonoBehaviour
{
    public static AudioClip playerAttack, fireball, poof, step, blood_explode, coin, heal, cut, fireball_impact, campfire;
    static AudioSource audioSrc;

    void Start()
    {
        playerAttack = Resources.Load<AudioClip>("playerAttack");
        fireball = Resources.Load<AudioClip>("fireball");
        poof = Resources.Load<AudioClip>("poof");
        step = Resources.Load<AudioClip>("step");
        blood_explode = Resources.Load<AudioClip>("blood_explosion");
        coin = Resources.Load<AudioClip>("coin");
        heal = Resources.Load<AudioClip>("heal");
        cut = Resources.Load<AudioClip>("cut");
        fireball_impact = Resources.Load<AudioClip>("fireball_impact");
        campfire = Resources.Load<AudioClip>("campfire");

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
            case "heal":
                audioSrc.volume = 0.8f;
                audioSrc.PlayOneShot(heal);
                break;
            case "cut":
                audioSrc.volume = 0.5f;
                audioSrc.PlayOneShot(cut);
                break;
            case "fireball_impact":
                audioSrc.volume = 0.5f;
                audioSrc.PlayOneShot(fireball_impact);
                break;
            case "campfire":
                audioSrc.volume = 0.5f;
                audioSrc.PlayOneShot(campfire);
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
