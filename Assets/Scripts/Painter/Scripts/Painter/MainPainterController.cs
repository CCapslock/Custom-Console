using ClearParticls;
using SprayParticls;
using System.Collections.Generic;
using UnityEngine;

namespace Painter
{
    public class MainPainterController : IExecuter
    {
        private Camera _camera;
        private Color _color = Color.black;
        private int _size = 20;
        private PaintMode _paintMode = PaintMode.Off;
        private Collider _paintableObject;
        private PaintInputController _inputController;
        private PaintAllController _paintAllController;
        private DrawHandler _drawCircle = new DrawCircle();
        private DrawHandler _drawLine = new DrawLine();
        private List<IObserver> _observers = new List<IObserver>();
        private IObserver _clearParticle = new ClearParticleController();
        private IObserver _sprayParticle = new SprayParticleController();

        public MainPainterController(Camera camera)
        {
            _camera = camera;
            _inputController = new PaintInputController(_camera);
            _paintAllController = new PaintAllController();
        }

        public Vector3 Points() => _inputController.Points;
        public PaintMode PaintMode => _paintMode;

        public void Run(PaintMode paintMode)
        {
            _paintMode = paintMode;
            ModeSelection();
        }

        public void Run(Color color, PaintMode paintMode, Collider paintableObject) //удалить?
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
                    _observers.Clear();
                    break;

                case PaintMode.PaintAll:
                    _paintAllController.Run(_color, _paintableObject);
                    break;

                case PaintMode.PaintCircle:
                    //_observers.Add(_sprayParticle);
                    _inputController.Run(1, _color, _size, _drawCircle);
                    break;

                case PaintMode.PaintLine:
                    _observers.Add(_clearParticle);
                    _inputController.Run(1, _color, _size, _drawLine, _observers);
                    break;

                case PaintMode.PaintStencil:            //Не реализовано создание трафарета
                    _observers.Add(_sprayParticle);
                    _inputController.Run(2, _color, _size, _drawCircle, _observers);
                    break;
            }
        }

        public void Execute()
        {
            if (_paintMode == PaintMode.PaintCircle || _paintMode == PaintMode.PaintStencil || _paintMode == PaintMode.PaintLine)
            {
                _inputController.Execute();
            }
        }
    }
}

