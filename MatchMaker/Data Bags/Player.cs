using System;

namespace MatchMaker.Data_Bags
{
    public class Player
    {
        private readonly int _id;

        public Player(int id)
        {
            _id = id;
        }

        public bool Equals(Player other)
        {
            //Check for null and compare run-time types.
            if ((other == null) || this.GetType() != other.GetType())
            {
                return false;
            }

            return _id == other._id;
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }
}
