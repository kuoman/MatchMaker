using System.Collections.Generic;
using MatchMaker;

namespace MatchMakerTests.TestDoubles
{
    public class TestNotRandom : IRandom
    {
        public int Next(int maxValue)
        {
            return 0;
        }

        public List<T> Shuffle<T>(List<T> list)
        {
            return list;
        }
    }
}
