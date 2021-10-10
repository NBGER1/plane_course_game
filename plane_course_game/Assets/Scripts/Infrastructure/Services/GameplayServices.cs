using Gameplay;
using Gameplay.Core;
using Gameplay.InputDir;
using Infrastructure.Database;
using Infrastructure.Managers;
using Infrastructure.Services.Coroutines;
using UnityEngine;

namespace Infrastructure.Services
{
    public static class GameplayServices
    {
        #region Fields

        private static EventBus _eventBus;
        private static ICoroutineService _coroutineService;
        private static IUnityCore _unityCore;
        private static GameCore _gameCore;

        #endregion


        #region Methods

        public static void Initialize()
        {
            _eventBus = new EventBus();
            var csgo = new GameObject("CoroutineService");
            _coroutineService = csgo.AddComponent<CoroutineService>();

            var coreGo = new GameObject("UnityCore");
            _unityCore = coreGo.AddComponent<UnityCore>();
       //     _coroutineService.WaitFor(0.1f)
       //         .OnEnd(() => { PlayerPrefsDB.LoadData(); });
      //      VfxManager.Instance.Initialize();

            var gcgo = new GameObject("GameCore");
            _gameCore = gcgo.AddComponent<GameCore>();
        }

        #endregion

        #region Properties

        public static IUnityCore UnityCore => _unityCore;
        public static EventBus EventBus => _eventBus;
        public static ICoroutineService CoroutineService => _coroutineService;

        #endregion
    }
}