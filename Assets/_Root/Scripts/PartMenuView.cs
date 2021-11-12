using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

class PartMenuView : MonoBehaviour
{
    [SerializeField] Button _back;
    public void Init(UnityAction backToConsole)
    {
        _back.onClick.AddListener(backToConsole);
    }
}
