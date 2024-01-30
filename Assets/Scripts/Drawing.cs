using UnityEngine;
using UnityEngine.UI;

public class Drawing : MonoBehaviour
{
    [SerializeField] private LineRenderer linePrefab; 
    [SerializeField] private LineColorManager lineColorManager;
    [SerializeField] private LineManager lineManager;
    [SerializeField] private Image pointSprite; 
    [SerializeField] private float depth;

    private LineRenderer _currentLine; 
    private Camera _mainCamera;

    private void Awake()
    {
        _mainCamera = Camera.main;
    }

    private void Update()
    {
        var mousePos = GetMouseWorldPosition();
        pointSprite.transform.position = mousePos;
        
        if (Input.GetMouseButtonDown(0))
        {
            CreateNewLine();
        }
        else if (Input.GetMouseButton(0))
        {
            if (_currentLine != null)
            {
                AddPointToCurrentLine();
            }
        }
    }

    private void AddPointToCurrentLine()
    {
        var mousePos = GetMouseWorldPosition();
        var positionCount = _currentLine.positionCount;
        positionCount++;
        _currentLine.positionCount = positionCount;
        _currentLine.SetPosition(positionCount - 1, mousePos);
    }

    private void CreateNewLine()
    {
        _currentLine = Instantiate(linePrefab);
        var mousePos = GetMouseWorldPosition();
        _currentLine.positionCount = 2;
        _currentLine.SetPosition(0, mousePos);
        _currentLine.SetPosition(1, mousePos);

        var currentColor = lineColorManager.GetCurrentColor();
        _currentLine.startColor = currentColor;
        _currentLine.endColor = currentColor;

        lineManager.AddLine(_currentLine);
        
        pointSprite.color = currentColor;
    }

    private Vector3 GetMouseWorldPosition()
    {
        var mousePos = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
        return new Vector3(mousePos.x, mousePos.y, depth);
    }
    public void EraseAllLines()
    {
        lineManager.EraseAllLines();
    }
}
