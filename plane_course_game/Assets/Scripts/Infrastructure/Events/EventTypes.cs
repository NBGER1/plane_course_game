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
        //# Collectibles
        OnCollectibleCollect,
        //# Database
        OnPlayerDataLoaded,
        OnPlayerBalanceChange
    }
}