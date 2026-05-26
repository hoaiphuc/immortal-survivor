using System;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float maxHp = 10f;

    float currentHp;

    public float CurrentHp => currentHp;
    public float MaxHp => maxHp;
    public event Action OnDeath;

    void Awake() => currentHp = maxHp;

    public void TakeDamage(float amount)
    {
        if (currentHp <= 0f) return;
        currentHp -= amount;
        if (currentHp <= 0f) Die();
    }

    void Die()
    {
        OnDeath?.Invoke();
        Destroy(gameObject);
    }

    [ContextMenu("Test: Take 5 Damage")]
    void TestDamage() => TakeDamage(5f);
}
