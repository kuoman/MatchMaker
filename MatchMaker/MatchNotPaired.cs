using MatchMaker.Data_Bags;

namespace MatchMaker
{
    public class MatchNotPaired : IMatchPair
    {
        public bool Contains(QueueItem queueItem)
        {
            return false;
        }

        public bool IsPairFull()
        {
            return false;
        }

        public IBattle AddMatchToBattle(IBattle battle)
        {
            return new BattleNotReady();
        }
    }
}