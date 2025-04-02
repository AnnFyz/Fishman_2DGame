using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RadioactiveCharge : MonoBehaviour
{
    public int maxHealth = 5;
    public int RadChar { get { return currentRadChar; } }
    int currentRadChar = 0;
    public float Health { get { return currentHealth; } }
    [SerializeField] int currentHealth;
    [SerializeField] Image healthBar;
    [SerializeField] Image radiationBar;

    void Start()
    {
        currentRadChar = 0;
        currentHealth = maxHealth;
    }
    public void ChangeRadChar()
    {
        if (radiationBar.fillAmount <= 1f)
        {
            radiationBar.fillAmount += 0.1f;
        }

    }

    public void ChangeHealth(int amount)
    {
       currentHealth += amount;
       healthBar.fillAmount = (float)currentHealth / (float)maxHealth;
    }
}
