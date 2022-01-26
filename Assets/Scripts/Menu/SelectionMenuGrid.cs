using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CustomConsole
{
    public class SelectionMenuGrid : MonoBehaviour
    {
        [SerializeField] private List<Image> _imgObj;
        [SerializeField] private List<Button> _btnObj;

        public List<Image> ImgObj => _imgObj;
        public List<Button> BtnObj => _btnObj;
    }
}
