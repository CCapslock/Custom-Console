using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

class PartMenuView : MonoBehaviour, IDisposable
{
    [SerializeField] Button _backButton;

    public void Init(UnityAction BackToMenu)
    {
        _backButton.onClick.AddListener(BackToMenu);
    }

    public void Dispose()
    {
        _backButton.onClick.RemoveAllListeners();
    }
}
