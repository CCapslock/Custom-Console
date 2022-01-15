using UnityEngine;
using UnityEngine.UI;

namespace CustomConsole
{
    public class StartController : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private GameObject _followObj;
        [SerializeField] private Transform _canvas;
        [SerializeField] private Transform _console;
        [SerializeField] private Transform _workPlace;
        [SerializeField] private Transform _offScreen;

        private GameProfile _gameProfile;
        private MainController _mainController;

        private void Awake()
        {
            _gameProfile = new GameProfile();
            _mainController = new MainController(_gameProfile, _camera, _followObj, _canvas, _console, _workPlace, _offScreen);
            _gameProfile.CurrentState.Value = GameMode.MenuMode;
        }

        private void Update()
        {
            if (_gameProfile.Executers != null)
            {
                foreach (IExecuter executer in _gameProfile.Executers)
                {
                    executer.Execute();
                }
            }
        }
    }
}