using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAnim : MonoBehaviour
{
    private Animator animZ;
    
    void Awake()
    {
        animZ = GetComponent<Animator>();
    }

    public void MoveAnim(float speed)
    {
        animZ.SetFloat("Speed", speed);
    }

    public void AttackAnim(bool isAttacking)
    {
        animZ.SetBool("IsAttack", isAttacking);
    }

    public void DeadAnim(bool isDead)
    {
        animZ.SetBool("IsDead", isDead);
    }
}
