using UnityEngine;

namespace CustomConsole
{
    internal class SelectionController
    {
        private string _viewPath = "Prefabs/SelectionMenu";
        private GameProfile _gameProfile;
        private SelectionMenuView _menuView;
        private GameObject _objectView;

        public SelectionController(GameProfile gameProfile)
        {
            GameObject followObj = null;   //позже изменить
            _gameProfile = gameProfile;
            _menuView = LoadView();
            _menuView.Init(StartGame, followObj);
        }

        private void StartGame()
        {
            _menuView.ClickButton();
            _gameProfile.CurrentState.Value = GameMode.PaintMode;
        }

        private SelectionMenuView LoadView()
        {
            _objectView = Object.Instantiate(Resources.Load<GameObject>(_viewPath));
            return _objectView.GetComponent<SelectionMenuView>();
        }

        public void Dispose()
        {
            Object.Destroy(_objectView);
        }
    }
}


