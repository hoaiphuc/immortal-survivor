using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game/Upgrade Pool")]
public class UpgradePool : ScriptableObject
{
    public UpgradeData[] upgrades;

    public UpgradeData[] PickRandom(int count)
    {
        var pool = new List<UpgradeData>(upgrades);
        for (int i = pool.Count - 1; i > 0; i--)
        {
            int j = Random.Range(0, i + 1);
            (pool[i], pool[j]) = (pool[j], pool[i]);
        }
        count = Mathf.Min(count, pool.Count);
        var result = new UpgradeData[count];
        for (int i = 0; i < count; i++) result[i] = pool[i];
        return result;
    }
}
