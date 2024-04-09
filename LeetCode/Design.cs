using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    #region "Design"
    //Title: 382. Linked List Random Node
    //Link: https://leetcode.com/problems/linked-list-random-node
    //Difficulty: Medium
    //Tags: Linked List, Math, Reservoir Sampling, Randomized
    public class Solution
    {
        List<int> a = new List<int>();
        public Solution(ListNode head)
        {
            while (head != null)
            {
                a.Add(head.val);
                head = head.next;
            }
        }
        public int GetRandom()
        {
            Random rnd = new Random();
            int rand = rnd.Next(0, a.Count);
            return a[rand];
        }
    }
    //Title: 535. Encode and Decode TinyURL
    //Link: https://leetcode.com/problems/encode-and-decode-tinyurl
    //Difficulty: Medium
    //Tags: Hash Table, String, Design, Hash Function
    public class Codec
    {
        // Encodes a URL to a shortened URL
        public string encode(string longUrl)
        {
            var encoded = System.Text.Encoding.UTF8.GetBytes(longUrl);
            return System.Convert.ToBase64String(encoded);
        }
        // Decodes a shortened URL to its original URL.
        public string decode(string shortUrl)
        {
            var decoded = System.Convert.FromBase64String(shortUrl);
            return System.Text.Encoding.UTF8.GetString(decoded);
        }
    }
    //Title: 1603. Design Parking System
    //Link: https://leetcode.com/problems/design-parking-system
    //Difficulty: Easy
    //Tags: Design, Simulation, Counting
    public class ParkingSystem
    {
        int big;
        int medium;
        int small;
        public ParkingSystem(int big, int medium, int small)
        {
            this.big = big;
            this.medium = medium;
            this.small = small;
        }
        public bool AddCar(int carType)
        {
            if (carType == 1)
            {
                if (this.big > 0)
                {
                    this.big -= 1;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (carType == 2)
            {
                if (this.medium > 0)
                {
                    this.medium -= 1;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (carType == 3)
            {
                if (this.small > 0)
                {
                    this.small -= 1;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
    }
    //Title: 933. Number of Recent Calls
    //Link: https://leetcode.com/problems/number-of-recent-calls
    //Difficulty: Easy
    //Tags: Design, Queue, Data Stream
    public class RecentCounter
    {
        List<int> a;
        public RecentCounter()
        {
            this.a = new List<int>();
        }
        public int Ping(int t)
        {
            this.a.Add(t);
            int counter = 0;
            foreach (int b in a)
            {
                if (t - 3000 <= b && b <= t)
                {
                    counter++;
                }
            }
            return counter;
        }
    }
    //Title: 2043. Simple Bank System
    //Link: https://leetcode.com/problems/simple-bank-system
    //Difficulty: Medium
    //Tags: Array, Hash Table, Design, Simulation
    public class Bank
    {
        long[] vault;
        int accounts;
        public Bank(long[] balance)
        {
            this.vault = new long[balance.Length];
            int counter = 0;
            this.accounts = balance.Length;
            for (int i = 0; i < balance.Length; i++)
            {
                this.vault[counter] = balance[counter];
                counter++;
            }
        }
        public bool Transfer(int account1, int account2, long money)
        {
            if (account1 > this.accounts || account2 > this.accounts)
            {
                return false;
            }
            if (this.vault[account1 - 1] >= money)
            {
                this.vault[account1 - 1] -= money;
                this.vault[account2 - 1] += money;
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool Deposit(int account, long money)
        {
            if (account > this.accounts)
            {
                return false;
            }
            this.vault[account - 1] += money;
            return true;
        }
        public bool Withdraw(int account, long money)
        {
            if (account > this.accounts)
            {
                return false;
            }
            if (this.vault[account - 1] >= money)
            {
                this.vault[account - 1] -= money;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    //Title: 398. Random Pick Index
    //Link: https://leetcode.com/problems/random-pick-index
    //Difficulty: Medium
    //Tags: Hash Table, Math, Reservoir Sampling, Randomized
    public class RandomPick
    {
        Dictionary<int, List<int>> a = new Dictionary<int, List<int>>();
        public RandomPick(int[] nums)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                if (!a.ContainsKey(nums[i]))
                {
                    List<int> b = new List<int>();
                    b.Add(i);
                    a.Add(nums[i], b);
                }
                else
                {
                    a[nums[i]].Add(i);
                }
            }
        }
        public int Pick(int target)
        {
            List<int> c = a[target];
            Random rnd = new Random();
            int rand = rnd.Next(0, c.Count);
            return c[rand];
        }
    }
    //Title: 2671. Frequency Tracker
    //Link: https://leetcode.com/problems/frequency-tracker
    //Difficulty: Medium
    //Tags: Hash Table, Design
    public class FrequencyTracker
    {
        Dictionary<int, int> a = new Dictionary<int, int>();
        Dictionary<int, int> b = new Dictionary<int, int>();
        public FrequencyTracker()
        {

        }
        public void Add(int number)
        {
            if (!a.ContainsKey(number))
            {
                a.Add(number, 1);
                if (!b.ContainsKey(1))
                {
                    b.Add(1, 1);
                }
                else
                {
                    b[1]++;
                }
            }
            else
            {
                int count = a[number];
                a[number]++;
                if (b.ContainsKey(count))
                {
                    if (b[count] == 1)
                    {
                        b.Remove(count);
                    }
                    else
                    {
                        b[count]--;
                    }
                }
                if (!b.ContainsKey(count + 1))
                {
                    b.Add(count + 1, 1);
                }
                else
                {
                    b[count + 1]++;
                }
            }
        }
        public void DeleteOne(int number)
        {
            if (a.ContainsKey(number))
            {
                int count = a[number];
                if (a[number] == 1)
                {
                    a.Remove(number);
                }
                else
                {
                    a[number]--;
                }
                if (!b.ContainsKey(count - 1))
                {
                    b.Add(count - 1, 1);
                }
                else
                {
                    b[count - 1]++;
                }
                if (b.ContainsKey(count))
                {
                    if (b[count] == 1)
                    {
                        b.Remove(count);
                    }
                    else
                    {
                        b[count]--;
                    }
                }
            }
        }
        public bool HasFrequency(int frequency)
        {
            if (b.ContainsKey(frequency))
            {
                return true;
            }
            return false;
        }
    }
    //Title: 1381. Design a Stack With Increment Operation
    //Link: https://leetcode.com/problems/design-a-stack-with-increment-operation
    //Difficulty: Medium
    //Tags: Array, Stack, Design
    public class CustomStack
    {
        List<int> a = new List<int>();
        int max = 0;
        public CustomStack(int maxSize)
        {
            this.max = maxSize;
        }
        public void Push(int x)
        {
            if (a.Count != max)
            {
                a.Add(x);
            }
        }
        public int Pop()
        {
            if (a.Count > 0)
            {
                int val = a[a.Count - 1];
                a.RemoveAt(a.Count - 1);
                return val;
            }
            else
            {
                return -1;
            }
        }
        public void Increment(int k, int val)
        {
            if (a.Count > 0)
            {
                if (a.Count < k)
                {
                    for (int i = 0; i < a.Count; i++)
                    {
                        a[i] = a[i] + val;
                    }
                }
                else
                {
                    for (int i = 0; i < k; i++)
                    {
                        a[i] = a[i] + val;
                    }
                }
            }
        }
    }
    //Title: 2336. Smallest Number in Infinite Set
    //Link: https://leetcode.com/problems/smallest-number-in-infinite-set
    //Difficulty: Medium
    //Tags: Hash Table, Design, Heap(Priority Queue)
    public class SmallestInfiniteSet
    {
        SortedDictionary<int, int> a = new SortedDictionary<int, int>();
        public SmallestInfiniteSet()
        {
            for (int i = 1; i < 2000; i++)
            {
                a.Add(i, 1);
            }
        }
        public int PopSmallest()
        {
            int val = a.ElementAt(0).Key;
            a.Remove(a.ElementAt(0).Key);
            return val;
        }
        public void AddBack(int num)
        {
            if (!a.ContainsKey(num))
            {
                a.Add(num, 1);
            }
        }
    }
    //Title: 155. Min Stack
    //Link: https://leetcode.com/problems/min-stack
    //Difficulty: Medium
    //Tags: Stack, Design
    public class MinStack
    {
        List<int> a = new List<int>();
        SortedDictionary<int, int> b = new SortedDictionary<int, int>();
        public MinStack()
        {

        }
        public void Push(int val)
        {
            a.Add(val);
            if (!b.ContainsKey(val))
            {
                b.Add(val, 1);
            }
            else
            {
                b[val]++;
            }
        }
        public void Pop()
        {
            int val = a[a.Count - 1];
            a.RemoveAt(a.Count - 1);
            if (b.ContainsKey(val))
            {
                if (b[val] == 1)
                {
                    b.Remove(val);
                }
                else
                {
                    b[val]--;
                }
            }
        }
        public int Top()
        {
            int val = a[a.Count - 1];
            return val;
        }
        public int GetMin()
        {
            return b.ElementAt(0).Key;
        }
    }
    //Title: 1845. Seat Reservation Manager
    //Link: https://leetcode.com/problems/seat-reservation-manager
    //Difficulty: Medium
    //Tags: Design, Heap(Priority Queue)
    public class SeatManager
    {
        SortedDictionary<int, int> a = new SortedDictionary<int, int>();
        SortedDictionary<int, int> b = new SortedDictionary<int, int>();
        public SeatManager(int n)
        {
            for (int i = 1; i <= n; i++)
            {
                if (!a.ContainsKey(i))
                {
                    a.Add(i, 0);
                }
            }
        }
        public int Reserve()
        {
            int val = a.ElementAt(0).Key;
            b.Add(val, 1);
            a.Remove(val);
            return val;
        }
        public void Unreserve(int seatNumber)
        {
            b.Remove(seatNumber);
            a.Add(seatNumber, 0);
        }
    }
    //Title: 2424. Longest Uploaded Prefix
    //Link: https://leetcode.com/problems/longest-uploaded-prefix
    //Difficulty: Medium
    //Tags: Binary Search, Union Find, Design, Binary Indexed Tree, Segment Tree, Heap(Priority Queue), Ordered Set
    public class LUPrefix
    {
        int[] a;
        public LUPrefix(int n)
        {
            this.a = new int[n];
        }
        public void Upload(int video)
        {
            a[video - 1] = video;
        }
        public int Longest()
        {
            int count = Array.IndexOf(a, 0);
            if (count == -1)
            {
                count = a.Length;
            }
            return count;
        }
    }
    //Title: 895. Maximum Frequency Stack
    //Link: https://leetcode.com/problems/maximum-frequency-stack
    //Difficulty: Hard
    //Tags: Hash Table, Stack, Design, Ordered Set
    public class FreqStack
    {
        Dictionary<int, int> a;
        List<int> b;
        SortedDictionary<int, List<int>> c;
        public FreqStack()
        {
            this.a = new Dictionary<int, int>();
            this.b = new List<int>();
            this.c = new SortedDictionary<int, List<int>>(new ReverseSortComparer());
        }
        public void Push(int val)
        {
            if (!a.ContainsKey(val))
            {
                a.Add(val, 1);
                if (!c.ContainsKey(1))
                {
                    c.Add(1, new List<int> { val });
                }
                else
                {
                    c[1].Add(val);
                }
            }
            else
            {
                c[a[val]].Remove(val);
                if (c[a[val]].Count == 0)
                {
                    c.Remove(a[val]);
                }
                a[val]++;
                if (!c.ContainsKey(a[val]))
                {
                    c.Add(a[val], new List<int> { val });
                }
                else
                {
                    c[a[val]].Add(val);
                }
            }
            b.Add(val);
        }
        public int Pop()
        {
            int min = Int32.MinValue;
            int integer = -1;
            if (c.ElementAt(0).Value.Count == 1)
            {
                int num = c.ElementAt(0).Value[0];
                int index = b.LastIndexOf(num);
                if (index != -1 && index > min)
                {
                    min = index;
                    integer = num;
                }
            }
            else if (c.ElementAt(0).Value.Count > 1)
            {
                int[] d = new int[2];
                d = GetIndex(b, c.ElementAt(0).Value);
                if (d[0] != -1)
                {
                    min = d[0];
                    integer = d[1];
                }
            }
            c[a[integer]].Remove(integer);
            if (c[a[integer]].Count == 0)
            {
                c.Remove(a[integer]);
            }
            a[integer]--;
            if (!c.ContainsKey(a[integer]))
            {
                c.Add(a[integer], new List<int> { integer });
            }
            else
            {
                if (a[integer] != 0)
                {
                    c[a[integer]].Add(integer);
                }
            }
            if (a[integer] == 0)
            {
                a.Remove(integer);
            }
            b.RemoveAt(min);
            return integer;
        }
        public int[] GetIndex(List<int> list, List<int> topfreq)
        {
            int[] ans = new int[2];
            ans[0] = -1;
            ans[1] = -1;
            for (int index = list.Count - 1; index >= 0; index--)
            {
                if (topfreq.Contains(list[index]))
                {
                    ans[0] = index;
                    ans[1] = list[index];
                    return ans;
                }
            }
            return ans;
        }
    }
    //Title: 432. All O`one Data Structure
    //Link: https://leetcode.com/problems/all-oone-data-structure
    //Difficulty: Hard
    //Tags: Hash Table, Linked List, Design, Doubly-Linked List
    public class AllOne
    {
        Dictionary<string, int> a;
        SortedDictionary<int, List<string>> b;
        public AllOne()
        {
            this.a = new Dictionary<string, int>();
            this.b = new SortedDictionary<int, List<string>>(new ReverseSortComparer());
        }
        public void Inc(string key)
        {
            if (!a.ContainsKey(key))
            {
                a.Add(key, 1);
                if (!b.ContainsKey(1))
                {
                    b.Add(1, new List<string> { key });
                }
                else
                {
                    b[1].Add(key);
                }
            }
            else
            {
                b[a[key]].Remove(key);
                if (b[a[key]].Count == 0)
                {
                    b.Remove(a[key]);
                }
                a[key]++;
                if (!b.ContainsKey(a[key]))
                {
                    b.Add(a[key], new List<string> { key });
                }
                else
                {
                    b[a[key]].Add(key);
                }
            }
        }
        public void Dec(string key)
        {
            if (a[key] == 1)
            {
                b[a[key]].Remove(key);
                if (b[a[key]].Count == 0)
                {
                    b.Remove(a[key]);
                }
                a.Remove(key);
            }
            else
            {
                b[a[key]].Remove(key);
                if (b[a[key]].Count == 0)
                {
                    b.Remove(a[key]);
                }
                a[key]--;
                if (!b.ContainsKey(a[key]))
                {
                    b.Add(a[key], new List<string> { key });
                }
                else
                {
                    b[a[key]].Add(key);
                }
            }
        }
        public string GetMaxKey()
        {
            if (a.Count == 0) return "";
            return b.ElementAt(0).Value[0];
        }
        public string GetMinKey()
        {
            if (a.Count == 0) return "";
            return b.ElementAt(b.Count - 1).Value[0];
        }
    }
    //Title: 295. Find Median from Data Stream
    //Link: https://leetcode.com/problems/find-median-from-data-stream
    //Difficulty: Hard
    //Tags: Two Pointers, Design, Sorting, Heap(Priority Queue), Data Stream
    public class MedianFinder
    {
        List<int> a;
        public MedianFinder()
        {
            this.a = new List<int>();
        }
        public void AddNum(int num)
        {
            InsertIntoSortedList(a, num, (a, b) => a.CompareTo(b));
        }
        public double FindMedian()
        {
            int size = a.Count;
            if (size == 1) { return (double)a[0]; }
            if (size % 2 == 0)
            {
                int mid1 = a[(size / 2) - 1];
                int mid2 = a[((size / 2))];
                return (double)(mid1 + mid2) / 2;
            }
            else
            {
                int median = ((size + 1) / 2) - 1;
                return (double)a[median];
            }
        }
        public void InsertIntoSortedList(IList list, IComparable value, Comparison<IComparable> comparison)
        {
            var startIndex = 0;
            var endIndex = list.Count;
            while (endIndex > startIndex)
            {
                var windowSize = endIndex - startIndex;
                var middleIndex = startIndex + (windowSize / 2);
                var middleValue = (IComparable)list[middleIndex];
                var compareToResult = comparison(middleValue, value);
                if (compareToResult == 0)
                {
                    list.Insert(middleIndex, value);
                    return;
                }
                else if (compareToResult < 0)
                {
                    startIndex = middleIndex + 1;
                }
                else
                {
                    endIndex = middleIndex;
                }
            }
            list.Insert(startIndex, value);
        }
    }
    //Title: 729. My Calendar I
    //Link: https://leetcode.com/problems/my-calendar-i
    //Difficulty: Medium
    //Tags: Binary Search, Design, Segment Tree, Ordered Set
    public class MyCalendar
    {
        List<BookRange> a;
        public MyCalendar()
        {
            this.a = new List<BookRange>();
        }
        public bool Book(int start, int end)
        {
            foreach (BookRange i in a)
            {
                if ((start >= i.start && start < i.end) || (end <= i.end && end > i.start) || (start < i.start && end > i.end))
                {
                    return false;
                }
            }
            BookRange b = new BookRange();
            b.start = start;
            b.end = end;
            a.Add(b);
            return true;
        }
    }
    #endregion
}