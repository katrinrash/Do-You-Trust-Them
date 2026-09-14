using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// Manages the presentation of a game ending, including fade transitions, result display, achievement notification, and returning to the main menu.
/// </summary>

public class PlayEnding : MonoBehaviour
{
    [SerializeField] private GameObject fader;
    [SerializeField] private SwitchAnimation switchAnimation;
    [SerializeField] private NotebookManager notebook;
    [SerializeField] private MenuView menuView;
    [SerializeField] private TextMeshProUGUI infoText;
    [SerializeField] private TextMeshProUGUI hintText;
    [SerializeField] private GameObject backgroung;
    [SerializeField] private Image resultIcon;

    private string _endingText;
    private string _achievementText;
    private Sprite _achievementSprite;


    public void FinishGAme(string endingText, string achievementText, Sprite achievementSprite, Sprite icon)
    {
        resultIcon.sprite = icon;
        _endingText = endingText;
        _achievementText = achievementText;
        _achievementSprite = achievementSprite;

        StartCoroutine(FadeInControll());
    }

    private IEnumerator FadeInControll()
    {
        fader.SetActive(true);
        notebook.isAvailable = false;
        menuView.SetAccess(false);
        switchAnimation.FadeIn();

        yield return new WaitForSeconds(switchAnimation.FadeDuration);

        backgroung.SetActive(true);
        resultIcon.gameObject.SetActive(true);
        infoText.text = _endingText;
        hintText.gameObject.SetActive(true);

        Notification.Instance.Achievement(_achievementText, _achievementSprite);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DaysManager.Instance.ResetDay();
            SceneManager.LoadScene("MainMenu");
        }
    }
}
