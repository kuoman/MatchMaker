namespace MatchMaker.Data_Bags.Tanks
{
    public interface ITank
    {
        bool IsTier(int tier);
        bool IsTankType(string tankType);
        bool IsRanking(string tankRanking);
        bool IsSameTankType(ITank tank);
        bool IsSameTankTier(ITank tank);
        bool IsSameTankRank(ITank tank);
        bool IsNextTierTank(ITank tank);
        bool IsNextTierTank(int tank);
    }
}