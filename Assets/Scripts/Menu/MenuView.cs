using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace CustomConsole
{
    public class MenuView : MonoBehaviour
    {
        [SerializeField] private Button _buttonStart;
        [SerializeField] private Button _settingsButton;
        [SerializeField] private Button _buyButton;
        [SerializeField] private Button _levelsButton;
        [SerializeField] private Button _settingsCloseButton;
        [SerializeField] private Button _buyCloseButton;
        [SerializeField] private Button _levelsCloseButton;
        [SerializeField] private GameObject _objMenu;
        [SerializeField] private GameObject _settingsMenu;
        [SerializeField] private GameObject _buyMenu;
        [SerializeField] private GameObject _levelsMenu;

        //[SerializeField] private Text _textStart;
        private GameObject _followObj;

        public void Init(UnityAction startGame, GameObject followObj)
        {
            _followObj = followObj;
            _buttonStart.onClick.AddListener(startGame);
            _settingsButton.onClick.AddListener(SettingsNenu);
            _buyButton.onClick.AddListener(BuyMenu);
            _levelsButton.onClick.AddListener(LevelsMenu);
            _settingsCloseButton.onClick.AddListener(CloseButton);
            _buyCloseButton.onClick.AddListener(CloseButton);
            _levelsCloseButton.onClick.AddListener(CloseButton);
        }

        private void CloseButton()
        {
            _settingsMenu.SetActive(false);
            _buyMenu.SetActive(false);
            _levelsMenu.SetActive(false);
        }

        private void LevelsMenu()
        {
            _levelsMenu.SetActive(true);
        }

        private void BuyMenu()
        {
            _buyMenu.SetActive(true);
        }

        private void SettingsNenu()
        {
            _settingsMenu.SetActive(true);
        }

        public void ClickButton()
        {
            //_buttonStart.gameObject.SetActive(false);
            _objMenu.SetActive(false);
            //_textStart.gameObject.SetActive(false);
            _followObj.SetActive(true);
        }

        protected void OnDestroy()
        {
            _buttonStart.onClick.RemoveAllListeners();
        }
    }
}
