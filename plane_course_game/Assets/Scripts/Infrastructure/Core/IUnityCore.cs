namespace Gameplay.Core
{
    public interface IUnityCore
    {
        #region Methods

        void RegisterUpdate(IUpdatable updatable);
        void UnregisterUpdate(IUpdatable updatable);
        #endregion
    }
}