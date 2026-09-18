using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// SO for configurable puzzle clue data.
/// </summary>

[CreateAssetMenu(fileName = "SOPuzzleClues", menuName = "Scriptable Objects/SOPuzzleClues")]
public class SOPuzzleClues : ScriptableObject
{
    public List<string> cluesName;
    public List<Sprite> docImage;
    public List<string> cluesThoughtsText;
    public string cluesSummary;
}
