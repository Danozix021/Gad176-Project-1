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
        fireRate = 0.3f;
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0) && Time.time >= timeToFire)
        {
            timeToFire = Time.time + fireRate;
            Shoot();
        }
    }
}
