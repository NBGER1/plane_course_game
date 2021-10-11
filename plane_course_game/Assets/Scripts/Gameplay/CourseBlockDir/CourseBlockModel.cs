using UnityEngine;

namespace Gameplay.CourseBlockDir
{
    [CreateAssetMenu(menuName = "Gameplay/Models/Course Block Model", fileName = "Course Block Model")]
    public class CourseBlockModel : ScriptableObject
    {
        #region Editor

        [SerializeField] [Range(0f, 1f)] private float _targetAppearanceChance;

        #endregion

        #region Properties

        public float TargetAppearanceChance => _targetAppearanceChance;

        #endregion
    }
}