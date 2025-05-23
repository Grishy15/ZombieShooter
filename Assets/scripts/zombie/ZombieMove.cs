using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMove : MonoBehaviour
{
    private ZombieAnim zombieAnim;

    private Transform trChar;
    private Transform trZ;
    private Rigidbody2D rbZ;
    private Collider2D rbColl;
    public LayerMask rayLayMask;     
    public Transform pointRay;
    
    public float speed = 5;
    public float moveUp = 15;
    public float damage = 10;
    private float moveInput;
    private float distance;
    public float minDist = 12;
    public float minDistAttack = 2.5f;
    public float timer = 4;
    public float rayDist = 2;
    
    public bool isFollow = false;

    void Awake()
    {
        trZ = GetComponent<Transform>();
        rbZ = GetComponent<Rigidbody2D>();
        trChar = FindObjectOfType<MoveChar>().transform;
        zombieAnim = GetComponent<ZombieAnim>();
        rbColl = GetComponent<Collider2D>();
    }
    
    void FixedUpdate()
    {
        Turning();
        if (CheckDistance(minDist))
        {
            Follow();
            isFollow = true;
        }
        else
        {
            isFollow = false;
        }

        RandomMove();
        RayCastObstacle();
    }
    
    private void Update()
    {
        Attack();
    }

    void Turning()
    {
        transform.localScale = new Vector3(Mathf.Sign(moveInput), 1, 1);
    }

    void Attack()
    {
        if(CheckDistance(minDistAttack))
        {
            zombieAnim.AttackAnim(true);
        }
        else zombieAnim.AttackAnim(false);
    }

    void Follow()
    {
        Vector2 direction = trChar.position - trZ.position;
        moveInput = direction.x > 0 ? 1 : -1;
        if (isFollow)
            Move();
    }

    void Move()
    {
        float x = moveInput * speed;
        float y = rbZ.velocity.y;
        rbZ.velocity = new Vector2(x, y);
    }

    bool CheckDistance(float minDistance)
    {
        distance = Vector2.Distance(trZ.position,trChar.position);
        if(distance <= minDistance) return true; 
        else return false;
    }
    
    void RandomMove()
    {
        timer -= Time.deltaTime;
        if (timer <= 0 && !isFollow)
        {
            moveInput = Mathf.Sign(Random.Range(-1, 1));
            timer = Random.Range(3, 7);
        }
        Move();
    }
    
    public void IsInactiveZombie(bool isActive)
    {
        if(isActive)
        {
            rbZ.isKinematic = false;
            rbColl.enabled = true;
            enabled = true;
        }
        else
        {
            rbZ.isKinematic = true;
            rbColl.enabled = false;
            enabled = false;
        }
    }

    private void RayCastObstacle()
    {
        RaycastHit2D hit = Physics2D.Raycast(pointRay.position, trZ.right, rayDist, rayLayMask); 
        if(hit.collider != null)
        {
            trZ.Translate(Vector3.up * moveUp * Time.deltaTime);
        }
    }
}
