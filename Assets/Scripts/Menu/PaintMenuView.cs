using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace CustomConsole
{
    public class PaintMenuView : MonoBehaviour
    {
        [SerializeField] private Button _settingsButton;
        [SerializeField] private Button _whiteButton;
        [SerializeField] private Button _yelowButton;
        [SerializeField] private Button _greenButton;
        [SerializeField] private Button _redButton;
        [SerializeField] private Button _blueButton;
        [SerializeField] private Button _blackButton;
        [SerializeField] private GameObject _settingsMenu;

        public void Init(UnityAction ColorWhite, UnityAction ColorYelow, UnityAction ColorGreen, UnityAction ColorRed, UnityAction ColorBlue, UnityAction ColorBlack)
        {
            _settingsButton.onClick.AddListener(SettingsNenu);
            _whiteButton.onClick.AddListener(ColorWhite);
            _yelowButton.onClick.AddListener(ColorYelow);
            _greenButton.onClick.AddListener(ColorGreen);
            _redButton.onClick.AddListener(ColorRed);
            _blueButton.onClick.AddListener(ColorBlue);
            _blackButton.onClick.AddListener(ColorBlack);
        }

        private void SettingsNenu()
        {
            _settingsMenu.SetActive(true);
        }
    }
}
