using UnityEngine;

class PartController :MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private Transform _console;
    [SerializeField] private Transform _workPlace;
    [SerializeField] private Transform _offScreen;

    [SerializeField] private PartMenuView _partMenuView;

    PartSelector _partSelector;
    GameObject _part;


    private void Awake()
    {
        _partSelector = new PartSelector();
        _partSelector.Init(_camera,SetWorkObject);
        _partSelector.Active = true;

        _partMenuView.Init(BackToConsole);
    }

    private void Update()
    {
        _partSelector.Action();
    }


    private void SetWorkObject(GameObject part)
    {
        _console.parent = _offScreen;
        _console.localPosition = Vector3.zero;
        _console.rotation = Quaternion.identity;

        part.transform.parent = _workPlace;
        part.transform.localPosition = Vector3.zero;
        part.transform.rotation = Quaternion.Euler(0, 180, 0);
        _partSelector.Active = false;
        _part = part;
    }
    private void BackToConsole()
    {
        _console.parent = _workPlace;
        _console.localPosition = Vector3.zero;
        _console.rotation = Quaternion.Euler(0,180,0);
        //изменить когда будет меню
        _part.transform.parent = _console;
        _part.transform.position = _part.GetComponent<IPart>().InitialPosition;
        _part.transform.rotation = Quaternion.Euler(0, 180, 0);
        _partSelector.Active = true;
    }
}
