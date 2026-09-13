using UnityEngine;
using UnityEngine.UI;

public class GameOver_Btn : MonoBehaviour
{
    [SerializeField] private GameObject toTurnOff;
    [SerializeField] private GameObject mainGameUI;
    [SerializeField] private TimerController timer;
    [SerializeField] private CombVizualizer comboVizualizer;
    [SerializeField] private GridGenerator gridGenerator;
    [SerializeField] private ResetBtnLogic resetBtnLogic;

    private Button button;

    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        toTurnOff.SetActive(false);
        mainGameUI.SetActive(true);

        timer.StartTimer(duration: 30f);
        comboVizualizer.CreateTarget();
        gridGenerator.ResetGrid();
        resetBtnLogic.SetReset(amount: 5);

    }
}
