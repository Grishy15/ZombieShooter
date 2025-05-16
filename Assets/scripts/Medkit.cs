using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medkit : MonoBehaviour
{
    private Transform trMed;
    private CharHP charHP;

    public float healAmount = 50;
    
    void Start()
    {
        trMed = GetComponent<Transform>();
        charHP = FindObjectOfType<CharHP>();
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            bool isHeal = charHP.HealHP(healAmount);
            gameObject.SetActive(!isHeal);
        }
    }
}
