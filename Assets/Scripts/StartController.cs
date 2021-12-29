using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CustomConsole
{
    public class StartController : MonoBehaviour
    {
        [SerializeField] private Camera _camera;

        private GameProfile _gameProfile;
        private List<IExecuter> _executers = new List<IExecuter>();
        private MainController _mainController;
        
        private void Awake()
        {
            _gameProfile = new GameProfile();
            _mainController = new MainController(_gameProfile, _camera);
        }

        private void Update()
        {
            if(_gameProfile.Executers != null)
            {
                foreach (IExecuter executer in _gameProfile.Executers)
                {
                    executer.Execute();
                }
            }
        }
    }
}


