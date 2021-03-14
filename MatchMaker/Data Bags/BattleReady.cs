namespace MatchMaker.Data_Bags
{
    public class BattleReady : IBattle
    {
        private Team TeamA = new Team();
        private Team TeamB = new Team();

        public bool IsReadyToFight()
        {
            return (TeamA.HasFullTeam() && TeamB.HasFullTeam());
        }

        public bool ContainsPlayer(Player player)
        {
            return TeamA.HasPlayer(player) || TeamB.HasPlayer(player);
        }

        public void AddQueueItemToTeamA(QueueItem queueItem)
        {
            AddToQueueItem(TeamA, queueItem);
        }

        public void AddQueueItemToTeamB(QueueItem queueItem)
        {
            AddToQueueItem(TeamB, queueItem);
        }

        private void AddToQueueItem(Team team, QueueItem queueItem)
        {
            team.AddQueueItem(queueItem);
        }
    }
}