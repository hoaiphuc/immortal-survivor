using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Prefab")]
    [SerializeField] private GameObject enemyPrefab;

    [Header("Spawn Settings")]
    [SerializeField] private float spawnInterval = 2f;
    [SerializeField] private int maxEnemies = 20;
    [SerializeField] private float minSpawnRadius = 8f;
    [SerializeField] private float maxSpawnRadius = 12f;

    private Transform _player;
    private int _activeEnemyCount;

    private void Start()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj == null)
        {
            Debug.LogError("EnemySpawner: No GameObject with tag 'Player' found.");
            return;
        }
        _player = playerObj.transform;
        StartCoroutine(SpawnLoop());
    }

    private IEnumerator SpawnLoop()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);

            if (_activeEnemyCount < maxEnemies)
                SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        Vector2 direction = Random.insideUnitCircle.normalized;
        float distance = Random.Range(minSpawnRadius, maxSpawnRadius);
        Vector3 spawnPos = _player.position + new Vector3(direction.x, direction.y, 0f) * distance;

        GameObject enemy = Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
        _activeEnemyCount++;

        // Decrement counter when enemy is destroyed
        enemy.GetComponent<EnemyHealth>().OnDeath += () => _activeEnemyCount--;
    }
}
