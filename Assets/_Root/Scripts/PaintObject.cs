using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintObject : MonoBehaviour
{
    [Range(5, 512)]
    [SerializeField] private int _textureSize = 128;
    [SerializeField] private TextureWrapMode _textureWrapMode;
    [SerializeField] private FilterMode _filterMode;
    [SerializeField] private Texture2D _texture;
    [SerializeField] private Material _material;

    [SerializeField] private Camera _camera;
    [SerializeField] private Collider _collider;
    [SerializeField] private Color _color = Color.black;
    [SerializeField] private int _size = 5;

    private void OnValidate()
    {
        if(_texture == null)
        {
            _texture = new Texture2D(_textureSize, _textureSize);
        }
        if(_texture.width != _textureSize)
        {
            _texture.Resize(_textureSize, _textureSize);
        }

        _texture.wrapMode = _textureWrapMode;
        _texture.filterMode = _filterMode;
        _material.mainTexture = _texture;
        _texture.Apply();
        
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;
            if(Physics.Raycast(ray, out hit, 100f))   //_collider.Raycast(ray, out hit, 100f)
            {
                int rayX = (int)(hit.textureCoord.x * _textureSize);
                int rayY = (int)(hit.textureCoord.y * _textureSize);

                Debug.Log($"{hit.textureCoord.x} - {hit.textureCoord.y}");

                for (int y = 0; y < _size; y++)
                {
                    for (int x = 0; x < _size; x++)
                    {
                        float x2 = Mathf.Pow(x - _size/2, 2);
                        float y2 = Mathf.Pow(y - _size/2, 2);
                        float r2 = Mathf.Pow(_size / 2 - 0.5f, 2);

                        if(x2 + y2 < r2)
                        {
                            _texture.SetPixel(rayX + x - _size / 2, rayY + y - _size / 2, _color);
                        }
                    }
                }
                _texture.Apply();
            }
        }
    }
}
