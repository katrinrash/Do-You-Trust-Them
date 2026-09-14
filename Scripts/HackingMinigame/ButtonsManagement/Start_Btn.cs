using UnityEngine;

/// <summary>
/// Manages the hacking mini-game start flow
/// </summary>

public class Start_Btn : MG_StateBase_Btn
{
    [SerializeField] private AudioManager audioManager;

    protected override void OnButtonClick()
    {
        base.OnButtonClick();

        mainGameUI.SetActive(true);
        timer.StartTimer(duration: 30f);

        audioManager.PlayHackingSound();
        audioManager.StopAmbient();
        audioManager.MuteSteps();
    }
}
