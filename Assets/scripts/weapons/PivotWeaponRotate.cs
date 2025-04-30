using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PivotWeaponRotate : MonoBehaviour
{
    private Transform wTrans;
    public Camera mainCam;
    private Quaternion tarRotate;
    private float angleRotate = 5;

    void Awake()
    {
        wTrans = GetComponent<Transform>();
    }

    public void RotateWeapon(float horizontal)
    {
        Vector3 mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        float angle = Mathf.Atan2(mousePos.y - wTrans.position.y, mousePos.x - wTrans.position.x) * Mathf.Rad2Deg;
        angle += horizontal > 0? angle: (horizontal < 0? -angle : angle);
        tarRotate = Quaternion.Euler(0,0,angle);
        wTrans.rotation = Quaternion.Slerp(wTrans.rotation, tarRotate, angleRotate * Time.deltaTime);
    }
}
