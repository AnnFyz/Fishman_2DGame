using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour
{
    [SerializeField] int currentSceneIndex;
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
            if (currentSceneIndex != 4)
            {
                SceneManager.LoadScene(currentSceneIndex + 1);
            }
            else if (currentSceneIndex == 4)
            {
                SceneManager.LoadScene(0);
            }
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (currentSceneIndex > 0)
            {
                SceneManager.LoadScene(currentSceneIndex - 1);
            }
        }


        //if (radoaktiveChar != null && fishController != null)
        //{
        //    if (radoaktiveChar.radChar == 3)
        //    {
        //        Debug.Log("NEXTLEVEL");
        //        SceneManager.LoadScene(sceneIndex);
        //    }
        //}

    }


    public void LoadNextScene()
    {
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadGoodEnding()
    {
        SceneManager.LoadScene(currentSceneIndex + 1);
    }


    public void LoadBadEnding()
    {
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
}
