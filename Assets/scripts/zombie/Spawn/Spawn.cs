using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject prefabZ;
    private List <Transform> Points = new List <Transform>();
    private Vector3 pos;
    private Quaternion rotate;
    private int index = 0;
    public int zCount = 6;

    void Awake()
    {
        Points.AddRange(GetComponentsInChildren<Transform>());
    }
    void Start()
    {
        SetPoints();
    }
    public void Spawning()
    {
        GameObject newZ = Instantiate(prefabZ, pos, rotate);
    }
    void SetPoints()
    {
        for(int i = 0; i < zCount; i ++)
        {
            index = Random.Range(0,Points.Count);
            pos = Points[index].position;
            rotate = Points[index].rotation;
            Spawning();
        }
    }
}
