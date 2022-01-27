using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CustomConsole
{
    public class NintendoSwitchView : MonoBehaviour
    {
        [SerializeField] List<GameObject> _obj;

        [SerializeField] List<GameObject> _objEdit;

        [SerializeField] private List<Sprite> _objImg;

        public List<GameObject> Obj => _obj;
        public List<GameObject> ObjEdit => _objEdit;
        public List<Sprite> ObjImg => _objImg;
    }
}
