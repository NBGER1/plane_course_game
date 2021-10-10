using System;
using Gameplay.FactoriesDir;
using Infrastructure.Abstracts;
using UnityEngine;

namespace Infrastructure.Factories
{
    public class GameplayFactories : Singleton<GameplayFactories>
    {
        #region Editor

        [SerializeField] private CourseBlockFactoryBase _mesaBlockFactory;
        [SerializeField] private PlayerFactory _playerFactory;
        [SerializeField] private ProjectileFactoryBase _bulletProjectileFactory;
        #endregion

        #region Methods

        protected override GameplayFactories GetInstance()
        {
            return this;
        }

        #endregion

        #region Properties

        public CourseBlockFactoryBase MesaBlockFactory => _mesaBlockFactory;
        public PlayerFactory PlayerFactory => _playerFactory;
        public ProjectileFactoryBase BulletProjectileFactory => _bulletProjectileFactory;

        #endregion
    }
}