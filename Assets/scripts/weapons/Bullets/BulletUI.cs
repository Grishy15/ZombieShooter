using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BulletUI : MonoBehaviour
{
    public TextMeshProUGUI textBulletAmount;
    public int bulletAmount = 31;
    void Start()
    {
        textBulletAmount.text = bulletAmount.ToString();
    }
    public int UpdateBulletAmount()
    {
        if (bulletAmount > 0)
        {
            bulletAmount -= 1;
        }
        textBulletAmount.text = bulletAmount.ToString();
        return bulletAmount;
    }

    public bool ResetBulletsAmount()
    {
        if (bulletAmount < 30)
        {
            bulletAmount = 30;
            textBulletAmount.text = bulletAmount.ToString();
            return true;
        }
        else return false;
    }
}
