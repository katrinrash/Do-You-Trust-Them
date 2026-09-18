using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Manages clues for interactive objects.
/// </summary>

public class ObjectClues : MonoBehaviour
{
    [SerializeField] private List<ObjectSOClues> objectSOCluesForDays;
    [SerializeField] private TextMeshProUGUI cluesText;
    [SerializeField] private Transform container;
    [SerializeField] private GameObject btnPref;
    [SerializeField] private ItemInspectionManager itemInspectionManager;
    [SerializeField] private PickupableItem itemPrefabForInspection;
    [SerializeField] private string objectName;

    private ObjectSOClues _currentDayClues;
    private Btn_Object_Clues _cluesBtnLogic;
    private bool _cluesAdded = false;

    private void OnEnable()
    {
        DaysManager.OnDayChanged += OnDayChanged;
    }

    private void OnDestroy()
    {
        DaysManager.OnDayChanged -= OnDayChanged;
    }

    private void OnDayChanged(DayContentSO SO)
    {
        if (objectSOCluesForDays.Count == 0 || !SO.activeObjects.Contains(objectName))
            return;

        _currentDayClues = objectSOCluesForDays[0];
        objectSOCluesForDays.RemoveAt(0);
        _cluesAdded = false;
    }

    public void AddClues()
    {
        if (_cluesAdded)
        {
            Notify();
            return;
        }

        GameObject button = Instantiate(btnPref, container);
        button.GetComponentInChildren<Text>().text = _currentDayClues.objectName;

        _cluesBtnLogic = button.GetComponent<Btn_Object_Clues>();

        _cluesBtnLogic.objPrefab = itemPrefabForInspection;
        _cluesBtnLogic.itemInspectionManager = itemInspectionManager;

        AddClueText();
        Notify();

        ObjectActivity.Instance.SetCompletedTask(objectName);
        _cluesAdded = true;
    }

    private void Notify()
    {
        if (_cluesAdded)
        {
            Notification.Instance.ShowThought("Nothing new");
            return;
        }
        
        Notification.Instance.ShowNotification("New clues added" + "  " + $"*{_currentDayClues.buttonDirectory}*");
        Notification.Instance.ShowThought(_currentDayClues.characterThought);
    }

    private void AddClueText()
    {
        cluesText.text += "-- " + _currentDayClues.objectClue + "\n";
    }
}
