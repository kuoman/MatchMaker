namespace MatchMaker.Data_Bags
{
    public interface ITank
    {
        bool IsTier(int tier);
        bool IsTankType(string tankType);

        bool IsRanking(string tankRanking);
    }
}