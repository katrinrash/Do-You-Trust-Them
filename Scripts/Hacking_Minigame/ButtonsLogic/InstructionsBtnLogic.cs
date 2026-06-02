using UnityEngine;
using UnityEngine.UI;

public class InstructionsBtnLogic : MonoBehaviour
{
    [SerializeField] private GameObject instructionsPanel;
    [SerializeField] private GameObject blocker;

    private bool _isPanelActive = false;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(ShowInstructions);
    }

    private void ShowInstructions()
    {
        _isPanelActive = !_isPanelActive;
        instructionsPanel.SetActive(_isPanelActive);
        blocker.SetActive(_isPanelActive);

        Time.timeScale = _isPanelActive ? 0f : 1f; // Pause/Resume the game based on panel state
    }
}
