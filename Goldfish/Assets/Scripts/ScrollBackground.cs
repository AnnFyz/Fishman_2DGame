using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBackground : MonoBehaviour
{
    [SerializeField] private float horizontalSpeed = 0.2f;
    [SerializeField] private float verticalSpeed = 0.2f;

    private Renderer re;
    void Start()
    {
        re = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 offset = new Vector2(Time.time * horizontalSpeed, Time.time * verticalSpeed);
        re.material.mainTextureOffset = offset;
    }
}
