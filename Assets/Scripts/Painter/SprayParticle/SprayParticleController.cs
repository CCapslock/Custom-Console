using UnityEngine;

namespace Spray
{
    public class SprayParticleController : IObserver
    {
        private SprayParticleModel _sprayParticleModel = Resources.Load<SprayParticleModel>("SprayParticle");

        public void ObserverUpdate(Vector3 points)
        {
            Object.Instantiate(_sprayParticleModel, new Vector3(points.x, points.y, points.z-0.04f), Quaternion.Euler(0, 90, 0));
        }
    }
}