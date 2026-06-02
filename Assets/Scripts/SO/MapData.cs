using UnityEngine;

[CreateAssetMenu(menuName = "Game/Map Data")]
public class MapData : ScriptableObject
{
    public string mapName;
    public StageData stageData;
    public string sceneName = "GamePlay";
}
