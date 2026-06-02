using UnityEngine;
using System.Collections.Generic;

public class CombGenerator
{
    public List<string> combination { get; private set; }

    private string[] possibleElements = { "A7", "B5", "D9", "0E" };

    private int combinationLength = 4;


    public List<string> GenerateCombination()
    {
        combination = new List<string>();

        for (int i = 0; i < combinationLength; i++)
        {
            combination.Add(possibleElements[Random.Range(0, possibleElements.Length)]);
        }

        return combination;

    }
}
