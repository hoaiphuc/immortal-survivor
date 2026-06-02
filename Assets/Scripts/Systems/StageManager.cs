using System;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    [SerializeField] private SelectedStageData selectedStageData;
    [SerializeField] private GameObject enemySpawnerPrefab;

    private StageData stageData;

    private EnemySpawner enemySpawner;
    public event Action OnStageClear;

    private float _stageTimer;
    private State _state;

    private enum State { Spawning, BossPhase, StageClear }

    private void Start()
    {
        stageData = selectedStageData.current;
        enemySpawner = Instantiate(enemySpawnerPrefab, transform).GetComponent<EnemySpawner>();
        _state = State.Spawning;
        enemySpawner.StartSpawning(stageData);
    }

    private void Update()
    {
        if (_state != State.Spawning) return;

        _stageTimer += Time.deltaTime;
        if (_stageTimer >= stageData.stageDuration)
            StartBossPhase();
    }

    private void StartBossPhase()
    {
        _state = State.BossPhase;
        enemySpawner.StopSpawning();

        Vector2 dir = UnityEngine.Random.insideUnitCircle.normalized;
        Vector3 spawnPos = FindFirstObjectByType<PlayerHealth>().transform.position
                           + new Vector3(dir.x, dir.y, 0f) * stageData.bossSpawnRadius;

        GameObject boss = Instantiate(stageData.bossPrefab, spawnPos, Quaternion.identity);
        boss.GetComponent<EnemyHealth>().OnDeath += OnBossDefeated;
    }

    private void OnBossDefeated()
    {
        _state = State.StageClear;
        OnStageClear?.Invoke();
    }
}
