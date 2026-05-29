using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelUpPanel : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private GameObject[] options;
    [SerializeField] private UpgradePool upgradePool;

    private PlayerExp _playerExp;
    private UpgradeData[] _currentChoices;

    private void Start()
    {
        _playerExp = FindFirstObjectByType<PlayerExp>();
        _playerExp.OnLevelUp += Show;
        panel.SetActive(false);
    }

    private void Show(int level)
    {
        _currentChoices = upgradePool.PickRandom(3);
        panel.SetActive(true);
        Time.timeScale = 0f;

        for (int i = 0; i < options.Length; i++)
        {
            var upgrade = _currentChoices[i];
            options[i].transform.Find("Title").GetComponent<TextMeshProUGUI>().text = upgrade.upgradeName;
            options[i].transform.Find("Description").GetComponent<TextMeshProUGUI>().text = upgrade.description;
            Transform iconTransform = options[i].transform.Find("Image");
            if (iconTransform != null) iconTransform.GetComponent<Image>().sprite = upgrade.icon;
        }
    }

    public void SelectOption(int index)
    {
        var upgrade = _currentChoices[index];
        Debug.Log($"[LevelUpPanel] Selected: {upgrade.upgradeName} on {_playerExp.gameObject.name}");
        upgrade.Apply(_playerExp.gameObject);
        panel.SetActive(false);
        Time.timeScale = 1f;
    }
}
