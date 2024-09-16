using System;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] float range = 15;
    [SerializeField] int damage;
    [SerializeField] GameObject arrowPrefab;

   public Transform target;

    string enemyTag = "Enemy";
    float fireCountdown = 0f;
    float fireRate = 1f;

    private void Start()
    {
        InvokeRepeating("FindClosestTarget", 0f, .5f);
    }
    private void Update()
    {
        if (target == null) {return;}
        FireCountdown();
    }

    void FireCountdown()
    {
        if (fireCountdown <= 0)
        {
            Invoke("ShootArrow", 0);
            fireCountdown = 1f / fireRate;
        }
        fireCountdown -= Time.deltaTime;
    }

    void FindClosestTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float closestDistance = Mathf.Infinity;
        GameObject closestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector2.Distance(transform.position, enemy.transform.position);

            if (distanceToEnemy < closestDistance)
            {
                closestDistance = distanceToEnemy;
                closestEnemy = enemy;
            }
        }

        if (closestEnemy != null && closestDistance <= range)
        {
            target = closestEnemy.transform;
        }
        else {target = null; }
    }

    void ShootArrow()
    {
        GameObject tempArrow = Instantiate (arrowPrefab, transform);
        ArrowShooting shootingScript = tempArrow.GetComponent<ArrowShooting>();
        if (shootingScript != null)
        {
            shootingScript.SeekEnemy(target, damage);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
