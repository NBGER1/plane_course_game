using System;
using Infrastructure.Database;
using Infrastructure.Managers;
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