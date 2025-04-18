using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NuclearParticlesDeploy : MonoBehaviour
{

    [SerializeField] private float minRespawnTime = 5.0f;
    [SerializeField] private float maxRespawnTime = 10.0f;
    GameObject nuckearParticles;
    void Start()
    {
        nuckearParticles = GameAssets.GetInstance().NuclearSign;
        StartCoroutine(NucParWave());
    }


    private void SpawnNucPar()
    {
        GameObject w = Instantiate(nuckearParticles) as GameObject;
        if (SceneManager.GetActiveScene().buildIndex == 1 )
        {
            w.transform.position = new Vector2(GameHandler.screenBounds.x * 2, Random.Range(GameHandler.screenBounds.y / 3, -GameHandler.screenBounds.y));
        }
        else if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            w.transform.position = new Vector2(GameHandler.screenBounds.x * 1.25f, Random.Range(-GameHandler.screenBounds.y * 2f, -GameHandler.screenBounds.y * 1f));
        }
        else if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            w.transform.position = new Vector2(GameHandler.screenBounds.x * 2, Random.Range(GameHandler.screenBounds.y /2, -GameHandler.screenBounds.y/2));
        }
    }

    IEnumerator NucParWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minRespawnTime, maxRespawnTime));
            SpawnNucPar();
        }


    }
}
