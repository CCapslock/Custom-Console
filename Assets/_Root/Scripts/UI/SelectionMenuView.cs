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
        [SerializeField] private Button _settingsCloseButton;
        [SerializeField] private Button _sprayButton;
        [SerializeField] private GameObject _objMenu;
        [SerializeField] private GameObject _settingsMenu;
        [SerializeField] private GameObject _paintMenu;
        [SerializeField] private GameObject _selectionObjMenu;
        [SerializeField] private SelectionMenuGrid _selectionMenuGrid;

        private NintendoSwitchView _nintendoSwitchView;

        public void Init(UnityAction startSpray, NintendoSwitchView nintendoSwitchView)
        {
            _nintendoSwitchView = nintendoSwitchView;
            //_buttonStart.onClick.AddListener(startGame);
            _buttonStart.onClick.AddListener(SelecMode);
            _settingsButton.onClick.AddListener(SettingsNenu);
            _settingsCloseButton.onClick.AddListener(CloseButton);
            _sprayButton.onClick.AddListener(startSpray);
            InsertIcons();
        }

        private void InsertIcons()
        {
            for(int i = 0; i < _nintendoSwitchView.ObjImg.Count; i++)
            {
                _selectionMenuGrid.ImgObj[i].gameObject.SetActive(true);
                _selectionMenuGrid.ImgObj[i].sprite = _nintendoSwitchView.ObjImg[i];
            }

        }

        private void SelecMode()
        {
            _buttonStart.gameObject.SetActive(false);
            _selectionObjMenu.SetActive(true);
            //_paintMenu.SetActive(true);
        }

        private void CloseButton()
        {
            _settingsMenu.SetActive(false);
        }

        private void SettingsNenu()
        {
            _settingsMenu.SetActive(true);
        }

        public void ClickButton()
        {
            _objMenu.SetActive(false);
        }

        protected void OnDestroy()
        {
            _buttonStart.onClick.RemoveAllListeners();
        }
    }
}