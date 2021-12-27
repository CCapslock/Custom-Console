using UnityEngine;

[CreateAssetMenu(fileName = nameof(Level), menuName = "DataStore/" + nameof(Level), order = 0)]
public sealed class Level : ScriptableObject
{
    [SerializeField] public GameObject _model;
    [SerializeField] public Color _color;
    [SerializeField] public Grafity _grafity;
    [SerializeField] public Vector3 _gragityPosition;
    [SerializeField] public Stiker _stiker;
    [SerializeField] public Vector3 _stikerPosition;
    // как хранить декорирование?
}