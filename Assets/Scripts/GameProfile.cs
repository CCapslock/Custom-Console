using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CustomConsole
{
    internal class GameProfile
    {
        private Color _color = new Color(1,1,1,1);

        private List<IExecuter> _executers = new List<IExecuter>();
        public SubscriptionProperty<GameMode> CurrentState { get; }

        public Color Color
        {
            get => _color;
            set => _color = value;
        }

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

        public GameProfile()
        {
            CurrentState = new SubscriptionProperty<GameMode>();
        }
    }
}


