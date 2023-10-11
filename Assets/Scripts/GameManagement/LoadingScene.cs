using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScene : MonoBehaviour
{
    public CanvasGroup c;

    void Start()
    {
        StartCoroutine(Fade());
    }
    IEnumerator Fade()
    {
        for (float alpha = 1f; alpha >= -0.05f; alpha -= 0.05f)
        {
            c.alpha = alpha;
            yield return new WaitForSecondsRealtime(0.1f);
        }

        // once done, go to next scene
        SceneManager.LoadSceneAsync("Mario Scene", LoadSceneMode.Single);
    }

    public void ReturnToMain()
    {
        SceneManager.LoadSceneAsync("MainMenu", LoadSceneMode.Single);
        Debug.Log("Return to main menu");
    }
}
