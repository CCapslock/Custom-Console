using UnityEngine;

[CreateAssetMenu(fileName = nameof(Stikers), menuName = "DataStore/" + nameof(Stikers), order = 0)]
public sealed class Stikers : ScriptableObject
{
    [SerializeField] public Stiker[] _stikers;

    public Stiker GetStiker(int id)
    {
        return _stikers[id];
    }
    public int Lenght => _stikers.Length;
}
