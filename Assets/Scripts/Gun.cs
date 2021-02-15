using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject firePoint;
    public GameObject bulletVfx;
    public float fireRate;

    private int count = 0;
    private float timeToFire = 0f;
    void Start()
    {
    }

    void Update()
    {
        if (Time.time >= timeToFire)
        {
            timeToFire = Time.time + 1f / fireRate;
            SpawnVFX();
        }
    }

    public void SpawnVFX()
    {
        GameObject bullet;

        if (firePoint != null)
        {
            bullet = Instantiate(bulletVfx, firePoint.transform.position, Quaternion.identity);
            bullet.transform.localRotation = firePoint.transform.rotation;
        }
        else
            bullet = Instantiate(bulletVfx);

        bullet.transform.parent = gameObject.transform;
        // var ps = bullet.GetComponent<ParticleSystem>();

        // if (bullet.transform.childCount > 0)
        // {
        //     ps = bullet.transform.GetChild(0).GetComponent<ParticleSystem>();
        // }
    }
}