using System;
using Gameplay.EventParamsDir;
using Infrastructure.Events;
using Infrastructure.Services;
using UnityEngine;

namespace Infrastructure.Database
{
    [CreateAssetMenu(menuName = "Gameplay/Models/Player Model", fileName = "Player Model")]
    [Serializable]
    public class PlayerModel : ScriptableObject
    {
        #region Events

        #endregion

        #region Editor

        [SerializeField] private int _score;
        [SerializeField] private int _bestScore;

        #endregion

        #region Methods

        public void Set(PlayerModel model)
        {
            _score = model.Score;
        }

        public PlayerModel()
        {
            _score = 0;
        }

        public void EditorAddScore(int score)
        {
            _score += score;
            Infrastructure.Database.PlayerPrefsDB.EditorSaveData(this);
        }

        public void EditorWithdrawScore(int score)
        {
            _score = Mathf.Max(0, _score - score);
            Infrastructure.Database.PlayerPrefsDB.EditorSaveData(this);
        }

        public void AddScore(int score)
        {
            var oldScore = _score;
            _score += score;
            var eParams = new OnPlayerScoreChangeEventParams(oldScore, _score);
            GameplayServices.EventBus.Publish(EventTypes.OnPlayerScoreChange, eParams);
            if (_bestScore < _score)
            {
                _bestScore = _score;
            }

            Infrastructure.Database.PlayerPrefsDB.SaveData();
        }

        public void ResetScore()
        {
            var oldScore = _score;
            _score = 0;
            var eParams = new OnPlayerScoreChangeEventParams(oldScore, _score);
            GameplayServices.EventBus.Publish(EventTypes.OnPlayerScoreChange, eParams);
        }

        public void WithdrawScore(int score)
        {
            var oldScore = _score;
            _score = Mathf.Max(0, _score - score);
            var eParams = new OnPlayerScoreChangeEventParams(oldScore, _score);
            GameplayServices.EventBus.Publish(EventTypes.OnPlayerScoreChange, eParams);
            Infrastructure.Database.PlayerPrefsDB.SaveData();
        }

        #endregion

        #region Properties

        public int Score => _score;
        public int BestScore => _bestScore;

        #endregion
    }
}