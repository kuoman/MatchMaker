namespace MatchMaker.Data_Bags
{
    public class QueueItem
    {
        private readonly Player _player;
        private readonly Tank _tank;

        public QueueItem(Player player, Tank tank)
        {
            _player = player;
            _tank = tank;
        }

        public bool HasPlayer(Player player)
        {
            return player == _player;
        }
    }
}