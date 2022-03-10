using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuController : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Difficulity");
    }

    public void Act1()
    {
        SceneManager.LoadScene("Adventure");
    }

    public void Act2()
    {
        SceneManager.LoadScene("Boss");
    }
}
