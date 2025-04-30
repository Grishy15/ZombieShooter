using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChar : MonoBehaviour
{
    private Transform camTrans;
    public Transform charTrans;
    public float speedFollow = 10;
   
    void Awake()
    {
        camTrans = GetComponent<Transform>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        MovingCamera();
    }
    void MovingCamera()
    {
        camTrans.position = Vector3.MoveTowards(camTrans.position,charTrans.position, speedFollow * Time.deltaTime);
        float x = camTrans.position.x;
        float y = camTrans.position.y;
        float z = -10;
        camTrans.position = new Vector3(x, y, z);
    }
}
