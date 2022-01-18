using UnityEngine;

namespace CustomConsole
{
    internal class PaintController
    {
        private string _viewPath = "Prefabs/PaintMenu";
        private PaintMenuView _menuView;
        private GameObject _objectView;

        public PaintController()
        {
            _menuView = LoadView();
            _menuView.Init();
        }

        private PaintMenuView LoadView()
        {
            _objectView = Object.Instantiate(Resources.Load<GameObject>(_viewPath));
            return _objectView.GetComponent<PaintMenuView>();
        }

        public void Dispose()
        {
            Object.Destroy(_objectView);
        }
    }
}