namespace MatchMaker.Data_Bags
{
    public interface IBattle
    {
        bool IsReadyToFight();
        bool IsNotReadyToFight();
        bool ContainsPlayer(Player player);
        void AddQueueItemToTeamA(QueueItem queueItem);
        void AddQueueItemToTeamB(QueueItem queueItem);
    }
}