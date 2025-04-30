using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharHP : MonoBehaviour
{
    private Image HPImage;
    private float currentHP = 100;

    void Awake()
    {
        HPImage = GetComponentInChildren<Image>();
    }

    void OnEnable()
    {
        currentHP = 100;
        HPImage.fillAmount = currentHP / 100;
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
            HPImage.fillAmount = currentHP / 100;
        }
        else
        {
            Time.timeScale = 0;
            gameObject.SetActive(false);
        }
    }
}
