using System;
using System.Collections.Generic;

namespace MatchMaker
{
    public interface IRandom
    {
        int Next(int maxValue);
        List<T> Shuffle<T>(List<T> list);
    }

    public class RandomWrapper : IRandom
    {
        private static readonly Random Random = new Random();

        public int Next(int maxValue)
        {
            return Random.Next(maxValue);
        }

        public List<T> Shuffle<T>(List<T> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                int k = Next(list.Count - 1);
                T value = list[k];
                list[k] = list[i];
                list[i] = value;
            }

            return list;
        }
    }

    public static class RandomFactory
    {
        private static readonly IRandom Random = new RandomWrapper();
        public static IRandom Create() => Create(Random);

        public static IRandom Create(IRandom random) => random;
    }
}
