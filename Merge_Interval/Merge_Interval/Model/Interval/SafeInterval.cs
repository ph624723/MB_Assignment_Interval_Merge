using Merge_Interval.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merge_Interval.Model.Interval
{
    /// <summary>
    /// Interval describing a continuous interval between two numbers.
    /// All methods do not allow null inputs and throw a NoNullAllowedException if a null input is given.
    /// </summary>
    public class SafeInterval<T> : IntervalBase<SafeInterval<T>, T> where T : IComparable<T>
    {
        private T _start;
        private T _end;

        [NotNull]
        public override T Start
        {
            get => _start;
            set
            {
                // Check that internal fields will always be non-null and in correct order
                if (value == null) throw new NoNullAllowedException(Resources.StringResources.NullArgumentError);
                if (_end.CompareTo(value) < 0) throw new ArgumentException(Resources.StringResources.OrderArgumentError);
                _start = value;
            }
        }
        [NotNull]
        public override T End
        {
            get => _end;
            set
            {
                // Check that internal fields will always be non-null and in correct order
                if (value == null) throw new NoNullAllowedException(Resources.StringResources.NullArgumentError);
                if (value.CompareTo(_start) < 0) throw new ArgumentException(Resources.StringResources.OrderArgumentError);
                _end = value;
            }
        }

        /// <param name="start">Start value for the interval. Cannot be null or a NoNullAllowedException will be thorwn.</param>
        /// <param name="end">End value for the interval. Cannot be null or a NoNullAllowedException will be thorwn.</param>
        public SafeInterval([NotNull] T start, [NotNull] T end)
        {
            // Check that internal fields will always be non-null and in correct order
            if (start == null || end == null) throw new NoNullAllowedException(Resources.StringResources.NullArgumentError);
            if (end.CompareTo(start) < 0) throw new ArgumentException(Resources.StringResources.OrderArgumentError);
            _start = start;
            _end = end;
        }

        /// <param name="compareInterval">SafeInterval to compare to. Cannot be null or a NoNullAllowedException will be thorwn.</param>
        public override bool Intersects([NotNull] SafeInterval<T> compareInterval)
            // Check input is non-null
            => compareInterval == null
                ? throw new NoNullAllowedException(Resources.StringResources.NullArgumentError)
                // returns true if the intervals overlap or touch
                : Start.CompareTo(compareInterval.End) <= 0 && End.CompareTo(compareInterval.Start) >= 0;

        /// <param name="compareInterval">SafeInterval to compare to. Cannot be null or a NoNullAllowedException will be thorwn.</param>
        public override IEnumerable<SafeInterval<T>> Union([NotNull] SafeInterval<T> compareInterval)
        {
            // Check input is non-null
            if (compareInterval == null) throw new NoNullAllowedException(Resources.StringResources.NullArgumentError);

            return Intersects(compareInterval) ?
                // Intersection -> return a new interval that represents the convex hull of both intervals
                new List<SafeInterval<T>>() { new(ComparableMathExtensions.Min(Start, compareInterval.Start), ComparableMathExtensions.Max(End, compareInterval.End)) } :
                // No intersection -> return both intervals
                new List<SafeInterval<T>>() { this, compareInterval };
        }
    }
}
