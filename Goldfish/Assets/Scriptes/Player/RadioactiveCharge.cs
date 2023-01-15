using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RadioactiveCharge : MonoBehaviour
{
    public float maxHealth = 5;
    public int radChar { get { return currentRadChar; } }
    int currentRadChar = 0;
    public float health { get { return currentHealth; } }
    int currentHealth;
    UIHealthBar healthBarScript;
    UIProgressBar progressBarScript;

    void Start()
    {
        healthBarScript = FindObjectOfType<UIHealthBar>();
        progressBarScript = FindObjectOfType<UIProgressBar>();
        currentRadChar = 0;
        currentHealth = 5;
    }
    public void ChangeRadChar()
    {
        if (progressBarScript.progressScrollbar.size <= 1f)
        {
            progressBarScript.progressScrollbar.size += 0.1f;
        }
    }

    public void ChangeHealth(int amount)
    {
       currentHealth += amount;
       healthBarScript.scrollbar.size = currentHealth / maxHealth;
    }
}
