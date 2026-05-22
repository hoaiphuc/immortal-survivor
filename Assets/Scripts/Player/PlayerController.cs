using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;

    Rigidbody2D rb;
    Animator animator;
    SpriteRenderer spriteRenderer;
    InputAction moveAction;
    Vector2 moveInput;

    static readonly int SpeedHash = Animator.StringToHash("Speed");

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        moveAction = InputSystem.actions.FindAction("Move");
    }

    void Update()
    {
        moveInput = Vector2.ClampMagnitude(moveAction.ReadValue<Vector2>(), 1f);

        if (animator != null)
            animator.SetFloat(SpeedHash, moveInput.sqrMagnitude);

        if (spriteRenderer != null && Mathf.Abs(moveInput.x) > 0.01f)
            spriteRenderer.flipX = moveInput.x < 0f;
    }

    void FixedUpdate()
    {
        rb.linearVelocity = moveInput * moveSpeed;
    }
}
