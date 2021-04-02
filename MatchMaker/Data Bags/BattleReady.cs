namespace MatchMaker.Data_Bags
{
    public class BattleReady : IBattle
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

        private void AddToQueueItem(Team team, QueueItem queueItem)
        {
            team.AddQueueItem(queueItem);
        }

        public void FinalizeBattle(QueueItems queueItems)
        {
            _teamA.FinalizeBattle(queueItems);
            _teamB.FinalizeBattle(queueItems);
        }
    }
}