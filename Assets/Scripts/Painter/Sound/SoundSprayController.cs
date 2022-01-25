using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Spray
{
    public class SoundSprayController : IObserver
    {
        private SoundSprayModel _soundSprayModel;
        public void ObserverUpdate(Vector3 points)
        {
            if (!_soundSprayModel)
            {
                _soundSprayModel = Object.Instantiate(Resources.Load<SoundSprayModel>("SoundSpray"));
            }
        }
    }
}
