using UnityEngine;
using TMPro;

public class LevelUpPanel : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private GameObject[] options;

    private PlayerExp _playerExp;

    private void Start()
    {
        _playerExp = FindFirstObjectByType<PlayerExp>();
        _playerExp.OnLevelUp += Show;
        panel.SetActive(false);
    }

    private void Show(int level)
    {
        panel.SetActive(true);
        Time.timeScale = 0f;

        string[] labels = { "Option A", "Option B", "Option C" };
        for (int i = 0; i < options.Length; i++)
        {
            if (options[i] == null) { Debug.LogError($"options[{i}] is null — check Inspector"); continue; }
            var tmp = options[i].GetComponentInChildren<TextMeshProUGUI>();
            if (tmp == null) { Debug.LogError($"options[{i}] has no TextMeshProUGUI child"); continue; }
            tmp.text = labels[i];
        }
    }

    public void SelectOption(int index)
    {
        panel.SetActive(false);
        Time.timeScale = 1f;
    }
}
