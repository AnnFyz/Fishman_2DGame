using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroyableEffect : MonoBehaviour
{
    [SerializeField] float autoDestroyTime = 1;
   
    void Start()
    {
        StartCoroutine(AutoDestroy());
    }

  IEnumerator AutoDestroy()
    {
        yield return new WaitForSeconds(autoDestroyTime);
        Destroy(gameObject);

    }
}
