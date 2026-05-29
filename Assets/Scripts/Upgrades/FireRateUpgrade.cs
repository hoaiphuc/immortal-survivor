using UnityEngine;

[CreateAssetMenu(menuName = "Game/Upgrades/Fire Rate")]
public class FireRateUpgrade : UpgradeData
{
    public float amount = 0.5f;

    public override void Apply(GameObject player)
    {
        var c = player.GetComponent<PlayerAutoShoot>();
        if (c == null) { Debug.LogError("FireRateUpgrade: PlayerAutoShoot not found on " + player.name); return; }
        c.UpgradeFireRate(amount);
        Debug.Log($"FireRate +{amount}");
    }
}
