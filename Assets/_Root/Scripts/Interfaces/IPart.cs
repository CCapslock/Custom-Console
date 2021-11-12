using UnityEngine;

public interface IPart
{
    GameObject PartGameObject { get; }
    Vector3 InitialPosition { get; }
}