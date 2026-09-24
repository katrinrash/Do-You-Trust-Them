using System.Collections;
using UnityEngine;

/// <summary>
/// Manages day transitions with fade animation.
/// </summary>

public class DaysSwitchWithAnimation : MonoBehaviour
{ 
    [SerializeField] private GameObject fader;
    [SerializeField] private SwitchAnimation switchAnimation;
    [SerializeField] private NotebookManager notebook;
    [SerializeField] private MenuView menuView;
    [SerializeField] private InfoManager infoManager;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(FadeOutControll());
        }
    }

    public void Switch()
    { 
        StartCoroutine(FadeInControll());
    }


    private IEnumerator FadeInControll()
    {
        fader.SetActive(true);
        notebook.isAvailable = false;
        menuView.SetAccess(false);
        switchAnimation.FadeIn();

        yield return new WaitForSeconds(switchAnimation.FadeDuration);

        DaysManager.Instance.NextDay();
    }

    private IEnumerator FadeOutControll()
    {
        switchAnimation.FadeOut();
        infoManager.ClearInfoBetweenDays();

        yield return new WaitForSeconds(switchAnimation.FadeDuration);

        fader.SetActive(false);
        gameObject.SetActive(false);
        notebook.isAvailable = true;
        menuView.SetAccess(true);
        infoManager.SetNotebookChanges();
    }
}
