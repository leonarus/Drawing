using System.Collections.Generic;
using UnityEngine;

public class LineManager : MonoBehaviour
{
    private readonly List<LineRenderer> _createdLines = new();

    public void AddLine(LineRenderer line)
    {
        _createdLines.Add(line);
    }

    public void EraseAllLines()
    {
        _createdLines.ForEach(line => Destroy(line.gameObject));
        _createdLines.Clear();
    }
}