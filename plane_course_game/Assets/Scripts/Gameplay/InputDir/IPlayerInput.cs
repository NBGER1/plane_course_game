
namespace Gameplay.InputDir
{
    public interface IPlayerInput
    {
        #region Methods

        //void SetPresenter(CharacterPresenter presenter);
        void AttackRight();
        void MoveHorizontal(float force);
        void MoveVertical(float force);

        #endregion
    }
}