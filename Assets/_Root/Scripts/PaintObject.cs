using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintObject : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private Color _color = Color.blue;
    [SerializeField] private int _size = 5;

    private int _textureSize = 500;
    private Texture2D _texture;
    private Color[] _colorTexture;

    private void Start()
    {
        _texture = new Texture2D(_textureSize, _textureSize);
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100f))
            {
                if (_colorTexture == null)
                {
                    var txtr = (Texture2D)hit.collider.GetComponent<Renderer>().material.mainTexture;
                    _colorTexture = txtr.GetPixels(0);
                    _texture.SetPixels(_colorTexture, 0);
                }

                int rayX = (int)(hit.textureCoord.x * _textureSize);
                int rayY = (int)(hit.textureCoord.y * _textureSize);

                DrowCircle(rayX, rayY, hit);
            }
        }
    }

    private void DrowCircle(int rayX, int rayY, RaycastHit hit)
    {
        for (int y = 0; y < _size; y++)
        {
            for (int x = 0; x < _size; x++)
            {
                float x2 = Mathf.Pow(x - _size / 2, 2);
                float y2 = Mathf.Pow(y - _size / 2, 2);
                float r2 = Mathf.Pow(_size / 2 - 0.5f, 2);

                if (x2 + y2 < r2)
                {
                    _texture.SetPixel(rayX + x - _size / 2, rayY + y - _size / 2, _color);
                }
            }
        }
        _texture.Apply();
        hit.collider.GetComponent<Renderer>().material.mainTexture = _texture;
    }
}
