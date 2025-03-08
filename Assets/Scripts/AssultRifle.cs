using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssaultRifle : Weapons
{
    private float timeToFire = 0;
    public float fireRate;

    // Start is called before the first frame update
    new void Start()
    {
        fireRate = 0.12f;
        maxAmmo = 25;
        ammoCount = maxAmmo;
        base.Start();
    }

    // Update is called once per frame
    new void Update()
        {
            if (Input.GetKey(KeyCode.Mouse0) && Time.time >= timeToFire && ammoCount > 0)
            {
                timeToFire = Time.time + fireRate;
                Shoot();
            }

            Reload();
            
            base.Update(); 
        }
}
