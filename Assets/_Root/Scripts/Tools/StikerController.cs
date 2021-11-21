using UnityEngine;
using UnityEngine.Events;

class StikerController : IToolController
{
    private StikerView _view;
    private Stikers _stikersData;
    private Camera _camera;
    public StikerController (Camera camera, Transform canvas, UnityAction back)
    {
        _stikersData = (Stikers)Resources.Load("ScriptableObjects/Stikers");
        var viewObject = Resources.Load<GameObject>("UI/StikerView");
        _view = Object.Instantiate(viewObject, canvas).GetComponent<StikerView>();
        _view.Init(_stikersData._stikers,back,Clear);
        _camera = camera;
    }
    public void Action() 
    {
        Touch touch = Input.GetTouch(0);
        switch (touch.phase)
        {
            case TouchPhase.Began:
                Ray ray = _camera.ScreenPointToRay(touch.position);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, 10))
                {
                    var stiker = Object.Instantiate(_stikersData.Get(_view.IdStiker), hit.transform);
                    stiker.transform.position = hit.point;
                    // стикер должен огибать деталь
                    // применить измение размера и вращения;
                }
                break;
        }
    }
    public void Clear()
    {
        Object.Destroy(_view.gameObject);
    }
}
