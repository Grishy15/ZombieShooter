using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform startPoint;
    private BulletUI bulletUI;
    private int bulletAmount;

    private void Awake()
    {
        bulletUI = FindObjectOfType<BulletUI>();
    }

    private void Start()
    {
        bulletAmount = bulletUI.UpdateBulletAmount();
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0) && bulletAmount > 0)
        {
            GameObject newBullet = Instantiate(bulletPrefab, startPoint.position, startPoint.rotation);
            newBullet.transform.right = startPoint.right;
            bulletAmount = bulletUI.UpdateBulletAmount();
        }
    }
}
