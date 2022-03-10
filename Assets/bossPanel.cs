using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class bossPanel : MonoBehaviour
{
    public TMPro.TextMeshProUGUI text;
    public UnityEngine.UI.Button buttonReplay;
    public UnityEngine.UI.Text buttonText;

    void Update()
    {
        if (kana.health <= 0)
        {
            Time.timeScale = 0.3f;
            GameObject.Find("BackGroundSound").GetComponent<AudioSource>().volume = 0.2f;
            text.text = "CONGRATULATION";

            StartCoroutine(EndPanel());
            buttonText.text = "PLAY AGAIN";
            buttonReplay.onClick.AddListener(Replay);
        }

        if (pauseButton.isPaused)
        {
            Time.timeScale = 0f;
            text.text = "PAUSED";
            buttonText.text = "CONTINUE";
            buttonReplay.onClick.AddListener(Continue);
        }

        if (GameObject.Find("hero") == null)
        {
            text.text = "YOU DIED";
            gameManager.score = 0;
            buttonText.text = "CONTINUE";
            buttonReplay.onClick.AddListener(Again);
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
        SceneManager.LoadScene("Boss");
        pauseButton.isPaused = false;

    }

    public void Replay()
    {
        Time.timeScale = 1f;
        GameObject.Find("BackGroundSound").GetComponent<AudioSource>().volume = 1f;
        GameObject.Find("PausePanel").GetComponent<CanvasGroup>().alpha = 0;
        pauseButton.isPaused = false;
        SceneManager.LoadScene("Adventure");    }

    public void Quit()
    {
        Time.timeScale = 1f;
        GameObject.Find("BackGroundSound").GetComponent<AudioSource>().volume = 1f;
        pauseButton.isPaused = false;
        SceneManager.LoadScene("Menu");
    }

    IEnumerator EndPanel()
    {
        yield return new WaitForSeconds(1f);

        gamePanel.isPause = true;
        GameObject.Find("PausePanel").GetComponent<CanvasGroup>().alpha = 1;
        Time.timeScale = 1f;
    }
}
