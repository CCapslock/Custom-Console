using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = nameof(DecorationMaterial), menuName = "DataStore/" + nameof(DecorationMaterial), order = 0)]
public sealed class DecorationMaterial : ScriptableObject
{
    [SerializeField] public int _Id;
    [SerializeField] public Material _material;
    [SerializeField] DecoratableType _type;
    [SerializeField] Sprite _sprite;
    public int GetId()
    {
        return _Id;
    }
    public Material GetMaterial()
    {
        return _material;
    }
    public Sprite GetSprite()
    {
        return _sprite;
    }
    public bool ForType(DecoratableType type)
    {   if (_type == DecoratableType.Both) return true;
        if (_type == type) return true;
            else return false;
    }
}
