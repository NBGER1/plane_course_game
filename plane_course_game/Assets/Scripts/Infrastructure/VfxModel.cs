using UnityEngine;

namespace Gameplay
{
    [CreateAssetMenu(menuName = "Gameplay/Models/Vfx/Vfx Model", fileName = "Vfx Model")]
    public class VfxModel : ScriptableObject
    {
        #region Editor

        [SerializeField] private  Object _projectileHitVfx;
        [SerializeField] private Object _targetHitVfx;
        #endregion

        #region Properties

        public Object ProjectileHitVfx => _projectileHitVfx;
        public Object TargetHitVfx => _targetHitVfx;
        #endregion
    }
}