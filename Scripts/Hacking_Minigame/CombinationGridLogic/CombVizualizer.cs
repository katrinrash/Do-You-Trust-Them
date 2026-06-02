using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CombVizualizer : MonoBehaviour
{ 
    [SerializeField] private TextMeshProUGUI targetComboText;
    [SerializeField] private TextMeshProUGUI choicesText;

    public List<string> targetCombination { get; private set; }

    private CombGenerator combGenerator = new CombGenerator();    

    private void Start()
    {
        CreateTarget();
    }

    public void CreateTarget()
    {
        targetCombination = combGenerator.GenerateCombination();
        targetComboText.text = "Your Target: " + string.Join(" ", targetCombination);
        choicesText.text = "Your Choices: ";

        MiniGameManager.Instance.Init();
    }

    public void UpdateChoicesText(string value)
    {
        choicesText.text += value + " ";
    }

}
