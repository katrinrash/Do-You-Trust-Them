using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Main manager for the day system and entry point for day-related gameplay logic.
/// </summary>

public class DaysManager : MonoBehaviour
{
    public static event Action<DayContentSO> OnDayChanged;
    public static DaysManager Instance { get; private set; }

    [SerializeField] private List<DayContentSO> days;
    [SerializeField] private PlayerController playerController;
    [SerializeField] private GameObject finishBtn;
    [SerializeField] private GameObject reportBtn;

    public DayContentSO CurrentDay { get; private set; }
    public int CurrentDayIndex { get; private set; }


    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        CurrentDayIndex = 0;
        LoadDay(CurrentDayIndex);
    }

    public void LoadDay(int dayIndex)
    {
        CurrentDay = days[dayIndex];
        OnDayChanged?.Invoke(CurrentDay);
        finishBtn.SetActive(false);
        reportBtn.SetActive(false);
    }

    public void NextDay()
    {
        CurrentDayIndex++;
        
        if (CurrentDayIndex < days.Count)
            LoadDay(CurrentDayIndex);

        if (playerController != null)
            playerController.ResetPlayerPosition();
    }

    public void ResetDay()
    {
        CurrentDayIndex = 0;
    }

}
