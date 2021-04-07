namespace MatchMaker.Data_Bags
{
    public class Battle : IBattle
    {
        private readonly Team _teamA = new Team();
        private readonly Team _teamB = new Team();

        public bool IsReadyToFight()
        {
            return (_teamA.HasFullTeam() && _teamB.HasFullTeam());
        }

        public bool IsNotReadyToFight()
        {
            return !IsReadyToFight();
        }

        public bool ContainsPlayer(Player player)
        {
            return _teamA.HasPlayer(player) || _teamB.HasPlayer(player);
        }

        public void AddQueueItemToTeamA(QueueItem queueItem)
        {
            AddToQueueItem(_teamA, queueItem);
        }

        public void AddQueueItemToTeamB(QueueItem queueItem)
        {
            AddToQueueItem(_teamB, queueItem);
        }

        public QueueItems FlushTeamsBackToQueue(QueueItems queueItems)
        {
            queueItems = _teamA.ResetQueueItems(queueItems);
            queueItems = _teamB.ResetQueueItems(queueItems);
            return queueItems;
        }

        private void AddToQueueItem(Team team, QueueItem queueItem)
        {
            team.AddQueueItem(queueItem);
        }
    }
}