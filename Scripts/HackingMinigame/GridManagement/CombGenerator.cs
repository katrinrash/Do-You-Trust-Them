using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Generates random combinations from a predefined set of elements.
/// </summary>

public class CombGenerator
{
    private readonly string[] possibleElements = { "A7", "B5", "D9", "0E" };
    private readonly int combinationLength = 4;


    public List<string> GenerateCombination()
    {
        var combination = new List<string>();

        for (int i = 0; i < combinationLength; i++)
        {
            combination.Add(possibleElements[Random.Range(0, possibleElements.Length)]);
        }

        return combination;

    }
}
