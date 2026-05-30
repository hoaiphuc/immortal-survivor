using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameResultPanel : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private TextMeshProUGUI titleText;
    [SerializeField] private string mainMenuSceneName = "MainMenu";

    private void Start()
    {
        FindFirstObjectByType<PlayerHealth>().OnDeath += () => Show(false);
        FindFirstObjectByType<StageManager>().OnStageClear += () => Show(true);
        panel.SetActive(false);
    }

    private void Show(bool isWin)
    {
        panel.SetActive(true);
        Time.timeScale = 0f;
        titleText.text = isWin ? "Chiến Thắng!" : "Thất Bại!";
    }

    public void PlayAgain()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(mainMenuSceneName);
    }
}
