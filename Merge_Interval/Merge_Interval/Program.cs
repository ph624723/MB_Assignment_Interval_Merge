using Merge_Interval.Model.Interval;

Interval<double> interval1 = new Interval<double>(1,6.5);
Interval<double> interval2 = new Interval<double>(4.2, 11);
Interval<double> interval3 = new Interval<double>(-3, 0);

//Interval<double> interval4 = new Interval<double>(0, -1);
//interval3.Start = 5;

Console.WriteLine("i1: " + interval1);
Console.WriteLine("i2: " + interval2);
Console.WriteLine("i3: " + interval3);

Console.WriteLine("i1 intersects i2: " + interval1.Intersects(interval2));
Console.WriteLine("i1 intersects i3: " + interval1.Intersects(interval3));
Console.WriteLine("i2 intersects i3: " + interval2.Intersects(interval3));

Console.WriteLine("Union of i1 and i2:\n" + String.Join('\n',interval2.Union(interval1)));
Console.WriteLine("Union of i1 and i3:\n" + String.Join('\n', interval3.Union(interval1)));