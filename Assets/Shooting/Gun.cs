using System;
using System.Diagnostics;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 15f;
    public float impactForce = 30f;


    public ParticleSystem muzzleflash;
    public Transform TargetPoint;


    private float nextTimeToFire = 0f;


    private void Start()
    {
    
    }
    void Update()
    {

        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
           nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }

    }

    void Shoot()
    {
        muzzleflash.Play();

        RaycastHit hit;
        if (Physics.Raycast(TargetPoint.transform.position, TargetPoint.transform.forward, out hit, range))
        {
            UnityEngine.Debug.Log(hit.transform.name);


            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }
            
            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }
            
        }

    }
}
