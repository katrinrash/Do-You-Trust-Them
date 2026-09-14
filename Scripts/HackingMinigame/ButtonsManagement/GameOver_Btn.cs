using UnityEngine;

/// <summary>
/// Manages the hacking mini-game restart flow after Game Over.
/// </summary>

public class GameOver_Btn : MG_StateBase_Btn
{
    [SerializeField] private CombVizualizer comboVizualizer;
    [SerializeField] private GridGenerator gridGenerator;
    [SerializeField] private ResetBtnLogic resetBtnLogic;

    protected override void OnButtonClick()
    {
        base.OnButtonClick();

        mainGameUI.SetActive(true);
        timer.StartTimer(duration: 30f);
        comboVizualizer.CreateTarget();
        gridGenerator.ResetGrid();
        resetBtnLogic.SetReset(amount: 5);
    }
}
