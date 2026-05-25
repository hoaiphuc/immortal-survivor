using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 2f;
    [SerializeField] string playerTag = "Player";

    Rigidbody2D rb;
    Animator animator;
    SpriteRenderer spriteRenderer;
    Transform target;

    static readonly int SpeedHash = Animator.StringToHash("Speed");

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        GameObject player = GameObject.FindWithTag(playerTag);
        if (player != null) target = player.transform;
    }

    void Update()
    {
        if (target == null) return;

        if (animator != null)
            animator.SetFloat(SpeedHash, 1f);

        if (spriteRenderer != null)
        {
            float dx = target.position.x - transform.position.x;
            if (Mathf.Abs(dx) > 0.01f) spriteRenderer.flipX = dx < 0f;
        }
    }

    void FixedUpdate()
    {
        if (target == null)
        {
            rb.linearVelocity = Vector2.zero;
            return;
        }

        Vector2 dir = ((Vector2)target.position - rb.position).normalized;
        rb.linearVelocity = dir * moveSpeed;
    }

    public void SetTarget(Transform t) => target = t;
}
