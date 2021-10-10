using UnityEngine;

namespace Gameplay.ProjectilesDir
{
    [CreateAssetMenu(menuName = "Gameplay/Models/Projectiles/Bullet Model", fileName = "Bullet Model")]

    public class ProjectileModel : ScriptableObject
    {
        #region Editor

        [SerializeField] private float _damage;
        [SerializeField] private float _speed;
        [SerializeField] private float _maxDistance;
        #endregion

        #region Properties

        public float Damage => _damage;
        public float Speed => _speed;
        public float MaxDistance => _maxDistance;

        #endregion
    }
}