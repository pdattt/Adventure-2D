using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beatriceContact : MonoBehaviour
{
    public GameObject hero, heal;
    public int heroFullHealth;
    public Animator animator;
    public AudioSource audioCast;
    public GameObject fadeHealthBar;
    //public float FadeRate;

    void Start()
    {
        heroFullHealth = hero.GetComponent<heroMovement>().health;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            Debug.Log("Heal");
            animator.SetTrigger("Touch");
            StartCoroutine(FadeImage(true));
            audioCast.Play();
            hero.GetComponent<heroMovement>().health = heroFullHealth;
            StartCoroutine(Heal());
            Destroy(Instantiate(heal, hero.transform.position, Quaternion.identity, hero.transform), 0.8f);
            //heal.transform.parent = hero.transform;
        }           
    }

    IEnumerator Heal()
    {
        yield return new WaitForSeconds(0.3f);
        soundManager.PlaySound("heal");
    }

    //IEnumerator FadeIn()
    //{
    //    float targetAlpha = 1.0f;
    //    Color curColor = fadeHealthBar.GetComponent<UnityEngine.UI.Image>().color;
    //    while (Mathf.Abs(curColor.a - targetAlpha) > 0.0001f)
    //    {
    //        Debug.Log(fadeHealthBar.GetComponent<UnityEngine.UI.Image>().material.color.a);
    //        curColor.a = Mathf.Lerp(curColor.a, targetAlpha, FadeRate * Time.deltaTime);
    //        fadeHealthBar.GetComponent<UnityEngine.UI.Image>().color = curColor;
    //        yield return null;
    //    }
    //}

    IEnumerator FadeImage(bool fadeAway)
    {
        if (fadeAway)
        {
            for (float i = 1; i >= 0; i -= Time.deltaTime)
            {
                fadeHealthBar.GetComponent<UnityEngine.UI.Image>().color = new Color(151, 241, 156, i);
                yield return null;
            }
        }
    }
}
