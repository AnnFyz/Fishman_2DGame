using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundaries : MonoBehaviour
{
    float offsetX;
    float offsetY;
    void Start()
    {
        offsetX = transform.localScale.x / 2;
        offsetY = transform.localScale.y / 2;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, (GameHandler.screenBounds.x * -1 + offsetX) , GameHandler.screenBounds.x - offsetX);
        viewPos.y = Mathf.Clamp(viewPos.y, (GameHandler.screenBounds.y* -1 + offsetY), GameHandler.screenBounds.y - offsetY);
        transform.position = viewPos;
    }
}
