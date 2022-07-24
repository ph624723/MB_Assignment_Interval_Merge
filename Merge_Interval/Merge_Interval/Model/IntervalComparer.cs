using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merge_Interval.Model
{
    /// <summary>
    /// IComparer to sort Interval objects by their start value
    /// </summary>
    public class CompareIntervalByStart<TInterval, TNumber> : IComparer<IntervalBase<TInterval, TNumber>>
        where TInterval : IntervalBase<TInterval, TNumber>
        where TNumber : IComparable<TNumber>
    {
        public int Compare(IntervalBase<TInterval, TNumber>? first, IntervalBase<TInterval, TNumber>? second)
        {
            return first != null && second != null ? 
                first.Start.CompareTo(second.Start):
                0;
        }
    }

    /// <summary>
    /// IComparer to sort Interval objects by their end value
    /// </summary>
    public class CompareIntervalByEnd<TInterval, TNumber> : IComparer<IntervalBase<TInterval, TNumber>>
        where TInterval : IntervalBase<TInterval, TNumber>
        where TNumber : IComparable<TNumber>
    {
        public int Compare(IntervalBase<TInterval, TNumber>? first, IntervalBase<TInterval, TNumber>? second)
        {
            return first != null && second != null ?
                first.End.CompareTo(second.End) :
                0;
        }
    }
}
