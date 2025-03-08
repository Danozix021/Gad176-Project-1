using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Weapons : MonoBehaviour
{
    protected int maxAmmo;
    protected int ammoCount;

    public float raycastDistance = 100f;
    public Camera MainCamera;
    protected Vector3 screenCenter;

    public TextMeshProUGUI AmmoUI;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        MainCamera = Camera.main;
        if (MainCamera == null)
        {
            Debug.Log("Camera Not Found");
        }
        screenCenter = new Vector3(Screen.width / 2, Screen.height / 2, 0);
    }

    protected void Update()
    {
        AmmoUI.text = ammoCount + " / " + maxAmmo;
    }

    protected virtual void Shoot()
    {
            Debug.Log("SHOOOOTINNGGGGG");
            Ray ray = MainCamera.ScreenPointToRay(screenCenter);
            RaycastHit hit;
            ammoCount--;

        if (Physics.Raycast(ray, out hit, raycastDistance))
            {
                if (hit.collider.CompareTag("Enemy"))
                {
                    Debug.Log("Enemy hit");
                    Enemies enemies = hit.collider.GetComponent<Enemies>();
                    enemies.OnHit();
                    enemies.enemyHealth -= 1;
                    Debug.Log($"{enemies.enemyHealth}");
                    
                    if (enemies.enemyHealth <= 0)
                    {
                        enemies.Die();
                    }
                }
            } 
    }

    protected virtual void Reload()
    {
        if (Input.GetKeyDown(KeyCode.R) && ammoCount < maxAmmo)
        {
            ammoCount = maxAmmo;
        }
    }
}
