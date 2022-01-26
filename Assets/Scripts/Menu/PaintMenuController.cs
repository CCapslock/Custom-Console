using UnityEngine;
using UnityEngine.Events;

namespace CustomConsole
{
    internal class PaintMenuController
    {
        private string _viewPath = "Prefabs/PaintMenu";
        private GameProfile _gameProfile;
        private PaintMenuModel _menuView;
        private GameObject _objectView;

        public PaintMenuController(GameProfile gameProfile)
        {
            _gameProfile = gameProfile;
            _menuView = LoadView();
            _menuView.Init(ColorWhite, ColorYelow, ColorGreen, ColorRed, ColorBlue, ColorBlack);
        }

        private void ColorBlack()
        {
            _gameProfile.Color = new Color(0, 0, 0, 1);
        }

        private void ColorBlue()
        {
            _gameProfile.Color = new Color(0, 0.2880645f, 1, 1);
        }

        private void ColorRed()
        {
            _gameProfile.Color = new Color(0, 0, 0.1469479f, 1);
        }

        private void ColorGreen()
        {
            _gameProfile.Color = new Color(0.05993233f, 0.8584906f, 0.2500702f, 1);
        }

        private void ColorYelow()
        {
            _gameProfile.Color = new Color(0.9668521f, 1, 0, 1);
        }

        private void ColorWhite()
        {
            _gameProfile.Color = new Color(1, 1, 1, 1);
        }

        private PaintMenuModel LoadView()
        {
            _objectView = Object.Instantiate(Resources.Load<GameObject>(_viewPath));
            return _objectView.GetComponent<PaintMenuModel>();
        }

        public void Dispose()
        {
            Object.Destroy(_objectView);
        }
    }
}