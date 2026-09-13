using UnityEngine;

public class GameFlowManager : MonoBehaviour
{
    public static GameFlowManager Instance { get; private set; }

    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private GameObject winUI;
    [SerializeField] private GameObject gameUI;

    private void Awake()
    {
        Instance = this;
    }

    public void WinGame()
    {
        gameUI.SetActive(false);
        winUI.SetActive(true);
        SceneLoader.Instance.UnloadMinigameScene(delay: 2f, isSolved: true);
    }

    public void GameOver()
    {
        gameOverUI.SetActive(true);
        gameUI.SetActive(false);  
    }

}
