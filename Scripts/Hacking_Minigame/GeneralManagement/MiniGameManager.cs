using System.Collections.Generic;
using UnityEngine;

public class MiniGameManager : MonoBehaviour
{
    public static MiniGameManager Instance { get; private set; }

    [SerializeField] private CombVizualizer comboVizualizer;
    [SerializeField] private TimerController timerController;

    public List<int> currentCombo { get; private set;}

    private List<string> _comboCheck = new List<string>();
    private bool _isHorizontalTurn;
    private (int lastRow,int lastColumn) _positionData; // tuple
    private int _elementIndex;

    private void Awake()
    {
       Instance = this;
    }

    public void Init()
    {
        currentCombo = new List<int>();
        _comboCheck = comboVizualizer.targetCombination;
        _elementIndex = 0;
        _isHorizontalTurn = true;
        _positionData = (0, 0);
    }

    public void OnButtonClick(ButtonLogic button)
    {
        if (_elementIndex >= _comboCheck.Count || button.Value != _comboCheck[_elementIndex])
            return;

        if (currentCombo.Count == 0 && button.Row == 0) 
        {
            AcceptButton(button);
            return;
        }

        if ((_isHorizontalTurn && button.Row == _positionData.lastRow) || (!_isHorizontalTurn && button.Column == _positionData.lastColumn))
        {
            AcceptButton(button);
        }

    }

    private void AcceptButton(ButtonLogic btn)
    {
        btn.Select();
        _elementIndex++;
        comboVizualizer.UpdateChoicesText(btn.Value);
        currentCombo.Add(_elementIndex);

        if(currentCombo.Count == _comboCheck.Count)
        {
            timerController.StopTimer();
            GameFlowManager.Instance.WinGame();
        }

        _positionData.lastRow = btn.Row;
        _positionData.lastColumn = btn.Column;
        _isHorizontalTurn = !_isHorizontalTurn;
    }

}
