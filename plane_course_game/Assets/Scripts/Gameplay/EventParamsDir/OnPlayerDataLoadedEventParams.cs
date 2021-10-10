using GizmoSlots.Models;
using Infrastructure.Events;

namespace Gameplay.EventParamsDir
{
    public class OnPlayerDataLoadedEventParams : EventParams
    {
        #region Fields

        private PlayerModel _playerModel;

        #endregion

        #region Methods

        public OnPlayerDataLoadedEventParams(PlayerModel playerModel)
        {
            _playerModel = playerModel;
        }

        #endregion

        #region Properties

        public PlayerModel PlayerModel => _playerModel;

        #endregion
    }
}