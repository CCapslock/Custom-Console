using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

class DecorationView : MonoBehaviour, IDisposable
{
    [SerializeField] Button _leftButton;
    [SerializeField] Image _middle;
    [SerializeField] Button _rightButton;

    [SerializeField] Button _backButton;
    [SerializeField] Button _resetButton;
    [SerializeField] Button _doneButton;

    [SerializeField] GameObject _background;

    private Action UpdateMaterial;

    private List<DecorationMaterial> _decorationMaterials;

    public int IdMaterial => _idMaterial;

    private int _idMaterial = 0;

    private int _numMaterial = 0;

    public void Init(Action updateMaterial, UnityAction Back, UnityAction Done)
    {
        UpdateMaterial = updateMaterial;

        _backButton.onClick.AddListener(Back);
        _resetButton.onClick.AddListener(ToStartOfList);
        _doneButton.onClick.AddListener(Done);
        _leftButton.onClick.AddListener(Previous);
        _rightButton.onClick.AddListener(Next);

        _background.SetActive(false);
        _resetButton.gameObject.SetActive(false);
        _doneButton.gameObject.SetActive(false);
    }
    public void Fill(List<DecorationMaterial> decorationMaterials)
    {
        _resetButton.gameObject.SetActive(true);
        _background.SetActive(true);
        _doneButton.gameObject.SetActive(true);

        _leftButton.gameObject.SetActive(false);
        _rightButton.gameObject.SetActive(true);

        _decorationMaterials = decorationMaterials;
        _idMaterial = _decorationMaterials[0].GetId();
        _numMaterial = 0;
        
        _middle.sprite = _decorationMaterials[_numMaterial].GetSprite();
        _rightButton.image.sprite = _decorationMaterials[_numMaterial+1].GetSprite();
        
    }
    public void Hide()
    {
        _resetButton.gameObject.SetActive(false);
        _doneButton.gameObject.SetActive(false);
        _background.SetActive(false);
    }

    private void Refill()
    {
        if (_numMaterial - 1 >= 0)
        {
            if (!_leftButton.gameObject.activeSelf) _leftButton.gameObject.SetActive(true);
            _leftButton.image.sprite = _decorationMaterials[_numMaterial - 1].GetSprite();
        }
        else
        {
            _leftButton.gameObject.SetActive(false);
        }

        _middle.sprite = _decorationMaterials[_numMaterial].GetSprite();
        _idMaterial = _decorationMaterials[_numMaterial].GetId();

        if (_numMaterial + 1 <= _decorationMaterials.Count - 1)
        {
            if (!_rightButton.gameObject.activeSelf) _rightButton.gameObject.SetActive(true);
            _rightButton.image.sprite = _decorationMaterials[_numMaterial + 1].GetSprite();
        }
        else
        {
            _rightButton.gameObject.SetActive(false);
        }
        UpdateMaterial.Invoke();
    }

    private void Next()
    {
        if (_numMaterial < _decorationMaterials.Count - 1)
        {
            _numMaterial++;
            Refill();
        }
    }
    private void Previous()
    {
        if (_numMaterial > 0)
        {
            _numMaterial--;
            Refill();
        }
    }
    private void ToStartOfList()
    {
        _idMaterial = _decorationMaterials[0].GetId();
        _numMaterial = 0;
        Refill();
    }
    public void Dispose()
    {
        _backButton.onClick.RemoveAllListeners();
        _resetButton.onClick.RemoveAllListeners();
        _doneButton.onClick.RemoveAllListeners();
        _leftButton.onClick.RemoveAllListeners();
        _rightButton.onClick.RemoveAllListeners();
    }
}