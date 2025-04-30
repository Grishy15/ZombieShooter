using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public float speedRotate = 0.2f;
    public float speedFollow = 40;
    private Renderer render;
    private Transform trBG;
    private Transform trChar;

    void Awake()
    {
        render = GetComponent<Renderer>();
        trBG = GetComponent<Transform>();
        trChar = FindObjectOfType<MoveChar>().transform;
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        Vector3 axis = new Vector3(x, 0, 0);
        FollowBG();
        MoveBG(axis);
    }

    void MoveBG(Vector3 axis)
    {
        if(axis.sqrMagnitude > 0.2f)
        {
            float moveX = axis.x * speedRotate * Time.deltaTime;
            render.material.mainTextureOffset += new Vector2(moveX, 0);
        }
    }

    void FollowBG()
    {
        trBG.position = Vector2.Lerp(trBG.position, trChar.position, Time.deltaTime * speedFollow);
    }
}
