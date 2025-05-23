using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharHP : MonoBehaviour
{
    private Image HPGreen;
    private Image HPRed;

    private float currentHP = 100;
    private float damageAmount = 0;

    void Awake()
    {
        HPGreen = transform.GetChild(0).GetComponent<Image>();
        HPRed = transform.GetChild(1).GetComponent<Image>();
    }

    void OnEnable()
    {
        currentHP = 100;
        damageAmount = 0;
        HPGreen.fillAmount = currentHP / 100;
        HPRed.fillAmount = damageAmount;
        Time.timeScale = 1;
    }

    void OnDisable()
    {
        Time.timeScale = 0;
    }

    public void TakeDamage(float damage)
    {
        if(0 < currentHP)
        {
            currentHP -= damage;
            damageAmount += damage;
            HPGreen.fillAmount = currentHP / 100;
            HPRed.fillAmount = damageAmount / 100;
        }
        else
        {
            Time.timeScale = 0;
            gameObject.SetActive(false);
        }
    }

    public bool HealHP(float healAmount)
    {
        if (currentHP < 100)
        {
            currentHP += healAmount;
            damageAmount -= healAmount;
            HPGreen.fillAmount = currentHP / 100;
            HPRed.fillAmount = damageAmount / 100;
            return true;
        }
        else return false;
    }
}
