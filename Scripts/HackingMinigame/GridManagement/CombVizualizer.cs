using System.Collections.Generic;
using TMPro;
using UnityEngine;

/// <summary>
/// Manages the target combination UI, including generating and displaying the target combination and updating the player's current choices.
/// </summary>

public class CombVizualizer : MonoBehaviour
{ 
    [SerializeField] private TextMeshProUGUI targetComboText;
    [SerializeField] private TextMeshProUGUI choicesText;

    public List<string> TargetCombination { get; private set; }

    private CombGenerator _combGenerator = new CombGenerator();    

    private void Start()
    {
        CreateTarget();
    }

    public void CreateTarget()
    {
        TargetCombination = _combGenerator.GenerateCombination();
        targetComboText.text = "Your Target: " + string.Join(" ", TargetCombination);
        choicesText.text = "Your Choices: ";

        MiniGameManager.Instance.Init();
    }

    public void UpdateChoicesText(string value)
    {
        choicesText.text += value + " ";
    }

}
