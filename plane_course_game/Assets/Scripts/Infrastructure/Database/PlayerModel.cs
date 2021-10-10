using System;
using Gameplay.EventParamsDir;
using Infrastructure.Events;
using Infrastructure.Services;
using UnityEngine;

namespace GizmoSlots.Models
{
    [CreateAssetMenu(menuName = "Gizmo Slots/Models/Player Model", fileName = "Player Model")]
    [Serializable]
    public class PlayerModel : ScriptableObject
    {
        #region Events

        #endregion

        #region Editor

        [SerializeField] private int _coinsBalance;

        #endregion

        #region Methods

        public void Set(PlayerModel model)
        {
            _coinsBalance = model.CoinsBalance;
        }

        public PlayerModel()
        {
            _coinsBalance = 0;
        }

        public void EditorAddCoins(int coinsToAdd)
        {
            _coinsBalance += coinsToAdd;
            Infrastructure.Database.PlayerPrefsDB.EditorSaveData(this);
        }

        public void EditorWithdrawCoins(int coinsToWithdraw)
        {
            _coinsBalance = Mathf.Max(0, _coinsBalance - coinsToWithdraw);
            Infrastructure.Database.PlayerPrefsDB.EditorSaveData(this);
        }

        public void AddCoins(int coinsToAdd)
        {
            var oldBalance = _coinsBalance;
            _coinsBalance += coinsToAdd;
            var eParams = new OnPlayerBalanceChangeEventParams(oldBalance, _coinsBalance);
            GameplayServices.EventBus.Publish(EventTypes.OnPlayerBalanceChange, eParams);
            Infrastructure.Database.PlayerPrefsDB.SaveData();
        }

        public void WithdrawCoins(int coinsToWithdraw)
        {
            var oldBalance = _coinsBalance;
            _coinsBalance = Mathf.Max(0, _coinsBalance - coinsToWithdraw);
            var eParams = new OnPlayerBalanceChangeEventParams(oldBalance, _coinsBalance);
            GameplayServices.EventBus.Publish(EventTypes.OnPlayerBalanceChange, eParams);
            Infrastructure.Database.PlayerPrefsDB.SaveData();
        }

        #endregion

        #region Properties

        public int CoinsBalance => _coinsBalance;

        #endregion
    }
}