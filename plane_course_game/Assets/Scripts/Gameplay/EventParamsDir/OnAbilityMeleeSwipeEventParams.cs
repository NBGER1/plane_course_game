using System.Xml.Serialization;
using Infrastructure.Events;
using UnityEditorInternal;
using UnityEngine;

namespace Gameplay.EventParamsDir
{
    public class OnAbilityMeleeSwipeEventParams : EventParams
    {
        #region Fields

        private Vector3 _position;
        private string _attackerID;
        #endregion

        #region Constructor

        public OnAbilityMeleeSwipeEventParams(Vector3 position,string attackerID)
        {
            _position = position;
            _attackerID = attackerID;
        }

        #endregion

        #region Properties

        public Vector3 Position => _position;
        public string AttackerID => _attackerID;

        #endregion
    }
}