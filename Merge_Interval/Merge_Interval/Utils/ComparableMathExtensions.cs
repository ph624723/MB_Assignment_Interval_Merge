using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merge_Interval.Utils
{
    /// <summary>
    /// Helper class to provide standard recurring math operations for the IComparable interface.
    /// </summary>
    internal static class ComparableMathExtensions
    {
        /// <summary>
        /// Returns the maximum of two given comparable objects
        /// </summary>
        /// <param name="first">First value to compare.</param>
        /// /// <param name="second">Second value to compare.</param>
        /// <returns>The input object representing the bigger value</returns>
        public static T Max<T>(T first, T second) where T : IComparable<T> =>
            first?.CompareTo(second) > 0 ? first : second;

        /// <summary>
        /// Returns the minimum of two given comparable objects
        /// </summary>
        /// <param name="first">First value to compare.</param>
        /// /// <param name="second">Second value to compare.</param>
        /// <returns>The input object representing the lesser value</returns>
        public static T Min<T>(T first, T second) where T : IComparable<T> =>
            first?.CompareTo(second) < 0 ? first : second;
    }
}
