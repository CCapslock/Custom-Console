using UnityEngine;

namespace Painter
{
    public class MainPainterController
    {
        private Camera _camera;
        private Color _color = Color.black;
        private int _size = 20;
        private PaintMode _paintMode = PaintMode.Off;
        private Collider _paintableObject;
        private PaintInputController _inputController;
        private DrawHandler _drawCircle = new DrawCircle();
        private int _num = 0;

        public MainPainterController(Camera camera)
        {
            _camera = camera;
            _inputController = new PaintInputController(_camera);
        }

        public Vector3 Points()
        {
            return _inputController.Points;
        }

        public void Run(PaintMode paintMode)
        {
            _paintMode = paintMode;
            ModeSelection();
        }

        public void Run(Color color, PaintMode paintMode, Collider paintableObject)
        {
            _color = color;
            _paintMode = paintMode;
            _paintableObject = paintableObject;
            ModeSelection();
        }

        public void Run(Color color, int size, PaintMode paintMode)
        {
            _color = color;
            _paintMode = paintMode;
            _size = size;
            ModeSelection();
        }

        private void ModeSelection()
        {
            switch (_paintMode)
            {
                case PaintMode.Off:
                    _inputController.Run(0);
                    _num = 0;
                    break;

                case PaintMode.PaintAll:
                    _num = 0;
                    break;

                case PaintMode.PaintCircle:
                    _inputController.Run(1, _color, _size, _drawCircle);
                    _num = 1;
                    break;

                case PaintMode.PaintStencil:            //Не реализовано создание трафарета
                    _inputController.Run(2, _color, _size, _drawCircle);
                    _num = 2;
                    break;
            }
        }

        public void Execute()
        {
            if (_num != 0)
            {
                _inputController.Execute();
            }
        }
    }
}

