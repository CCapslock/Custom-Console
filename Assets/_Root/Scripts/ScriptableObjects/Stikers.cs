using UnityEngine;

[CreateAssetMenu(fileName = nameof(Stikers), menuName = "DataStore/" + nameof(Stikers), order = 0)]
public sealed class Stikers : ScriptableObject
{
    [SerializeField] public GameObject[] _stikers;

    public GameObject Get(int id)
    {
        return _stikers[id];
    }
}
