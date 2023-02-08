using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class fire : MonoBehaviour
{
    public GameObject bullet;
    public float fireRate;
    public float fireTime;
    Transform firePoint;


    // Start is called before the first frame update
    void Start()
    { 
        firePoint = transform.GetChild(1);
        InvokeRepeating("Fire", fireTime, fireRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Fire()
    {
        Instantiate(bullet, firePoint.position,firePoint.rotation);
    }
}
