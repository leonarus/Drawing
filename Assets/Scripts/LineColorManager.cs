using UnityEngine;

public class LineColorManager : MonoBehaviour
{
    [SerializeField] private Color[] lineColors =  { Color.blue,Color.yellow, Color.green,Color.red, Color.white, };
    private int _currentColorIndex = -1;

    public Color GetCurrentColor()
    {
        return _currentColorIndex < 0 ? Color.clear : lineColors[_currentColorIndex];
    }

    public void ChangeColorIndex(int colorIndex)
    {
        _currentColorIndex = colorIndex;
    }
}