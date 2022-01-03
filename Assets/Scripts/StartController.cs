using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CustomConsole
{
    public class StartController : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private Button _start;
        [SerializeField] private GameObject _followObj;

        private GameProfile _gameProfile;
        private MainController _mainController;
        
        private void Awake()
        {
            _gameProfile = new GameProfile();
            _mainController = new MainController(_gameProfile, _camera);
            _start.onClick.AddListener(StartGame);
        }

        private void StartGame()
        {
            _start.gameObject.SetActive(false);
            _followObj.SetActive(true);
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


