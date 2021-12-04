using UnityEngine;

namespace ClearParticls
{
    public interface IObserver
    {
        void ObserverUpdate(Vector3 points);
    }
}