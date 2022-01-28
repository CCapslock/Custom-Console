using System;
using UnityEngine;
using UnityEngine.Events;

namespace CustomConsole
{
    internal class PaintMenuController
    {
        private string _viewPath = "Prefabs/PaintMenu";
        private GameProfile _gameProfile;
        private PaintMenuView _menuView;
        private GameObject _objectView;
        private ObjectControlls _objectControlls;
        private Action<bool> ActiveInput;
        private UnityAction Refill;

        public PaintMenuController(UnityAction refill,Action<bool> activeInput,ObjectControlls objectControlls,GameProfile gameProfile)
        {
            Refill = refill;
            ActiveInput = activeInput;
            _objectControlls = objectControlls;
            _objectControlls.active = false;
            _gameProfile = gameProfile;
            _menuView = LoadView();
            _menuView.Init(Dispose,MoveOrPaint,ColorWhite, ColorYelow, ColorGreen, ColorRed, ColorBlue, ColorBlack);
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
            _gameProfile.Color = new Color(1, 0, 0, 1);
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
        private void MoveOrPaint()
        {
            _objectControlls.active = _objectControlls.active ? false : true;
            ActiveInput(!_objectControlls.active);
        }

        private PaintMenuView LoadView()
        {
            _objectView = UnityEngine.Object.Instantiate(Resources.Load<GameObject>(_viewPath));
            return _objectView.GetComponent<PaintMenuView>();
        }

        public void Dispose()
        {
            UnityEngine.Object.Destroy(_objectView);
            Refill();
        }
    }
}