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
        private FreeMode _freeMode;
        private LevelMode _levelMode;

        private Camera _camera;
        private Transform _canvas;
        private Transform _console;
        private Transform _workPlace;
        private Transform _offScreen;

        private GameObject _followObj;

        public MainController (GameProfile gameProfile, Camera camera, GameObject followObj, Transform canvas, Transform console, Transform workPlace, Transform offScreen)
        {
            _followObj = followObj;
            _camera = camera;
            _canvas = canvas;
            _console = console;
            _workPlace = workPlace;
            _offScreen = offScreen;
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

                case GameMode.FreeMode:
                    _freeMode = new FreeMode(_camera, _canvas, _console, _workPlace, _offScreen);
                    _gameProfile.AddExecuter(_freeMode);
                    break;

                case GameMode.LevelMode:
                    _levelMode = new LevelMode(); //заполнить позже
                    break;
            }
            //чистить при запуске
        }
    }
}


