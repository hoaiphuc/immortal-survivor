using System;
using UnityEngine;

public class PlayerExp : MonoBehaviour
{
    [SerializeField] private int expToNextLevel = 100;
    [SerializeField] public float attractRadius = 4f;
    public float expMultiplier = 1f;

    public int CurrentExp { get; private set; }
    public int Level { get; private set; } = 1;

    public event Action<int> OnExpChanged;
    public event Action<int> OnLevelUp;

    public void AddExp(int amount)
    {
        CurrentExp += Mathf.RoundToInt(amount * expMultiplier);
        OnExpChanged?.Invoke(CurrentExp);

        while (CurrentExp >= expToNextLevel)
        {
            CurrentExp -= expToNextLevel;
            Level++;
            expToNextLevel = Mathf.RoundToInt(expToNextLevel * 1.2f);
            OnLevelUp?.Invoke(Level);
            Debug.Log($"Level Up! Current level: {Level}");
        }
    }
}
