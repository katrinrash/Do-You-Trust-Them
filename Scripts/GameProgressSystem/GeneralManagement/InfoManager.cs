using System.Collections.Generic;
using TMPro;
using UnityEngine;

/// <summary>
/// Manages informational UI updates between game days, including displaying day information and updating notebook entries.
/// </summary>

public class InfoManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> infoPages;
    [SerializeField] private List<GameObject> nextBtns;
    [SerializeField] private TextMeshProUGUI infoText;
    [SerializeField] private TextMeshProUGUI hintText;

    void OnEnable()
    {
        DaysManager.OnDayChanged += OnDayChanged;
    }

    void OnDisable()
    {
        DaysManager.OnDayChanged -= OnDayChanged;
    }

    private void OnDayChanged(DayContentSO sO)
    {
        SetInfoBetweenDays();
    }

    private void SetInfoBetweenDays()
    {
        infoText.text = DaysManager.Instance.CurrentDay.textBetweenDays;
        hintText.gameObject.SetActive(true);
    }

    public void SetNotebookChanges()
    {
        TextMeshProUGUI infoText = infoPages[DaysManager.Instance.CurrentDayIndex].GetComponentInChildren<TextMeshProUGUI>();
        infoText.text = DaysManager.Instance.CurrentDay.textBetweenDays;
        Notification.Instance.ShowNotification("New information has been added to the notebook");

        if (DaysManager.Instance.CurrentDay.dayName == "Day1")
            return;
        
        nextBtns[DaysManager.Instance.CurrentDayIndex - 1].SetActive(true);
    }

    public void ClearInfoBetweenDays()
    {
        infoText.text = string.Empty;
        hintText.gameObject.SetActive(false);
    }
}
