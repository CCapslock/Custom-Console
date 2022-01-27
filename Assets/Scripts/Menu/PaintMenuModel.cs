using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace CustomConsole
{
    public class PaintMenuModel : MonoBehaviour
    {
        [SerializeField] private Button _buttonFinish;
        [SerializeField] private Button _settingsButton;
        [SerializeField] private Button _whiteButton;
        [SerializeField] private Button _yelowButton;
        [SerializeField] private Button _greenButton;
        [SerializeField] private Button _redButton;
        [SerializeField] private Button _blueButton;
        [SerializeField] private Button _blackButton;
        [SerializeField] private GameObject _settingsMenu;

        private NintendoSwitchView _nintendoSwitchView;

        public void Init(UnityAction FinishGame, UnityAction ColorWhite, UnityAction ColorYelow, UnityAction ColorGreen, UnityAction ColorRed, UnityAction ColorBlue, UnityAction ColorBlack, NintendoSwitchView nintendoSwitchView)
        {
            _nintendoSwitchView = nintendoSwitchView;
            _buttonFinish.onClick.AddListener(FinishGame);
            _settingsButton.onClick.AddListener(SettingsNenu);
            _whiteButton.onClick.AddListener(ColorWhite);
            _yelowButton.onClick.AddListener(ColorYelow);
            _greenButton.onClick.AddListener(ColorGreen);
            _redButton.onClick.AddListener(ColorRed);
            _blueButton.onClick.AddListener(ColorBlue);
            _blackButton.onClick.AddListener(ColorBlack);
        }

        public void FinishButton()
        {
            for(int i = 0; i < _nintendoSwitchView.Obj.Count; i++)
            {
                _nintendoSwitchView.Obj[i].GetComponent<Renderer>().material.mainTexture = 
                    _nintendoSwitchView.ObjEdit[i].GetComponent<Renderer>().material.mainTexture;
                _nintendoSwitchView.Obj[i].SetActive(true);
                _nintendoSwitchView.ObjEdit[i].SetActive(false);
            }
        }

        private void SettingsNenu()
        {
            _settingsMenu.SetActive(true);
        }
    }
}
