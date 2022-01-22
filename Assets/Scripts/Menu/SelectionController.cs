using UnityEngine;

namespace CustomConsole
{
    internal class SelectionController
    {
        private string _viewPath = "Prefabs/SelectionMenu";
        private GameProfile _gameProfile;
        private SelectionMenuView _menuView;
        private NintendoSwitchView _nintendoSwitchView;
        private GameObject _objectView;

        public SelectionController(GameProfile gameProfile, NintendoSwitchView nintendoSwitchView)
        {
            _nintendoSwitchView = nintendoSwitchView;
            _gameProfile = gameProfile;
            _menuView = LoadView();
            _menuView.Init(StartSpray, _nintendoSwitchView);
        }

        private void StartSpray()
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


