using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] SoundSO sound;
    [SerializeField] RawImage image;

    private void Awake()
    {
        sound.audioSource = gameObject.AddComponent<AudioSource>();
        sound.audioSource.clip = sound.audioClip;
        sound.audioSource.volume = sound.volume;
        sound.audioSource.pitch = sound.pitch;
        sound.audioSource.loop = sound.loop;
    }
    private void Start()
    {
        sound.audioSource.Play();
        StartCoroutine(FadeImage(true));
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
                image.color = new Color(image.color.r, image.color.g, image.color.b, i);
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
                image.color = new Color(image.color.r, image.color.g, image.color.b, i);
                yield return null;
            }
        }
    }

    public void LoadNewScene()
    {
        StartCoroutine(StartLoadingNewScene());
    }

    IEnumerator StartLoadingNewScene()
    {
        // loop over 1 second
        for (float i = 0, j = 1f; i <= 1; i += Time.deltaTime, j -= Time.deltaTime)
        {
            // set color with i as alpha
            image.color = new Color(image.color.r, image.color.b, image.color.g, i);
            sound.audioSource.volume = j;
            yield return null;
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
