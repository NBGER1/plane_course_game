using Gameplay.PlayerDir;
using UnityEngine;

namespace Gameplay.FactoriesDir
{
    public class PlayerFactory : MonoBehaviour
    {
        #region Editor

        [SerializeField] private Object _view;
        [SerializeField] private PlayerModel _model;

        #endregion

        #region Methods

        public PlayerPresenter Create()
        {
            //todo model  
            var view = Instantiate(_view) as GameObject;
            var model = Instantiate(_model);
            var presenter = new PlayerPresenter(model, view.GetComponent<PlayerView>());
            return presenter;
        }

        #endregion
    }
}