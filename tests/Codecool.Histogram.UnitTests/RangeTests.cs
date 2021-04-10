using System;
using System.Collections;
using NUnit.Framework;

namespace Codecool.Histogram.UnitTests
{
    [TestFixture]
    public class RangeTests
    {
        [Test]
        public void ToSmallerThanFrom()
        {
            Assert.Throws<ArgumentException>(() => new Range(5, 3));
        }

        [Test]
        public void IsFromSmallerThanZero()
        {
            Assert.Throws<ArgumentException>(() => new Range(-3, 0));
        }
        
        [TestCaseSource(nameof(TestCases))]
        public void WordIsInRange(string word, bool isInRange)
        {
            var range = new Range(1, 4);
            if (isInRange)
            {
                Assert.IsTrue(range.IsInRange(word));
            }
            else
            {
                Assert.IsFalse(range.IsInRange(word));
            }
        }

        public static IEnumerable TestCases
        {
            get
            {
                yield return new TestCaseData("d", true);
                yield return new TestCaseData("dsadfdf", false);
            }
        }

        [TestCase(5, 10)]
        public void TestRange_ToString(int from, int to)
        {
            var range = new Range(from, to);
            string expected = $"{from} - {to}";
            Assert.AreEqual(expected, range.ToString());
        }
    }
}