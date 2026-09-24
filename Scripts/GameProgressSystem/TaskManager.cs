using System.Collections.Generic;
using TMPro;
using UnityEngine;

/// <summary>
/// Manages the task UI for the current day, including task creation, completion tracking, and task list updates.
/// </summary>

public class TaskManager : MonoBehaviour
{
    public static TaskManager Instance { get; private set; }

    [SerializeField] private GameObject textPref;
    [SerializeField] private Transform textPlace;
    [SerializeField] private TextMeshProUGUI mainTaskPlace;

    private Dictionary<string, TextMeshProUGUI> _allTasks = new Dictionary<string, TextMeshProUGUI>();

    #region Unity Life Cycle

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void OnEnable()
    {
        DaysManager.OnDayChanged += OnDayChanged;
    }

    void OnDisable()
    {
        DaysManager.OnDayChanged -= OnDayChanged;
    }

    #endregion

    private void OnDayChanged(DayContentSO sO)
    {
        _allTasks.Clear();
        mainTaskPlace.text = sO.mainTask;
    }

    public void SetComputerTasks(List<string> name, List<string> tasks)
    {
        int index = 0;
        foreach (var task in name)
        {
            GameObject obj = Instantiate(textPref, textPlace);
            TextMeshProUGUI text = obj.GetComponentInChildren<TextMeshProUGUI>();

            text.text = $"-- {tasks[index]}";
            _allTasks[task] = text;
            index++;
        }

    }

    public void SetObjectTasks(List<string> names, List<string> tasks)
    {
        int index = 0;
        foreach (var task in names)
        {
            GameObject obj = Instantiate(textPref, textPlace);
            TextMeshProUGUI text = obj.GetComponentInChildren<TextMeshProUGUI>();

            text.text = $"-- {tasks[index]}";
            _allTasks[task] = text;
            index++;
        }
    }

    public void SetInteractionTasks(List<string> names, List<string> tasks)
    {
        int index = 0;
        foreach (var task in names)
        {          
            GameObject obj = Instantiate(textPref, textPlace);
            TextMeshProUGUI text = obj.GetComponentInChildren<TextMeshProUGUI>();

            text.text = $"-- {tasks[index]}";
            _allTasks[task] = text;
            index++;
        }
    }

    public void CompleteTask(string name)
    {
        TextMeshProUGUI currentTask = _allTasks[name];
        currentTask.color = Color.gray;
        currentTask.fontStyle = FontStyles.Strikethrough;
        Notification.Instance.ShowNotification($"One task completed");
    }

    public void ClearTasks()
    {
        foreach (Transform child in textPlace)
            Destroy(child.gameObject);
    }

}
