using MatchMaker.Data_Bags;

namespace MatchMaker.Strategies
{
    public class SameWinRateCategory: IStrategy
    {
        private readonly int _winRateCategory;

        public SameWinRateCategory(int winRateCategory)
        {
            _winRateCategory = winRateCategory;
        }

        public IBattle PopulateBattle(QueueItems queueItems, IBattle battleReady)
        {
            return CreateMatchPair(queueItems).AddMatchToBattle(battleReady);
        }

        public IMatchPair CreateMatchPair(QueueItems queueItems)
        {
            return queueItems.ByWinRate(_winRateCategory).GetMatchPair(queueItems);
        }
    }
}