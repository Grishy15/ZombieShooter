using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBox : MonoBehaviour
{
    private BulletUI bulletUI;

    private void Awake()
    {
        bulletUI = FindObjectOfType<BulletUI>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            bool canPickUp = bulletUI.ResetBulletsAmount();
            if(canPickUp == true)
            {
                gameObject.SetActive(false);
            }
        }
    }
}
