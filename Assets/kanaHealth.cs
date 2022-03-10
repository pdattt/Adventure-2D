using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kanaHealth : MonoBehaviour
{
    public kana kana;
    public GameObject kanaHealthBar;
    public float fullHealth;

    void Start()
    {
        fullHealth = kana.health;
    }

    void Update()
    {
        if (kanaHealthBar.GetComponent<UnityEngine.UI.Image>().fillAmount == 0)
            Debug.Log("End game");

        if(kana)
            kanaHealthBar.GetComponent<UnityEngine.UI.Image>().fillAmount = kana.health / fullHealth;
    }
}
