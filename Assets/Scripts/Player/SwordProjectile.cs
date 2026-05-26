using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class SwordProjectile : MonoBehaviour
{
    [SerializeField] private float maxRange = 10f;

    private Vector2 _startPos;
    private float _damage;
    private Rigidbody2D _rb;

    public void Init(Vector2 direction, float speed, float damage)
    {
        _damage = damage;
        _rb = GetComponent<Rigidbody2D>();
        _startPos = transform.position;

        // Xoay sprite theo hướng bay
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle + 90f);

        _rb.linearVelocity = direction * speed;
    }

    private void Update()
    {
        if (Vector2.SqrMagnitude((Vector2)transform.position - _startPos) >= maxRange * maxRange)
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        EnemyHealth enemy = other.GetComponent<EnemyHealth>();
        if (enemy == null) return;

        enemy.TakeDamage(_damage);
        Destroy(gameObject);
    }
}
