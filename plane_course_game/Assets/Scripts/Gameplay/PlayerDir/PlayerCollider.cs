using System;
using UnityEngine;

namespace Gameplay.PlayerDir
{
    public class PlayerCollider : MonoBehaviour
    {
        
        #region Events

        public event Action<Collider> OnCollision;


        #endregion
        #region Methods

        public void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("CourseBlock"))
            {
                Debug.Log($"YOU HIT A BLOCK");
                OnCollision?.Invoke(other);
            }
        }

        #endregion
    }
}