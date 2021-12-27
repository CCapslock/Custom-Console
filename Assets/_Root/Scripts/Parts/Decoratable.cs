using UnityEngine;

class Decoratable :MonoBehaviour
{
    private Outline _outline;
    private MeshRenderer _renderer;
    [SerializeField] public DecoratableType type;
    public bool OutlineEnabled
    {
        set => _outline.enabled = value;
        get => _outline.enabled;
    }
    private void Awake()
    {
        _outline = GetComponent<Outline>();
        _outline.enabled = false;

        _renderer = GetComponent<MeshRenderer>();
    }
    public void SetMaterial(Material newMaterial)
    {
         _renderer.material =  newMaterial;
    }
}
