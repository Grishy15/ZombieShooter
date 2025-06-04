using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireMeshRenderer : MonoBehaviour
{
    private float time;
    public List<Material> materials = new ();
    private MeshRenderer mesh;
    private void Awake()
    {
        mesh = GetComponent<MeshRenderer>();

    }
    private void OnEnable()
    {
        mesh.sharedMaterial = materials[Random.Range(0, materials.Count)];
    }
    public void TurnOff(float currentTime)
    {
        if(time < Time.time)
        {
            time = currentTime + 0.1f;
            gameObject.SetActive(false);
        }
    }
    public void TurnOn()
    {
        gameObject.SetActive(true);
    }
}
