using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SentryAttack : MonoBehaviour
{
    public float detectionRadius = 5f;
    public float fireRate = 1f;
    public GameObject bulletPrefab;
    public Transform firePoint;

    private float fireCooldown = 0f;

    private void Update()
    {
        Collider2D[] enemiesInRange = Physics2D.OverlapCircleAll(transform.position, detectionRadius);
        Collider2D closestEnemy = FindClosestEnemy(enemiesInRange);

        if(closestEnemy != null)
        {
            AimAtEnemy(closestEnemy.transform);

            if(fireCooldown <= 0f)
            {
                FireAtEnemy(closestEnemy.transform);
                fireCooldown = 1f / fireRate;
            }
        }

        fireCooldown -= Time.deltaTime;
    }

    Collider2D FindClosestEnemy(Collider2D[] enemies)
    {
        Collider2D closestEnemy = null;
        float minDistance = Mathf.Infinity;

        foreach(Collider2D enemy in enemies)
        {
            float distance = Vector2.Distance(transform.position, enemy.transform.position);
            if(distance < minDistance && enemy.CompareTag("Enemy"))
            {
                minDistance = distance;
                closestEnemy = enemy;
            }
        }
        return closestEnemy;
    }

    void AimAtEnemy(Transform enemy)
    {
        Vector2 direction = enemy.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    void FireAtEnemy(Transform enemy)
    {
        Vector2 direction = (enemy.position - firePoint.position).normalized;
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet.GetComponent<Rigidbody2D>().velocity = direction * 10f;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
