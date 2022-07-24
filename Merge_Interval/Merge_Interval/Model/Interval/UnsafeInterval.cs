using Merge_Interval.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merge_Interval.Model.Interval
{
    /// <summary>
    /// SafeInterval describing a continuous interval between two numbers.
    /// All methods do expect non-null valid inputs but do not perform nullchecks at runtime for simplicity / efficiency.
    /// </summary>
    public class UnsafeInterval<T> : IntervalBase<UnsafeInterval<T>, T> where T : IComparable<T>
    {
        public override T Start { get; set; }

        public override T End { get; set; }

        public UnsafeInterval(T start, T end)
        {
            Start = start;
            End = end;
        }

        public override bool Intersects(UnsafeInterval<T> compareInterval)
            // returns true if the intervals overlap or touch
            => Start.CompareTo(compareInterval.End) <= 0 && End.CompareTo(compareInterval.Start) >= 0;

        public override IEnumerable<UnsafeInterval<T>> Union(UnsafeInterval<T> compareInterval)
            => Intersects(compareInterval) ?
                // Intersection -> return a new interval that represents the convex hull of both intervals
                new List<UnsafeInterval<T>>() { new(ComparableMathExtensions.Min(Start, compareInterval.Start), ComparableMathExtensions.Max(End, compareInterval.End)) } :
                // No intersection -> return both intervals
                new List<UnsafeInterval<T>>() { this, compareInterval };
    }
}
