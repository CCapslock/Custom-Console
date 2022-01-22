using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CustomConsole
{
    public class NintendoSwitchView : MonoBehaviour
    {
        [SerializeField] List<GameObject> _obj;

        [SerializeField] private List<Sprite> _objImg;

        public List<GameObject> Obj
        {
            get => _obj;
        }

        public List<Sprite> ObjImg
        {
            get => _objImg;
        }
    }
}
