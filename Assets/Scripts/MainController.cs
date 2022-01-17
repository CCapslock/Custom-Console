//using Painter;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CustomConsole
{
    internal class MainController
    {
        private GameProfile _gameProfile;
        private MenuController _menuController;
        private SelectionController _selectionController;
        private Camera _camera;
        private GameObject _followObj;

        public MainController (GameProfile gameProfile, Camera camera, GameObject followObj)
        {
            _followObj = followObj;
            _camera = camera;
            _gameProfile = gameProfile;
            _gameProfile.CurrentState.SubscribeOnChange(ModeSelection);
        }

        private void ModeSelection(GameMode state)
        {
            switch (state)
            {
                case GameMode.MenuMode:
                    _menuController = new MenuController(_gameProfile, _followObj);
                    break;

                case GameMode.SelectionMode:
                    _selectionController = new SelectionController(_gameProfile);
                    _menuController.Dispose();
                    Debug.Log("SelectionMode Activated");
                    break;

                case GameMode.PaintMode:
                    _selectionController.Dispose();
                    Debug.Log("PaintMode Activated");
                    break;
            }
        }
    }
}


