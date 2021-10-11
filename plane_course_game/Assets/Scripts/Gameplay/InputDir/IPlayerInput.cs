namespace Gameplay.InputDir
{
    public interface IPlayerInput
    {
        #region Methods

        void MoveHorizontal(float force);
        void MoveVertical(float force);
        void Fire();

        #endregion
    }
}