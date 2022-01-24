using System;
using UnityEngine;
using UnityEngine.Events;
using Object = UnityEngine.Object;
using Painter;
using CustomConsole;

class ToolMenu
{
    ToolMenuView _view;
    IToolController _toolController;
    readonly Transform _canvas;
    UnityAction _back;
    readonly Camera _camera;
    IPart _part;
    ObjectControlls _objectControlls;
    GameProfile _gameProfile;
    PaintMenuController _paintController;

    public ToolMenu(GameProfile gameProfile, ObjectControlls objectControlls, Camera camera, Transform canvas, UnityAction backToConsole)
    {
        _gameProfile = gameProfile;
        _objectControlls = objectControlls;
        _camera = camera;
        _canvas = canvas;
        _back = backToConsole;
    }
    public void Action()
    {
        if (_toolController != null) _toolController.Execute();
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
        _paintController = new PaintMenuController(_gameProfile);
        MainPainterController paint = new MainPainterController(_camera, PaintMode.PaintCircle);
        paint.Run(50, PaintMode.PaintCircle);
        _toolController = paint;
    }
    public void SetSprayTool()
    {
        Clear();
        //выбор графити
        _toolController = new MainPainterController(_camera, PaintMode.PaintStencil);
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
        _paintController = null;
        if (_view != null) Object.Destroy(_view.gameObject);
        if (_toolController != null)
        {
            _toolController.Clear();
            _toolController = null;
        }
    }
}