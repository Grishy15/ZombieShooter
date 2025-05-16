using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZombieHP : MonoBehaviour
{
    private Image HPImage;
    private Transform transZ;

    private ZombieAnim anim;
    private ZombieMove zMove;
    private SpawnLoot spawnLoot;
    private Spawn spawn;
    private KillCount killCount;

    public bool isDead;
    public bool isActive;

    private float currentHP = 100;

    void Awake()
    {
        transZ = GetComponentInParent<Transform>();
        HPImage = GetComponentInChildren<Image>();
        anim = GetComponent<ZombieAnim>();
        zMove = GetComponent<ZombieMove>();
        spawnLoot = FindObjectOfType<SpawnLoot>();
        spawn = FindObjectOfType<Spawn>();
        killCount = FindObjectOfType<KillCount>();
    }

    void OnEnable()
    {
        ResetZombie();
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
            zMove.IsInactiveZombie(false);
            spawnLoot.SpawnNewLoot(transZ.position, transZ.rotation);
            DeadActive();
        }
    }
    public void ResetZombie() //Call from script Respawn()
    {
        isDead = false;
        anim.DeadAnim(isDead);
        currentHP = 100;
        HPImage.fillAmount = currentHP / 100;
        zMove.IsInactiveZombie(true);
    }

    private void DeadActive()
    {
        isDead = true;
        anim.DeadAnim(isDead);
        killCount.SetCountKill(1);
        StartCoroutine(spawn.WaitTimeForRespawn());
    }        
}
