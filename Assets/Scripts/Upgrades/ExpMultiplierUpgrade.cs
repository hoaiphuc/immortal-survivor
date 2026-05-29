using UnityEngine;

[CreateAssetMenu(menuName = "Game/Upgrades/Exp Multiplier")]
public class ExpMultiplierUpgrade : UpgradeData
{
    [Range(0.1f, 1f)] public float percentBonus = 0.2f;

    public override void Apply(GameObject player)
    {
        player.GetComponent<PlayerExp>().expMultiplier += percentBonus;
    }
}
