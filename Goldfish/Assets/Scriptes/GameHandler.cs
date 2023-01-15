using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour
{
    [SerializeField] int sceneIndex;
    public static Vector2 screenBounds;
    RadioactiveCharge radoaktiveChar;
    GoldFishController fishController;

    void Start()
    {

        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        radoaktiveChar = FindObjectOfType<RadioactiveCharge>();
        fishController = FindObjectOfType<GoldFishController>();
    }


    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (sceneIndex != 4)
            {
                SceneManager.LoadScene(sceneIndex + 1);
            }
            else if (sceneIndex == 4)
            {
                SceneManager.LoadScene(0);
            }
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (sceneIndex > 0)
            {
                SceneManager.LoadScene(sceneIndex - 1);
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



}
