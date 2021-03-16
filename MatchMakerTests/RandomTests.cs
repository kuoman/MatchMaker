using System.Collections.Generic;
using FluentAssertions;
using MatchMaker;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MatchMakerTests
{
    [TestClass]
    public class RandomTests
    {
        // testing random is odd, will break every once in a while, no easy way to do it. 
        [TestMethod]
        public void ShouldRandomizeNumber()
        {
            IRandom random = RandomFactory.Create();

            random.Next(100000).Should().NotBe(1);
        }

        // testing random shuffling is odd, will break every once in a while, no easy way to do it.  
        [TestMethod]
        public void ShouldShuffleList()
        {
            List<int> unshuffledList = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10};

            List<int> shuffled = RandomFactory.Create().Shuffle(unshuffledList);

            bool listNotShuffled = true;
            for (int i = 0; i < shuffled.Count; i++)
            {
                if (shuffled[i] == i) break;
                
                listNotShuffled = false;
            }

            listNotShuffled.Should().BeFalse();
        }
    }
}
