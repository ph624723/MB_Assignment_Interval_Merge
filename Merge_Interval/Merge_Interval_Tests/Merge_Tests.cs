using Merge_Interval.Model.Interval;
using Merge_Interval.Utils;

namespace Merge_Interval_Tests
{
    /// <summary>
    /// Dummy unit tests for the MERGE functionality (inpired by the assignment)
    /// </summary>
    [TestClass]
    public class Merge_Tests
    {
        /// <summary>
        /// Test using SafeInterval class.
        /// </summary>
        [TestMethod]
        public void Merge_SafeInterval()
        {
            List<SafeInterval<int>>  intervals = new List<SafeInterval<int>>();
            intervals.Add(new SafeInterval<int>(25, 30));
            intervals.Add(new SafeInterval<int>(2, 19));
            intervals.Add(new SafeInterval<int>(14, 23));
            intervals.Add(new SafeInterval<int>(4, 8));

            intervals = IntervalHelper.MERGE<SafeInterval<int>, int>(intervals);

            Assert.AreEqual(2, intervals.Count);
            Assert.AreEqual(new SafeInterval<int>(2,23),intervals[0]);
            Assert.AreEqual(new SafeInterval<int>(25, 30), intervals[1]);
        }

        /// <summary>
        /// Test using UnsafeInterval class.
        /// </summary>
        [TestMethod]
        public void Merge_UnsafeInterval()
        {
            List<UnsafeInterval<int>> intervals = new List<UnsafeInterval<int>>();
            intervals.Add(new UnsafeInterval<int>(25, 30));
            intervals.Add(new UnsafeInterval<int>(2, 19));
            intervals.Add(new UnsafeInterval<int>(14, 23));
            intervals.Add(new UnsafeInterval<int>(4, 8));

            intervals = IntervalHelper.MERGE<UnsafeInterval<int>, int>(intervals);

            Assert.AreEqual(2, intervals.Count);
            Assert.AreEqual(new UnsafeInterval<int>(2, 23), intervals[0]);
            Assert.AreEqual(new UnsafeInterval<int>(25, 30), intervals[1]);
        }
    }
}