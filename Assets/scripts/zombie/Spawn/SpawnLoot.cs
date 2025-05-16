using UnityEngine;

public class SpawnLoot : MonoBehaviour
{
    public GameObject medkit, bulletBox;
    private Vector3 pos;
    private Quaternion rotate;
    public void Spawning()
    {
        GameObject newMedkit = Instantiate(medkit, pos, rotate);
        GameObject newBulletBox = Instantiate(bulletBox, pos, rotate);
    }
    public void SpawnNewLoot(Vector3 position, Quaternion rotation)
    {
        pos = position;
        rotate = rotation;
        Spawning();
    }
}
