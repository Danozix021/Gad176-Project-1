using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int health;

    public GameObject pistol;
    public GameObject assaultRifle;
    
    
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        pistol.SetActive(true);
        assaultRifle.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            pistol.SetActive(true);
            assaultRifle.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            pistol.SetActive(false);
            assaultRifle.SetActive(true);
        }
    }
}
