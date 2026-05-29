using UnityEngine;

[CreateAssetMenu(menuName = "Game/Upgrades/Damage")]
public class DamageUpgrade : UpgradeData
{
    public float amount = 5f;

    public override void Apply(GameObject player)
    {
        var c = player.GetComponent<PlayerAutoShoot>();
        if (c == null) { Debug.LogError("DamageUpgrade: PlayerAutoShoot not found on " + player.name); return; }
        c.UpgradeDamage(amount);
        Debug.Log($"Damage +{amount}");
    }
}
