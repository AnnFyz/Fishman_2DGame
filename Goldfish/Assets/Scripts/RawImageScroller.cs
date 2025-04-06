using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RawImageScroller : MonoBehaviour
{
    RawImage _image;
    [SerializeField] float _x, _y;

    private void Awake()
    {
        _image = GetComponent<RawImage>();
    }
    void Update()
    {
        _image.uvRect = new Rect(_image.uvRect.position + (new Vector2(_x, _y) * Time.deltaTime), _image.uvRect.size);
    }
}
