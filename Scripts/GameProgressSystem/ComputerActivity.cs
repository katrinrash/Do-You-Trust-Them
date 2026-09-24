using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages computer-related day activities, including task setup, completion tracking, and activity progress updates.
/// </summary>

public class ComputerActivity : MonoBehaviour, IActivity
{
    public static ComputerActivity Instance { get; private set;}

    private List<string> _computers;
    private ComputerTasks _computerTasks;

    // Nested class to handle activity tasks
    private class ComputerTasks : ActivityTasksController
    {
        public ComputerTasks(DayContentSO currentDay) : base(currentDay) { }

        public override void SetTasks()
        { 
            TaskManager.Instance.SetComputerTasks(_names, _tasks);
        }
    }

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
        if (sO.activeComputersNames.Count == 0)
           return; 

        _computers = new List<string>(sO.activeComputersNames);
        _computerTasks = new ComputerTasks(currentDay: sO);
        _computerTasks.SetTasks();

        SubscribeForControl();
    }

    public void SubscribeForControl()
    {
        ProgressController.Instance.SetDayActivities(this);
    }

    public void SetCompletedTask(string taskName)
    {
        if (!_computers.Contains(taskName))
            return;

        OnActivityCompleted(taskName);
    }

    private void OnActivityCompleted(string name)
    {
        _computers.Remove(name);
        _computerTasks.CompleteTask(name);
        ProgressController.Instance.ManageUpdates(this);
    }

    public bool IsActivityCompleted()
    {
        return _computers.Count == 0;
    }
}

