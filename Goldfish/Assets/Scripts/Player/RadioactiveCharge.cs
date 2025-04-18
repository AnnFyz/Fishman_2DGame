using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RadioactiveCharge : MonoBehaviour
{
    public int maxHealth = 5;
    [SerializeField] GameObject damageParticles;
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
        damageParticles.SetActive(false);
    }
    public void ChangeRadChar()
    {
        radiationBar.fillAmount += .1f;

        if (radiationBar.fillAmount >= 1f)
        {
            radiationBar.fillAmount = 1f;
            GameHandler.GetInstance().LoadNextScene();
        }
    }

    public void ChangeHealth(int amount)
    {
        currentHealth += amount;
        if(currentHealth > 0)
        {
            healthBar.fillAmount = (float)currentHealth / (float)maxHealth;
            StartCoroutine(StartDamageEffect());
        }
        else
        {
            currentHealth = 0;
            GameHandler.GetInstance().LoadBadEnding();
        }

     
    }

    IEnumerator StartDamageEffect()
    {
        damageParticles.SetActive(true);
        SoundManager.Instance.PlaySound("DamageReceiving");
        yield return new WaitForSeconds(1.5f);
        damageParticles.SetActive(false);
    }
}
