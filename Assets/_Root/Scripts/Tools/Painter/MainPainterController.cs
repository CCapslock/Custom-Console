using ClearParticls;
using CustomConsole;
using SprayParticls;
using System.Collections.Generic;
using UnityEngine;

namespace Painter
{
    public class MainPainterController : IExecuter,IToolController
    {
        private Camera _camera;
        private Color _color = Color.black;
        private int _size = 20;
        private GameProfile _gameProfile;
        private PaintMode _paintMode = PaintMode.Off;
        private Collider _paintableObject;
        private PaintInputController _inputController;
        private PaintAllController _paintAllController;
        private DrawHandler _drawCircle = new DrawCircle();
        private DrawHandler _drawLine = new DrawLine();
        private List<IObserver> _observers = new List<IObserver>();
        private IObserver _clearParticle = new ClearParticleController();
        private IObserver _sprayParticle = new SprayParticleController();

        public void Active(bool active)
        {
             _inputController._active = active;
        }

        public MainPainterController(Camera camera, GameProfile gameProfile)
        {
            _camera = camera;
            _gameProfile = gameProfile;
            _inputController = new PaintInputController( _camera);
            _paintAllController = new PaintAllController();
        }
        public MainPainterController(GameProfile gameProfile, Camera camera, PaintMode paintMode)
        {
            _camera = camera;
            _paintMode = paintMode;
            _gameProfile = gameProfile;
            _inputController = new PaintInputController( _camera);
            _paintAllController = new PaintAllController();
        }

        public Vector3 Points() => _inputController.Points;
        public PaintMode PaintMode => _paintMode;

        public void Run(int size, PaintMode paintMode)
        {
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
                    _inputController.Run(1);
                    //_observers.Add(_sprayParticle);
                    _inputController.Run(1, _gameProfile, _size, _drawCircle);
                    break;

                case PaintMode.PaintLine:
                    _observers.Add(_clearParticle);
                    _inputController.Run(1, _gameProfile, _size, _drawLine, _observers);
                    break;

                case PaintMode.PaintStencil:            //Не реализовано создание трафарета
                    _observers.Add(_sprayParticle);
                    _inputController.Run(2, _gameProfile, _size, _drawCircle, _observers);
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
        public void Clear()
        {
            _inputController = null;
        }
    }
}

