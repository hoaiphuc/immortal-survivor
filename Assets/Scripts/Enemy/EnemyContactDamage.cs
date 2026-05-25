using UnityEngine;

public class EnemyContactDamage : MonoBehaviour
{
    [SerializeField] float damage = 10f;

    void OnCollisionStay2D(Collision2D collision)
    {
        PlayerHealth hp = collision.collider.GetComponent<PlayerHealth>();
        if (hp != null) hp.TakeDamage(damage);
    }
}
