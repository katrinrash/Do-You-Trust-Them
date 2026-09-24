using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages overall activity progress for the current day.
/// </summary>

public class ProgressController : MonoBehaviour
{
    public static ProgressController Instance { get; private set; }

    [SerializeField] private GameObject finishDayButton;
    [SerializeField] private GameObject sendReportButton;

    private List<IActivity> _activeActivities = new List<IActivity>();
    private List<IActivity> _completedActivities = new List<IActivity>();

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void SetDayActivities(IActivity activityType)
    {
        _activeActivities.Add(activityType);
    }

    public void ManageUpdates(IActivity activityType)
    {
        if (activityType.IsActivityCompleted())
        { 
            _completedActivities.Add(activityType);
            CheckProgress();
        }
    }

    private void CheckProgress()
    {
        if (_activeActivities.Count != _completedActivities.Count)
        {
            return;
        }

        FinishTheDay();
    }

    private void FinishTheDay()
    { 
       _activeActivities.Clear();
       _completedActivities.Clear();

        if (DaysManager.Instance.CurrentDay.dayName == "Day3")
        { 
            sendReportButton.SetActive(true);
            Notification.Instance.ShowNotification("It is time to send the report. Check the notebook to do so");
            return;
        }

        finishDayButton.SetActive(true);
        Notification.Instance.ShowNotification("Time to go home. Check your notebook to end the day");

    }

}
