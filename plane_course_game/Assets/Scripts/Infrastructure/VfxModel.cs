using UnityEngine;

namespace Gameplay
{
    [CreateAssetMenu(menuName = "Gameplay/Models/Vfx/Vfx Model", fileName = "Vfx Model")]
    public class VfxModel : ScriptableObject
    {
        #region Editor

        [SerializeField] private  Object _barrelDestroyedVfx;
        [SerializeField] private  Object _goldCollectibleVfx;

        #endregion

        #region Properties

        public Object GoldCollectibleVfx => _goldCollectibleVfx;
        public Object BarrelDestroyedVfx => _barrelDestroyedVfx;

        #endregion
    }
}