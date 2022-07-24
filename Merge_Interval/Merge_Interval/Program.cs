using Merge_Interval.Model.Interval;
using Merge_Interval.Utils;
using System.Diagnostics;

Stopwatch stopwatch = new Stopwatch();

//Generate a random list of intervals to merge
List<Tuple<double, double>> intervals = new List<Tuple<double, double>>();
Random rd = new Random();
for (int i = 0; i < 1000000; i++)
{
    int start = rd.Next(-100, 100);
    int end = rd.Next(start, start+30);
    intervals.Add(new Tuple<double, double>(start, end));
}

//Generate interval lists of the SafeInterval und UnsafeInterval type
List<UnsafeInterval<double>> intervals1 = intervals.ConvertAll(x => new UnsafeInterval<double>(x.Item1, x.Item2));
List<SafeInterval<double>> intervals2 = intervals.ConvertAll(x => new SafeInterval<double>(x.Item1, x.Item1));

Console.WriteLine("Unsorted:");
//Console.WriteLine(String.Join('\n', intervals1));
//Wait for user to continue
String? x = Console.ReadLine();

//Merge SafeInterval list and measure execution time
stopwatch.Restart();
intervals2 = IntervalHelper.MERGE<SafeInterval<double>,double>(intervals2);
stopwatch.Stop();
Console.WriteLine("\nMerged in {0}ms:", stopwatch.ElapsedMilliseconds);
//Console.WriteLine(String.Join('\n', intervals2));
x = Console.ReadLine();

//Merge UnsafeInterval list and measure execution time
stopwatch.Restart();
intervals1 = IntervalHelper.MERGE<UnsafeInterval<double>, double>(intervals1);
stopwatch.Stop();
Console.WriteLine("\nMerged in {0}ms:", stopwatch.ElapsedMilliseconds);
//Console.WriteLine(String.Join('\n', intervals1));
//Wait for user to continue
x = Console.ReadLine();

// Expectation: 
// The memory usage after the inital List initialization is not increased by calling IntervalHelper.MERGE
// Execution using SafeInterval takes a bit longer
