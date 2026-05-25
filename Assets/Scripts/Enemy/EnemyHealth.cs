using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float maxHp = 10f;

    float currentHp;

    public float CurrentHp => currentHp;
    public float MaxHp => maxHp;

    void Awake() => currentHp = maxHp;

    public void TakeDamage(float amount)
    {
        if (currentHp <= 0f) return;
        currentHp -= amount;
        if (currentHp <= 0f) Die();
    }

    void Die()
    {
        Destroy(gameObject);
    }

    [ContextMenu("Test: Take 5 Damage")]
    void TestDamage() => TakeDamage(5f);
}
