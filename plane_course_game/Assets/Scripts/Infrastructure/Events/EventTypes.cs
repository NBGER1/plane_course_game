namespace Infrastructure.Events
{
    public enum EventTypes
    {
        
        //# Infrastructure
        OnDatabaseLoad,
        
        //# UI
        OnUIButtonClick,
        
        //# Abilities
        OnAbilityMeleeSwipe,
        //# Props
        OnBarrelDestroyed,
        //# Collectibles
        OnCollectibleCollect,
        //# Database
        OnPlayerDataLoaded,
        OnPlayerBalanceChange
    }
}