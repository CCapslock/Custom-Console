using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = nameof(DecorationMaterials), menuName = "DataStore/" + nameof(DecorationMaterials), order = 0)]
public sealed class DecorationMaterials : ScriptableObject
{
    [SerializeField] public DecorationMaterial[] _materials;
    public DecorationMaterial GetById(int Id)
    {
        foreach (DecorationMaterial elem in _materials)
        {
            if (elem.GetId() == Id)
            {
                return elem;
            }
        }
        return null;
    }
    public DecorationMaterial GetDecorationMaterial(int num)
    {
        return _materials[num];
    }
    public List<DecorationMaterial> GetWithType(DecoratableType type)
    {
        List<DecorationMaterial> result = new List<DecorationMaterial>();
        foreach(DecorationMaterial elem in _materials)
        {
            if (elem.ForType(type)) result.Add(elem);
        }
        return result;
    }
    public int Lenght => _materials.Length;
}
