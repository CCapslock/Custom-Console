using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

class ToolMenuView : MonoBehaviour, IDisposable
{
    [SerializeField] Button _backButton;

    [SerializeField] Button _brushButton;
    [SerializeField] Button _sprayButton;
    [SerializeField] Button _stikerButton;
    [SerializeField] Button _decorationButton;

    public void SetBackButton(UnityAction Back, UnityAction Destroy)
    {
        _backButton.onClick.AddListener(Back);
        _backButton.onClick.AddListener(Destroy);
    }

    public void Clear()
    {
        _brushButton.gameObject.SetActive(false);

        _sprayButton.gameObject.SetActive(false);
        _stikerButton.gameObject.SetActive(false);
        _decorationButton.gameObject.SetActive(false);
    }

    public void BackPart(UnityAction brush, UnityAction spray, UnityAction stiker)
    {
        Clear();
        _brushButton.onClick.AddListener(brush);
        _brushButton.gameObject.SetActive(true);
        _sprayButton.onClick.AddListener(spray);
        _sprayButton.gameObject.SetActive(true);
        _stikerButton.onClick.AddListener(stiker);
        _stikerButton.gameObject.SetActive(true);
    }
    public void ControllerPart(UnityAction brush, UnityAction decoration)
    {
        Clear();
        _brushButton.onClick.AddListener(brush);
        _brushButton.gameObject.SetActive(true);
        _decorationButton.onClick.AddListener(decoration);
        _decorationButton.gameObject.SetActive(true);
    }

    public void Dispose()
    {
        _backButton.onClick.RemoveAllListeners();
        _brushButton.onClick.RemoveAllListeners();
        _sprayButton.onClick.RemoveAllListeners();
        _stikerButton.onClick.RemoveAllListeners();
        _decorationButton.onClick.RemoveAllListeners();
    }
}
