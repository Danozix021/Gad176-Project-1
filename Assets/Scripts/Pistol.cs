using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Weapons
{
    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
        maxAmmo = 7;
        ammoCount = maxAmmo;
        Debug.Log(ammoCount + "ammo");
    }

    // Update is called once per frame
    new void Update()
        {   
            if (Input.GetKeyDown(KeyCode.Mouse0) && ammoCount > 0)
            {
                Shoot();
            }

            Reload();
            base.Update();
        }
}
