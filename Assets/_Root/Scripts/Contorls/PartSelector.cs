using UnityEngine;
using UnityEngine.Events;

public class PartSelector
{
    public bool active;
    private Camera _camera;
    private UnityAction<GameObject> SetWorkObject;

    public PartSelector(Camera camera, UnityAction<GameObject> setWorkObject)
    {
        _camera = camera;
        SetWorkObject = setWorkObject;
    }

    public void Action()
    {
        if (active)
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                switch (touch.phase)
                {
                    case TouchPhase.Began:
                        Ray ray = _camera.ScreenPointToRay(touch.position);
                        RaycastHit hit;
                        if (Physics.Raycast(ray, out hit, 10))
                        {
                            IPart result;
                            hit.collider.TryGetComponent<IPart>(out result);
                            if (result != null) SetWorkObject(result.PartGameObject);
                        }
                        break;
                }
            }
        }
    }
}
