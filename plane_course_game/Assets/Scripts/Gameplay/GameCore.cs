using Gameplay.CameraDir;
using Gameplay.Core;
using Gameplay.EventParamsDir;
using Gameplay.InputDir;
using Infrastructure.Events;
using Infrastructure.Factories;
using Infrastructure.Services;
using UnityEngine;
using UnityEngine.AI;

namespace Gameplay
{
    public class GameCore : MonoBehaviour
    {
        #region Fields

        private IPlayerInput _playerInput;

        #endregion

        #region Methods

        private void SubscribeEvents()
        {
        }

     
     


        private void Start()
        {
            SubscribeEvents();
            var playerSpawn = GameObject.FindGameObjectWithTag("PlayerSpawn");
            GameplayServices.CoroutineService
                .WaitFor(1f)
                .OnStart(() =>
                {
                
                })
                .OnEnd(() =>
                {
                 //   var presenter =
                   //     GameplayFactories.Instance.MvpPlayerFactory.Create(playerSpawn.transform.position);
                  //  _playerInput = new PlayerInput(presenter);
                 //   GameplayServices.UnityCore.RegisterUpdate(_playerInput as IUpdatable);
                 //   var cameraController = new PlayerCameraController();
                 //   cameraController.Initialize(presenter.ViewTransform);
                  //  GameplayServices.UnityCore.RegisterUpdate(cameraController);
                });
        }


        #endregion
    }
}