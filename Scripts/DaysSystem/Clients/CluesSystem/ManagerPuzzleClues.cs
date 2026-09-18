using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Manages puzzle clues for each game day.
/// </summary>

public class ManagerPuzzleClues : MonoBehaviour
{
    [SerializeField] private List<SOPuzzleClues> puzzleCluesListDays;
    [SerializeField] private TextMeshProUGUI cluesText;
    [SerializeField] private Transform container;
    [SerializeField] private GameObject btnPref;
    [SerializeField] private CluesViewManager cluesViewManager;
    [SerializeField] private string objectName;

    private SOPuzzleClues _currentDayClues;
    private BtnCluesLogic _cluesBtnLogic;
    private bool _cluesAdded = false;

    private void OnEnable()
    {
        DaysManager.OnDayChanged += OnDayChanged;
    }

    private void OnDisable()
    {
        DaysManager.OnDayChanged -= OnDayChanged;
    }

    private void OnDayChanged(DayContentSO SO)
    {
        if (puzzleCluesListDays.Count == 0 || !SO.activeInteractionsNames.Contains(objectName))
            return;

        _currentDayClues = puzzleCluesListDays[0];
        puzzleCluesListDays.RemoveAt(0);
        _cluesAdded = false;
    }


    public void AddClues()
    {
        if (_cluesAdded)
            return;

        for (int i = 0; i < _currentDayClues.cluesName.Count; i++)
        {
            GameObject button = Instantiate(btnPref, container);

            button.GetComponentInChildren<Text>().text = _currentDayClues.cluesName[i];

            _cluesBtnLogic = button.GetComponent<BtnCluesLogic>();

            _cluesBtnLogic.cluesView = cluesViewManager.cluesView;
            _cluesBtnLogic.textPanel = cluesViewManager.textPanel;
            _cluesBtnLogic.imagePlace = cluesViewManager.imagePlace;
            _cluesBtnLogic.image = _currentDayClues.docImage[i];
            _cluesBtnLogic.text = null;

        }

        AddClueText();
        Notify();
        _cluesAdded = true;
    }

    private void Notify()
    {
        Notification.Instance.ShowNotification("New clues added" + "  " + "*General*");
        Notification.Instance.ShowThought(_currentDayClues.cluesSummary);
    }

    private void AddClueText()
    {
        foreach (var clueText in _currentDayClues.cluesThoughtsText)
        {
            cluesText.text += "-- " + clueText + "\n";
        }
    }

}
