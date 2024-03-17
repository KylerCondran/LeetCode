using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class Hard
    {
        #region "Hard"
        //Title: 4. Median of Two Sorted Arrays
        //Link: https://leetcode.com/problems/median-of-two-sorted-arrays
        //Tags: Array, Binary Search, Divide and Conquer
        public static double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {

            int[] merged = nums1.Concat(nums2).ToArray();
            Array.Sort(merged);
            int size = merged.Length;
            if (size == 1) { return merged[0]; }
            if (size % 2 == 0)
            {
                int mid1 = merged[(size / 2) - 1];
                int mid2 = merged[((size / 2))];
                return (double)(mid1 + mid2) / 2;
            }
            else
            {
                int median = ((size + 1) / 2) - 1;
                return merged[median];
            }
        }
        //Title: 1944. Number of Visible People in a Queue
        //Link: https://leetcode.com/problems/number-of-visible-people-in-a-queue
        //Tags: Array, Stack, Monotonic Stack
        public static int[] CanSeePersonsCount(int[] heights)
        {
            int[] a = new int[heights.Length];
            int cansee = 0;
            for (int i = 0; i < heights.Length; i++)
            {
                a[i] = 0;
                int tallestsofar = 0;
                for (int j = i + 1; j < heights.Length; j++)
                {
                    if (heights[i] > heights[j])
                    {
                        if (tallestsofar < heights[j])
                        {
                            tallestsofar = heights[j];
                            cansee++;
                        }
                    }
                    else
                    {
                        cansee++;
                        break;
                    }
                }
                a[i] = cansee;
                cansee = 0;
            }
            return a;
        }
        //Title: 41. First Missing Positive
        //Link: https://leetcode.com/problems/first-missing-positive
        //Tags: Array, Hash Table
        public static int FirstMissingPositive(int[] nums)
        {
            int counter = 1;
            Array.Sort(nums);
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] > 0 && nums[i] >= counter)
                {
                    if (nums[i] != counter)
                    {
                        return counter;
                    }
                    counter++;
                }
            }
            if (nums.Max() < 0)
            {
                return 1;
            }
            return nums.Max() + 1;
        }
        //Title: 239. Sliding Window Maximum
        //Link: https://leetcode.com/problems/sliding-window-maximum
        //Tags: Array, Queue, Sliding Window, Heap(Priority Queue), Monotonic Queue
        //======================================================================================================================
        //I wrote and used this custom class to change the default sort behavior of the SortedDictionary from ascending to descending.
        //This sorts the keys in descending order which allows SortedDictionary.Keys.First() to be called rather than 
        //SortedDictionary.Keys.Last() which is much slower with larger datasets, likely due to iterating from the top to the bottom.
        //This allowed me to pass the time limit exceeded restriction and optimized the runtime complexity of my algorithm.
        //======================================================================================================================
        //public class ReverseSortComparer : IComparer<int>
        //{
        //    public int Compare(int x, int y)
        //    {
        //        return y.CompareTo(x);
        //    }
        //}
        //======================================================================================================================
        static int[] MaxSlidingWindow(int[] nums, int k)
        {
            SortedDictionary<int, int> a = new SortedDictionary<int, int>(new ReverseSortComparer());
            Queue<int> q = new Queue<int>();
            int final = nums.Length - k + 1;
            int[] ans = new int[final];
            int index = 0;
            for (int i = 0; i < k; i++)
            {
                q.Enqueue(nums[i]);
                if (!a.ContainsKey(nums[i]))
                {
                    a.Add(nums[i], 1);
                }
                else
                {
                    a[nums[i]]++;
                }
            }
            ans[index] = a.Keys.First();
            index++;
            for (int i = k; i < nums.Length; i++)
            {
                int peek = q.Peek();
                if (a[peek] == 1)
                {
                    a.Remove(peek);
                }
                else
                {
                    a[peek]--;
                }
                q.Dequeue();
                q.Enqueue(nums[i]);
                if (!a.ContainsKey(nums[i]))
                {
                    a.Add(nums[i], 1);
                }
                else
                {
                    a[nums[i]]++;
                }
                ans[index] = a.Keys.First();
                index++;
            }
            return ans;
        }
        #endregion
    }
    public class ReverseSortComparer : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            return y.CompareTo(x);
        }
    }
}