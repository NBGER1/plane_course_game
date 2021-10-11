using Gameplay.EventParamsDir;
using Infrastructure.Abstracts;
using Infrastructure.Events;
using Infrastructure.Services;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Infrastructure.Managers
{
    public class UIManager : Singleton<UIManager>
    {
        #region Editor

        [SerializeField] private TextMeshProUGUI _playerScoreText;
        #endregion

        #region Methods
        

        protected override UIManager GetInstance()
        {
            return this;
        }

        public void Initialize()
        {
            GameplayServices.EventBus.Subscribe(EventTypes.OnPlayerScoreChange,OnCollectibleCollect);
        }

        private void OnCollectibleCollect(EventParams obj)
        {
            var eParams = obj as OnPlayerScoreChangeEventParams;
            _playerScoreText.text = eParams.Score.ToString();
        }

        private void OnDestroy()
        {
        }

        #endregion
    }
}