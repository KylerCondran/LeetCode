﻿using System;
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
        //Title: 273. Integer to English Words
        //Link: https://leetcode.com/problems/integer-to-english-words
        //Tags: Math, String, Recursion
        public static string NumberToWords(int num)
        {
            int start = num;
            string startstring = start.ToString();
            char[] c = startstring.ToCharArray();
            Array.Reverse(c);
            string backwards = new string(c);
            string final = "";
            Dictionary<int, string> a = new Dictionary<int, string>();
            a.Add(0, "Zero");
            a.Add(1, "One");
            a.Add(2, "Two");
            a.Add(3, "Three");
            a.Add(4, "Four");
            a.Add(5, "Five");
            a.Add(6, "Six");
            a.Add(7, "Seven");
            a.Add(8, "Eight");
            a.Add(9, "Nine");
            a.Add(10, "Ten");
            a.Add(11, "Eleven");
            a.Add(12, "Twelve");
            a.Add(13, "Thirteen");
            a.Add(14, "Fourteen");
            a.Add(15, "Fifteen");
            a.Add(16, "Sixteen");
            a.Add(17, "Seventeen");
            a.Add(18, "Eighteen");
            a.Add(19, "Nineteen");
            a.Add(20, "Twenty");
            a.Add(30, "Thirty");
            a.Add(40, "Forty");
            a.Add(50, "Fifty");
            a.Add(60, "Sixty");
            a.Add(70, "Seventy");
            a.Add(80, "Eighty");
            a.Add(90, "Ninety");
            a.Add(100, "Hundred");
            a.Add(1000, "Thousand");
            a.Add(1000000, "Million");
            a.Add(1000000000, "Billion");
            if (num == 0)
            {
                return a[0];
            }
            //billion
            if (num > 999999999)
            {
                int billion = 0;
                while (num > 999999999)
                {
                    billion++;
                    num = num - 1000000000;
                }
                final += a[billion] + " " + a[1000000000] + " ";
            }
            //hundred million
            if (num > 99999999)
            {
                int hundred = 0;
                while (num > 99999999)
                {
                    hundred++;
                    num = num - 100000000;
                }
                final += a[hundred] + " " + a[100] + " ";
            }
            //ten million
            if (num > 19999999)
            {
                int tens = 0;
                while (num > 9999999)
                {
                    tens++;
                    num = num - 10000000;
                }
                final += a[tens * 10] + " ";
            }
            //one million
            if (num > 999999)
            {
                int million = 0;
                while (num > 999999)
                {
                    million++;
                    num = num - 1000000;
                }
                final += a[million] + " " + a[1000000] + " ";
            }
            if (!final.Contains("Million") && start > 999999)
            {
                int counter = 0;
                for (int i = 6; i < backwards.Length; i++)
                {
                    if (counter >= 3)
                    {
                        break;
                    }
                    if (backwards[i] != '0')
                    {
                        final = final + a[1000000] + " ";
                        break;
                    }
                    counter++;
                }
            }
            //hundred thousand
            if (num > 99999)
            {
                int hundred = 0;
                while (num > 99999)
                {
                    hundred++;
                    num = num - 100000;
                }
                final += a[hundred] + " " + a[100] + " ";
            }
            //ten thousand
            if (num > 19999)
            {
                int tens = 0;
                while (num > 9999)
                {
                    tens++;
                    num = num - 10000;
                }
                final += a[tens * 10] + " ";
            }
            //one thousand
            if (num > 999)
            {
                int thousand = 0;
                while (num > 999)
                {
                    thousand++;
                    num = num - 1000;
                }
                final += a[thousand] + " " + a[1000] + " ";
            }
            if (!final.Contains("Thousand") && start > 999)
            {
                int counter = 0;
                for (int i = 3; i < backwards.Length; i++)
                {
                    if (counter >= 3)
                    {
                        break;
                    }
                    if (backwards[i] != '0')
                    {
                        final = final + a[1000] + " ";
                        break;
                    }
                    counter++;
                }
            }
            //hundred
            if (num > 99)
            {
                int hundred = 0;
                while (num > 99)
                {
                    hundred++;
                    num = num - 100;
                }
                final += a[hundred] + " " + a[100] + " ";
            }
            //tens
            if (num > 19)
            {
                int tens = 0;
                while (num > 9)
                {
                    tens++;
                    num = num - 10;
                }
                final += a[tens * 10] + " ";
            }
            //ones
            if (num > 0)
            {
                int ones = 0;
                while (num > 0)
                {
                    ones++;
                    num = num - 1;
                }
                final += a[ones];
            }
            final = final.TrimEnd();
            return final;
        }
        //Title: 23. Merge k Sorted Lists
        //Link: https://leetcode.com/problems/merge-k-sorted-lists
        //Tags: Linked List, Divide and Conquer, Heap(Priority Queue), Merge Sort
        public static ListNode MergeKLists(ListNode[] lists)
        {
            SortedDictionary<int, int> a = new SortedDictionary<int, int>();
            ListNode head = null;
            foreach (var list in lists)
            {
                ListNode mylist = list;
                while (mylist != null)
                {
                    int listval = mylist.val;
                    if (!a.ContainsKey(listval))
                    {
                        a.Add(listval, 1);
                    }
                    else
                    {
                        a[listval]++;
                    }
                    mylist = mylist.next;
                }
            }
            foreach (KeyValuePair<int, int> b in a)
            {
                for (int i = 0; i < b.Value; i++)
                {
                    AddLink(ref head, b.Key);
                }
            }
            return head;
        }
        public static void AddLink(ref ListNode headref, int linkval)
        {
            ListNode link = new ListNode(linkval);
            if (headref == null)
            {
                headref = link;
            }
            else
            {
                ListNode current = headref;
                while (current.next != null)
                {
                    current = current.next;
                }
                current.next = link;
            }
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
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }
}