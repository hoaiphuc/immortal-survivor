using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Spawn Radius")]
    [SerializeField] private float minSpawnRadius = 8f;
    [SerializeField] private float maxSpawnRadius = 12f;

    private Transform _player;
    private int _activeEnemyCount;
    private StageData _stageData;
    private List<Coroutine> _waveCoroutines = new();

    private void Start()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj == null)
        {
            Debug.LogError("EnemySpawner: No GameObject with tag 'Player' found.");
            return;
        }
        _player = playerObj.transform;
    }

    public void StartSpawning(StageData data)
    {
        _stageData = data;
        _activeEnemyCount = 0;
        _waveCoroutines.Clear();

        foreach (var wave in data.waves)
            _waveCoroutines.Add(StartCoroutine(WaveLoop(wave)));
    }

    public void StopSpawning()
    {
        foreach (var c in _waveCoroutines)
            if (c != null) StopCoroutine(c);
        _waveCoroutines.Clear();
    }

    private IEnumerator WaveLoop(StageData.WaveData wave)
    {
        yield return new WaitForSeconds(wave.startTime);

        float waveElapsed = 0f;
        float duration = wave.endTime - wave.startTime;

        while (waveElapsed < duration)
        {
            float interval = wave.GetInterval(waveElapsed);
            yield return new WaitForSeconds(interval);
            waveElapsed += interval;

            if (_activeEnemyCount < _stageData.maxEnemies)
                SpawnEnemy(wave.PickRandom());
        }
    }

    private void SpawnEnemy(GameObject prefab)
    {
        Vector2 dir = Random.insideUnitCircle.normalized;
        float dist = Random.Range(minSpawnRadius, maxSpawnRadius);
        Vector3 spawnPos = _player.position + new Vector3(dir.x, dir.y, 0f) * dist;

        GameObject enemy = Instantiate(prefab, spawnPos, Quaternion.identity);
        _activeEnemyCount++;
        enemy.GetComponent<EnemyHealth>().OnDeath += () => _activeEnemyCount--;
    }
}
