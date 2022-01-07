using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CustomConsole
{
    internal class MenuController
    {
        private string _viewPath = "Prefabs/Menu";
        private GameProfile _gameProfile;
        private MenuView _menuView;

        public MenuController(GameProfile gameProfile, GameObject followObj)
        {
            _gameProfile = gameProfile;
            _menuView = LoadView();
            _menuView.Init(StartGame, followObj);
        }

        private void StartGame()
        {
            _menuView.ClickButton();
            _gameProfile.CurrentState.Value = GameMode.SelectionMode;
        }

        private MenuView LoadView()
        {
            GameObject objectView = Object.Instantiate(Resources.Load<GameObject>(_viewPath));
            return objectView.GetComponent<MenuView>();
        }

    }
}


