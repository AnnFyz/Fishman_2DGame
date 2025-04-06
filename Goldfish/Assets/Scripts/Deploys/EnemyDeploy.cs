using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyDeploy : MonoBehaviour
{

    [SerializeField] private float minRespawnTime = 3.0f;
    [SerializeField] private float maxRespawnTime = 5.0f;
    static int offset = 20;
    GameObject enemies;
    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            enemies = GameAssets.GetInstance().Enemy;
            StartCoroutine(EnemysWave());
        }
    }


    private void SpawnEnemy()
    {
        GameObject e = Instantiate(enemies) as GameObject;
        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            e.transform.position = new Vector2(GameHandler.screenBounds.x + offset, -GameHandler.screenBounds.y + Random.Range(offset / 2.5f, offset));
        }
    }

    IEnumerator EnemysWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minRespawnTime, maxRespawnTime));
            SpawnEnemy();
        }


    }
}
