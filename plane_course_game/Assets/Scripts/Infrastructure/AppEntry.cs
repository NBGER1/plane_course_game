using Infrastructure.Services;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Infrastructure
{
    public class AppEntry : MonoBehaviour
    {
        #region Fields

        #endregion

        #region Methods

        void Awake()
        {
            GameplayServices.Initialize();
        }

        #endregion
    }
}