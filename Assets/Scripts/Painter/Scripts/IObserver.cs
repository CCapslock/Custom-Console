using UnityEngine;

namespace Painter
{
    public interface IObserver
    {
        void ObserverUpdate(Vector3 points);
    }
}