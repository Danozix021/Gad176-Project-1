using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    public Transform PlayerPosition;
    public float EnemyMoveSpeed;
    public EnemyManager manager;

    public int enemyHealth;

    protected GameObject player;
    public GameObject bulletPrefab;

    public float bulletSpeed = 10f;
    public float shootCooldown = 2f;
    protected float shootTimer;

    public float hitDuration;
    public Color hitColor = Color.red;

    private Color originalColor;
    private Renderer enemyRenderer;
    private Coroutine hitCoroutine;

    protected virtual void Start()
    {
        hitDuration = 0.1f;
        EnemyMoveSpeed = 3f;

        enemyRenderer = GetComponent<Renderer>();
        originalColor = enemyRenderer.material.color;

        manager = FindObjectOfType<EnemyManager>();

        player = GameObject.FindGameObjectWithTag("Player");
        if (player == null)
        {
            Debug.Log("NO PLAYER FOUND!!!");
            return;
        }
        PlayerPosition = player.transform;

        manager.AddEnemyToList(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    protected virtual void MoveTowardsPlayer()
    {
        if (PlayerPosition == null)
        {
            Debug.Log("Player position is NULL in an ENEMY");
            return;
        }

        //Debug.Log("Enemy Moving Towards Player" + transform.position);
        Vector3 direction = (PlayerPosition.position - transform.position).normalized;

        Vector3 lookDirection = PlayerPosition.position - transform.position;
        lookDirection.y = 0f;
        Quaternion targetRotaion = Quaternion.LookRotation(lookDirection);
        float rotationSpeed = 5f;
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotaion, rotationSpeed * Time.deltaTime);

        transform.position += EnemyMoveSpeed * Time.deltaTime * direction;
    }

    public virtual void Die()
    {
        manager.RemoveEnemyFromList(this);
        Destroy(gameObject);
    }

    public virtual void OnHit()
    {
        Debug.Log("hitDuration is " + hitDuration);
        if (hitCoroutine != null)
        {
            StopCoroutine(hitCoroutine);
            hitCoroutine = null;  
        }
        hitCoroutine = StartCoroutine(FlashHitColor());
    }

    private IEnumerator FlashHitColor()
    {
        enemyRenderer.material.color = hitColor;
        yield return new WaitForSeconds(hitDuration);
        if (enemyRenderer != null)
        {
            enemyRenderer.material.color = originalColor;
        }
    }

    protected virtual void ShootAtPlayer()
    {
        float playerHeadPosition = 1f;
        Vector3 targetPosition = PlayerPosition.position + Vector3.up * playerHeadPosition;

        Vector3 ShootDirection = (targetPosition - transform.position).normalized;

        Quaternion bulletRotation = Quaternion.LookRotation(ShootDirection) * Quaternion.Euler(90f,0,0);
        GameObject bullet = Instantiate(bulletPrefab, transform.position, bulletRotation);

        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        Collider bulletCollider = bullet.GetComponent<Collider>();
        bulletCollider.isTrigger = true;

        rb.velocity = ShootDirection * bulletSpeed;
        rb.constraints = RigidbodyConstraints.FreezeRotation;

        Destroy(bullet, 5f);
    }
}
