namespace MatchMaker.Data_Bags.Tanks
{
    public interface ITank
    {
        bool IsTier(int tier);
        bool IsTankType(string tankType);
        bool IsRanking(string tankRanking);
    }
}