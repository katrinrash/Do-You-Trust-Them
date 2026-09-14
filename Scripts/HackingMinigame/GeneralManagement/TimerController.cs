using TMPro;
using UnityEngine;

/// <summary>
/// Manages the mini-game timer, including countdown, timer display, and triggering the Game Over state when time runs out.
/// </summary>

public class TimerController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;

    private bool _isTimerRunning;
    private float _timeLeft;

    public void StartTimer(float duration)
    {
        _timeLeft = duration;
        _isTimerRunning = true;
    }

    public void StopTimer()
    {
        _isTimerRunning = false;
    }

    private void Update()
    {
        if (!_isTimerRunning)
            return;

        _timeLeft -= Time.deltaTime;
        timerText.text = "Time Left: " + Mathf.CeilToInt(_timeLeft).ToString() + " sec.";

        if (_timeLeft <= 0)
        {
            _isTimerRunning = false;
            GameFlowManager.Instance.GameOver();
        }

    }
}
