using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour
{
    public static Vector2 screenBounds;
    private static GameHandler Instance;
    [SerializeField] RawImage image;
    public static GameHandler GetInstance()
    {
        return Instance;
    }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(FadeImage(true));
    }



    public void LoadNextScene()
    {
        StartCoroutine(StartLoadingNewScene(SceneManager.GetActiveScene().buildIndex + 1, "NewLevel", false));
    }


    public void LoadGoodEnding()
    {
        StartCoroutine(StartLoadingNewScene(5, "GoodEnding", true));
    }


    public void LoadBadEnding()
    {
        StartCoroutine(StartLoadingNewScene(4, "BadEnding", true));
    }

    IEnumerator StartLoadingNewScene(int index, string sound, bool stopBackgroundMusic)
    {
        // loop over 1 second
        for (float i = 0, j = 1f; i <= 1; i += Time.deltaTime, j -= Time.deltaTime)
        {
            // set color with i as alpha
            image.color = new Color(image.color.r, image.color.b, image.color.g, i);
            if (stopBackgroundMusic)
            {
                if(j <= 0.15)
                {
                    SoundManager.Instance.GetSound("BackgroundMusic").audioSource.volume = j;
                }
               
            }
            SoundManager.Instance.PlaySound(sound);
            yield return null;
        }

        SceneManager.LoadScene(index);
    }

    public IEnumerator FadeImage(bool fadeAway)
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
}
