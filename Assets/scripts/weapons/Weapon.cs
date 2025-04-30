using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform startPoint;

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            GameObject newBullet = Instantiate(bulletPrefab, startPoint.position, startPoint.rotation);
            newBullet.transform.right = startPoint.right;
        }
    }
}
