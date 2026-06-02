using UnityEngine;
using UnityEngine.UI;

public class Start_Btn : MonoBehaviour
{
    [SerializeField] private GameObject toTurnOff;
    [SerializeField] private GameObject mainGameUI;
    [SerializeField] private TimerController timer;
    [SerializeField] private AudioManager audioManager;

    private Button _button;

    private void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(OnButtonClick);
        
    }

    private void OnButtonClick()
    {
        toTurnOff.SetActive(false);
        mainGameUI.SetActive(true);

        timer.StartTimer(duration: 30f);
        
        if (audioManager != null)
        {
            audioManager.PlayHackingSound();
            audioManager.StopAmbient();
            audioManager.MuteSteps();
        }

    }
}
