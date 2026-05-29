using UnityEngine;

[CreateAssetMenu(menuName = "Game/Upgrades/Move Speed")]
public class MoveSpeedUpgrade : UpgradeData
{
    public float amount = 0.5f;

    public override void Apply(GameObject player)
    {
        var c = player.GetComponent<PlayerController>();
        if (c == null) { Debug.LogError("MoveSpeedUpgrade: PlayerController not found on " + player.name); return; }
        c.UpgradeMoveSpeed(amount);
        Debug.Log($"MoveSpeed +{amount}");
    }
}
