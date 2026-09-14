using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// Manages the main interactive buttons of the hacking mini-game, including their data, interactions, and visual states.
/// </summary>

public class ButtonLogic : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public string Value { get; private set; } 
    public int Row { get; private set; } 
    public int Column { get; private set; } 

    private Button button;
    private Image buttonBackground;
    private Color defaultColor;

    public void Setup(string value, int row, int column)
    { 
        Value = value;
        Row = row;
        Column = column;

        button = GetComponent<Button>();
        buttonBackground = GetComponent<Image>();
        defaultColor = buttonBackground.color;

        button.GetComponentInChildren<Text>().text = value; 
        button.onClick.AddListener(OnButtonClick);
    }

    public void ResetButton(string value)
    {
        Value = value;
        button.GetComponentInChildren<Text>().text = value;
    }

    #region Button Interactions

    public void OnPointerEnter(PointerEventData eventData) => Highlight();
    public void OnPointerExit(PointerEventData eventData) => Unhighlight();

    private void Highlight()
    {
        if(button.interactable)
        buttonBackground.color = Color.gray; 
    }

    private void Unhighlight()
    {
        if (button.interactable)
        buttonBackground.color = defaultColor; 
    }

    private void OnButtonClick()
    {
        MiniGameManager.Instance.OnButtonClick(this);
    }

    public void Select()
    {
        buttonBackground.color = Color.green;
        button.interactable = false;
    }

    #endregion
}
