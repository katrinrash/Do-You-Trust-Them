using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages mini-game activities for each day, including task setup, completion tracking, and activity progress updates.
/// </summary>

public class MiniGamesActivity : MonoBehaviour, IActivity
{
    public static MiniGamesActivity Instance { get; private set; }

    private List<string> _miniGames;
    private MiniGamesTasks _miniGamesTasks;

    // Nested class to handle activity tasks
    private class MiniGamesTasks : ActivityTasksController
    {
        public MiniGamesTasks(DayContentSO currentDay) : base(currentDay) { }

        public override void SetTasks()
        {
            TaskManager.Instance.SetInteractionTasks(names, tasks);
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
        if (sO.activeInteractionsNames.Count == 0)
            return;

        _miniGames = new List<string>(sO.activeInteractionsNames);
        _miniGamesTasks = new MiniGamesTasks(currentDay: sO);
        _miniGamesTasks.SetTasks();

        SubscribeForControl();
    }

    public void SubscribeForControl()
    {
        ProgressController.Instance.SetDayActivities(this);
    }

    public void SetCompletedTask(string taskName)
    {
        if (!_miniGames.Contains(taskName))
            return;

        OnActivityCompleted(taskName);
    }

    private void OnActivityCompleted(string name)
    {
        _miniGames.Remove(name);
        _miniGamesTasks.CompleteTask(name);
        ProgressController.Instance.ManageUpdates(this);
    }

    public bool IsActivityCompleted()
    {
        return _miniGames.Count == 0;
    }
}
