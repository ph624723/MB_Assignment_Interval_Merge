using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Merge_Interval.Model;

namespace Merge_Interval.Utils
{
    /// <summary>
    /// Helper class containing operations to be performed on Interval objects.
    /// </summary>
    public static class IntervalHelper
    {
        /// <summary>
        /// Reduces the intervals in a given list by merging any intervals that overlap 
        /// </summary>
        /// <param name="intervalList">List of intervals to merge. </param>
        /// <returns>The input list with merged intervals.</returns>
        public static List<TInterval> MERGE<TInterval, T>([NotNull] List<TInterval> intervalList)
            where TInterval : IntervalBase<TInterval,T>
            where T : IComparable<T>
        {
            throw new NotImplementedException();
        }
    }
}
