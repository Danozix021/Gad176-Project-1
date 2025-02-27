using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{
    public float raycastDistance = 100f;
    public Camera MainCamera;
    protected Vector3 screenCenter;

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

    // Update is called once per frame
    void Update()
    {
        
    }

    protected virtual void Shoot()
    {
            Debug.Log("SHOOOOTINNGGGGG");
            Ray ray = MainCamera.ScreenPointToRay(screenCenter);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, raycastDistance) )
            {
                if (hit.collider.CompareTag("Enemy"))
                {
                    Debug.Log("Enemy hit");
                    Enemies enemies = hit.collider.GetComponent<Enemies>();
                    enemies.OnHit();
                    enemies.EnemyHealth -= 1;
                    Debug.Log($"{enemies.EnemyHealth}");
                    
                    if (enemies.EnemyHealth <= 0)
                    {
                    enemies.Die();
                    }
                }
            } 
    }
}
