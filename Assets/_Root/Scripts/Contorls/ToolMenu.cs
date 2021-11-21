using System;
using UnityEngine;
using UnityEngine.Events;
using Object = UnityEngine.Object;

class ToolMenu
{
    ToolMenuView _view;
    IToolController _toolController;
    readonly Transform _canvas;
    UnityAction _back;
    readonly Camera _camera;
    PartType _partType;

    public ToolMenu(Camera camera, Transform canvas, UnityAction backToConsole)
    {
        _camera = camera;
        _canvas = canvas;
        _back = backToConsole;
    }
    public void Action()
    {
        if (_toolController != null) _toolController.Action();
    }

    public void Fill(PartType type)
    {
        _partType = type;
        var viewObject = Resources.Load<GameObject>("UI/ToolMenu");
        _view = Object.Instantiate(viewObject, _canvas).GetComponent<ToolMenuView>();
        _view.SetBackButton(_back,Clear);
        switch (type)
        {
            case PartType.Back:
                _view.BackPart(
                   SetBrushTool,
                    SetSprayTool,
                    SetStikerTool);
                break;
            case PartType.Controller:
                _view.ControllerPart(
                    SetBrushTool,
                    SetStikerTool,
                    SetDecorationTool);
                break;
        }        
    }
    public void Refill()
    {
        Fill(_partType);
    }
    public void SetBrushTool()
    {
        Clear();
        _toolController = null;
    }
    public void SetSprayTool()
    {
        Clear();
        _toolController = null;
    }
    public void SetStikerTool()
    {
        Clear();
        _toolController = new StikerController(_camera, _canvas, Refill);                
    }
    public void SetDecorationTool()
    {
        Clear();
        _toolController = null;
    }
    public void Clear()
    {
        Object.Destroy(_view.gameObject);
        if(_toolController != null) _toolController.Clear();
    }
}