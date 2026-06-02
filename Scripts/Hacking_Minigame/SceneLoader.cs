using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader Instance { get; private set; }

    [SerializeField] private GameObject player; 
    [SerializeField] private GameObject mainEventSystem; 
    [SerializeField] private MenuView menuView; 
    [SerializeField] private NotebookManager notebookManager; 
    [SerializeField] private ScreenViewController screenViewController;
    [SerializeField] private AudioManager audioManager;

    private int _sceneIndex = 2; // Index of the minigame scene in the build settings

    private void Awake()
    {
       Instance = this;
    }

    public void LoadMinigameScene(ScreenViewController screenViewController)
    {
        this.screenViewController = screenViewController;
        StartCoroutine(LoadMinigameSceneCoroutine());
    }

    public void UnloadMinigameScene(float delay, bool isSolved)
    {
       StartCoroutine(UnloadScene(delay, isSolved));
    }

    private IEnumerator LoadMinigameSceneCoroutine()
    {
        mainEventSystem.SetActive(false);
        menuView.SetAccess(false); 
        notebookManager.isAvailable = false;
        audioManager.gameObject.SetActive(false); // Disable audio manager during minigame

        // AsyncLoading to show minigame over the main scene
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(_sceneIndex, LoadSceneMode.Additive);

        while (!asyncLoad.isDone)
        {
            yield return null; 
        }

        Scene loadedScene = SceneManager.GetSceneByName("Hacking_MiniGame");
        SceneManager.SetActiveScene(loadedScene);

        player.SetActive(false); 

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

    }

    private IEnumerator UnloadScene(float delay, bool isSolved)
    {
        yield return new WaitForSeconds(delay);

        AsyncOperation asyncUnload = SceneManager.UnloadSceneAsync(_sceneIndex);

        while (!asyncUnload.isDone)
        {
            yield return null;
        }

        player.SetActive(true);
        mainEventSystem.SetActive(true);
        audioManager.gameObject.SetActive(true); // Re-enable audio manager after minigame

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        
        if (!isSolved)
        {
            menuView.SetAccess(true);
            notebookManager.isAvailable = true;
            screenViewController.IsHacked = false;
        }
        else
        {
            screenViewController.EnterScreenView();
        }

    }

}
