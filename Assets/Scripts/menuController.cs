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

    public void EasyMode()
    {
        SceneManager.LoadScene("Adventure");
    }
}
