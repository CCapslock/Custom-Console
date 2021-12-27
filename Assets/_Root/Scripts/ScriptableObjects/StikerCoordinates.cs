using UnityEngine;

[CreateAssetMenu(fileName = nameof(StikerCoordinates), menuName = "DataStore/" + nameof(StikerCoordinates), order = 0)]
public sealed class StikerCoordinates : ScriptableObject
{
    [SerializeField] private Vector2 _xValueMovement;
    [SerializeField] private Vector2 _yValueMovement;

    public Vector2 GetX => _xValueMovement;
    public Vector2 GetY => _yValueMovement;
}
