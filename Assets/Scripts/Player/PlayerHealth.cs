using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float maxHp = 100f;
    [SerializeField] float invulnTime = 0.5f;

    float currentHp;
    float invulnUntil;

    public float CurrentHp => currentHp;
    public float MaxHp => maxHp;
    public bool IsAlive => currentHp > 0f;
    public event Action OnDeath;

    void Awake() => currentHp = maxHp;

    public void TakeDamage(float amount)
    {
        if (!IsAlive || Time.time < invulnUntil) return;

        currentHp -= amount;
        invulnUntil = Time.time + invulnTime;
        Debug.Log($"Player HP: {currentHp:F0}/{maxHp:F0}");

        if (currentHp <= 0f) Die();
    }

    void Die()
    {
        OnDeath?.Invoke();
    }

    [ContextMenu("Test: Take 10 Damage")]
    void TestDamage() => TakeDamage(10f);
}
