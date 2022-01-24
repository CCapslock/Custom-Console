using UnityEngine;
using UnityEngine.Events;

class StikerController : IToolController
{
    private StikerView _view;
    private Stikers _stikersData;
    private Camera _camera;
    private MeshRenderer _stikerRender;
    private Transform _stikerTransform;
    public StikerController (ObjectControlls objectControlls,Camera camera, Transform canvas, UnityAction back)
    {
        _stikersData = Resources.Load<Stikers>("ScriptableObjects/Stikers");
        GameObject viewObject = Resources.Load<GameObject>("UI/StikerView");
        _view = Object.Instantiate(viewObject, canvas).GetComponent<StikerView>();
       _camera = camera;

        RaycastHit hit;
        if (Physics.Raycast(_camera.transform.position, _camera.transform.forward, out hit, 10))
        {
            StikerCoordinates coordinates = Resources.Load<StikerCoordinates>("ScriptableObjects/StikerCoordinates");
            GameObject stiker = Object.Instantiate(Resources.Load<GameObject>("StikerParent"), hit.transform);
            stiker.transform.position = new Vector3(hit.point.x, hit.point.y, hit.point.z-0.01f);
            objectControlls.SetObject(stiker.transform);
            objectControlls.SetMovement(coordinates.GetX, coordinates.GetY);
            _stikerRender = stiker.transform.GetChild(0).GetComponent<MeshRenderer>();
            _stikerTransform = stiker.transform;
        }

        _view.Init(_stikersData, UpdateStiker, SizeUpdate, RotationUpdate, back, Clear);
    }
    public void UpdateStiker()
    {
        _stikerRender.material = _stikersData.GetStiker(_view.IdStiker).GetMaterial();
    }public void SizeUpdate(float size)
    {
        _stikerTransform.localScale = new Vector3(size, size,_stikerTransform.localScale.z);
    }
    public void RotationUpdate(float angle)
    {
        _stikerTransform.rotation = Quaternion.Euler(0,0,angle);
    }
    public void Execute() 
    {

    }
    public void Clear()
    {
        Object.Destroy(_view.gameObject);
    }
}
