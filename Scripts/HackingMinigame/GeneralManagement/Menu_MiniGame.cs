using UnityEngine;

/// <summary>
/// Manages the mini-game menu.
/// </summary>

public class Menu_MiniGame : MonoBehaviour
{
    [SerializeField] private GameObject menuPanel;

    private bool _isMenuOpen = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !_isMenuOpen)
        {
            OpenMenu();
            _isMenuOpen = true;
        }
    }

    public void OpenMenu()
    {
        Time.timeScale = 0f;
        menuPanel.SetActive(true);
    }

    public void ExitMenu()
    {
        Time.timeScale = 1f;
        menuPanel.SetActive(false);
        _isMenuOpen = false;
    }

    public void ExitMiniGame()
    {
        Time.timeScale = 1f;
        SceneLoader.Instance.UnloadMinigameScene(delay: 0f, isSolved: false);
    }
}
