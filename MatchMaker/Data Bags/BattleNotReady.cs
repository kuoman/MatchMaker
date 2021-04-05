namespace MatchMaker.Data_Bags
{
    public class BattleNotReady : IBattle
    {
        public bool IsReadyToFight()
        {
            return false;
        }

        public bool IsNotReadyToFight()
        {
            return true;
        }

        public bool ContainsPlayer(Player player)
        {
            return false;
        }

        public void AddQueueItemToTeamA(QueueItem queueItem)
        {
            
        }

        public void AddQueueItemToTeamB(QueueItem queueItem)
        {
            
        }

        public void FinalizeBattle(QueueItems queueItems)
        {
            
        }
    }
}
