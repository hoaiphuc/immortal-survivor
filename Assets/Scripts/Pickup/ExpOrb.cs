using UnityEngine;

public class ExpOrb : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 6f;
    private int expAmount;

    private Transform _player;
    private PlayerExp _playerExp;
    private bool _attracting;

    public void SetExp(int amount) => expAmount = amount;

    private void Start()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj == null) return;
        _player = playerObj.transform;
        _playerExp = playerObj.GetComponent<PlayerExp>();
    }

    private void Update()
    {
        if (_player == null) return;

        float dist = Vector2.Distance(transform.position, _player.position);

        if (!_attracting && dist <= _playerExp.attractRadius)
            _attracting = true;

        if (_attracting)
        {
            transform.position = Vector2.MoveTowards(
                transform.position,
                _player.position,
                moveSpeed * Time.deltaTime
            );
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        _playerExp?.AddExp(expAmount);
        Destroy(gameObject);
    }
}
