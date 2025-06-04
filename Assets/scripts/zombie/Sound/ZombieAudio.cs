using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAudio : MonoBehaviour
{
    [SerializeField]private AudioSource idleSound;
    [SerializeField]private AudioSource deadSound;
    [SerializeField]private AudioSource damageSound;

    private ZombieHP zHP;

    private void Awake()
    {
        zHP = GetComponentInParent<ZombieHP>();
    }
    private void OnEnable()
    {
        zHP.OnIdleSound += IdleSound;
        zHP.OnDeadSound += DeadSound;
        zHP.OnDamagedSound += DamageSound;
        IdleSound();
    }

    private void OnDisable()
    {
        zHP.OnIdleSound -= IdleSound;
        zHP.OnDeadSound -= DeadSound;
        zHP.OnDamagedSound -= DamageSound;
        DeadSound();
    }
    private void IdleSound()
    {
        idleSound.Play();
    }
    private void DeadSound()
    {
        idleSound.Stop();
        deadSound.Play();
    }

    private void DamageSound()
    {
        damageSound.Play();
    }
}
