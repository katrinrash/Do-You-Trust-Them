using System.Collections.Generic;

/// <summary>
/// Provides base logic for managing activity tasks, including task setup and completion handling.
/// </summary>

public class ActivityTasksController
{
    protected List<string> _names;
    protected List<string> _tasks;

    public ActivityTasksController(DayContentSO currentDay)
    {
        _names = new List<string>(currentDay.activeInteractionsNames);
        _tasks = new List<string>(currentDay.activeInteractionsTasks);
    }

    public virtual void SetTasks() { }

    public void CompleteTask(string name)
    {
        TaskManager.Instance.CompleteTask(name);
    }
}