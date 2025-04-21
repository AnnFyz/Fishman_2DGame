using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour
{
    [SerializeField] RawImage image;

    void Start()
    {
        StartCoroutine(FadeImage(true));
    }
    public void LoadNewScene(int index)
    {
        if(SoundManager.Instance != null) { Destroy(SoundManager.Instance.gameObject); }
        StartCoroutine(StartLoadingNewScene(index));
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    IEnumerator StartLoadingNewScene(int index)
    {
        // loop over 1 second
        for (float i = 0, j = 1f; i <= 1; i += Time.unscaledDeltaTime, j -= Time.unscaledDeltaTime)
        {
            // set color with i as alpha
            image.color = new Color(image.color.r, image.color.b, image.color.g, i);
            yield return null;
        }

        Time.timeScale = 1;
        SceneManager.LoadScene(index);
    }

    IEnumerator FadeImage(bool fadeAway)
    {
        // fade from opaque to transparent
        if (fadeAway)
        {
            // loop over 1 second backwards
            for (float i = 1; i >= 0; i -= Time.unscaledDeltaTime)
            {
                // set color with i as alpha
                image.color = new Color(image.color.r, image.color.b, image.color.g, i);
                yield return null;
            }
        }
        // fade from transparent to opaque
        else
        {
            // loop over 1 second
            for (float i = 0; i <= 1; i += Time.unscaledDeltaTime)
            {
                // set color with i as alpha
                image.color = new Color(image.color.r, image.color.b, image.color.g, i);
                yield return null;
            }
        }
    }
}
