using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHealthBar : MonoBehaviour
{
    float maxSize = 1.0f;
    public Scrollbar scrollbar;
    void Start()
    {
        scrollbar = GetComponent<Scrollbar>();
        scrollbar.size = maxSize;
    }

   
}
