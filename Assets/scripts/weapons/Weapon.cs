using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform startPoint;
    private BulletUI bulletUI;
    private FireMeshRenderer fireMesh;
    private DamageEffectZ dmgEffectZ;
    [SerializeField]public LayerMask layerRayCastFire;

    private int bulletAmount;
    private float time;
    private float interval=0.3f;
    public float rayDist = 200;
    public float fireDamage = 3f;
    private void Awake()
    {
        bulletUI = FindObjectOfType<BulletUI>();
        fireMesh = GetComponentInChildren<FireMeshRenderer>();
    }

    private void OnEnable()
    {
        fireMesh.gameObject.SetActive(false);
    }

    private void Start()
    {
        bulletAmount = bulletUI.UpdateBulletAmount();
    }

    void Update()
    {
        if(Input.GetMouseButton(0) && bulletAmount > 0 && time<Time.time)
        {
            time = Time.time + interval;
            fireMesh.TurnOn();
            bulletAmount = bulletUI.UpdateBulletAmount();
            RayCastFire();
        }
        else
        {
            fireMesh.TurnOff(time);
        }
    }

    void RayCastFire()
    {
        RaycastHit2D hit = Physics2D.Raycast(startPoint.position, startPoint.right, rayDist, layerRayCastFire);
        if (hit.collider != null)
        {
            hit.collider.GetComponent<ZombieHP>().TakeDamage(fireDamage);
            Debug.Log("HitEnemy");
        }
    }
}
