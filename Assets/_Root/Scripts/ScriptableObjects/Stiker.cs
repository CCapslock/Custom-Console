using UnityEngine;

[CreateAssetMenu(fileName = nameof(Stiker), menuName = "DataStore/" + nameof(Stiker), order = 0)]
public sealed class Stiker : ScriptableObject
{
    [SerializeField] public Material _material;
    [SerializeField] public Sprite _sprite;
    public Material GetMaterial()
    {
        return _material;
    }
    public Sprite GetSprite()
    {
        return _sprite;
    }
}
