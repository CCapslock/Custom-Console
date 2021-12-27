using System.Collections.Generic;
using UnityEngine;

public interface IPart
{
    GameObject PartGameObject { get; }
    List<GameObject> JoinedParts { get; }
    Vector3 InitialPosition { get; }

    PartType Type { get; }
}