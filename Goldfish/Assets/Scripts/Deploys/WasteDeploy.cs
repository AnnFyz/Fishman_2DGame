using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WasteDeploy : MonoBehaviour
{

    [SerializeField] private float minRespawnTime = 1.0f;
    [SerializeField] private float maxRespawnTime = 2.0f;
    GameObject waste;
    void Start()
    {
      waste = GameAssets.GetInstance().Waste;
        StartCoroutine(WasteWave());
    }


    private void SpawnWaste()
    {
        GameObject w = Instantiate(waste) as GameObject;
        
        if (SceneManager.GetActiveScene().buildIndex == 1 || SceneManager.GetActiveScene().buildIndex == 2)
        {
            w.transform.position = new Vector2(GameHandler.screenBounds.x * 2, Random.Range(GameHandler.screenBounds.y / 3, -GameHandler.screenBounds.y));
        }

        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            w.transform.position = new Vector2(Random.Range(GameHandler.screenBounds.x / 3, -GameHandler.screenBounds.x), GameHandler.screenBounds.y * 2);
        }
    }

    IEnumerator WasteWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minRespawnTime, maxRespawnTime));
            SpawnWaste();
        }
    }
}
