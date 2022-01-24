using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

class DecorationController : IToolController
{
    private DecorationView _view;
    private DecorationMaterials _decorationMaterials;
    private List<Decoratable> _parts = new List<Decoratable>();
    private Camera _camera;
    private Decoratable _chosenDecPart;

    public DecorationController(IPart part,Camera camera, Transform canvas, UnityAction refill)
    {
        _decorationMaterials = (DecorationMaterials)Resources.Load("ScriptableObjects/DecorationMaterials");
        var viewObject = Resources.Load<GameObject>("UI/DecorationView");
        _view = Object.Instantiate(viewObject, canvas).GetComponent<DecorationView>();
        _view.Init(UpdateMaterial, refill, BackToChosingPart);
        _camera = camera;
        foreach(GameObject child in part.JoinedParts)
        {
            child.TryGetComponent<Decoratable>(out Decoratable result);
            if (result != null)
            {
                _parts.Add(result);
                result.OutlineEnabled = true;
            }
        }        
    }

    public void Execute()
    {
        if ((Input.touchCount > 0) && (_chosenDecPart == null))
        {
            Touch touch = Input.GetTouch(0);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    Ray ray = _camera.ScreenPointToRay(touch.position);
                    RaycastHit hit;
                    if (Physics.Raycast(ray, out hit, 10))
                    {
                        Decoratable result;
                        hit.collider.TryGetComponent<Decoratable>(out result);
                        if (result != null)
                        {
                            _chosenDecPart = result;
                            _view.Fill(_decorationMaterials.GetWithType(result.type));
                            UpdateMaterial();
                            _camera.transform.position = hit.transform.position;
                            _camera.transform.position = new Vector3(hit.transform.position.x, hit.transform.position.y, (hit.transform.position.z-0.3f));
                        }
                    }
                    break;
            }
        }
    }
    public void BackToChosingPart()
    {
        _camera.transform.position = new Vector3(0, 0, -1); 
        _view.Hide();
        _chosenDecPart = null;
    }
    public void UpdateMaterial()
    {
        _chosenDecPart.SetMaterial(_decorationMaterials.GetById(_view.IdMaterial).GetMaterial());
    }

    public void Clear()
    {
        foreach (Decoratable part in _parts)
        {
            part.OutlineEnabled = false;
        }
        Object.Destroy(_view.gameObject);
        _camera.transform.position = new Vector3(0, 0, -1);
    }
}
