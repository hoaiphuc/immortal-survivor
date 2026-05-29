using UnityEngine;

[CreateAssetMenu(menuName = "Game/Upgrades/Attract Radius")]
public class AttractRadiusUpgrade : UpgradeData
{
    public float amount = 1f;

    public override void Apply(GameObject player)
    {
        player.GetComponent<PlayerExp>().attractRadius += amount;
    }
}
