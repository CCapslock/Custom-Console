using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

class StikerView : MonoBehaviour,IDisposable
{
    [SerializeField] Button _leftButton;
    [SerializeField] Image _middle;
    [SerializeField] Button _rightButton;

    [SerializeField] Button _backButton;
    [SerializeField] Button _resetButton;

    [SerializeField] Slider _sizeSlider;
    [SerializeField] Slider _rotationSlider;

    private Action UpdateStiker;

    private Stikers _stikers;

    public int IdStiker => _idStiker; 

    private int _idStiker = 0;

    public void Init(Stikers stikers, 
        Action updateStiker,
        UnityAction<float> SizeUpdate, 
        UnityAction<float> RotationUpdate,
        UnityAction Back,
        UnityAction Destroy)
    {
        _stikers = stikers;

        UpdateStiker = updateStiker;

        _backButton.onClick.AddListener(Back); 
        _backButton.onClick.AddListener(Destroy);
        _resetButton.onClick.AddListener(ResetID); 
        _leftButton.onClick.AddListener(Previous);
        _rightButton.onClick.AddListener(Next);

        _sizeSlider.onValueChanged.AddListener(SizeUpdate);
        _rotationSlider.onValueChanged.AddListener(RotationUpdate);
        Refill();
    }
    private void Refill()
    {
        if (_idStiker - 1 >= 0)
        {
            if (!_leftButton.gameObject.activeSelf) _leftButton.gameObject.SetActive(true);
            _leftButton.image.sprite = _stikers.GetStiker(_idStiker - 1).GetSprite();
        }
        else
        {
            _leftButton.gameObject.SetActive(false);
        }

        _middle.sprite = _stikers.GetStiker(_idStiker).GetSprite();

        if (_idStiker + 1 <= _stikers.Lenght - 1)
        {
            if (!_rightButton.gameObject.activeSelf) _rightButton.gameObject.SetActive(true);
            _rightButton.image.sprite = _stikers.GetStiker(_idStiker + 1).GetSprite();
        }
        else
        {
            _rightButton.gameObject.SetActive(false);
        }
        UpdateStiker.Invoke();
    }
    private void Next()
    {
        if (_idStiker < _stikers.Lenght - 1)
        {
            _idStiker++;
            Refill();
        }
    }
    private void Previous()
    {
        if (_idStiker > 0)
        {
            _idStiker--;
            Refill();
        }
    }
    private void ResetID()
    {
        _idStiker = 0;
        Refill();
    }

    public void Dispose()
    {
        _backButton.onClick.RemoveAllListeners();
        _leftButton.onClick.RemoveAllListeners();
        _resetButton.onClick.RemoveAllListeners();
        _rightButton.onClick.RemoveAllListeners();
        _sizeSlider.onValueChanged.RemoveAllListeners();
        _rotationSlider.onValueChanged.RemoveAllListeners();
    }
}