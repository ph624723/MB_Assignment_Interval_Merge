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
    }
}
