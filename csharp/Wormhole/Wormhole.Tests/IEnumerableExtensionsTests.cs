using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Wormhole.Tests
{
    [TestClass]
    public class IEnumerableExtensionsTests
    {
        static readonly IEnumerable<int> emptyData = Enumerable.Empty<int>();
        static readonly IEnumerable<int> smallData = Enumerable.Range(1, 10);
        static readonly IEnumerable<int> largeData = Enumerable.Range(1, 1000);

        [TestMethod]
        public void EmptyReduceWhile()
        {
            var initial = 0;
            var expected = initial;
            var actual = emptyData.ReduceWhile((x, y) => Tuple.Create(false, x + y), initial);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void NullReduceWhile() {
            IEnumerable<int> nullData = null;

            var initial = 0;
            var expected = initial;

            var actual = nullData.ReduceWhile((x, acc) => Tuple.Create(false, x + acc), initial);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ReduceWhileSumElementsLessThanFive()
        {
            var initial = 0;
            var expected = 15;

            var actual = smallData.ReduceWhile((x, acc) => Tuple.Create(x > 5, (x > 5) ? acc : x + acc), initial);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ReduceWhileSumElementsLessThanFivePlusThree()
        {
            var initial = 3;
            var expected = 18;

            var actual = smallData.ReduceWhile((x, acc) => Tuple.Create(x > 5, (x > 5) ? acc : x + acc), initial);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ReduceMax() {
            var initial = 0;
            var expected = 10;

            var actual = smallData.Reduce((x, acc) => x > acc ? x : acc, initial);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ScanSum()
        {
            var initial = 0;
            var expected = new int[] { 1, 3, 6, 10, 15, 21, 28, 36, 45, 55 };

            var actual = smallData.Scan((x, acc) => x + acc, initial).ToArray();

            Assert.AreEqual(expected.Length, actual.Length);

            for (int i = 0; i < expected.Length; i++) {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }

        [TestMethod]
        public void ChunkPairsOnly()
        {
            var actual = smallData.Chunk(1, 2, false);
            var expectedLength = smallData.Count() - 1;

            Assert.AreEqual(expectedLength, actual.Count());
            Assert.IsTrue(actual.All(x => x.Count() == 2));
            Assert.IsTrue(actual.All(x => x.Last() - x.First() == 1));
        }

        [TestMethod]
        public void ChunkOdds()
        {
            var actual = smallData.Chunk(2, 1, false);
            var expectedLength = smallData.Count() / 2 + smallData.Count() % 2;

            Assert.AreEqual(expectedLength, actual.Count());
            Assert.IsTrue(actual.All(x => x.Count() == 1));
            Assert.IsTrue(actual.All(x => x.First() % 2 == 1));
        }

        [TestMethod]
        public void ChunkByThrees()
        {
            var actual = smallData.Select(Utility.Dec).ChunkBy(x => x / 3);
            var expectedLength = (int) Math.Ceiling(smallData.Count() / 3.0);

            Assert.AreEqual(expectedLength, actual.Count());
            Assert.AreEqual(smallData.Count(), actual.SelectMany(Utility.Identity).Count());
            Assert.IsTrue(actual.SkipLast(1).All(x => x.Count() == 3));
        }

        [TestMethod]
        public void FreqsOfFive()
        {
            var actual = smallData.Frequencies(x => x % 5);

            Assert.AreEqual(5, actual.Count());
            Assert.IsTrue(actual.All(x => x.Value == 2));
        }
    }
}
