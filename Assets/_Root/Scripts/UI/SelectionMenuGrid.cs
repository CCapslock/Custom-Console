using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CustomConsole
{
    public class SelectionMenuGrid : MonoBehaviour
    {
        [SerializeField] private List<Image> _imgObj;

        public List<Image> ImgObj
        {
            get => _imgObj;
        }
    }
}
