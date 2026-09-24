using System.Collections.Generic;
using UnityEngine;

public class ObjectActivity : MonoBehaviour, IActivity
{
    public static ObjectActivity Instance { get; private set; }

    private List<string> _objects;
    private ObjectTasks _objTasks;

    // Nested class to handle activity tasks
    private class ObjectTasks : ActivityTasksController
    {
        public ObjectTasks(DayContentSO currentDay) : base(currentDay) { }

        public override void SetTasks()
        {
            TaskManager.Instance.SetObjectTasks(names, tasks);
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
       if (sO.activeObjects.Count == 0)
           return;

        _objects = new List<string>(sO.activeObjects);
        _objTasks = new ObjectTasks(currentDay: sO);
        _objTasks.SetTasks();

        SubscribeForControl();
    }

    public void SubscribeForControl()
    {
        ProgressController.Instance.SetDayActivities(this);
    }

    public void SetCompletedTask(string taskName)
    {
        if (!_objects.Contains(taskName))
           return;

        OnActivityCompleted(taskName);
    }

    private void OnActivityCompleted(string name)
    {
        _objects.Remove(name);
        _objTasks.CompleteTask(name);
        ProgressController.Instance.ManageUpdates(this);
    }

    public bool IsActivityCompleted()
    {
        return _objects.Count == 0;
    }
}
