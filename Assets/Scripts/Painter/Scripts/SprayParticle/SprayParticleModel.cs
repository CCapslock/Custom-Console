using UnityEngine;

namespace SprayParticls
{
    public class SprayParticleModel : MonoBehaviour
    {
        private ParticleSystem _parts;

        private void Start()
        {
            _parts = GetComponent<ParticleSystem>();
            Destroy(gameObject, _parts.main.duration);
        }
    }
}
