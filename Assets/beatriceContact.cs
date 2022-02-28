using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beatriceContact : MonoBehaviour
{
    public GameObject hero, heal;
    public int heroFullHealth;
    public Animator animator;
    public AudioSource audioCast;

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

}
