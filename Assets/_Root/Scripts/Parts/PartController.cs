using System;
using UnityEngine;

class PartController :MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private Transform _canvas;
    [SerializeField] private Transform _console;
    [SerializeField] private Transform _workPlace;
    [SerializeField] private Transform _offScreen;

    private PartMenuView _partMenuView;

    private PartSelector _partSelector;
    private PartControll _partRotation;
    private ToolMenu _toolMenu;

    private GameObject _part;


    private void Awake()
    {
        CreateView();
        _partRotation = new PartControll(_workPlace);
        _partSelector = new PartSelector(_camera, SetWorkObject);
        _toolMenu = new ToolMenu(_camera, _canvas, BackToConsole);
        _partSelector.Active = true;              
    }

    private void CreateView()
    {
        var viewObject = Resources.Load<GameObject>("UI/PartMenuView");
        _partMenuView = UnityEngine.Object.Instantiate(viewObject, _canvas).GetComponent<PartMenuView>();
        _partMenuView.Init(null); //поменять когда будет меню игры  
    }

    private void Update()
    {
        _partSelector.Action();
        _partRotation.Action();
        _toolMenu.Action();
    }


    private void SetWorkObject(GameObject part)
    {
        Destroy(_partMenuView.gameObject);
        _console.parent = _offScreen;
        _console.localPosition = Vector3.zero;
        _console.rotation = Quaternion.identity;

        part.transform.parent = _workPlace;
        part.transform.localPosition = Vector3.zero;
        part.transform.rotation = Quaternion.Euler(0, 180, 0);
        _partSelector.Active = false;
        _part = part;
        _toolMenu.Fill(part.GetComponent<IPart>().Type);        
    }
    private void BackToConsole()
    {
        _console.parent = _workPlace;
        _console.localPosition = Vector3.zero;
        _console.rotation = Quaternion.Euler(0,180,0);

        _part.transform.parent = _console;
        _part.transform.position = _part.GetComponent<IPart>().InitialPosition;
        _part.transform.rotation = Quaternion.Euler(0, 180, 0);
        _partSelector.Active = true;
        CreateView();
    }
}
