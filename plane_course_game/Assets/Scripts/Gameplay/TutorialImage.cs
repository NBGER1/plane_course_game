using Infrastructure.Events;
using Infrastructure.Services;
using UnityEngine;

namespace Gameplay
{
    public class TutorialImage : MonoBehaviour
    {
        #region Methods

        public void KillTutorial()
        {
            Destroy(gameObject);
            GameplayServices.EventBus.Publish(EventTypes.OnTutorialEnd,null);
        }

        #endregion
    }
}