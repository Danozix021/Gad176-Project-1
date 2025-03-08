using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    [SerializeField]private int health;

    public GameObject pistol;
    public GameObject assaultRifle;

    public TextMeshProUGUI HealthUI;
    
    
    // Start is called before the first frame update
    void Start()
    {
        health = 10;
        Cursor.lockState = CursorLockMode.Locked;
        pistol.SetActive(true);
        assaultRifle.SetActive(false);
        HealthUI.text = "Health: " + health;
    }

    // Update is called once per frame
    void Update()
    {
        HealthUI.text = "Health: " + health;
        if (Input.GetKeyDown(KeyCode.Alpha1)) // clicking 1 goes to pistol
        {
            pistol.SetActive(true);
            assaultRifle.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2)) // clicking 2 goes to AR
        {
            pistol.SetActive(false);
            assaultRifle.SetActive(true);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (health > 0)
            {
                health--;
            }

            if (health <= 0)
            {
                health = 0;
                Debug.Log("You Died");
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {
            health--;

        }
        if (health <= 0)
        {
            health = 0;
            Debug.Log("You Died");
        }
    }
}
