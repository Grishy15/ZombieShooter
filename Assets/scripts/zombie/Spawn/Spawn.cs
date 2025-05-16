using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject prefabZ;
    private List <Transform> points = new List <Transform>();
    private List <ZombieHP> enemies = new List <ZombieHP>();
    private Vector3 pos;
    private Quaternion rotate;
    private int index = 0;
    public int zCount = 6;

    void Awake()
    {
        points.AddRange(GetComponentsInChildren<Transform>());
    }
    void Start()
    {
        SetRandomPoints();
        Spawning();
    }
    public void Spawning()
    {
        for (int i = 0; i < zCount; i++)
        {
            GameObject newZ = Instantiate(prefabZ, pos, rotate);
            SetRandomPoints();
            ZombieHP newZombie = newZ.GetComponent<ZombieHP>();
            enemies.Add(newZombie);
        }
    }
    void SetRandomPoints()
    {
        index = Random.Range(0, points.Count);
        pos = points[index].position;
        rotate = points[index].rotation;
    }

    void RespawnEnemy()
    {
        foreach(ZombieHP enemy in enemies)
        {
            if(enemy.isDead)
            {
                enemy.ResetZombie();
                SetRandomPoints();
                enemy.transform.position = pos;
            }
        }
    }

    public IEnumerator WaitTimeForRespawn()
    {
        yield return new WaitForSeconds(Random.Range(3f,5f));
        RespawnEnemy();
    }
}
