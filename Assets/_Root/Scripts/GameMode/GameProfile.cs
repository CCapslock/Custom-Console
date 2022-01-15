using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CustomConsole
{
    internal class GameProfile
    {
        private List<IExecuter> _executers = new List<IExecuter>();
        public SubscriptionProperty<GameMode> CurrentState { get; }

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

        public void AddExecuter(IExecuter executer)
        {
            _executers.Add(executer);
        }
        public void RemoveExecuter(IExecuter executer)
        {
            _executers.Remove(executer);
        }
    }
}


