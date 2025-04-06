using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour
{
    public static Vector2 screenBounds;
    private static GameHandler Instance;
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
    }


    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (SceneManager.GetActiveScene().buildIndex != 4)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            else if (SceneManager.GetActiveScene().buildIndex == 4)
            {
                SceneManager.LoadScene(0);
            }
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (SceneManager.GetActiveScene().buildIndex > 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
            }
        }
    }


    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadGoodEnding()
    {
        SceneManager.LoadScene(5);
    }


    public void LoadBadEnding()
    {
        SceneManager.LoadScene(4);
    }
}
