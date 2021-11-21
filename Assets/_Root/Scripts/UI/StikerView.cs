using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

class StikerView : MonoBehaviour,IDisposable
{
    [SerializeField] float _stikerSize;
    [SerializeField] float _stikerRotation;
    [SerializeField] Button _backButton;
    public int IdStiker => _idStiker; 

    private int _idStiker;

    public void Init(GameObject[] stikers, UnityAction Back, UnityAction Destroy)
    {
        _backButton.onClick.AddListener(Back); 
        _backButton.onClick.AddListener(Destroy);

        //получить пример UI, на его основе сделать заполнение меню выбора
    }

    public void Dispose()
    {
        _backButton.onClick.RemoveAllListeners();
    }
}