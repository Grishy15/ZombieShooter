using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAttack : MonoBehaviour
{
    private CharHP charHP;
    public float damage = 15;
    private float nextTimer = 0;
    private float intervalTimer = 1;

    void Awake()
    {
        charHP = FindObjectOfType<CharHP>();
    }

    void OnCollisionStay2D(Collision2D coll)
    {
        if(coll.gameObject.tag == "Player")
        {
            Debug.Log("CollisionState");
            if(Time.time > nextTimer)
            {
                Debug.Log("DamageTaken");
                charHP.TakeDamage(damage);
                nextTimer = Time.time + intervalTimer;
            }
        }
    }
}
