using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    internal class Program
    {
        #region "Notes"
        //Complexity classes
        //The following list contains common time complexities of algorithms:

        //* O(1) The running time of a constant-time algorithm does not depend on the
        //input size.A typical constant-time algorithm is a direct formula that
        //calculates the answer.

        //* O(log n) A logarithmic algorithm often halves the input size at each step.The
        //running time of such an algorithm is logarithmic, because log2 n equals the
        //number of times n must be divided by 2 to get 1.

        //* O(pn) A square root algorithm is slower than O(log n) but faster than O(n).
        //A special property of square roots is that pn = n / pn, so the square root pn
        //lies, in some sense, in the middle of the input.

        //* O(n) A linear algorithm goes through the input a constant number of times.This
        //is often the best possible time complexity, because it is usually necessary to
        //access each input element at least once before reporting the answer.

        //* O(n log n) This time complexity often indicates that the algorithm sorts the input,
        //because the time complexity of efficient sorting algorithms is O(n log n).
        //Another possibility is that the algorithm uses a data structure where each
        //operation takes O(log n) time.

        //* O(n2) A quadratic algorithm often contains two nested loops.It is possible to
        //go through all pairs of the input elements in O(n2) time.

        //* O(n3) A cubic algorithm often contains three nested loops.It is possible to go
        //through all triplets of the input elements in O(n3) time.

        //* O(2n) This time complexity often indicates that the algorithm iterates through
        //all subsets of the input elements.For example, the subsets of { 1, 2, 3} are ;,
        //{1}, {2}, {3}, {1, 2}, {1, 3}, {2, 3} and {1, 2, 3}.

        //* O(n!) This time complexity often indicates that the algorithm iterates through
        //all permutations of the input elements. For example, the permutations of
        //{ 1, 2, 3} are (1, 2, 3), (1, 3, 2), (2, 1, 3), (2, 3, 1), (3, 1, 2) and (3, 2, 1).

        //* Optimize your code: Review your code and look for any inefficiencies, such as nested loops or redundant computations.By optimizing your code, you can reduce the time complexity and avoid TLE.

        //* Use data structures and algorithms: Efficient data structures and algorithms can help you solve problems faster.Familiarize yourself with common data structures like arrays, linked lists, and trees, as well as algorithms like binary search, dynamic programming, and divide and conquer.

        //* Practice and improve your problem-solving skills: The more you practice, the better you'll get at solving problems efficiently. LeetCode offers a wide range of problems to practice with, so make sure to try different problems to improve your skills.

        //* Understand the problem: Make sure you fully understand the problem you're trying to solve. Misunderstanding the problem can lead to inefficient or incorrect solutions.

        //* Use memoization: Memoization is a technique where you store the results of expensive function calls and return the cached result when the same inputs occur again.This can help reduce the time complexity of certain problems. Precomputing.

        //* Be mindful of language-specific optimizations: Different programming languages have different strengths and weaknesses. Choose a language that suits the problem you're trying to solve and make use of any language-specific optimizations.

        //* Consider parallel processing: If the problem allows for it, you can try parallel processing to speed up the solution.This involves breaking the problem into smaller sub-problems and solving them simultaneously using multiple threads or processes.

        //* Use LeetCode's hints and discussions: LeetCode provides hints and discussions for each problem. These can help you understand the problem better and find more efficient solutions.
        #endregion
        #region "Main"
        static void Main(string[] args)
        {
            //Dummy Data:
            char[][] u = new char[9][];
            u[0] = new char[] { '.', '.', '9', '7', '4', '8', '.', '.', '.' };
            u[1] = new char[] { '7', '.', '.', '.', '.', '.', '.', '.', '.' };
            u[2] = new char[] { '.', '2', '.', '1', '.', '9', '.', '.', '.' };
            u[3] = new char[] { '.', '.', '7', '.', '.', '.', '2', '4', '.' };
            u[4] = new char[] { '.', '6', '4', '.', '1', '.', '5', '9', '.' };
            u[5] = new char[] { '.', '9', '8', '.', '.', '.', '3', '.', '.' };
            u[6] = new char[] { '.', '.', '.', '8', '.', '3', '.', '2', '.' };
            u[7] = new char[] { '.', '.', '.', '.', '.', '.', '.', '.', '6' };
            u[8] = new char[] { '.', '.', '.', '2', '7', '5', '9', '.', '.' };
            int[][] q = new int[10][];
            q[0] = new int[] { 1, 5 };
            q[1] = new int[] { 10, 4 };
            q[2] = new int[] { 4, 3 };
            q[3] = new int[] { 7, 3 };
            q[4] = new int[] { 3, 10 };
            q[5] = new int[] { 9, 8 };
            q[6] = new int[] { 8, 10 };
            q[7] = new int[] { 4, 3 };
            q[8] = new int[] { 1, 5 };
            q[9] = new int[] { 1, 5 };
            int k = 4;
            int f = 1000000000;
            string r = "s z z z s";
            string v = "s z ejt";
            string[] a = new string[] { "time", "to", "code" };
            int[] b = new int[] { 41, 8467, 6334, 6500, 9169, 5724, 1478 };
            char[] c = new char[] { 'h', 'e', 'l', 'l', 'o' };
            int[] d = new int[] { 174, 188, 377, 437, 54, 498, 455, 239, 183, 347, 59, 199, 52, 488, 147, 82 };
            int[] e = new int[] { 1, 2, 3 };
            List<IList<int>> z = new List<IList<int>>();
            z.Add(new List<int>() { -1 });
            z.Add(new List<int>() { 2, 3 });
            z.Add(new List<int>() { 1, -1, -3 });
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            //Execute Method Here
            stopwatch.Stop();
            Console.WriteLine("Time taken: " + stopwatch.ElapsedMilliseconds + "ms");
            Console.WriteLine("Done.");
            Console.ReadLine();
        }
        #endregion
    }
}