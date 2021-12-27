using UnityEngine;

[CreateAssetMenu(fileName = nameof(Levels), menuName = "DataStore/" + nameof(Levels), order = 0)]
public sealed class Levels : ScriptableObject
{
    [SerializeField] public Level[] _levels;

    public Level GetLevel(int num)
    {
        return _levels[num];
    }
}