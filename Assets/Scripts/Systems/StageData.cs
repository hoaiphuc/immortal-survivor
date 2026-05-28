using UnityEngine;

[CreateAssetMenu(menuName = "Game/Stage Data", fileName = "StageData")]
public class StageData : ScriptableObject
{
    [Header("Stage")]
    public float stageDuration = 120f;
    public int maxEnemies = 30;
    public string nextSceneName;

    [Header("Boss")]
    public GameObject bossPrefab;
    public float bossSpawnRadius = 6f;

    [Header("Waves")]
    public WaveData[] waves;

    [System.Serializable]
    public class WaveData
    {
        public string waveName;
        public float startTime;
        public float endTime;
        public float spawnIntervalStart = 2f;
        public float spawnIntervalEnd = 0.5f;
        public EnemyEntry[] enemies;

        public float GetInterval(float waveElapsed)
        {
            float duration = endTime - startTime;
            float t = duration > 0f ? Mathf.Clamp01(waveElapsed / duration) : 1f;
            return Mathf.Lerp(spawnIntervalStart, spawnIntervalEnd, t);
        }

        public GameObject PickRandom()
        {
            float total = 0f;
            foreach (var e in enemies) total += e.weight;

            float roll = Random.Range(0f, total);
            float cumulative = 0f;
            foreach (var e in enemies)
            {
                cumulative += e.weight;
                if (roll <= cumulative) return e.prefab;
            }
            return enemies[^1].prefab;
        }
    }

    [System.Serializable]
    public class EnemyEntry
    {
        public GameObject prefab;
        public float weight = 1f;
    }
}
