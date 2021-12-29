using Painter;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CustomConsole
{
    public class MainController : MonoBehaviour
    {
        private GameMode _gameMode = GameMode.MenuMode;
        private GameProfile _gameProfile;
        private IExecuter _mainPainterController;
        private Camera _camera;

        public MainController (GameProfile gameProfile, Camera camera)
        {
            _camera = camera;
            _gameProfile = gameProfile;
            _mainPainterController = new MainPainterController(_camera);
            _gameProfile.Executers.Add(_mainPainterController);
        }

        public void Run(GameMode gameMode)
        {
            _gameMode = gameMode;
            ModeSelection();
        }

        private void ModeSelection()
        {
            switch (_gameMode)
            {
                case GameMode.MenuMode:
                    break;

                case GameMode.SelectionMode:
                    break;

                case GameMode.PaintMode:
                    break;
            }
        }
    }
}


