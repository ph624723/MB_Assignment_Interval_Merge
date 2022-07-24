using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Merge_Interval.Utils;

namespace Merge_Interval.Model
{
    /// <summary>
    /// Interface describing the general behavior of an interval between two numbers.
    /// </summary>
    public abstract class IntervalBase<TInterval, TNumber>
        where TInterval : IntervalBase<TInterval, TNumber>
        where TNumber : IComparable<TNumber>
    {
        /// <summary>
        /// Start value of the interval
        /// </summary>
        public abstract TNumber Start { get; set; }

        /// <summary>
        /// End value of the interval
        /// </summary>
        public abstract TNumber End { get; set; }

        /// <summary>
        /// Determines if the given interval overlaps with the current one, false otherwise.
        /// </summary>
        /// <param name="compareInterval">Interval to compare to.</param>
        /// <returns>bool value representing overlap of the intervals.</returns>
        public abstract bool Intersects(TInterval compareInterval);

        /// <summary>
        /// Determines the union of the current and the given interval.
        /// </summary>
        /// <param name="compareInterval">Interval to compare to.</param>
        /// <returns>An IEnumerable with one Interval object should the inputs overlap or two objects otherwise.</returns>
        public abstract IEnumerable<TInterval> Union(TInterval compareInterval);

        /// <summary>
        /// Returns a string that represents the current interval as [Start,End].
        /// </summary>
        public override string ToString() => "[" + Start + "," + End + "]";

        /// <summary>
        /// Determines whether this instance is equal to obj, which also has to be of type Interval&lt;<typeparamref name="TNumber"/>&gt;.
        /// </summary>
        /// <param name="obj">Object to compare to.</param>
        /// <returns>true if object is of type Interval&lt;<typeparamref name="TNumber"/>&gt; and start as well as end value are equal, false otherwise.</returns>
        public override bool Equals(object? obj)
        {
            TInterval? other = obj as TInterval;
            return other == null ? false : Start.Equals(other.Start) && End.Equals(other.End);
        }
    }
}
