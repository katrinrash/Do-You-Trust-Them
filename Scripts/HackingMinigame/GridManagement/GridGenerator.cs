using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages the hacking mini-game grid, including button generation, element assignment, and grid reset logic.
/// </summary>

public class GridGenerator : MonoBehaviour
{
    [SerializeField] private Transform container;
    [SerializeField] private List<GameObject> createdButtons;

    private string[] _possibleElements = { "A7", "B5", "D9", "0E" };
    private int _gridLength = 5;

    private void Start()
    {
        GenerateGrid();
    }

    public void GenerateGrid()
    { 

        for (int i = 0; i < createdButtons.Count; i++)
        {
            createdButtons[i].transform.SetParent(container, false);
            createdButtons[i].SetActive(true);

            var buttonLogic = createdButtons[i].GetComponent<ButtonLogic>();

            buttonLogic.Setup(
                _possibleElements[Random.Range(0, _possibleElements.Length)], // Randomly selects an element from the array
                i / _gridLength, // Row index
                i % _gridLength // Column index
                );
        }

    }

    public void ResetGrid()
    {
        foreach (GameObject btn in createdButtons)
        {
            btn.GetComponent<ButtonLogic>().ResetButton(value: _possibleElements[Random.Range(0, _possibleElements.Length)]); 
        }
    }

}
