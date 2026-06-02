using UnityEngine;
using UnityEngine.SceneManagement;

public class MapSelectController : MonoBehaviour
{
    [SerializeField] private SelectedStageData selectedStageData;
    [SerializeField] private string mainMenuSceneName = "MainMenu";

    public void SelectMap(string sceneName, StageData stageData)
    {
        selectedStageData.current = stageData;
        SceneManager.LoadScene(sceneName);
    }

    public void GoBack()
    {
        SceneManager.LoadScene(mainMenuSceneName);
    }
}
