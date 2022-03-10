using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseButton : MonoBehaviour
{
    public static bool isPaused = false;
    public void Pause()
    {
        isPaused = true;
        GameObject.Find("PausePanel").GetComponent<CanvasGroup>().alpha = 1;
    }

    void LateUpdate()
    {
        if (GameObject.Find("hero") == null)
            StartCoroutine(StartPause());
    }

    IEnumerator StartPause()
    {
        yield return new WaitForSeconds(0.5f);
        Pause();
    }
}
