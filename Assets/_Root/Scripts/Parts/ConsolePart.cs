using UnityEngine;

public class ConsolePart : MonoBehaviour, IPart
{
    [SerializeField] private PartType _partType;

    GameObject IPart.PartGameObject => gameObject;
    Vector3 IPart.InitialPosition => _initialPosition;
    PartType IPart.Type => _partType;

    private Vector3 _initialPosition;

    private void Awake()
    {
        _initialPosition = transform.position;
    }
}
