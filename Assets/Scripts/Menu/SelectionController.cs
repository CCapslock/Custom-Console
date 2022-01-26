using UnityEngine;

namespace CustomConsole
{
    internal class SelectionController
    {
        private string _viewPath = "Prefabs/SelectionMenu";
        private GameProfile _gameProfile;
        private SelectionMenuModel _menuView;
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

        private SelectionMenuModel LoadView()
        {
            _objectView = Object.Instantiate(Resources.Load<GameObject>(_viewPath));
            return _objectView.GetComponent<SelectionMenuModel>();
        }

        public void Dispose()
        {
            Object.Destroy(_objectView);
        }
    }
}


