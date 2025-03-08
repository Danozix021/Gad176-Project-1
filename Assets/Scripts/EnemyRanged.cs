using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRanged : Enemies
{
    public float stoppingDistance;
    [SerializeField] private GameObject bulletPrefab;
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
                Attack();
                shootTimer = shootCooldown;
            }
        }
    }
    protected void ShootAtPlayer()
    {
        float playerHeadPosition = 1f;
        Vector3 targetPosition = PlayerPosition.position + Vector3.up * playerHeadPosition;

        Vector3 ShootDirection = (targetPosition - transform.position).normalized;

        Quaternion bulletRotation = Quaternion.LookRotation(ShootDirection) * Quaternion.Euler(90f, 0, 0);
        GameObject bullet = Instantiate(bulletPrefab, transform.position, bulletRotation);

        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        Collider bulletCollider = bullet.GetComponent<Collider>();
        bulletCollider.isTrigger = true;

        rb.velocity = ShootDirection * bulletSpeed;
        rb.constraints = RigidbodyConstraints.FreezeRotation;

        Destroy(bullet, 5f);
    }
    protected override void Attack()
    {
        base.Attack();
        ShootAtPlayer();
    }
}
