using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Spray
{
    public class SoundSprayModel : MonoBehaviour
    {
        private void Update()
        {
            if (Input.GetMouseButtonUp(0))
            {
                Destroy(gameObject);
            }
        }
    }
}
