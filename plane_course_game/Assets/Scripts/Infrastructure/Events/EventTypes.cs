namespace Infrastructure.Events
{
    public enum EventTypes
    {
        //# Infrastructure
        OnDatabaseLoad,

        //# UI
        OnUIButtonClick,

        //# Course Blocks
        OnCourseBlockFinish,


        //# Database
        OnPlayerDataLoaded,
        OnProjectileCollision,
        OnTargetCollision,

        //Player Gameplay
        OnPlayerScoreChange,
        OnPlayerHealthChange,
        OnPlayerAmmoChange,
        OnPlayerReloadingStart,
        OnPlayerReloadingEnd,
        OnTutorialEnd,
        OnGameOver,
    }
}