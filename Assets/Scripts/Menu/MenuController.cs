using UnityEngine;

namespace CustomConsole
{
    internal class MenuController
    {
        private string _viewPath = "Prefabs/Menu";
        private GameProfile _gameProfile;
        private MenuView _menuView;
        private GameObject _objectView;

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
            _objectView = Object.Instantiate(Resources.Load<GameObject>(_viewPath));
            return _objectView.GetComponent<MenuView>();
        }

        public void Dispose()
        {
            Object.Destroy(_objectView);
        }
    }
}


