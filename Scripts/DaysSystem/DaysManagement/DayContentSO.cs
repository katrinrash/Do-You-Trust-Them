using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// SO for configurable data for a game day.
/// </summary>

[CreateAssetMenu(fileName = "DayContentSO", menuName = "Scriptable Objects/DayContentSO")]
public class DayContentSO : ScriptableObject
{
    [Header("Day Data")]
    public string dayName;
    public string textBetweenDays;
    public string mainTask;

    [Header("Computers")]
    public List<string> activeComputersNames;
    public List<string> activeComputersTasks; 

    [Header("Objects")]
    public List<string> objectsInDay;
    public List<string> activeObjects;
    public List<string> activeObjectsTasks;

    [Header("Interactions")]
    public List<string> activeInteractionsNames;
    public List<string> activeInteractionsTasks;

    [Header("Printer Images")]
    public List<Sprite> printerImages;

    [Header("Puzzle Textures")]
    public Texture2D puzzleTextures;
}
