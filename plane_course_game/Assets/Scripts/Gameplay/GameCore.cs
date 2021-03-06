using System;
using System.Collections;
using System.Collections.Generic;
using Gameplay.Core;
using Gameplay.CourseBlockDir;
using Gameplay.EventParamsDir;
using Gameplay.InputDir;
using Infrastructure.Database;
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
        private int _blockSize = 50;
        private float _gameSpeed = 40f;
        private Transform _lastBlockTransform;
        private CourseBlockPresenter[] _presenters;
        private bool _initialized = false;

        #endregion

        #region Methods

        private void SubscribeEvents()
        {
            GameplayServices.EventBus.Subscribe(EventTypes.OnCourseBlockFinish, OnCourseBlockFinish);
            GameplayServices.EventBus.Subscribe(EventTypes.OnTargetCollision, OnTargetCollision);
            GameplayServices.EventBus.Subscribe(EventTypes.OnTutorialEnd, OnTutorialEnd);
        }

        private void OnTutorialEnd(EventParams obj)
        {
            var presenter = GameplayFactories.Instance.PlayerFactory.Create();
         //   presenter.SetViewPosition(new Vector3(0, 8, -6));
            _playerInput = new PlayerInput(presenter);
            GameplayServices.UnityCore.RegisterUpdate(_playerInput as IUpdatable);
            presenter.ShowCinematicIntro();
        }

        private void OnTargetCollision(EventParams obj)
        {
            var eParams = obj as OnTargetCollisionEventParams;
            PlayerPrefsDB.PlayerModel.AddScore(eParams.Score);
        }

        private void OnCourseBlockFinish(EventParams eventParams)
        {
            var eParams = eventParams as OnCourseBlockFinishEventParams;
            GameplayServices.CoroutineService.RunCoroutine(
                ResetBlockPosition(eParams.CourseBlockPresenter));
        }

        IEnumerator ResetBlockPosition(CourseBlockPresenter presenter)
        {
            yield return null;
            var newPos = _lastBlockTransform.position + Vector3.forward * _blockSize;
            presenter.SetPosition(newPos);
            yield return null;
            _lastBlockTransform = presenter.ViewTransform;
        }

        private IEnumerator SetCourse()
        {
            var pool = GameplayFactories.Instance.MesaBlockFactory.PoolSize;
            Queue<CourseBlockPresenter> _queue = new Queue<CourseBlockPresenter>();
            for (var i = 0; i < pool; i++)
            {
                var presenter = GameplayFactories.Instance.MesaBlockFactory.Create();
                presenter.SetViewActive();
                presenter.SetPosition(Vector3.forward * (i * _blockSize));
                presenter.MoveView(_gameSpeed);
                _queue.Enqueue(presenter);

                var target = GameplayFactories.Instance.CourseTargetBasicFactory.Create();
                target.SetViewActive();
                presenter.SetTarget(target);
            }

            yield return null;
            _presenters = _queue.ToArray();
            _lastBlockTransform = _presenters[_presenters.Length - 1].ViewTransform;
            _initialized = true;
        }


        private void Start()
        {
            SubscribeEvents();
            GameplayServices.CoroutineService
                .WaitFor(1f)
                .OnStart(() =>
                {
                    PlayerPrefsDB.PlayerModel.ResetScore();
                })
                .OnEnd(() => { GameplayServices.CoroutineService.RunCoroutine(SetCourse()); });
        }

        private void OnDestroy()
        {
            UnsubscribeEvents();
        }

        private void UnsubscribeEvents()
        {
            GameplayServices.EventBus.Unsubscribe(EventTypes.OnCourseBlockFinish, OnCourseBlockFinish);
            GameplayServices.EventBus.Unsubscribe(EventTypes.OnTargetCollision, OnTargetCollision);
            GameplayServices.EventBus.Unsubscribe(EventTypes.OnTutorialEnd, OnTutorialEnd);
        }

        #endregion
    }
}