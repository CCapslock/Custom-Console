using UnityEngine;

namespace Painter
{
    public class PaintInputController
    {
        private Camera _camera;
        private Color _color = Color.black;
        private int _size = 20;
        private DrawHandler _drawCircle;
        private bool BoolRaycast;

        private int _num = 0;
        private RaycastHit hit;
        private RaycastHit[] hits;
        private Texture2D _textureStencil;
        private Texture2D _textureObject;
        private int stencilRayX;
        private int stencilRayY;
        private int objectRayX;
        private int objectRayY;

        public Vector3 Points => hit.point;

        public PaintInputController(Camera camera)
        {
            _camera = camera;
        }

        public void Run(int Num)
        {
            _num = Num;
        }

        public void Run(int Num, Color color, int size, DrawHandler drawCircle)
        {
            _drawCircle = drawCircle;
            _num = Num;
            _color = color;
            _size = size;
            hits = new RaycastHit[_num];
            if(_num == 0)
            {
                hits = null;
                _textureStencil = null;
                _textureObject = null;
                stencilRayX = 0;
                stencilRayY = 0;
                objectRayX = 0;
                objectRayY = 0;
            }
        }

        public void Execute()
        {
            if (Input.GetMouseButton(0))
            {
                Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

                //RaycastHit hit;

                for (int i = 0; i < _num; i++)
                {
                    BoolRaycast = Physics.Raycast(ray, out hit, 100f);
                    if (BoolRaycast)
                    {
                        if (_num > 1)
                        {
                            if (hit.collider.CompareTag("Stencil"))
                            {
                                hits[0] = hit;
                                hits[0].collider.enabled = false;
                            }
                            if (hit.collider.CompareTag("Object"))
                            {
                                if (hits[0].collider.tag == "Stencil")
                                {
                                    hits[1] = hit;
                                    hits[0].collider.enabled = true;
                                }
                            }
                        }
                        else
                        {
                            hits[0] = hit;
                        }
                    }
                }

                for (int i = 0; i < _num; i++)
                {
                    if (BoolRaycast)
                    {
                        if (hits[i].collider.CompareTag("Stencil"))
                        {
                            if (_textureStencil == null)
                            {
                                var txtr = (Texture2D)hits[i].collider.GetComponent<Renderer>().material.mainTexture;
                                var _colorTextureStencil = txtr.GetPixels(0);
                                _textureStencil = new Texture2D(txtr.width, txtr.height);
                                _textureStencil.SetPixels(_colorTextureStencil, 0);
                            }

                            stencilRayX = (int)(hits[i].textureCoord.x * _textureStencil.width);
                            stencilRayY = (int)(hits[i].textureCoord.y * _textureStencil.height);
                        }

                        if (hits[i].collider.CompareTag("Object"))
                        {
                            if (_textureObject == null)
                            {
                                var txtr = (Texture2D)hits[i].collider.GetComponent<Renderer>().material.mainTexture;
                                var _colorTextureObject = txtr.GetPixels(0);
                                _textureObject = new Texture2D(txtr.width, txtr.height);
                                _textureObject.SetPixels(_colorTextureObject, 0);
                            }

                            objectRayX = (int)(hits[i].textureCoord.x * _textureObject.width);
                            objectRayY = (int)(hits[i].textureCoord.y * _textureObject.height);
                        }
                    }
                }
                if (BoolRaycast) Draw();
            }
        }

        private void Draw()
        {
            BoolRaycast = false;
            for (int x = 0; x < _size; x++)
            {
                for (int y = 0; y < _size; y++)
                {
                    if (_drawCircle.Check(x, y, _size))
                    {
                        if (_textureStencil != null)
                        {
                            if (_textureStencil.GetPixel(stencilRayX + x - _size / 2, stencilRayY + y - _size / 2).a != 0)
                            {
                                _textureStencil.SetPixel(stencilRayX + x - _size / 2, stencilRayY + y - _size / 2, _color);
                            }
                            else
                            {
                                _textureObject.SetPixel(objectRayX + x - _size / 2, objectRayY + y - _size / 2, _color);
                            }
                        }
                        else
                        {
                            _textureObject.SetPixel(objectRayX + x - _size / 2, objectRayY + y - _size / 2, _color);
                        }
                    }
                }
            }

            if (_textureStencil != null)
            {
                _textureStencil.Apply();
                _textureObject.Apply();
            }
            else
            {
                _textureObject.Apply();
            }


            foreach (var hit in hits)
            {
                if (hit.collider.CompareTag("Stencil"))
                {
                    hit.collider.GetComponent<Renderer>().material.mainTexture = _textureStencil;
                }
                if (hit.collider.CompareTag("Object"))
                {
                    hit.collider.GetComponent<Renderer>().material.mainTexture = _textureObject;
                }
            }
        }
    }
}