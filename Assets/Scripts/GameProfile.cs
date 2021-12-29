using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CustomConsole
{
    public class GameProfile : MonoBehaviour
    {
        private List<IExecuter> _executers = new List<IExecuter>();

        public List<IExecuter> Executers
        {
            get
            {
                return _executers;
            }
            set
            {
                _executers = value;
            }
        }
    }
}


