# Accepted LeetCode Solutions

This repository contains all my solutions to LeetCode problems implemented in C#. 

Here is a link to my LeetCode [Account](https://leetcode.com/u/KylerCondran/).

## About LeetCode

[LeetCode](https://leetcode.com/) is a popular online platform for practicing coding interview questions. It offers a vast array of problems across multiple difficulty levels, covering topics such as algorithms, data structures, and more.

## About This Repository

The primary goal of this repository is to challenge myself and provide a resource for learning and understanding different problem-solving techniques in C#. By analyzing and implementing solutions to LeetCode problems, you can improve your problem-solving skills, understand various algorithms and data structures, and prepare for technical interviews. This code base is not perfect and could benefit from further optimization and cleanup, and some of the code I wrote may be downright silly, but each solution was accepted by the LeetCode judging software at the time of publishing.

## Structure

In the project directory, I have a class file for each difficulty level of problems and an extra class file for helper methods. Each difficulty class file has two region tags, methods for individual problems are on top, and stand alone classes for design problems on bottom. The program class file contains the main run method, some dummy data, and helpful notes in case you wanted to run any of the solutions. There are also some folders for non C# related LeetCode categories. Each solution includes a numbered title, a link to the problem, tags associated with the problem, and the corresponding C# code that successfully solved the problem.

## Getting Started

1. Download
```
git clone https://github.com/KylerCondran/LeetCode.git
```

## Things I Wish I Knew When First Starting

- Question difficulties are often mislabeled, some easy's are quite hard, and there are hard problems which can be solved in 1 line of code.
- Sometimes the question description is purposely misleading or confusing, leetcode problem writers are tricksters and trolls. Hints, discussion section, and topic labels are often great clues. Understanding the problem is literally half the battle.
- It is better to do 100 easy's before you do a medium, and 100 medium's before you do a hard.
- What is hard for some people may be easy to you and vica versa, everyone has a unique skill set and learning ability.
- Non increasing just means decreasing but with duplicates, non decreasing means increasing but with duplicates.
- If you are stumped on a question, instead of looking at the solution, look at a solution for a similar problem to find some starter code or get a better idea of what is needed.
- Once you learn a new skill or data structure like linked lists or tree's, you will get some starter code that can then be used to pop 20-30 questions quickly with minimal changes.
- Spend some time exclusively hunting for problems you think you can accomplish, sort by difficulty / category / acceptance rate, use the browser bookmark toolbar and create folders, scan through questions and dump them into folders of different categories.
- Acceptance rate does not mean difficulty level, it means it was the average amount of submits required to get accepted status. This number can be skewed by purposely obtuse test cases not mentioned in the problem.
- The easiest way to start a GitHub portfolio is to just save your LeetCode solutions.
- Its best to get comfy and drink coffee while LeetCoding.

## Examples

Here is some super simple starter code to get you started working with common data structures.

### Building A Priority Queue
```
Dictionary<int, int> a = new Dictionary<int, int>();
for (int i = 0; i < nums.Length; i++)
{
    int val = nums[i];
    if (!a.ContainsKey(val))
    {
        a.Add(val, 1);
    }
    else
    {
        a[val]++;
    }
}
```
### Parsing A Linked List
```
while (head != null)
{
    int val = head.val;
    head = head.next;
}
```
### Parsing A Tree
```
Queue<TreeNode> q = new Queue<TreeNode>();
q.Enqueue(root);
while (q.Count > 0)
{
    TreeNode T = q.Dequeue();
    if (T.left != null)
    {
        q.Enqueue(T.left);
    }
    if (T.right != null)
    {
        q.Enqueue(T.right);
    }
}
```

## Submit Error Codes

### Time Limit Exceeded

This error code means your application took too long to finish. LeetCode has a built in cut off switch that kills your application if it does not finish in a predetermined amount of time. This can mean a few things, it can mean your application is getting stuck in an infinite loop, it can also mean your application was not as efficient as required by the problem. Large test cases can cause your program to struggle to finish in a reasonable amount of time. Some things you can do to optimize your code:

1. Analyze the time complexity of your algorithm to understand its performance characteristics.
2. Identify potential bottlenecks in your code that may be causing the slowdown.
3. Consider using more efficient algorithms or data structures to solve the problem.
4. Optimize your code by eliminating unnecessary operations or reducing the number of iterations.
5. Experiment with different approaches and optimizations until you find a solution that runs within the time limit specified by LeetCode.

The goal is to reduce calculations, calculate only what you need and do it once, use variables when you have finished the calculation and want to reuse the data, try to remove any nested loops or redundant computations, avoid expensive collection iteration calls like Dictionary.Count() / Dictionary.ElementAt(), use integer counter variables instead, precalculate data and hardcode if possible, use fast data structures like queues and stacks and hashsets and algorithms like binary search patterns, use a string builder instead of doing string concatenation ("stringa" + "stringb") because strings are immutable data types, cache the results of expensive calculations, minimize object creation, especially inside loops, and use for loops instead of foreach loops where possible.

Do not get discouraged, often when you hit time limit exceeded instead of racking your brain on the problem for hours its best to immediately put it aside, take note and log it in an excel sheet with the title, link to the problem, and how many test cases you got through, save and store the code in a project, move on and come back later with a fresh mind and outlook after you have had a chance to ponder how it can be optimized.

Some easy problems have time limits, more medium problems have time limits, and nearly all hard problems have time limits and brute force may not always be possible, some hard problems only have one solution which is a famous and obscure algorithm such as Kadane / Dijkstra / Euclid. 

Research Topics:  
[Time Complexity](https://en.wikipedia.org/wiki/Time_complexity)  
[Big O Notation](https://en.wikipedia.org/wiki/Big_O_notation)  

### Memory Limit Exceeded

This error code means you have a memory leak somewhere. One of your objects are getting too large to handle or you are not freeing resources after they are done being used. Consider using the data structures more efficiently, avoid allocating resources when unecessary, rethink the algorithm to use less space intensive techniques.

### Test Cases Passed But Took Too Long

This is a frustrating error code but it is actually really good news, it means you are super close to having your solution accepted but the program still took longer to finish than allowed. Final tweaks need to be made to make your application faster. Optimize your code to make it run faster, it may be stuggling on a larger than average test case.

## Data Structure Pros/Cons

1. Array
   - Optimal Use Case: When the size is fixed and known in advance, and random access or iteration over elements is frequent.
   - Potential Drawbacks: Fixed size, inefficient for dynamic resizing, and costly insertions/deletions in the middle.
     
2. List<T>
   - Optimal Use Case: When the size may change dynamically and frequent insertion/deletion at the end or random access to elements is required.
   - Potential Drawbacks: Dynamic resizing may lead to occasional memory reallocations and copying of elements, especially for large lists.
     
3. Dictionary<TKey, TValue>
   - Optimal Use Case: When key-value pairs need to be stored and efficient lookups by key are required.
   - Potential Drawbacks: Hash collisions can degrade performance, especially for poorly distributed keys. Additionally, iteration order is not guaranteed.

4. HashSet<T>
   - Optimal Use Case: When a collection of unique items needs to be stored, and fast membership tests (contains) are required.
   - Potential Drawbacks: Hash collisions and the need for a good hash function can impact performance. Iteration order is not guaranteed.
     
5. Queue<T>
   - Optimal Use Case: When a first-in-first-out (FIFO) data structure is needed, such as task scheduling or breadth-first search algorithms.
   - Potential Drawbacks: Inefficient for random access to elements. Removing elements other than the head of the queue requires iterating through the entire queue.
     
6. Stack<T>
   - Optimal Use Case: When a last-in-first-out (LIFO) data structure is needed, such as expression evaluation or backtracking algorithms.
   - Potential Drawbacks: Inefficient for random access to elements. Removing elements other than the top of the stack requires popping elements sequentially.
     
7. LinkedList<T>
   - Optimal Use Case: When frequent insertion/deletion at arbitrary positions in the collection is required, and random access is not necessary.
   - Potential Drawbacks: Higher memory overhead compared to arrays due to additional pointers. Inefficient for random access to elements.
     
8. SortedDictionary<TKey, TValue>
   - Optimal Use Case: When key-value pairs need to be stored, and iteration in sorted order by key is required.
   - Potential Drawbacks: Slower insertion and deletion compared to hash-based dictionaries due to maintaining sorted order.
     
9. SortedSet<T>
   - Optimal Use Case: When a collection of unique items needs to be stored, and iteration in sorted order is required.
   - Potential Drawbacks: Slower insertion and deletion compared to hash-based sets due to maintaining sorted order.  
