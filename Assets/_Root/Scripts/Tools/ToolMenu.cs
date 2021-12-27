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
    IPart _part;
    ObjectControlls _objectControlls;

    public ToolMenu(ObjectControlls objectControlls, Camera camera, Transform canvas, UnityAction backToConsole)
    {
        _objectControlls = objectControlls;
        _camera = camera;
        _canvas = canvas;
        _back = backToConsole;
    }
    public void Action()
    {
        if (_toolController != null) _toolController.Action();
    }

    public void Fill(IPart part)
    {
        _part = part;
        var viewObject = Resources.Load<GameObject>("UI/ToolMenu");
        _view = Object.Instantiate(viewObject, _canvas).GetComponent<ToolMenuView>();
        _view.SetBackButton(Clear,_back);
        switch (_part.Type)
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
                    SetDecorationTool);
                break;
        }        
    }
    public void Refill()
    {
        Clear();
        Fill(_part);
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
        _objectControlls.TurnToBack();
        _toolController = new StikerController(_objectControlls,_camera, _canvas, Refill);
    }
    public void SetDecorationTool()
    {
        Clear();
        _objectControlls.active = false;
        _toolController = new DecorationController(_part,_camera,_canvas,Refill);
    }
    public void Clear()
    {
        _objectControlls.active = true;
        _objectControlls.SetRotation();
        _objectControlls.ReturnControllToOriginal();
        _objectControlls.ClearRotation();
        if (_view != null) Object.Destroy(_view.gameObject);
        if (_toolController != null)
        {
            _toolController.Clear();
            _toolController = null;
        }
    }
}