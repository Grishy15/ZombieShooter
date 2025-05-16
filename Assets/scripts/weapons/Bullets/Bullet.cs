using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform bulletTrans;
    public float speed = 15;
    public float time = 5;
    public float damage = 8;
    void Awake()
    {
        bulletTrans = GetComponent<Transform>();
    }
    void Update()
    {
        bulletTrans.position += bulletTrans.right * Time.deltaTime * speed;
        time -= Time.deltaTime;

        if(time <= 0) Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.tag == "Enemy") 
        {
            coll.gameObject.GetComponent<ZombieHP>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
