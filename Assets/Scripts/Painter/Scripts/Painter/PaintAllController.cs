using UnityEngine;

namespace Painter
{
    public class PaintAllController
    {
        private Color _color;
        private Collider _paintableObject;
        private Texture2D _textureObject;

        public void Run(Color color, Collider paintableObject)
        {
            _color = color;
            _paintableObject = paintableObject;

            var txtr = (Texture2D)_paintableObject.GetComponent<Renderer>().material.mainTexture;
            _textureObject = new Texture2D(txtr.width, txtr.height);

            Paint();
        }

        private void Paint()
        {
            for (int y = 0; y < _textureObject.height; y++)
            {
                for (int x = 0; x < _textureObject.width; x++)
                {
                    _textureObject.SetPixel(x, y, _color);
                }
            }
            _textureObject.Apply();
            _paintableObject.GetComponent<Renderer>().material.mainTexture = _textureObject;
        }
    }
}