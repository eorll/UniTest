using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;

namespace Codecool.Histogram.UnitTests
{
    [TestFixture]
    public class HistogramTests
    {
        private Histogram _histogram;

        [SetUp]
        public void SetUp()
        {
            _histogram = new Histogram();
        }

        [Test]
        public void AmountLessThanZero()
        {
            Assert.Throws<ArgumentException>(() => _histogram.GenerateRanges(1, -1));
        }

        [Test]
        public void StepLessThanZero()
        {
            Assert.Throws<ArgumentException>(() => _histogram.GenerateRanges(-1, 1));
        }

        [Test]
        public void GenerateTest_EmptyText()
        {
            var ranges = new List<Range>() {new Range(0, 2), new Range(5, 10)};
            var test = _histogram.Generate("", ranges);
            var expected = new Dictionary<Range, int>();
            Assert.AreEqual(expected, test);
        }

        [Test]
        public void GenerateTest_NullText()
        {
            Assert.Throws<ArgumentException>(() => _histogram.Generate(null, new List<Range>()));
        }

        [Test]
        public void GenerateTest_GenerateHistogram()
        {
            var ranges = new List<Range>() {new Range(0, 2), new Range(3, 4)};
            var test = _histogram.Generate("od taaa taa", ranges);
            var expected = new Dictionary<Range, int>() {{new Range(0, 2), 1}, {new Range(3,4), 2}};
            Assert.AreEqual(expected, test);
        }
        [TestCaseSource(nameof(TestCasesNormalize))]
        public void NormalizeTest(string text, Dictionary<Range, int> expected)
        {
            var ranges = new List<Range>() {new Range(0, 2), new Range(3, 4), new Range(5, 8)};
            _histogram.Generate(text, ranges);
            _histogram.NormalizeValues();
            
            Assert.AreEqual(expected,_histogram.GetHistogram());
        }

        private static IEnumerable TestCasesNormalize
        {
            get
            {
                yield return new TestCaseData("if test passes, we will be happy!", new Dictionary<Range, int>()
                {
                    {new Range(0, 2), 100}, {new Range(3, 4), 0}, {new Range(5, 8), 0}
                });
                yield return new TestCaseData("because it is time to rethink how we work", new Dictionary<Range, int>()
                {
                    {new Range(0, 2), 100}, {new Range(3, 4), 50}, {new Range(5, 8), 0}
                });
            }
        } 
        
        
        
    }
}