using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRanged : Enemies
{
    public float stoppingDistance;
    // Start is called before the first frame update
    new void Start()
    {
        stoppingDistance = 10f;
        enemyHealth = 5;
        base.Start();
        shootTimer = shootCooldown;
    }

    // Update is called once per frame
    void Update()
    {
        shootTimer -= Time.deltaTime;
        if (Vector3.Distance(transform.position, player.transform.position) > stoppingDistance)
        {
            MoveTowardsPlayer();
        }
        else
        {
            if (shootTimer <= 0)
            {
                ShootAtPlayer();
                shootTimer = shootCooldown;
            }
        }
    }
}
