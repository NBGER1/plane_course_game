using Infrastructure.Events;

namespace Gameplay.EventParamsDir
{
    public class OnPlayerScoreChangeEventParams : EventParams
    {
        #region Fields

        private int _oldScore;
        private int _score;

        #endregion

        #region Methods

        public OnPlayerScoreChangeEventParams(int oldScore, int score)
        {
            _oldScore = oldScore;
            _score = score;
        }

        #endregion

        #region Properties

        public int Score => _score;
        public int OldScore => _oldScore;

        #endregion
    }
}