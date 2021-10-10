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

        [SerializeField] private Text _playerGoldText;
        #endregion

        #region Methods
        

        protected override UIManager GetInstance()
        {
            return this;
        }

        public void Initialize()
        {
            GameplayServices.EventBus.Subscribe(EventTypes.OnCollectibleCollect,OnCollectibleCollect);
        }

        private void OnCollectibleCollect(EventParams obj)
        {
            throw new System.NotImplementedException();
        }

        private void OnDestroy()
        {
        }

        #endregion
    }
}