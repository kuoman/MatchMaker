namespace MatchMaker.Data_Bags.Tanks
{
    public interface ITank
    {
        bool IsSameTankType(Tank tank);
        bool IsSameTankTier(Tank tank);
        bool IsSameTankRank(Tank tank);
        bool IsNextTierTank(Tank tank);
    }
}