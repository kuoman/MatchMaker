namespace MatchMaker
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
    }
}