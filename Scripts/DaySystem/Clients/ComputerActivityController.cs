using UnityEngine;

/// <summary>
/// Manages computer object availability based on the current day configuration.
/// </summary>

public class ComputerActivityController : MonoBehaviour
{
    [SerializeField] private string computerName;
    private ScreenViewController _screenViewController;

    private void OnEnable()
    {
        DaysManager.OnDayChanged += OnDayChanged;
        _screenViewController = GetComponent<ScreenViewController>();
    }

    private void OnDisable()
    {
        DaysManager.OnDayChanged -= OnDayChanged;
    }

    private void OnDayChanged(DayContentSO day)
    {
        if (day.activeComputersNames.Contains(computerName))
        {
            _screenViewController.enabled = true;
            _screenViewController.IsHacked = false;
            _screenViewController.SetName(computerName);
        }
        else
            _screenViewController.enabled = false;

    }

}
