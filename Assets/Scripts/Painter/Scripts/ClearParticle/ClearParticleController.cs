using UnityEngine;

namespace ClearParticls
{
    public class ClearParticleController : IObserver
    {
        private ClearParticleModel _clearParticleModel = Resources.Load<ClearParticleModel>("ClearParticle");

        public void ObserverUpdate(Vector3 points)
        {
            Object.Instantiate(_clearParticleModel, points, Quaternion.identity);
        }
    }
}