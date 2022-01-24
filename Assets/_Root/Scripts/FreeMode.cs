using CustomConsole;
using UnityEngine;

public class FreeMode : IExecuter
{
    private Transform _console;
    private Transform _canvas;
    private Transform _workPlace;
    private Transform _offScreen;

    private FreeModeView _freeModeView;

    private PartSelector _partSelector;
    private ObjectControlls _objectControlls;
    private ToolMenu _toolMenu;

    private GameObject _part;

    public FreeMode(GameProfile gameProfile,Camera camera, Transform canvas, Transform console, Transform workPlace, Transform offScreen)
    {
        _console = console;
        _workPlace = workPlace;
        _offScreen = offScreen;
        _canvas = canvas;
        CreateView();
        _objectControlls = new ObjectControlls(_workPlace);
        //консоль должна подниматься в рабочее положение
        _partSelector = new PartSelector(camera, SetWorkObject);
        _toolMenu = new ToolMenu(gameProfile,_objectControlls, camera, canvas, BackToConsole);
        _partSelector.active = true;              
    }

    private void CreateView()
    {
        var viewObject = Resources.Load<GameObject>("UI/PartMenuView");
        _freeModeView = UnityEngine.Object.Instantiate(viewObject, _canvas).GetComponent<FreeModeView>();
        _freeModeView.Init(null); //поменять когда будет меню игры  
    }

    public void Execute()
    {
        _partSelector.Action();
        _objectControlls.Action();
        _toolMenu.Action();
    }


    private void SetWorkObject(GameObject part)
    {
        Object.Destroy(_freeModeView.gameObject);
        _console.parent = _offScreen;
        _console.localPosition = Vector3.zero;
        _console.rotation = Quaternion.identity;

        part.transform.parent = _workPlace;
        part.transform.localPosition = Vector3.zero;
        part.transform.rotation = Quaternion.Euler(0, 180, 0);
        _partSelector.active = false;
        _part = part;
        _toolMenu.Fill(part.GetComponent<IPart>());        
    }
    private void BackToConsole()
    {
        _console.parent = _workPlace;
        _console.localPosition = Vector3.zero;
        _console.rotation = Quaternion.Euler(0,180,0);

        _part.transform.parent = _console;
        _part.transform.position = _part.GetComponent<IPart>().InitialPosition;
        _part.transform.rotation = Quaternion.Euler(0, 180, 0);
        _partSelector.active = true;
        _objectControlls.SetObject(_workPlace);
        _objectControlls.SetRotation();
        CreateView();
    }
}
