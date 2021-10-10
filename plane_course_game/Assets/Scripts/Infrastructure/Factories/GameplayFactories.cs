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

        #endregion

        #region Methods

        protected override GameplayFactories GetInstance()
        {
            return this;
        }

        #endregion

        #region Properties

        public CourseBlockFactoryBase MesaBlockFactory => _mesaBlockFactory;

        #endregion
    }
}