using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transition : MonoBehaviour
{
    [SerializeField] int sceneIndex;
      void OnTriggerEnter2D(Collider2D other)
     {
        GoldFishController fishController = other.gameObject.GetComponent<GoldFishController>();
        if (fishController != null)
        {
            SceneManager.LoadScene(sceneIndex);
        }
    }
}
