using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RawImage))]
public class PaintCanvas : MonoBehaviour
{
    [SerializeField] private GameObject _gameObject;
    [SerializeField] private Color _color = Color.black;
    [SerializeField] private int _size = 5;

    RectTransform rt;
    RawImage ri;
    Vector3 bottomLeft = Vector3.zero;
    Vector3 topRight = Vector3.zero;
    Texture2D canvas;

    int width = 0;
    int height = 0;

    void Start()
    {
        rt = GetComponent<RectTransform>();
        if (rt != null)
        {
            GetWorldCorners();
        }
        ri = GetComponent<RawImage>();
        if (ri != null)
        {
            CreateTexture2D();
        }
    }

    void Update()
    {
        if (rt != null)
        {
            if (ri != null)
            {
                HandleInput();
            }
        }
    }

    void HandleInput()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButton(0))
        {
            Vector2Int mousePos = Vector2Int.zero;
            ConvertMousePosition(ref mousePos);
            if (MouseIsInBounds(mousePos))
            {
                PaintTexture(mousePos, _color); // Also the color you want would be here to...
            }
        }
    }

    void PaintTexture(Vector2Int pos, Color color)
    {
        for(int y =0; y < _size; y++)
        {
            for(int x = 0; x < _size; x++)
            {
                 canvas.SetPixel(pos.x + x, pos.y + y, color);
            }
        }
        canvas.Apply(false);
    }

    bool MouseIsInBounds(Vector2Int mousePos)
    {
        if (mousePos.x >= 0 && mousePos.x < width)
        {
            if (mousePos.y >= 0 && mousePos.y < height)
            {
                return true;
            }
        }
        return false;
    }

    void ConvertMousePosition(ref Vector2Int mouseOut)
    {
        mouseOut.x = Mathf.RoundToInt(Input.mousePosition.x - bottomLeft.x);
        mouseOut.y = Mathf.RoundToInt(Input.mousePosition.y - bottomLeft.y);
    }

    void CreateTexture2D()
    {
        width = Mathf.RoundToInt(topRight.x - bottomLeft.x);
        height = Mathf.RoundToInt(topRight.y - bottomLeft.y);
        canvas = new Texture2D(width, height);
        ri.texture = canvas;
        _gameObject.GetComponent<Renderer>().material.mainTexture = canvas;
    }

    void GetWorldCorners()
    {
        if (rt != null)
        {
            Vector3[] corners = new Vector3[4];
            rt.GetWorldCorners(corners);
            bottomLeft = corners[0];
            topRight = corners[2];
        }
    }
}