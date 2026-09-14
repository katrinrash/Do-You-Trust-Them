using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages available game endings and selects the appropriate ending based on the player's outcome.
/// </summary>

public class StateController : MonoBehaviour
{
    public static StateController Instance { get; private set; }

    [SerializeField] private SendBtnLogic sendBtnLogic;
    [SerializeField] private List<GameObject> endingList;
    [SerializeField] private List<string> endingNames;

    private Dictionary<string, IEnding> _endings;

    void Awake()
    {
        if (Instance == null) 
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    { 
        _endings = new Dictionary<string, IEnding>();
        int index = 0;

        foreach (var ending in endingNames)
        {
            _endings[ending] = endingList[index++].GetComponent<IEnding>();
        }

        sendBtnLogic.enabled = false;
    }

    public void ManageEnding(string outcome)
    { 
       _endings[outcome].SetEnding();
    }
}
