using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace CustomConsole
{
    public class MenuView : MonoBehaviour
    {
        [SerializeField] private Button _buttonStart;
        [SerializeField] private Text _textStart;
        private GameObject _followObj;

        public void Init(UnityAction startGame, GameObject followObj)
        {
            _followObj = followObj;
            _buttonStart.onClick.AddListener(startGame);
        }

        public void ClickButton()
        {
            _buttonStart.gameObject.SetActive(false);
            _textStart.gameObject.SetActive(false);
            _followObj.SetActive(true);
        }

        protected void OnDestroy()
        {
            _buttonStart.onClick.RemoveAllListeners();
        }
    }
}
