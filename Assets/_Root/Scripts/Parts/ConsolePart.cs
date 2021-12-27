using System.Collections.Generic;
using UnityEngine;

public class ConsolePart : MonoBehaviour, IPart
{
    [SerializeField] private PartType _partType;
    [SerializeField] private List<GameObject> _joinedParts;
    
    GameObject IPart.PartGameObject => gameObject; 
    List<GameObject> IPart.JoinedParts => _joinedParts;
    Vector3 IPart.InitialPosition => _initialPosition;
    PartType IPart.Type => _partType;

    private Vector3 _initialPosition;

    private void Awake()
    {
        _initialPosition = transform.position;
        foreach(GameObject part in _joinedParts)
        {
            part.transform.parent = transform;
        }
    }
}
