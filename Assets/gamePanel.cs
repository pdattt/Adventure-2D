using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gamePanel : MonoBehaviour
{
    public static bool isPause = false;

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
            buttonReplay.onClick.AddListener(Again);
        }

        if (isPause)
        {
            Time.timeScale = 0f;
            buttonText.text = "CONTINUE";
            buttonReplay.onClick.AddListener(Continue);
        }

        if (GameObject.Find("hero") == null)
        {
            text.text = "YOU DIED";
            gameManager.score = 0;
        }
    }

    IEnumerator EndPanel()
    {
        yield return new WaitForSeconds(1f);

        gamePanel.isPause = true;
        GameObject.Find("PausePanel").GetComponent<CanvasGroup>().alpha = 1;
    }

    public void Continue()
    {
        gamePanel.isPause = false;
        Time.timeScale = 1f;
        GameObject.Find("BackGroundSound").GetComponent<AudioSource>().volume = 1f;
        GameObject.Find("PausePanel").GetComponent<CanvasGroup>().alpha = 0;

        if (GameObject.Find("hero") == null)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
        }
    }

    public void Again()
    {
        gamePanel.isPause = false;
        Time.timeScale = 1f;
        GameObject.Find("BackGroundSound").GetComponent<AudioSource>().volume = 1f;

        SceneManager.LoadScene("Adventure");
    }

    public void Quit()
    {
        gamePanel.isPause = false;
        Time.timeScale = 1f;
        GameObject.Find("BackGroundSound").GetComponent<AudioSource>().volume = 1f;
        SceneManager.LoadScene("Menu");
    }
}
