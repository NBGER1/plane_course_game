using System;
using Gameplay.EventParamsDir;
using GizmoSlots.Models;
using Infrastructure.Events;
using Infrastructure.Services;
using UnityEngine;

namespace Infrastructure.Database
{
    public static class PlayerPrefsDB
    {
        #region Fields

        private static PlayerModel _playerModel = ScriptableObject.CreateInstance<PlayerModel>();

        #endregion

        #region Consts

        private const string PLAYER_DATA_KEY = "PLAYER_DATA";

        #endregion


        #region Methods

        public static void LoadData()
        {
            if (!PlayerPrefs.HasKey(PLAYER_DATA_KEY))
            {
                var defaultData = ScriptableObject.CreateInstance<PlayerModel>();
                var jsonData = JsonUtility.ToJson(defaultData);
                PlayerPrefs.SetString(PLAYER_DATA_KEY, jsonData);
            }

            var dataString = PlayerPrefs.GetString(PLAYER_DATA_KEY);
            JsonUtility.FromJsonOverwrite(dataString, _playerModel);

            var eParams = new OnPlayerDataLoadedEventParams(_playerModel);
            Debug.Log($"Loaded coins {eParams.PlayerModel.Score}");
            GameplayServices.EventBus.Publish(EventTypes.OnPlayerDataLoaded, eParams);
        }

        public static void EditorSaveData(PlayerModel playerModel)
        {
            var playerData = JsonUtility.ToJson(playerModel);
            PlayerPrefs.SetString(PLAYER_DATA_KEY, playerData);
        }

        public static void SaveData()
        {
            if (_playerModel == null)
            {
                throw new Exception($"PlayerModel is null! LoadData first!");
            }

            var playerData = JsonUtility.ToJson(_playerModel);
            PlayerPrefs.SetString(PLAYER_DATA_KEY, playerData);
        }

        #endregion

        #region Properties

        public static PlayerModel PlayerModel => _playerModel;

        #endregion
    }
}