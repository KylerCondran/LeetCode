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
        #endregion
    }
}