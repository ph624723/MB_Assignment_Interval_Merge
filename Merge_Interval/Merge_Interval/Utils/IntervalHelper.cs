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
        /// <param name="intervalList">List of intervals to merge. Attention! To minimize memory usage, the original list object as well as contained intervals will be edited by this method.</param>
        /// <returns>The input list with merged intervals.</returns>
        public static List<TInterval> MERGE<TInterval, T>([NotNull] List<TInterval> intervalList)
            where TInterval : IntervalBase<TInterval,T>
            where T : IComparable<T>
        {
            //Check input list is non-null
            if (intervalList == null) throw new NoNullAllowedException(Resources.StringResources.NullArgumentError);
            //Skip execution for singleton list
            if (intervalList.Count == 1) return intervalList;

            //Sort list by the intervals's end values
            intervalList.Sort(IntervalBase<TInterval, T>.SortByEndValue);

            //Parse list in reverse to allow altering the original list and avoid a second list object
            int i = intervalList.Count - 1;
            while (i >= 0)
            {
                //Remember this element, which will be kept
                //All following elements that overlap will be removed while extending toKeepInterval to their union
                TInterval toKeepInterval = intervalList[i];
                while (--i >= 0 && toKeepInterval.Start.CompareTo(intervalList[i].End) <= 0)
                {
                    //A following element existed and overlaps with toKeepInterval -> extend toKeepInterval
                    toKeepInterval.Start = ComparableMathExtensions.Min(toKeepInterval.Start, intervalList[i].Start);
                    //Remove element that is now a subset of toKeepInterval
                    intervalList.RemoveAt(i);
                }
            }
            //return merged original list object to avoid copy / second list object
            return intervalList;
        }
    }
}
