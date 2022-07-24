# MB_Assignment_Interval_Merge

The given task has been implemented in C#.
Due to the simple algorithm the principles should, however, transfer to other languages like Java or Python.
The related Visual Studio solution is located under Merge_Interval/ 

General Assumptions:

1. The code might be part of a larger, well-organized data-structure. Thus, I have used a more complex definition of the interval entity than would have been absolutely necessary for this task, which only really required a basic Tuple.
The underlying idea was that where the MERGE code would be applied, different interval operations might be in use that could require or benefit from additional interval functionality, which would be easily implemented in the chosen structure.

2. The implementation should be robust against large inputs
a. Large intervals: 
Intervals are only defined through a pair of numerical values (start/end). I have used a generic implementation using IComparable. Thus, a sufficient type for the data that is to be used can and should be determined where the code is executed and the applied data is known.
b. Large input list:
The target of the implemented algorithm is to not increase memory usage during execution, to avoid overflow in case of large datasets. By not growing relative to the already existing input list this should be ensured. This is achieved by avoiding any internal copies of the list or e.g. the build-up of a second result list and instead operating on the original list.
This is the case for the applied List.Sort() (different to e.g. IEnumerable.OrderBy) which uses an unstable Quick-Sort on the original list. The merging on the sorted list is then also designed with this in mind.
Additionally, the algorithm is targeted to be efficient, which should of course be beneficial for large inputs.
Both these things clearly inhibit the readability of the code. Thus, for application limited to small inputs a more straight-forward approach might be preferable.

The development process is roughly documented in multiple Git commits.

I started out by defining a general Interval class and the functionality I expected to need. 
I was pretty sure from the beginning I was going to target an algorithm running on a sorted list of some kind, but still I wanted to structure the building blocks first.

Following this, I implemented the merging algorithm. As expected, it was possible to then simplify the actual "finding of intersection" and "creation of union" steps based on the sorted assumption.

Lastly, I added an "UnsafeInterval" class that skips any value-/null-checking to avoid unnecessary performance penalties while using known values. The performance of both classes is compared in the main program pipeline. I added a basic unit testing class that tests the example case from the task description.

As I designed the basic algorithm as pseudocode on my phone during a 1h train ride (See pseudocode picture), the actual implementation did not take long. The algorithm itself was transferred into code in well below an hour. I, however, took a bit of additional time (2-3h) documenting the code and designing the generic Interval model. The latter could of course have been shortened if time had been a critical factor or the code was interfacing to a preexisting data-structure.

Feel free to come back to me if there are any questions or points to talk about. I am happy to try and further illustrate my thought process.
