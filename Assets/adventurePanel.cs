using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class adventurePanel : MonoBehaviour
{
    public TMPro.TextMeshProUGUI text;
    public UnityEngine.UI.Button buttonReplay;
    public UnityEngine.UI.Text buttonText;

    void Update()
    {
        if (pauseButton.isPaused)
        {
            Time.timeScale = 0f;
            text.text = "PAUSED";
            buttonText.text = "CONTINUE";
            buttonReplay.onClick.AddListener(Again);
        }

        if (GameObject.Find("hero") == null)
        {
            text.text = "YOU DIED";
            gameManager.score = 0;
        }
    }

    public void Continue()
    {
        Time.timeScale = 1f;
        GameObject.Find("BackGroundSound").GetComponent<AudioSource>().volume = 1f;
        GameObject.Find("PausePanel").GetComponent<CanvasGroup>().alpha = 0;

        pauseButton.isPaused = false;
    }

    public void Again()
    {
        Time.timeScale = 1f;
        GameObject.Find("BackGroundSound").GetComponent<AudioSource>().volume = 1f;
        GameObject.Find("PausePanel").GetComponent<CanvasGroup>().alpha = 0;
        SceneManager.LoadScene("Adventure");

        pauseButton.isPaused = false;
    }

    public void Quit()
    {
        Time.timeScale = 1f;
        GameObject.Find("BackGroundSound").GetComponent<AudioSource>().volume = 1f;
        SceneManager.LoadScene("Menu");

        pauseButton.isPaused = false;
    }
}
