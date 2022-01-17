using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace CustomConsole
{
    public class SelectionMenuView : MonoBehaviour
    {
        [SerializeField] private Button _buttonStart;
        [SerializeField] private Button _settingsButton;
        [SerializeField] private Button _buyButton;
        [SerializeField] private Button _settingsCloseButton;
        [SerializeField] private Button _buyCloseButton;
        [SerializeField] private GameObject _objMenu;
        [SerializeField] private GameObject _settingsMenu;
        [SerializeField] private GameObject _buyMenu;
        [SerializeField] private GameObject _paintMenu;

        private GameObject _followObj;

        public void Init(UnityAction startGame, GameObject followObj)
        {
            _followObj = followObj;
            //_buttonStart.onClick.AddListener(startGame);
            _buttonStart.onClick.AddListener(SelecMode);
            _settingsButton.onClick.AddListener(SettingsNenu);
            _buyButton.onClick.AddListener(BuyMenu);
            _settingsCloseButton.onClick.AddListener(CloseButton);
            _buyCloseButton.onClick.AddListener(CloseButton);
        }

        private void SelecMode()
        {
            _buttonStart.gameObject.SetActive(false);
            _paintMenu.SetActive(true);
        }

        private void CloseButton()
        {
            _settingsMenu.SetActive(false);
            _buyMenu.SetActive(false);
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
            _objMenu.SetActive(false);
            //_followObj.SetActive(true);
        }

        protected void OnDestroy()
        {
            _buttonStart.onClick.RemoveAllListeners();
        }
    }
}