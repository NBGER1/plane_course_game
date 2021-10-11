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
        [SerializeField] private TextMeshProUGUI _playerAmmoText;
        [SerializeField] private GameObject _playerAmmoReloadIcon;
        [SerializeField] private TextMeshProUGUI _playerHealthText;

        #endregion

        #region Methods

        protected override UIManager GetInstance()
        {
            return this;
        }

        public void Initialize()
        {
            GameplayServices.EventBus.Subscribe(EventTypes.OnPlayerScoreChange, OnCollectibleCollect);
            GameplayServices.EventBus.Subscribe(EventTypes.OnPlayerAmmoChange, OnPlayerAmmoChange);
            GameplayServices.EventBus.Subscribe(EventTypes.OnPlayerHealthChange, OnPlayerHealthChange);
            GameplayServices.EventBus.Subscribe(EventTypes.OnPlayerReloadingEnd, OnPlayerReloadingEnd);
            GameplayServices.EventBus.Subscribe(EventTypes.OnPlayerReloadingStart, OnPlayerReloadingStart);
        }

        private void OnPlayerReloadingEnd(EventParams obj)
        {
            _playerAmmoReloadIcon.SetActive(false);
        }

        private void OnPlayerReloadingStart(EventParams obj)
        {
            _playerAmmoReloadIcon.SetActive(true);
        }

        private void OnPlayerHealthChange(EventParams obj)
        {
            var eParams = obj as OnHealthChangeEventParams;
            _playerHealthText.text = eParams.Health.ToString();
        }

        private void OnPlayerAmmoChange(EventParams obj)
        {
            var eParams = obj as OnAmmoChangeEventParams;
            _playerAmmoText.text = eParams.Ammo.ToString();
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