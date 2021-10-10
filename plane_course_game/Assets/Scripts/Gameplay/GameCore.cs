using Gameplay.Core;
using Gameplay.EventParamsDir;
using Gameplay.InputDir;
using Infrastructure.Events;
using Infrastructure.Factories;
using Infrastructure.Services;
using UnityEngine;

namespace Gameplay
{
    public class GameCore : MonoBehaviour
    {
        #region Fields

        private IPlayerInput _playerInput;
        private Vector3 _lastBlockPosition;
        private int _blockSize = 30;
        private float _gameSpeed = 40f;
        #endregion

        #region Methods

        private void SubscribeEvents()
        {
            GameplayServices.EventBus.Subscribe(EventTypes.OnCourseBlockFinish, OnCourseBlockFinish);
        }

        private void OnCourseBlockFinish(EventParams eventParams)
        {
            var eParams = eventParams as OnCourseBlockFinishEventParams;
            eParams.CourseBlockPresenter.SetPosition(_lastBlockPosition);
        }

        private void SetCourse()
        {
            var pool = 20;
            for (var i = 0; i < pool; i++)
            {
                var presenter = GameplayFactories.Instance.MesaBlockFactory.Create();
                presenter.SetViewActive(Vector3.forward * (i * _blockSize));
                presenter.MoveView(_gameSpeed);
            }
            _lastBlockPosition = Vector3.forward * (pool-1) * _blockSize;
        }

        private void Start()
        {
            SubscribeEvents();
            GameplayServices.CoroutineService
                .WaitFor(1f)
                .OnStart(() => { })
                .OnEnd(() =>
                {
                    SetCourse();
                    var presenter = GameplayFactories.Instance.PlayerFactory.Create();
                     _playerInput = new PlayerInput(presenter);
                     GameplayServices.UnityCore.RegisterUpdate(_playerInput as IUpdatable);
                });
        }

        #endregion
    }
}