using UnityEngine;

namespace Painter
{
    public class ClearParticle : IObserver
    {
        public void ObserverUpdate(Vector3 points)
        {
            Debug.Log($"ClearParticle - {points}");
        }
    }
}