using UnityEngine;

public class ConsolePart : MonoBehaviour, IPart
{
    GameObject IPart.PartGameObject => gameObject;
    Vector3 IPart.InitialPosition => _initialPosition;

    private Vector3 _initialPosition;

    private void Awake()
    {
        _initialPosition = transform.position;
    }
}
