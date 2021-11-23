using Painter;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartPainter : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private Button _circleButton;
    [SerializeField] private Button _stencilButton;
    [SerializeField] private Button _paintAllButton;
    [SerializeField] private Button _stopButton;
    [SerializeField] private Color _color = Color.black;
    [SerializeField] private int _size = 20;
    [SerializeField] private Collider _paintableObject;
    [SerializeField] private GameObject _stencil;

    private MainPainterController _mainPainterController;

    void Start()
    {
        _mainPainterController = new MainPainterController(_camera);
        _circleButton.onClick.AddListener(CircleButton);
        _stencilButton.onClick.AddListener(StencilButton);
        //_paintAllButton.onClick.AddListener(PaintAllButton);
        _stopButton.onClick.AddListener(StopButton);
    }

    private void StopButton()
    {
        _circleButton.gameObject.SetActive(true);
        _stencilButton.gameObject.SetActive(true);
        _paintAllButton.gameObject.SetActive(true);
        _stopButton.gameObject.SetActive(false);
        _mainPainterController.Run(PaintMode.Off);
    }

    private void PaintAllButton()
    {
        _stencil.SetActive(false);
        _circleButton.gameObject.SetActive(false);
        _stencilButton.gameObject.SetActive(false);
        _paintAllButton.gameObject.SetActive(false);
        _stopButton.gameObject.SetActive(true);
        _mainPainterController.Run(_color, PaintMode.PaintStencil, _paintableObject);
    }

    private void StencilButton()
    {
        _stencil.SetActive(true);
        _circleButton.gameObject.SetActive(false);
        _stencilButton.gameObject.SetActive(false);
        _paintAllButton.gameObject.SetActive(false);
        _stopButton.gameObject.SetActive(true);
        _mainPainterController.Run(_color, _size, PaintMode.PaintStencil);
    }

    private void CircleButton()
    {
        _stencil.SetActive(false);
        _circleButton.gameObject.SetActive(false);
        _stencilButton.gameObject.SetActive(false);
        _paintAllButton.gameObject.SetActive(false);
        _stopButton.gameObject.SetActive(true);
        _mainPainterController.Run(_color, _size, PaintMode.PaintCircle);
    }

    private void Update()
    {
        _mainPainterController.Execute();
    }
}
