using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIProgressBar : MonoBehaviour
{
    float startSize = 0.0f;
    public Scrollbar progressScrollbar;
    void Start()
    {
        progressScrollbar = GetComponent<Scrollbar>();
        progressScrollbar.size = startSize;
    }

   
}
