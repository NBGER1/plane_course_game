using System;
using Infrastructure.Database;
using Infrastructure.Events;
using Infrastructure.Managers;
using Infrastructure.Services;
using TMPro;
using UnityEngine;

namespace Gameplay.PopupsDir
{
    public class MainGamePopupView : MonoBehaviour
    {
        #region Editor

        [SerializeField] private TextMeshProUGUI _bestScoreText;

        #endregion

        #region Consts

        private const string GAME_SCENE = "Game";

        #endregion
        #region Methods

        //TODO temp location

        private void Start()
        {
            GameplayServices.EventBus.Subscribe(EventTypes.OnPlayerDataLoaded,OnPlayerDataLoaded);
           
        }

        private void OnPlayerDataLoaded(EventParams obj)
        {
            _bestScoreText.text = PlayerPrefsDB.PlayerModel.BestScore.ToString();
        }

        private void OnEnable()
        {
            _bestScoreText.text = PlayerPrefsDB.PlayerModel.BestScore.ToString();
        }

        public void Play()
        {
            SceneManager.MoveToGameScene();
        }

        public void Exit()
        {
            SceneManager.ExitApp();
        }

        #endregion
    }
}