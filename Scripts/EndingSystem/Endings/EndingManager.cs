using UnityEngine;

/// <summary>
/// Manages an individual game ending.
/// </summary>

public class EndingManager : MonoBehaviour, IEnding
{
    [Header("Logic")]
    [SerializeField] private SendBtnLogic sendBtnLogic;
    [SerializeField] private PlayEnding playEnding;

    [Header("Text")]
    [SerializeField] private string endingText;
    [SerializeField] private string achievementText;

    [Header("Sprites")]
    [SerializeField] private Sprite achievementSprite;
    [SerializeField] private Sprite icon;

    public void PlayEnding()
    {
        playEnding.gameObject.SetActive(true);
        playEnding.FinishGAme(endingText, achievementText, achievementSprite, icon);
    }

    public void SetEnding()
    {
        sendBtnLogic.enabled = true;
        sendBtnLogic.SetEnding(this);
    }
}
