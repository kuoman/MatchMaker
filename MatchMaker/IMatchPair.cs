using MatchMaker.Data_Bags;

namespace MatchMaker
{
    public interface IMatchPair
    {
        bool Contains(QueueItem queueItem);
        bool IsPairFull();
    }
}