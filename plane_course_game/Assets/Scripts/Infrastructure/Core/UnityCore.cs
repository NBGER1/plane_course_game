using System;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.Core
{
    public class UnityCore : MonoBehaviour, IUnityCore
    {
        #region Fields

        private IList<IUpdatable> _updatables = new List<IUpdatable>();

        #endregion

        #region Methods

        public void RegisterUpdate(IUpdatable updatable)
        {
            if (!_updatables.Contains(updatable))
            {
                _updatables.Add(updatable);
            }
        }

        public void UnregisterUpdate(IUpdatable updatable)
        {
            if (_updatables.Contains(updatable))
            {
                _updatables.Remove(updatable);
            }
        }

        private void Update()
        {
            for (var i = 0; i < _updatables.Count; i++)
            {
                _updatables[i]?.Update();
            }
        }

        #endregion
    }
}