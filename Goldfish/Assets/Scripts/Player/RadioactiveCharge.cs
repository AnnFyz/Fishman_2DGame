using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RadioactiveCharge : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] Image healthBar;
    [SerializeField] Image radiationBar;
    [Header("Health")]
    [SerializeField] int maxHealth = 5;
    [Header("Damage Effect")]
    [SerializeField] GameObject damageParticles;
    int _currentRadChar = 0;
    int _currentHealth;

    void Start()
    {
        _currentRadChar = 0;
        _currentHealth = maxHealth;
        damageParticles.SetActive(false);
    }
    public void ChangeRadChar()
    {
        radiationBar.fillAmount += .1f;

        if (radiationBar.fillAmount >= 1f)
        {
            radiationBar.fillAmount = 1f;
            if(SceneManager.GetActiveScene().buildIndex == 3)
            {
                GameHandler.GetInstance().LoadGoodEnding();
            }
            else
            {
                GameHandler.GetInstance().LoadNextScene();
            }
        }
    }

    public void ChangeHealth(int amount)
    {
        _currentHealth += amount;
        if(_currentHealth > 0)
        {
            healthBar.fillAmount = (float)_currentHealth / (float)maxHealth;
            StartCoroutine(StartDamageEffect());
        }
        else
        {
            _currentHealth = 0;
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
