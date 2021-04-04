using MatchMaker.Data_Bags;

namespace MatchMaker
{
    public class MatchPair : IMatchPair
    {
        private readonly QueueItem _queueItem01;
        private readonly QueueItem _queueItem02;

        public MatchPair(QueueItem queueItem01, QueueItem queueItem02)
        {
            _queueItem01 = queueItem01;
            _queueItem02 = queueItem02;
        }

        public bool Contains(QueueItem queueItem)
        {
            return _queueItem01 == queueItem || _queueItem02 == queueItem;
        }

        public bool IsPairFull()
        {
            return _queueItem01 != null && _queueItem02 != null;
        }
    }
}