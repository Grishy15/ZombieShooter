using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZombieHP : MonoBehaviour
{
    private Image HPImage;
    private float currentHP = 100;
    private ZombieAnim anim;
    private ZombieMove zMove;

    void Awake()
    {
        HPImage = GetComponentInChildren<Image>();
        anim = GetComponent<ZombieAnim>();
        zMove = GetComponent<ZombieMove>();
    }

    void OnEnable()
    {
        currentHP = 100;
        HPImage.fillAmount = currentHP / 100;
        zMove.IsInactiveZombie(false);
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
            anim.DeadAnim();
            zMove.IsInactiveZombie(true);
        }
    }
}
