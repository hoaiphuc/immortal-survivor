using UnityEngine;

public class PlayerAutoShoot : MonoBehaviour
{
    [Header("Projectile")]
    [SerializeField] private GameObject swordPrefab;

    [Header("Settings")]
    [SerializeField] private float detectionRadius = 6f;
    [SerializeField] private float fireRate = 1f;
    [SerializeField] private float damage = 5f;
    [SerializeField] private float projectileSpeed = 8f;
    [SerializeField] private LayerMask enemyLayer;

    private float _nextFireTime;

    private void Update()
    {
        if (Time.time < _nextFireTime) return;

        Transform nearest = FindNearestEnemy();
        if (nearest == null) return;

        _nextFireTime = Time.time + 1f / fireRate;
        FireAt(nearest);
    }

    private Transform FindNearestEnemy()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, detectionRadius, enemyLayer);
        if (hits.Length == 0) return null;

        Transform nearest = null;
        float minDist = float.MaxValue;
        foreach (Collider2D hit in hits)
        {
            float dist = Vector2.SqrMagnitude((Vector2)hit.transform.position - (Vector2)transform.position);
            if (dist < minDist)
            {
                minDist = dist;
                nearest = hit.transform;
            }
        }
        return nearest;
    }

    private void FireAt(Transform target)
    {
        Vector2 dir = ((Vector2)target.position - (Vector2)transform.position).normalized;
        GameObject proj = Instantiate(swordPrefab, transform.position, Quaternion.identity);
        SwordProjectile sword = proj.GetComponent<SwordProjectile>();
        if (sword == null)
        {
            Debug.LogError("SwordProjectile prefab thiếu script SwordProjectile!", swordPrefab);
            Destroy(proj);
            return;
        }
        sword.Init(dir, projectileSpeed, damage);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
