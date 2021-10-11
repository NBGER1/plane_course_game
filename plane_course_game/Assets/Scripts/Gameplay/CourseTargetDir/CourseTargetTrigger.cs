using System;
using UnityEngine;

namespace Gameplay.CourseTargetDir
{
    public class CourseTargetTrigger : MonoBehaviour
    {
        #region Events

        public event Action<Collider> OnCollision;

        #endregion

        #region Methods

        public void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Projectile"))
            {
                OnCollision?.Invoke(other);
            }
        }

        #endregion
    }
}