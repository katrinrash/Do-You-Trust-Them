using UnityEngine;

/// <summary>
/// SO for configurable clue data for interactive objects.
/// </summary>

[CreateAssetMenu(fileName = "ObjectSOClues", menuName = "Scriptable Objects/ObjectSOClues")]
public class ObjectSOClues : ScriptableObject
{
    public string objectName;
    public string objectClue;
    public string characterThought;
    public string buttonDirectory;  
}
