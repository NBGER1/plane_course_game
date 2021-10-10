using Infrastructure.Abstracts;
using UnityEngine;

namespace Infrastructure.Factories
{
    public class GameplayFactories : Singleton<GameplayFactories>
    {
        #region Editor

 

        #endregion

        #region Methods

        protected override GameplayFactories GetInstance()
        {
            return this;
        }

        #endregion

        #region Properties

    

        #endregion
    }
}