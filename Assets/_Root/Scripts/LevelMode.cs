using UnityEngine;

class LevelMode : MonoBehaviour
{
    //потом передавать все данные в конструкторе и убрать MonoBehaviour
    [SerializeField] private Camera _camera;
    [SerializeField] private Transform _canvas;
    [SerializeField] private Transform _console;
    [SerializeField] private Transform _workPlace;
    [SerializeField] private Transform _offScreen;

    [SerializeField] private Level _level;

    public void Start()
    {
        /*
         * запускать инструменты по очереди
         * брать информацию о уровне с SO
         * сверять то что сделал пользователь с SO
         * должен быть конец
         * 
         */
    }
}