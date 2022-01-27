//using Painter;
using Painter;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CustomConsole
{
    internal class MainController
    {
        private string _viewPath = "Prefabs/NintendoSwitch";
        private NintendoSwitchView _nintendoSwitchView;
        private GameProfile _gameProfile;
        private MenuController _menuController;
        private SelectionController _selectionController;
        private PaintMenuController _paintController;
        private MainPainterController _mainPainterController;
        private Camera _camera;
        private GameObject _followObj;
        private GameObject _objectView;

        public MainController (GameProfile gameProfile, Camera camera, GameObject followObj)
        {
            _followObj = followObj;
            _camera = camera;
            _gameProfile = gameProfile;
            _gameProfile.CurrentState.SubscribeOnChange(ModeSelection);
            _mainPainterController = new MainPainterController(_camera, _gameProfile);
            _gameProfile.Executers.Add(_mainPainterController);
            _nintendoSwitchView = LoadView();
        }

        private NintendoSwitchView LoadView()
        {
            _objectView = UnityEngine.Object.Instantiate(Resources.Load<GameObject>(_viewPath));
            return _objectView.GetComponent<NintendoSwitchView>();
        }

        private void ModeSelection(GameMode state)
        {
            switch (state)
            {
                case GameMode.MenuMode:
                    _menuController = new MenuController(_gameProfile, _followObj);
                    _selectionController?.Dispose();
                    _paintController?.Dispose();
                    _mainPainterController.Run(50, PaintMode.Off);
                    break;

                case GameMode.SelectionMode:
                    _selectionController = new SelectionController(_gameProfile, _nintendoSwitchView);
                    _menuController?.Dispose();
                    _paintController?.Dispose();
                    _mainPainterController.Run(50, PaintMode.Off);
                    break;

                case GameMode.PaintMode:
                    _paintController = new PaintMenuController(_gameProfile, _nintendoSwitchView);
                    _mainPainterController.Run(50, PaintMode.PaintCircle);
                    _menuController?.Dispose();
                    _selectionController.Dispose();
                    break;
            }
        }
    }
}


