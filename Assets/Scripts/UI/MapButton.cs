using UnityEngine;

public class MapButton : MonoBehaviour
{
    [SerializeField] private MapSelectController controller;
    [SerializeField] private string sceneName;
    [SerializeField] private StageData stageData;

    public void OnClick()
    {
        controller.SelectMap(sceneName, stageData);
    }
}
