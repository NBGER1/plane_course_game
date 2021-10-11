using UnityEngine;

namespace Gameplay.CourseTargetDir
{
    [CreateAssetMenu(menuName = "Gameplay/Models/Target Model", fileName = "Target Model")]
    public class CourseTargetModel : ScriptableObject
    {
        #region Editor

        [SerializeField] private int _score;

        #endregion

        #region Properties

        public int Score => _score;

        #endregion
    }
}