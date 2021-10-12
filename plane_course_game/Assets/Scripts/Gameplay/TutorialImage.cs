using System;
using Infrastructure.Events;
using Infrastructure.Services;
using TMPro;
using UnityEngine;

namespace Gameplay
{
    public class TutorialImage : MonoBehaviour
    {
        #region Editor

        [SerializeField] private TextMeshProUGUI _introText;

        #endregion

        #region Fields

        private bool _canContinue;

        #endregion
        #region Methods

        private void Awake()
        {
            _introText.text = "Loading..";
        }

        private void Start()
        {
            GameplayServices.CoroutineService
                .WaitFor(2)
                .OnEnd(() =>
                {
                    _introText.text = "Click Anywhere To Continue";
                    _canContinue = true;
                });
        }

        public void KillTutorial()
        {
            if(!_canContinue) return;
            GameplayServices.EventBus.Publish(EventTypes.OnTutorialEnd,null);
            Destroy(gameObject);
        }

        #endregion
    }
}