using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Security.Policy;
using System.Text.RegularExpressions;
using System.Collections;
using System.Net.Sockets;

namespace LeetCode
{
    public class Medium
    {
        #region "Medium"
        //Title: 238. Product of Array Except Self
        //Link: https://leetcode.com/problems/product-of-array-except-self
        //Tags: Array, Prefix Sum
        public static int[] ProductExceptSelf(int[] nums)
        {
            int[] a = new int[nums.Length];
            int prefix = 1;
            for (int i = 0; i < nums.Length; i++)
            {
                a[i] = prefix;

            }
            for (int i = 0; i < nums.Length; i++)
            {
                a[i] *= prefix;
                prefix *= nums[i];

            }
            int postfix = 1;
            for (int i = nums.Length - 1; i >= 0; i--)
            {
                a[i] *= postfix;
                postfix *= nums[i];

            }
            return a;
        }
        //Title: 3. Longest Substring Without Repeating Characters
        //Link: https://leetcode.com/problems/longest-substring-without-repeating-characters
        //Tags: Hash Table, String, Sliding Window
        public static int LengthOfLongestSubstring(string s)
        {
            Queue<char> q = new Queue<char>();
            int max = 0;
            foreach (char l in s)
            {
                while (q.Contains(l))
                {
                    q.Dequeue();
                }
                q.Enqueue(l);
                max = Math.Max(max, q.Count);
            }
            return max;
        }
        //Title: 8. String to Integer (atoi)
        //Link: https://leetcode.com/problems/string-to-integer-atoi
        //Tags: String
        public static int MyAtoi(string s)
        {
            s = s.TrimStart();
            if (s == "") { return 0; }
            bool negative = false;
            if (s[0] == '+')
            {
                s = s.Remove(0, 1);
            }
            else if (s[0] == '-')
            {
                negative = true;
                s = s.Remove(0, 1);
            }
            string digits = "";
            for (int i = 0; i < s.Length; i++)
            {
                if (char.IsDigit(s[i]))
                {
                    digits += s[i];
                }
                else
                {
                    break;
                }
            }
            if (digits == "") { return 0; }
            BigInteger x = 0;
            int final = 0;
            BigInteger.TryParse(digits, out x);
            if (0 <= x && x <= 2147483647)
            {
                if (negative)
                {
                    final = ((int)x);
                    final = final * -1;
                }
                else
                {
                    final = ((int)x);
                }
            }
            else
            {
                if (negative)
                {
                    final = -2147483648;
                }
                else
                {
                    final = 2147483647;
                }
            }
            return final;
        }
        //Title: 12. Integer to Roman
        //Link: https://leetcode.com/problems/integer-to-roman
        //Tags: Hash Table, Math, String
        public static string IntToRoman(int num)
        {
            string final = "";
            while (num >= 1000)
            {
                final += "M";
                num -= 1000;
            }
            if (num >= 900)
            {
                final += "CM";
                num -= 900;
            }
            if (num >= 500)
            {
                final += "D";
                num -= 500;
            }
            if (num >= 400)
            {
                final += "CD";
                num -= 400;
            }
            while (num >= 100)
            {
                final += "C";
                num -= 100;
            }
            if (num >= 90)
            {
                final += "XC";
                num -= 90;
            }
            if (num >= 50)
            {
                final += "L";
                num -= 50;
            }
            if (num >= 40)
            {
                final += "XL";
                num -= 40;
            }
            while (num >= 10)
            {
                final += "X";
                num -= 10;
            }
            if (num >= 9)
            {
                final += "IX";
                num -= 9;
            }
            if (num >= 5)
            {
                final += "V";
                num -= 5;
            }
            if (num >= 4)
            {
                final += "IV";
                num -= 4;
            }
            while (num >= 1)
            {
                final += "I";
                num -= 1;
            }
            return final;
        }
        //Title: 17. Letter Combinations of a Phone Number
        //Link: https://leetcode.com/problems/letter-combinations-of-a-phone-number
        //Tags: Hash Table, String, Backtracking
        public static IList<string> LetterCombinations(string digits)
        {
            List<char[]> a = new List<char[]>();
            List<string> b = new List<string>();
            if (digits.Length == 0)
            {
                return b;
            }
            char[] two = { 'a', 'b', 'c' };
            char[] three = { 'd', 'e', 'f' };
            char[] four = { 'g', 'h', 'i' };
            char[] five = { 'j', 'k', 'l' };
            char[] six = { 'm', 'n', 'o' };
            char[] seven = { 'p', 'q', 'r', 's' };
            char[] eight = { 't', 'u', 'v' };
            char[] nine = { 'w', 'x', 'y', 'z' };
            for (int i = 0; i < digits.Length; i++)
            {
                switch (digits[i])
                {
                    case '2':
                        a.Add(two);
                        break;
                    case '3':
                        a.Add(three);
                        break;
                    case '4':
                        a.Add(four);
                        break;
                    case '5':
                        a.Add(five);
                        break;
                    case '6':
                        a.Add(six);
                        break;
                    case '7':
                        a.Add(seven);
                        break;
                    case '8':
                        a.Add(eight);
                        break;
                    case '9':
                        a.Add(nine);
                        break;
                }
            }
            char first;
            char second;
            char third;
            char fourth;
            string final = "";
            foreach (char p in a[0])
            {
                first = p;
                if (a.Count > 1)
                {
                    foreach (char m in a[1])
                    {
                        second = m;
                        if (a.Count > 2)
                        {
                            foreach (char g in a[2])
                            {
                                third = g;
                                if (a.Count > 3)
                                {
                                    foreach (char h in a[3])
                                    {
                                        fourth = h;
                                        final = "";
                                        final += first;
                                        final += second;
                                        final += third;
                                        final += fourth;
                                        b.Add(final);
                                    }
                                }
                                else
                                {
                                    final = "";
                                    final += first;
                                    final += second;
                                    final += third;
                                    b.Add(final);
                                }
                            }
                        }
                        else
                        {
                            final = "";
                            final += first;
                            final += second;
                            b.Add(final);
                        }
                    }
                }
                else
                {
                    final = "";
                    final += first;
                    b.Add(final);
                }
            }
            return b;
        }
        //Title: 34. Find First and Last Position of Element in Sorted Array
        //Link: https://leetcode.com/problems/find-first-and-last-position-of-element-in-sorted-array
        //Tags: Array, Binary Search
        public static int[] SearchRange(int[] nums, int target)
        {
            int first = -1;
            int second = -1;
            int which = 0;
            int howmany = 0;
            int counter = 0;
            int[] a = new int[2];
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == target)
                {
                    howmany++;
                }
            }
            if (howmany == 0)
            {
                a[0] = -1;
                a[1] = -1;
                return a;
            }
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == target)
                {
                    if (howmany == 1)
                    {
                        a[0] = i;
                        a[1] = i;
                        return a;
                    }
                    else if (howmany == 2)
                    {
                        if (which == 0)
                        {
                            first = i;
                            which++;
                        }
                        else
                        {
                            second = i;
                        }
                    }
                    else if (howmany > 2)
                    {
                        counter++;
                        if (first == -1)
                        {
                            first = i;
                        }
                        if (second == -1 && counter == howmany)
                        {
                            second = i;
                        }
                    }
                }
            }
            a[0] = first;
            a[1] = second;
            return a;
        }
        //Title: 46. Permutations
        //Link: https://leetcode.com/problems/permutations
        //Tags: Array, Backtracking
        public static IList<IList<int>> Permute(int[] nums)
        {
            IEnumerable<IEnumerable<int>> result = GetPermutations(nums, nums.Length);
            List<IList<int>> aa = new List<IList<int>>();
            foreach (IEnumerable<int> o in result)
            {
                List<int> bb = new List<int>();
                foreach (int s in o)
                {
                    bb.Add(s);
                }
                aa.Add(bb);
            }
            return aa;
        }
        public static IEnumerable<IEnumerable<T>> GetPermutations<T>(IEnumerable<T> list, int length)
        {
            if (length == 1) return list.Select(t => new T[] { t });
            return GetPermutations(list, length - 1)
                .SelectMany(t => list.Where(e => !t.Contains(e)),
                    (t1, t2) => t1.Concat(new T[] { t2 }));
        }
        //Title: 49. Group Anagrams
        //Link: https://leetcode.com/problems/group-anagrams
        //Tags: Array, Hash Table, String, Sorting
        public static IList<IList<string>> GroupAnagrams(string[] strs)
        {
            List<IList<string>> a = new List<IList<string>>();
            int listindex = 0;
            Dictionary<string, int> c = new Dictionary<string, int>();
            foreach (string word in strs)
            {
                char[] d = word.ToCharArray();
                Array.Sort(d);
                string e = new String(d);
                if (!(c.ContainsKey(e)))
                {
                    List<string> b = new List<string>();
                    a.Add(b);
                    c.Add(e, listindex);
                    listindex++;
                }
                a[c[e]].Add(word);
            }
            return a;
        }
        //Title: 50. Pow(x, n)
        //Link: https://leetcode.com/problems/powx-n
        //Tags: Math, Recursion
        public static double MyPow(double x, int n)
        {
            return Math.Pow(x, n);
        }
        //Title: 73. Set Matrix Zeroes
        //Link: https://leetcode.com/problems/set-matrix-zeroes
        //Tags: Array, Hash Table, Matrix
        public static void SetZeroes(int[][] matrix)
        {
            var len = matrix.Length;
            var source = new int[len][];
            for (var x = 0; x < len; x++)
            {
                var inner = matrix[x];
                var ilen = inner.Length;
                var newer = new int[ilen];
                Array.Copy(inner, newer, ilen);
                source[x] = newer;
            }
            int yval = 0;
            foreach (int[] a in source)
            {
                int xval = 0;
                foreach (int b in a)
                {
                    if (b == 0)
                    {
                        for (int i = 0; i < a.Length; i++)
                        {
                            matrix[yval][i] = 0;
                        }
                        for (int i = 0; i < source.Length; i++)
                        {
                            matrix[i][xval] = 0;
                        }
                    }
                    xval++;
                }
                yval++;
            }
        }
        //Title: 75. Sort Colors
        //Link: https://leetcode.com/problems/sort-colors
        //Tags: Array, Two Pointers, Sorting
        public static void SortColors(int[] nums)
        {
            SortedDictionary<int, int> a = new SortedDictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (!a.ContainsKey(nums[i]))
                {
                    a.Add(nums[i], 1);
                }
                else
                {
                    a[nums[i]]++;
                }
            }
            int index = 0;
            foreach (KeyValuePair<int, int> b in a)
            {
                for (int i = 0; i < b.Value; i++)
                {
                    nums[index] = b.Key;
                    index++;
                }
            }
        }
        //Title: 137. Single Number II
        //Link: https://leetcode.com/problems/single-number-ii
        //Tags: Array, Bit Manipulation
        public static int SingleNumber(int[] nums)
        {
            Dictionary<int, int> a = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (!(a.ContainsKey(nums[i])))
                {
                    a.Add(nums[i], 1);
                }
                else
                {
                    a[nums[i]]++;
                }
            }
            foreach (KeyValuePair<int, int> b in a)
            {
                if (b.Value == 1)
                {
                    return b.Key;
                }
            }
            return -1;
        }
        //Title: 151. Reverse Words in a String
        //Link: https://leetcode.com/problems/reverse-words-in-a-string
        //Tags: Two Pointers, String
        public static string ReverseWords(string s)
        {
            string[] a = s.Split(' ');
            Array.Reverse(a);
            string final = "";
            for (int i = 0; i < a.Length; i++)
            {
                a[i] = a[i].Replace(" ", "");
                if (a[i] != "")
                {
                    final += a[i] + ' ';
                }
            }
            final = final.TrimEnd();
            return final;
        }
        //Title: 215. Kth Largest Element in an Array
        //Link: https://leetcode.com/problems/kth-largest-element-in-an-array
        //Tags: Array, Divide and Conquer, Sorting, Heap (Priority Queue), Quickselect
        public static int FindKthLargest(int[] nums, int k)
        {
            Array.Sort(nums);
            Array.Reverse(nums);
            return nums[k - 1];
        }
        //Title: 287. Find the Duplicate Number
        //Link: https://leetcode.com/problems/find-the-duplicate-number
        //Tags: Array, Two Pointers, Binary Search, Bit Manipulation
        public static int FindDuplicate(int[] nums)
        {
            List<int> a = new List<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (!a.Contains(nums[i]))
                {
                    a.Add(nums[i]);
                }
                else
                {
                    return nums[i];
                }
            }
            return -1;
        }
        //Title: 347. Top K Frequent Elements
        //Link: https://leetcode.com/problems/top-k-frequent-elements
        //Tags: Array, Hash Table, Divide and Conquer, Sorting, Heap (Priority Queue), Bucket Sort, Counting, Quickselect
        public static int[] TopKFrequent(int[] nums, int k)
        {
            Dictionary<int, int> a = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (!(a.ContainsKey(nums[i])))
                {
                    a.Add(nums[i], 1);
                }
                else
                {
                    a[nums[i]]++;
                }
            }
            var sortedDict = from entry in a orderby entry.Value descending select entry;
            List<int> b = new List<int>();
            int counter = 0;
            foreach (KeyValuePair<int, int> c in sortedDict)
            {
                if (counter == k) { break; }
                b.Add(c.Key);
                counter++;
            }
            int[] final = new int[b.Count];
            int index = 0;
            foreach (int i in b)
            {
                final[index] = i;
                index++;
            }
            return final;
        }
        //Title: 372. Super Pow
        //Link: https://leetcode.com/problems/super-pow
        //Tags: Math, Divide and Conquer
        public static int SuperPow(int a, int[] b)
        {
            BigInteger x = 0;
            string bignum = "";
            for (int i = 0; i < b.Length; i++)
            {
                bignum += b[i].ToString();
            }
            BigInteger.TryParse(bignum, out x);
            int final = 0;
            final = ((int)BigInteger.ModPow(a, x, 1337));
            return final;
        }
        //Title: 378. Kth Smallest Element in a Sorted Matrix
        //Link: https://leetcode.com/problems/kth-smallest-element-in-a-sorted-matrix
        //Tags: Array, Binary Search, Sorting, Heap (Priority Queue), Matrix
        public static int KthSmallest(int[][] matrix, int k)
        {
            int counter = 0;
            foreach (int[] a in matrix)
            {
                foreach (int b in a)
                {
                    counter++;
                }
            }
            int[] final = new int[counter];
            int index = 0;
            foreach (int[] a in matrix)
            {
                foreach (int b in a)
                {
                    final[index] = b;
                    index++;
                }
            }
            Array.Sort(final);
            return final[k - 1];
        }
        //Title: 438. Find All Anagrams in a String
        //Link: https://leetcode.com/problems/find-all-anagrams-in-a-string
        //Tags: Hash Table, String, Sliding Window
        public static IList<int> FindAnagrams(string s, string p)
        {
            List<int> a = new List<int>();
            if (p.Length > s.Length)
            {
                return a;
            }
            char[] f = p.ToCharArray();
            Array.Sort(f);
            string g = new String(f);
            Queue<char> q = new Queue<char>();
            int len = p.Length;
            for (int i = 0; i < len; i++)
            {
                q.Enqueue(s[i]);
            }
            int sindex = 0;
            char[] d = q.ToArray();
            Array.Sort(d);
            string e = new String(d);
            if (e == g)
            {
                a.Add(sindex);
            }
            sindex++;
            for (int i = len; i < s.Length; i++)
            {
                q.Dequeue();
                q.Enqueue(s[i]);
                char[] h = q.ToArray();
                Array.Sort(h);
                string j = new String(h);
                if (j == g)
                {
                    a.Add(sindex);
                }
                sindex++;
            }
            return a;
        }
        //Title: 451. Sort Characters By Frequency
        //Link: https://leetcode.com/problems/sort-characters-by-frequency
        //Tags: Hash Table, String, Sorting, Heap (Priority Queue), Bucket Sort, Counting
        public static string FrequencySort(string s)
        {
            Dictionary<char, int> a = new Dictionary<char, int>();
            for (int i = 0; i < s.Length; i++)
            {
                if (!(a.ContainsKey(s[i])))
                {
                    a.Add(s[i], 1);
                }
                else
                {
                    a[s[i]]++;
                }
            }
            string final = "";
            var sortedDict = from entry in a orderby entry.Value descending select entry;
            foreach (KeyValuePair<char, int> b in sortedDict)
            {
                char temp = b.Key;
                int times = b.Value;
                for (int i = 0; i < times; i++)
                {
                    final += temp;
                }
            }
            return final;
        }
        //Title: 468. Validate IP Address
        //Link: https://leetcode.com/problems/validate-ip-address
        //Tags: String
        public static string ValidIPAddress(string queryIP)
        {
            Match m = Regex.Match(queryIP, "^(?:(?:25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\\.){3}(?:25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])$", RegexOptions.IgnoreCase);
            Match n = Regex.Match(queryIP, "^(?:[A-F0-9]{1,4}:){7}[A-F0-9]{1,4}$", RegexOptions.IgnoreCase);
            if (m.Success == true)
            {
                return "IPv4";
            }
            if (n.Success == true)
            {
                return "IPv6";
            }
            return "Neither";
        }
        //Title: 648. Replace Words
        //Link: https://leetcode.com/problems/replace-words
        //Tags: Array, Hash Table, String, Trie
        public static string ReplaceWords(IList<string> dictionary, string sentence)
        {
            string[] a = sentence.Split(' ');
            var result = dictionary.OrderBy(x => x.Length);
            for (int i = 0; i < a.Length; i++)
            {
                string word = a[i];
                foreach (string b in result)
                {
                    if (word.Contains(b))
                    {
                        if (word.Substring(0, b.Length) == b)
                        {
                            a[i] = b;
                            break;
                        }
                    }
                }
            }
            string final = "";
            for (int i = 0; i < a.Length; i++)
            {
                final += a[i] + ' ';
            }
            final = final.TrimEnd();
            return final;
        }
        //Title: 686. Repeated String Match
        //Link: https://leetcode.com/problems/repeated-string-match
        //Tags: String, String Matching
        public static int RepeatedStringMatch(string a, string b)
        {
            int count = 1;
            string temp = a;
            while (temp.Length < b.Length)
            {
                temp += a;
                count++;
            }
            if (temp.Contains(b))
            {
                return count;
            }
            temp += a;
            count++;
            if (temp.Contains(b))
            {
                return count;
            }
            return -1;
        }
        //Title: 74. Search a 2D Matrix
        //Link: https://leetcode.com/problems/search-a-2d-matrix
        //Tags: Array, Binary Search, Matrix
        public static bool SearchMatrix(int[][] matrix, int target)
        {
            foreach (int[] i in matrix)
            {
                if (i.Contains(target))
                {
                    return true;
                }
            }
            return false;
        }
        //Title: 692. Top K Frequent Words
        //Link: https://leetcode.com/problems/top-k-frequent-words
        //Tags: Hash Table, String, Trie, Sorting, Heap (Priority Queue), Bucket Sort, Counting
        public static IList<string> TopKFrequent(string[] words, int k)
        {
            Dictionary<string, int> a = new Dictionary<string, int>();
            List<string> b = new List<string>();
            foreach (string word in words)
            {
                if (!(a.ContainsKey(word)))
                {
                    a.Add(word, 1);
                }
                else
                {
                    a[word]++;
                }
            }
            var sortedDict = from entry in a orderby entry.Value descending, entry.Key ascending select entry;
            int counter = 1;
            foreach (KeyValuePair<string, int> c in sortedDict)
            {
                if (counter <= k)
                {
                    b.Add(c.Key);
                    counter++;
                }
                else
                {
                    break;
                }
            }
            return b;
        }
        //Title: 739. Daily Temperatures
        //Link: https://leetcode.com/problems/daily-temperatures
        //Tags: Array, Stack, Monotonic Stack
        public static int[] DailyTemperatures(int[] temperatures)
        {
            int[] a = new int[temperatures.Length];
            int index = 0;
            for (int i = 0; i < temperatures.Length; i++)
            {
                int temp = temperatures[i];
                int counter = 0;
                bool found = false;
                for (int t = i + 1; t < temperatures.Length; t++)
                {
                    if (!(temperatures[t] > temp))
                    {
                        counter++;
                    }
                    else
                    {
                        found = true;
                        counter++;
                        break;
                    }
                }
                if (found == false)
                {
                    counter = 0;
                }
                a[index] = counter;
                index++;
            }
            return a;
        }
        //Title: 890. Find and Replace Pattern
        //Link: https://leetcode.com/problems/find-and-replace-pattern
        //Tags: Array, Hash Table, String
        public static IList<string> FindAndReplacePattern(string[] words, string pattern)
        {
            List<string> final = new List<string>();
            string pat = "";
            Dictionary<char, int> a = new Dictionary<char, int>();
            int index = 1;
            for (int i = 0; i < pattern.Length; i++)
            {
                if (!(a.ContainsKey(pattern[i])))
                {
                    a.Add(pattern[i], index);
                    pat += index.ToString() + '-';
                    index++;
                }
                else
                {
                    pat += a[pattern[i]].ToString() + '-';
                }
            }
            foreach (string word in words)
            {
                Dictionary<char, int> b = new Dictionary<char, int>();
                int patindex = 1;
                string match = "";
                for (int i = 0; i < word.Length; i++)
                {
                    if (!(b.ContainsKey(word[i])))
                    {
                        b.Add(word[i], patindex);
                        match += patindex.ToString() + '-';
                        patindex++;
                    }
                    else
                    {
                        match += b[word[i]].ToString() + '-';
                    }
                }
                if (match == pat)
                {
                    final.Add(word);
                }
            }
            return final;
        }
        //Title: 930. Binary Subarrays With Sum
        //Link: https://leetcode.com/problems/binary-subarrays-with-sum/
        //Tags: Array, Hash Table, Sliding Window, Prefix Sum
        public static int NumSubarraysWithSum(int[] nums, int goal)
        {
            int counter = 0;
            int sum = 0;
            for (int d = 0; d < nums.Length; d++)
            {
                for (int i = d; i < nums.Length; i++)
                {
                    sum += nums[i];
                    if (sum == goal)
                    {
                        counter++;
                    }
                }
                sum = 0;
            }
            return counter;
        }
        //Title: 1291. Sequential Digits
        //Link: https://leetcode.com/problems/sequential-digits
        //Tags: Enumeration
        public static IList<int> SequentialDigits(int low, int high)
        {
            List<int> a = new List<int>();
            List<int> b = new List<int>() { 12, 23, 34, 45, 56, 67, 78, 89, 123, 234, 345, 456, 567, 678, 789, 1234, 2345, 3456, 4567, 5678, 6789, 12345, 23456, 34567, 45678, 56789, 123456, 234567, 345678, 456789, 1234567, 2345678, 3456789, 12345678, 23456789, 123456789 };
            foreach (int x in b)
            {
                if (low <= x && x <= high)
                {
                    a.Add(x);
                }
            }
            return a;
        }
        //Title: 1324. Print Words Vertically
        //Link: https://leetcode.com/problems/print-words-vertically
        //Tags: Array, String, Simulation
        public static IList<string> PrintVertically(string s)
        {
            List<string> a = new List<string>();
            string[] strarray = s.Split(' ');
            int maxlength = 0;
            foreach (string word in strarray)
            {
                if (word.Length > maxlength)
                {
                    maxlength = word.Length;
                }
            }
            string[] answer = new string[maxlength];
            foreach (string word in strarray)
            {
                int counter = 0;
                for (int i = 0; i < maxlength; i++)
                {
                    if (i >= word.Length)
                    {
                        answer[counter] += ' ';
                        counter++;
                    }
                    else
                    {
                        answer[counter] += word[i];
                        counter++;
                    }
                }
                counter = 0;
            }
            for (int i = 0; i < answer.Length; i++)
            {
                answer[i] = answer[i].TrimEnd();
            }
            foreach (string word in answer)
            {
                a.Add(word);
            }
            return a;
        }
        //Title: 1338. Reduce Array Size to The Half
        //Link: https://leetcode.com/problems/reduce-array-size-to-the-half
        //Tags: Array, Hash Table, Greedy, Sorting, Heap (Priority Queue)
        public static int MinSetSize(int[] arr)
        {
            Dictionary<int, int> a = new Dictionary<int, int>();
            for (int i = 0; i < arr.Length; i++)
            {
                if ((!(a.ContainsKey(arr[i]))))
                {
                    a.Add(arr[i], 1);
                }
                else
                {
                    a[arr[i]]++;
                }
            }
            double half = arr.Length / 2;
            int removehowmany = 1;
            int runningtotal = 0;
            var sortedDict = from entry in a orderby entry.Value descending select entry;
            foreach (KeyValuePair<int, int> b in sortedDict)
            {
                runningtotal += b.Value;
                if (runningtotal >= half)
                {
                    return removehowmany;
                }
                removehowmany++;
            }
            return -1;
        }
        //Title: 1451. Rearrange Words in a Sentence
        //Link: https://leetcode.com/problems/rearrange-words-in-a-sentence
        //Tags: String, Sorting
        public static string ArrangeWords(string text)
        {
            List<string> b = new List<string>();
            text = text.ToLower();
            string[] a = text.Split(' ');
            int length = 0;
            string final = "";
            foreach (string i in a)
            {
                if (i.Length > length)
                {
                    length = i.Length;
                }
                b.Add(i);
            }
            for (int i = 1; i <= length; i++)
            {
                foreach (string c in b)
                {
                    if (c.Length == i)
                    {
                        final += c + ' ';
                    }
                }
            }
            final = final.TrimEnd();
            char[] letters = final.ToCharArray();
            letters[0] = char.ToUpper(letters[0]);
            string ans = new string(letters);
            return ans;
        }
        //Title: 1481. Least Number of Unique Integers after K Removals
        //Link: https://leetcode.com/problems/least-number-of-unique-integers-after-k-removals
        //Tags: Array, Hash Table, Greedy, Sorting, Counting
        public static int FindLeastNumOfUniqueInts(int[] arr, int k)
        {
            Dictionary<int, int> counter = new Dictionary<int, int>();
            foreach (int num in arr)
            {
                if (counter.ContainsKey(num))
                {
                    counter[num]++;
                }
                else
                {
                    counter.Add(num, 1);
                }
            }
            List<int> values = new List<int>();
            foreach (var pair in counter)
            {
                values.Add(pair.Value);
            }
            values.Sort();
            for (int i = 0; i < values.Count; i++)
            {
                if (values[i] > k)
                {
                    return values.Count - i;
                }
                if (values[i] == k)
                {
                    return values.Count - i - 1;
                }
                k -= values[i];
            }
            return 0;
        }
        //Title: 1492. The kth Factor of n
        //Link: https://leetcode.com/problems/the-kth-factor-of-n
        //Tags: Math, Number Theory
        public static int KthFactor(int n, int k)
        {
            List<int> a = new List<int>();
            for (int i = 1; i <= n; i++)
            {
                if (n % i == 0)
                {
                    a.Add(i);
                }
            }
            if (a.Count() < k) { return -1; }
            int[] ans = new int[a.Count];
            int index = 0;
            foreach (int i in a)
            {
                ans[index] = i;
                index++;
            }
            Array.Sort(ans);
            return ans[k - 1];
        }
        //Title: 1833. Maximum Ice Cream Bars
        //Link: https://leetcode.com/problems/maximum-ice-cream-bars
        //Tags: Array, Greedy, Sorting
        public static int MaxIceCream(int[] costs, int coins)
        {
            List<int> a = new List<int>();
            int counter = 0;
            for (int i = 0; i < costs.Length; i++)
            {
                a.Add(costs[i]);
            }
            while (coins > 0 && a.Count > 0)
            {
                bool cantafford = true;
                if (coins >= a.Min())
                {
                    coins -= a.Min();
                    a.Remove(a.Min());
                    cantafford = false;
                    counter++;
                }
                if (cantafford)
                {
                    break;
                }
            }
            return counter;
        }
        //Title: 1910. Remove All Occurrences of a Substring
        //Link: https://leetcode.com/problems/remove-all-occurrences-of-a-substring
        //Tags: String
        public static string RemoveOccurrences(string s, string part)
        {
            while (s.Contains(part))
            {
                s = s.Remove(s.IndexOf(part), part.Length);
            }
            return s;
        }
        //Title: 1980. Find Unique Binary String
        //Link: https://leetcode.com/problems/find-unique-binary-string
        //Tags: Array, Hash Table, String, Backtracking
        public static string FindDifferentBinaryString(string[] nums)
        {
            List<int> a = new List<int>();
            int length = nums[0].Length;
            for (int i = 0; i < nums.Length; i++)
            {
                int output = Convert.ToInt32(nums[i], 2);
                if (!(a.Contains(output)))
                {
                    a.Add(output);
                }
            }
            string ans = "";
            for (int i = 0; i < a.Max(); i++)
            {
                if (!(a.Contains(i)))
                {
                    ans = Convert.ToString(i, 2).PadLeft(length, '0');
                    break;
                }
            }
            if (ans == "")
            {
                ans = Convert.ToString(a.Max() + 1, 2).PadLeft(length, '0');
            }
            return ans;
        }
        //Title: 1985. Find the Kth Largest Integer in the Array
        //Link: https://leetcode.com/problems/find-the-kth-largest-integer-in-the-array
        //Tags: Array, String, Divide and Conquer, Sorting, Heap (Priority Queue), Quickselect
        public static string KthLargestNumber(string[] nums, int k)
        {
            BigInteger[] a = new BigInteger[nums.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                BigInteger b = 0;
                BigInteger.TryParse(nums[i], out b);
                a[i] = b;
            }
            Array.Sort(a);
            Array.Reverse(a);
            BigInteger ans = a[k - 1];
            return ans.ToString();
        }
        //Title: 2007. Find Original Array From Doubled Array
        //Link: https://leetcode.com/problems/find-original-array-from-doubled-array
        //Tags: Array, Hash Table, Greedy, Sorting
        public static int[] FindOriginalArray(int[] changed)
        {
            if (changed.Length % 2 != 0)
            {
                return new int[0];
            }
            Array.Sort(changed);
            Array.Reverse(changed);
            List<int> a = new List<int>();
            for (int i = 0; i < changed.Length; i++)
            {
                a.Add(changed[i]);
            }
            List<int> b = new List<int>();
            for (int i = 0; i < changed.Length / 2; i++)
            {
                int w = a[0];
                int q = a[1];
                double j = (double)w / (double)2;
                if (j % 1 == 0)
                {
                    if ((w == 0 && q != 0) || (q == 0 && w != 0))
                    {
                        return new int[0];
                    }
                    if ((a.Contains(w / 2)) || (w == 0 && q == 0))
                    {
                        a.Remove(w);
                        a.Remove(w / 2);
                        b.Add(w / 2);
                    }
                    else
                    {
                        return new int[0];
                    }
                }
            }
            if (a.Count == 0)
            {
                int[] final = new int[b.Count];
                int index = 0;
                foreach (int c in b)
                {
                    final[index] = c;
                    index++;
                }
                return final;
            }
            return new int[0];
        }
        //Title: 2023. Number of Pairs of Strings With Concatenation Equal to Target
        //Link: https://leetcode.com/problems/number-of-pairs-of-strings-with-concatenation-equal-to-target
        //Tags: Array, Hash Table, String, Counting
        public static int NumOfPairs(string[] nums, string target)
        {
            int counter = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                string a = nums[i];
                for (int t = 0; t < nums.Length; t++)
                {
                    if (t != i)
                    {
                        string b = nums[t];
                        if (a + b == target)
                        {
                            counter++;
                        }
                    }
                }
            }
            return counter;
        }
        //Title: 2149. Rearrange Array Elements by Sign
        //Link: https://leetcode.com/problems/rearrange-array-elements-by-sign
        //Tags: Array, Two Pointers, Simulation
        public static int[] RearrangeArray(int[] nums)
        {
            int[] positive = new int[(nums.Length / 2)];
            int[] negative = new int[(nums.Length / 2)];
            int p = 0;
            int n = 0;
            foreach (int x in nums)
            {
                if (x > 0)
                {
                    positive[p] = x;
                    p += 1;
                }
                else if (x < 0)
                {
                    negative[n] = x;
                    n += 1;
                }
            }
            p = 0;
            n = 0;
            int[] final = new int[nums.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                if (i % 2 == 0)
                {
                    final[i] = positive[p];
                    p += 1;
                }
                else
                {
                    final[i] = negative[n];
                    n += 1;
                }
            }
            return final;
        }
        //Title: 2390. Removing Stars From a String
        //Link: https://leetcode.com/problems/removing-stars-from-a-string
        //Tags: String, Stack, Simulation
        public static string RemoveStars(string s)
        {
            Stack<char> a = new Stack<char>();
            string final = "";
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '*')
                {
                    a.Pop();
                }
                else
                {
                    a.Push(s[i]);
                }
            }
            foreach (char b in a.Reverse())
            {
                final += b;
            }
            return final;
        }
        //Title: 2405. Optimal Partition of String
        //Link: https://leetcode.com/problems/optimal-partition-of-string
        //Tags: Hash Table, String, Greedy
        public static int PartitionString(string s)
        {
            List<char> a = new List<char>();
            int counter = 1;
            for (int i = 0; i < s.Length; i++)
            {
                if (!(a.Contains(s[i])))
                {
                    a.Add(s[i]);
                }
                else
                {
                    a.Clear();
                    a.Add(s[i]);
                    counter++;
                }
            }
            return counter;
        }
        //Title: 2443. Sum of Number and Its Reverse
        //Link: https://leetcode.com/problems/sum-of-number-and-its-reverse
        //Tags: Math, Enumeration
        public static bool SumOfNumberAndReverse(int num)
        {
            if (num <= 18)
            {
                if (num % 2 == 0)
                {
                    return true;
                }
            }
            for (int i = 0; i < num / 2; i++)
            {
                int half = num - i;
                string b = half.ToString();
                string a = i.ToString().PadLeft(b.Length, '0');
                char[] array = a.ToCharArray();
                Array.Reverse(array);
                string backwards = new String(array);
                if (backwards == b)
                {
                    return true;
                }
            }
            return false;
        }
        //Title: 2610. Convert an Array Into a 2D Array With Conditions
        //Link: https://leetcode.com/problems/convert-an-array-into-a-2d-array-with-conditions
        //Tags: Array, Hash Table
        public static IList<IList<int>> FindMatrix(int[] nums)
        {
            List<IList<int>> a = new List<IList<int>>();
            List<int> b = new List<int>();
            a.Add(b);
            int listcount = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                bool foundspot = false;
                foreach (List<int> e in a)
                {
                    if (!(e.Contains(nums[i])))
                    {
                        e.Add(nums[i]);
                        foundspot = true;
                        break;
                    }
                }
                if (foundspot == false)
                {
                    List<int> c = new List<int>();
                    a.Add(c);
                    listcount++;
                    a[listcount].Add(nums[i]);
                }
            }
            return a;
        }
        //Title: 36. Valid Sudoku
        //Link: https://leetcode.com/problems/valid-sudoku
        //Tags: Array, Hash Table, Matrix
        public static bool IsValidSudoku(char[][] board)
        {
            int[][,] localgroup = new int[9][,];
            localgroup[0] = new int[9, 2] { { 0, 0 }, { 0, 1 }, { 0, 2 }, { 1, 0 }, { 1, 1 }, { 1, 2 }, { 2, 0 }, { 2, 1 }, { 2, 2 } };
            localgroup[1] = new int[9, 2] { { 0, 3 }, { 0, 4 }, { 0, 5 }, { 1, 3 }, { 1, 4 }, { 1, 5 }, { 2, 3 }, { 2, 4 }, { 2, 5 } };
            localgroup[2] = new int[9, 2] { { 0, 6 }, { 0, 7 }, { 0, 8 }, { 1, 6 }, { 1, 7 }, { 1, 8 }, { 2, 6 }, { 2, 7 }, { 2, 8 } };
            localgroup[3] = new int[9, 2] { { 3, 0 }, { 3, 1 }, { 3, 2 }, { 4, 0 }, { 4, 1 }, { 4, 2 }, { 5, 0 }, { 5, 1 }, { 5, 2 } };
            localgroup[4] = new int[9, 2] { { 3, 3 }, { 3, 4 }, { 3, 5 }, { 4, 3 }, { 4, 4 }, { 4, 5 }, { 5, 3 }, { 5, 4 }, { 5, 5 } };
            localgroup[5] = new int[9, 2] { { 3, 6 }, { 3, 7 }, { 3, 8 }, { 4, 6 }, { 4, 7 }, { 4, 8 }, { 5, 6 }, { 5, 7 }, { 5, 8 } };
            localgroup[6] = new int[9, 2] { { 6, 0 }, { 6, 1 }, { 6, 2 }, { 7, 0 }, { 7, 1 }, { 7, 2 }, { 8, 0 }, { 8, 1 }, { 8, 2 } };
            localgroup[7] = new int[9, 2] { { 6, 3 }, { 6, 4 }, { 6, 5 }, { 7, 3 }, { 7, 4 }, { 7, 5 }, { 8, 3 }, { 8, 4 }, { 8, 5 } };
            localgroup[8] = new int[9, 2] { { 6, 6 }, { 6, 7 }, { 6, 8 }, { 7, 6 }, { 7, 7 }, { 7, 8 }, { 8, 6 }, { 8, 7 }, { 8, 8 } };
            foreach (char[] a in board)
            {
                List<char> b = new List<char>();
                for (int i = 0; i < a.Length; i++)
                {
                    if (a[i] != '.')
                    {
                        if (!b.Contains(a[i]))
                        {
                            b.Add(a[i]);
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
            for (int i = 0; i < 9; i++)
            {
                List<char> c = new List<char>();
                for (int t = 0; t < 9; t++)
                {
                    if (board[t][i] != '.')
                    {
                        if (!c.Contains(board[t][i]))
                        {
                            c.Add(board[t][i]);
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
            for (int i = 0; i < 9; i++)
            {
                List<char> d = new List<char>();
                for (int j = 0; j < localgroup[i].Length / 2; j++)
                {
                    int ycoord = localgroup[i][j, 0];
                    int xcoord = localgroup[i][j, 1];
                    if (board[ycoord][xcoord] != '.')
                    {
                        if (!d.Contains(board[ycoord][xcoord]))
                        {
                            d.Add(board[ycoord][xcoord]);
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }
        //Title: 2288. Apply Discount to Prices
        //Link: https://leetcode.com/problems/apply-discount-to-prices
        //Tags: String
        public static string DiscountPrices(string sentence, int discount)
        {
            string[] s = sentence.Split(' ');
            string[] ans = new string[s.Length];
            int counter = 0;
            foreach (string word in s)
            {
                if (word[0] == '$')
                {
                    string r = "$";
                    string digits = "";
                    for (int i = 1; i < word.Length; i++)
                    {
                        if (char.IsDigit(word[i]))
                        {
                            digits += word[i];
                        }
                        else
                        {
                            digits = "";
                            r = word;
                            break;
                        }
                    }
                    if (digits.Length > 0)
                    {
                        BigInteger d = 0;
                        BigInteger.TryParse(digits, out d);
                        if (discount == 100)
                        {
                            r += (0).ToString("0.00");
                        }
                        else
                        {
                            double c = discount * 0.01;
                            decimal f = 1 - (decimal)c;
                            decimal e = (decimal)d * f;
                            r += e.ToString("C2").Replace("¤", "").Replace(",", "");
                        }
                    }
                    ans[counter] = r;
                }
                else
                {
                    ans[counter] = word;
                }
                counter++;
            }
            string final = "";
            foreach (string word in ans)
            {
                final += word + ' ';
            }
            final = final.TrimEnd();
            return final;
        }
        //Title: 289. Game of Life
        //Link: https://leetcode.com/problems/game-of-life
        //Tags: Array, Matrix, Simulation
        public static void GameOfLife(int[][] board)
        {
            int yval = 0;
            var len = board.Length;
            var source = new int[len][];
            for (var x = 0; x < len; x++)
            {
                var inner = board[x];
                var ilen = inner.Length;
                var newer = new int[ilen];
                Array.Copy(inner, newer, ilen);
                source[x] = newer;
            }
            foreach (int[] a in source)
            {
                for (int i = 0; i < a.Length; i++)
                {
                    bool alive = false;
                    int liveneighbors = 0;
                    if (a[i] == 1)
                    {
                        alive = true;
                    }
                    if (i != a.Length - 1)
                    {
                        //right
                        if (source[yval][i + 1] == 1)
                        {
                            liveneighbors++;
                        }
                        //right down diagonal
                        if (yval != source.Length - 1)
                        {
                            if (source[yval + 1][i + 1] == 1)
                            {
                                liveneighbors++;
                            }
                        }
                        //right up diagonal
                        if (yval != 0)
                        {
                            if (source[yval - 1][i + 1] == 1)
                            {
                                liveneighbors++;
                            }
                        }
                    }
                    //down
                    if (yval != source.Length - 1)
                    {
                        if (source[yval + 1][i] == 1)
                        {
                            liveneighbors++;
                        }
                    }
                    //up
                    if (yval != 0)
                    {
                        if (source[yval - 1][i] == 1)
                        {
                            liveneighbors++;
                        }
                    }
                    if (i != 0)
                    {
                        //left
                        if (source[yval][i - 1] == 1)
                        {
                            liveneighbors++;
                        }
                        //left down diagonal
                        if (yval != source.Length - 1)
                        {
                            if (source[yval + 1][i - 1] == 1)
                            {
                                liveneighbors++;
                            }
                        }
                        //left up diagonal
                        if (yval != 0)
                        {
                            if (source[yval - 1][i - 1] == 1)
                            {
                                liveneighbors++;
                            }
                        }
                    }
                    if (alive)
                    {
                        if (liveneighbors < 2 || liveneighbors > 3)
                        {
                            board[yval][i] = 0;
                        }
                    }
                    else
                    {
                        if (liveneighbors == 3)
                        {
                            board[yval][i] = 1;
                        }
                    }
                }
                yval++;
            }
        }
        //Title: 2396. Strictly Palindromic Number
        //Link: https://leetcode.com/problems/strictly-palindromic-number
        //Tags: Math, Two Pointers, Brainteaser
        public static bool IsStrictlyPalindromic(int n)
        {
            return false;
        }
        //Title: 2. Add Two Numbers
        //Link: https://leetcode.com/problems/add-two-numbers
        //Tags: Linked List, Math, Recursion
        public static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode head = null;
            string num1 = "";
            string num2 = "";
            while (l1 != null)
            {
                num1 += l1.val.ToString();
                l1 = l1.next;
            }
            while (l2 != null)
            {
                num2 += l2.val.ToString();
                l2 = l2.next;
            }
            char[] a = num1.ToCharArray();
            char[] b = num2.ToCharArray();
            Array.Reverse(a);
            Array.Reverse(b);
            string a1 = new string(a);
            string b1 = new string(b);
            BigInteger d1 = 0;
            BigInteger d2 = 0;
            BigInteger.TryParse(a1, out d1);
            BigInteger.TryParse(b1, out d2);
            BigInteger sum = d1 + d2;
            string sumstr = sum.ToString();
            char[] sumrev = sumstr.ToCharArray();
            Array.Reverse(sumrev);
            string sumstrrev = new string(sumrev);
            for (int i = 0; i < sumstrrev.Length; i++)
            {
                int digit = 0;
                int.TryParse(sumstrrev[i] + "", out digit);
                AddLink(ref head, digit);
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
        //Title: 2181. Merge Nodes in Between Zeros
        //Link: https://leetcode.com/problems/merge-nodes-in-between-zeros
        //Tags: Linked List, Simulation
        public static ListNode MergeNodes(ListNode head)
        {
            Queue<int> q = new Queue<int>();
            ListNode ans = null;
            int sum = 0;
            while (head != null)
            {
                int listval = head.val;
                if (listval == 0 && sum != 0)
                {
                    q.Enqueue(sum);
                    sum = 0;
                }
                if (listval != 0)
                {
                    sum += listval;
                }
                head = head.next;
            }
            if (ans == null)
            {
                ListNode link = new ListNode(q.Peek());
                ans = link;
                q.Dequeue();
            }
            ListNode current = ans;
            while (current.next != null)
            {
                current = current.next;
            }
            while (q.Count > 0)
            {
                ListNode link = new ListNode(q.Peek());
                current.next = link;
                current = current.next;
                q.Dequeue();
            }
            return ans;
        }
        //Title: 2095. Delete the Middle Node of a Linked List
        //Link: https://leetcode.com/problems/delete-the-middle-node-of-a-linked-list
        //Tags: Linked List, Two Pointers
        public ListNode DeleteMiddle(ListNode head)
        {
            Queue<int> q = new Queue<int>();
            ListNode ans = null;
            int counter = 0;
            int half = 0;
            while (head != null)
            {
                int listval = head.val;
                q.Enqueue(listval);
                counter++;
                head = head.next;
            }
            if (counter == 1)
            {
                return ans;
            }
            if (counter % 2 == 0)
            {
                half = counter / 2;
            }
            else
            {
                half = (((counter + 1) / 2) - 1);
            }
            if (ans == null)
            {
                ListNode link = new ListNode(q.Peek());
                ans = link;
                q.Dequeue();
            }
            ListNode current = ans;
            int index = 1;
            while (q.Count > 0)
            {
                if (index != half)
                {
                    ListNode link = new ListNode(q.Peek());
                    current.next = link;
                    current = current.next;
                }
                q.Dequeue();
                index++;
            }
            return ans;
        }
        //Title: 445. Add Two Numbers II
        //Link: https://leetcode.com/problems/add-two-numbers-ii
        //Tags: Linked List, Math, Stack
        public static ListNode AddTwoNumbers2(ListNode l1, ListNode l2)
        {
            BigInteger num1 = 0;
            BigInteger num2 = 0;
            BigInteger sum = 0;
            string sumstr = "";
            string str1 = "";
            string str2 = "";
            ListNode ans = null;
            while (l1 != null)
            {
                int listval = l1.val;
                str1 += listval.ToString();
                l1 = l1.next;
            }
            while (l2 != null)
            {
                int listval = l2.val;
                str2 += listval.ToString();
                l2 = l2.next;
            }
            BigInteger.TryParse(str1, out num1);
            BigInteger.TryParse(str2, out num2);
            sum = num1 + num2;
            sumstr = sum.ToString();
            if (ans == null)
            {
                int startdigit = 0;
                int.TryParse(sumstr[0] + "", out startdigit);
                ListNode link = new ListNode(startdigit);
                ans = link;
            }
            ListNode current = ans;
            for (int i = 1; i < sumstr.Length; i++)
            {
                int digit = 0;
                int.TryParse(sumstr[i] + "", out digit);
                ListNode link = new ListNode(digit);
                current.next = link;
                current = current.next;
            }
            return ans;
        }
        //Title: 1669. Merge In Between Linked Lists
        //Link: https://leetcode.com/problems/merge-in-between-linked-lists
        //Tags: Linked List
        public static ListNode MergeInBetween(ListNode list1, int a, int b, ListNode list2)
        {
            Queue<int> q1 = new Queue<int>();
            Queue<int> q2 = new Queue<int>();
            Queue<int> q3 = new Queue<int>();
            ListNode ans = null;
            int counter = 0;
            while (list1 != null)
            {
                int listval = list1.val;
                if (counter < a)
                {
                    q1.Enqueue(listval);
                }
                else if (counter >= a && counter <= b)
                {

                }
                else if (counter > b)
                {
                    q2.Enqueue(listval);
                }
                counter++;
                list1 = list1.next;
            }
            while (list2 != null)
            {
                int listval = list2.val;
                q3.Enqueue(listval);
                list2 = list2.next;
            }
            if (ans == null)
            {
                ListNode link = new ListNode(q1.Peek());
                ans = link;
                q1.Dequeue();
            }
            ListNode current = ans;
            while (q1.Count > 0)
            {
                ListNode link = new ListNode(q1.Peek());
                current.next = link;
                current = current.next;
                q1.Dequeue();
            }
            while (q3.Count > 0)
            {
                ListNode link = new ListNode(q3.Peek());
                current.next = link;
                current = current.next;
                q3.Dequeue();
            }
            while (q2.Count > 0)
            {
                ListNode link = new ListNode(q2.Peek());
                current.next = link;
                current = current.next;
                q2.Dequeue();
            }
            return ans;
        }
        //Title: 1721. Swapping Nodes in a Linked List
        //Link: https://leetcode.com/problems/swapping-nodes-in-a-linked-list
        //Tags: Linked List, Two Pointers
        public static ListNode SwapNodes(ListNode head, int k)
        {
            List<int> a = new List<int>();
            ListNode ans = null;
            while (head != null)
            {
                int listval = head.val;
                a.Add(listval);
                head = head.next;
            }
            int n1 = a[k - 1];
            int n2 = a[a.Count - k];
            a[k - 1] = n2;
            a[a.Count - k] = n1;
            if (ans == null)
            {
                ListNode link = new ListNode(a[0]);
                ans = link;
            }
            ListNode current = ans;
            for (int i = 1; i < a.Count; i++)
            {
                ListNode link = new ListNode(a[i]);
                current.next = link;
                current = current.next;
            }
            return ans;
        }
        //Title: 442. Find All Duplicates in an Array
        //Link: https://leetcode.com/problems/find-all-duplicates-in-an-array
        //Tags: Array, Hash Table
        public static IList<int> FindDuplicates(int[] nums)
        {
            List<int> a = new List<int>();
            List<int> ans = new List<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (!a.Contains(nums[i]))
                {
                    a.Add(nums[i]);
                }
                else
                {
                    ans.Add(nums[i]);
                }
            }
            return ans;
        }
        //Title: 807. Max Increase to Keep City Skyline
        //Link: https://leetcode.com/problems/max-increase-to-keep-city-skyline
        //Tags: Array, Greedy, Matrix
        public static int MaxIncreaseKeepingSkyline(int[][] grid)
        {
            int len = grid.Length;
            int ilen = grid[0].Length;
            int counter = 0;
            foreach (int[] a in grid)
            {
                int rowmax = a.Max();
                for (int t = 0; t < ilen; t++)
                {
                    int colmax = 0;
                    int numtouse = 0;
                    for (int i = 0; i < len; i++)
                    {
                        colmax = Math.Max(colmax, grid[i][t]);
                    }
                    if (rowmax <= colmax)
                    {
                        numtouse = rowmax;
                    }
                    else if (colmax <= rowmax)
                    {
                        numtouse = colmax;
                    }
                    counter += numtouse - a[t];
                }
            }
            return counter;
        }
        //Title: 2545. Sort the Students by Their Kth Score
        //Link: https://leetcode.com/problems/sort-the-students-by-their-kth-score
        //Tags: Array, Sorting, Matrix
        public static int[][] SortTheStudents(int[][] score, int k)
        {
            SortedDictionary<int, int[]> a = new SortedDictionary<int, int[]>(new ReverseSortComparer());
            foreach (int[] b in score)
            {
                int mykey = b[k];
                a.Add(mykey, b);
            }
            var len = score.Length;
            var source = new int[len][];
            int x = 0;
            foreach (KeyValuePair<int, int[]> c in a)
            {
                var inner = score[x];
                var ilen = inner.Length;
                var newer = new int[ilen];
                Array.Copy(c.Value, newer, ilen);
                source[x] = newer;
                x++;
            }
            return source;
        }
        //Title: 19. Remove Nth Node From End of List
        //Link: https://leetcode.com/problems/remove-nth-node-from-end-of-list
        //Tags: Linked List, Two Pointers
        public static ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            Queue<int> q = new Queue<int>();
            ListNode ans = null;
            int counter = 0;
            while (head != null)
            {
                int listval = head.val;
                q.Enqueue(listval);
                counter++;
                head = head.next;
            }
            int index = 0;
            ListNode current = ans;
            while (q.Count > 0)
            {
                if (ans == null)
                {
                    if (index != counter - n)
                    {
                        ListNode link = new ListNode(q.Peek());
                        ans = link;
                        current = ans;
                    }
                }
                else
                {
                    if (index != counter - n)
                    {
                        ListNode link = new ListNode(q.Peek());
                        current.next = link;
                        current = current.next;
                    }
                }
                q.Dequeue();
                index++;
            }
            return ans;
        }
        //Title: 92. Reverse Linked List II
        //Link: https://leetcode.com/problems/reverse-linked-list-ii
        //Tags: Linked List
        public static ListNode ReverseBetween(ListNode head, int left, int right)
        {
            Queue<int> q1 = new Queue<int>();
            Queue<int> q2 = new Queue<int>();
            Queue<int> q3 = new Queue<int>();
            ListNode ans = null;
            int counter = 1;
            while (head != null)
            {
                int listval = head.val;
                if (counter < left)
                {
                    q1.Enqueue(listval);
                }
                else if (counter >= left && counter <= right)
                {
                    q2.Enqueue(listval);
                }
                else if (counter > right)
                {
                    q3.Enqueue(listval);
                }
                counter++;
                head = head.next;
            }
            ListNode current = ans;
            while (q1.Count > 0)
            {
                if (ans == null)
                {
                    ListNode link = new ListNode(q1.Peek());
                    ans = link;
                    current = ans;
                }
                else
                {
                    ListNode link = new ListNode(q1.Peek());
                    current.next = link;
                    current = current.next;
                }
                q1.Dequeue();
            }
            Queue<int> qrev = new Queue<int>(q2.Reverse());
            while (qrev.Count > 0)
            {
                if (ans == null)
                {
                    ListNode link = new ListNode(qrev.Peek());
                    ans = link;
                    current = ans;
                }
                else
                {
                    ListNode link = new ListNode(qrev.Peek());
                    current.next = link;
                    current = current.next;
                }
                qrev.Dequeue();
            }
            while (q3.Count > 0)
            {
                if (ans == null)
                {
                    ListNode link = new ListNode(q3.Peek());
                    ans = link;
                    current = ans;
                }
                else
                {
                    ListNode link = new ListNode(q3.Peek());
                    current.next = link;
                    current = current.next;
                }
                q3.Dequeue();
            }
            return ans;
        }
        //Title: 2487. Remove Nodes From Linked List
        //Link: https://leetcode.com/problems/remove-nodes-from-linked-list
        //Tags: Linked List, Stack, Recursion, Monotonic Stack
        public static ListNode RemoveNodes(ListNode head)
        {
            Stack<int> a = new Stack<int>();
            Stack<int> b = new Stack<int>();
            ListNode ans = null;
            while (head != null)
            {
                a.Push(head.val);
                head = head.next;
            }
            int myval = 0;
            while (a.Count > 0)
            {
                int curr = a.Peek();
                if (curr >= myval)
                {
                    b.Push(curr);
                    myval = curr;
                }
                a.Pop();
            }
            ListNode current = ans;
            while (b.Count > 0)
            {
                if (ans == null)
                {
                    ListNode link = new ListNode(b.Peek());
                    ans = link;
                    current = ans;
                }
                else
                {
                    ListNode link = new ListNode(b.Peek());
                    current.next = link;
                    current = current.next;
                }
                b.Pop();
            }
            return ans;
        }
        //Title: 328. Odd Even Linked List
        //Link: https://leetcode.com/problems/odd-even-linked-list
        //Tags: Linked List
        public static ListNode OddEvenList(ListNode head)
        {
            Queue<int> q1 = new Queue<int>();
            Queue<int> q2 = new Queue<int>();
            ListNode ans = null;
            int counter = 1;
            while (head != null)
            {
                int listval = head.val;
                if (counter % 2 != 0)
                {
                    q1.Enqueue(listval);
                }
                else
                {
                    q2.Enqueue(listval);
                }
                counter++;
                head = head.next;
            }
            ListNode current = ans;
            while (q1.Count > 0)
            {
                ListNode link = new ListNode(q1.Peek());
                if (ans == null)
                {
                    ans = link;
                    current = ans;
                }
                else
                {
                    current.next = link;
                    current = current.next;
                }
                q1.Dequeue();
            }
            while (q2.Count > 0)
            {
                ListNode link = new ListNode(q2.Peek());
                if (ans == null)
                {
                    ans = link;
                    current = ans;
                }
                else
                {
                    current.next = link;
                    current = current.next;
                }
                q2.Dequeue();
            }
            return ans;
        }
        //Title: 148. Sort List
        //Link: https://leetcode.com/problems/sort-list
        //Tags: Linked List, Two Pointers, Divide and Conquer, Sorting, Merge Sort
        public static ListNode SortList(ListNode head)
        {
            List<int> a = new List<int>();
            ListNode ans = null;
            while (head != null)
            {
                a.Add(head.val);
                head = head.next;
            }
            a.Sort();
            ListNode current = ans;
            foreach (int i in a)
            {
                ListNode link = new ListNode(i);
                if (ans == null)
                {
                    ans = link;
                    current = ans;
                }
                else
                {
                    current.next = link;
                    current = current.next;
                }
            }
            return ans;
        }
        //Title: 86. Partition List
        //Link: https://leetcode.com/problems/partition-list
        //Tags: Linked List, Two Pointers
        public static ListNode Partition(ListNode head, int x)
        {
            Queue<int> q1 = new Queue<int>();
            Queue<int> q2 = new Queue<int>();
            ListNode ans = null;
            int counter = 1;
            while (head != null)
            {
                int listval = head.val;
                if (listval < x)
                {
                    q1.Enqueue(listval);
                }
                else
                {
                    q2.Enqueue(listval);
                }
                counter++;
                head = head.next;
            }
            ListNode current = ans;
            while (q1.Count > 0)
            {
                ListNode link = new ListNode(q1.Peek());
                if (ans == null)
                {
                    ans = link;
                    current = ans;
                }
                else
                {
                    current.next = link;
                    current = current.next;
                }
                q1.Dequeue();
            }
            while (q2.Count > 0)
            {
                ListNode link = new ListNode(q2.Peek());
                if (ans == null)
                {
                    ans = link;
                    current = ans;
                }
                else
                {
                    current.next = link;
                    current = current.next;
                }
                q2.Dequeue();
            }
            return ans;
        }
        //Title: 147. Insertion Sort List
        //Link: https://leetcode.com/problems/insertion-sort-list
        //Tags: Linked List, Sorting
        public static ListNode InsertionSortList(ListNode head)
        {
            List<int> a = new List<int>();
            ListNode ans = null;
            while (head != null)
            {
                a.Add(head.val);
                head = head.next;
            }
            a.Sort();
            ListNode current = ans;
            foreach (int i in a)
            {
                ListNode link = new ListNode(i);
                if (ans == null)
                {
                    ans = link;
                    current = ans;
                }
                else
                {
                    current.next = link;
                    current = current.next;
                }
            }
            return ans;
        }
        //Title: 2816. Double a Number Represented as a Linked List
        //Link: https://leetcode.com/problems/double-a-number-represented-as-a-linked-list
        //Tags: Linked List, Math, Stack
        public static ListNode DoubleIt(ListNode head)
        {
            BigInteger num1 = 0;
            BigInteger sum = 0;
            string sumstr = "";
            string str1 = "";
            ListNode ans = null;
            while (head != null)
            {
                int listval = head.val;
                str1 += listval.ToString();
                head = head.next;
            }
            BigInteger.TryParse(str1, out num1);
            sum = num1 * 2;
            sumstr = sum.ToString();
            if (ans == null)
            {
                int startdigit = 0;
                int.TryParse(sumstr[0] + "", out startdigit);
                ListNode link = new ListNode(startdigit);
                ans = link;
            }
            ListNode current = ans;
            for (int i = 1; i < sumstr.Length; i++)
            {
                int digit = 0;
                int.TryParse(sumstr[i] + "", out digit);
                ListNode link = new ListNode(digit);
                current.next = link;
                current = current.next;
            }
            return ans;
        }
        //Title: 82. Remove Duplicates from Sorted List II
        //Link: https://leetcode.com/problems/remove-duplicates-from-sorted-list-ii
        //Tags: Linked List, Two Pointers
        public static ListNode DeleteDuplicates(ListNode head)
        {
            SortedDictionary<int, int> a = new SortedDictionary<int, int>();
            ListNode ans = null;
            while (head != null)
            {
                int listval = head.val;
                if (!a.ContainsKey(listval))
                {
                    a.Add(listval, 1);
                }
                else
                {
                    a[listval]++;
                }
                head = head.next;
            }
            ListNode current = ans;
            foreach (KeyValuePair<int, int> i in a)
            {
                if (i.Value == 1)
                {
                    ListNode link = new ListNode(i.Key);
                    if (ans == null)
                    {
                        ans = link;
                        current = ans;
                    }
                    else
                    {
                        current.next = link;
                        current = current.next;
                    }
                }
            }
            return ans;
        }
        //Title: 61. Rotate List
        //Link: https://leetcode.com/problems/rotate-list
        //Tags: Linked List, Two Pointers
        public ListNode RotateRight(ListNode head, int k)
        {
            Queue<int> q1 = new Queue<int>();
            ListNode ans = null;
            while (head != null)
            {
                q1.Enqueue(head.val);
                head = head.next;
            }
            if (q1.Count == 0)
            {
                return ans;
            }
            int rotations = k % q1.Count();
            Queue<int> q2 = new Queue<int>(q1.Reverse());
            if (k != 0)
            {
                for (int i = 0; i < rotations; i++)
                {
                    int myval = q2.Peek();
                    q2.Dequeue();
                    q2.Enqueue(myval);
                }
            }
            Queue<int> q3 = new Queue<int>(q2.Reverse());
            ListNode current = ans;
            while (q3.Count > 0)
            {
                ListNode link = new ListNode(q3.Peek());
                if (ans == null)
                {
                    ans = link;
                    current = ans;
                }
                else
                {
                    current.next = link;
                    current = current.next;
                }
                q3.Dequeue();
            }
            return ans;
        }
        //Title: 24. Swap Nodes in Pairs
        //Link: https://leetcode.com/problems/swap-nodes-in-pairs
        //Tags: Linked List, Recursion
        public static ListNode SwapPairs(ListNode head)
        {
            Queue<int> q1 = new Queue<int>();
            Queue<int> q2 = new Queue<int>();
            Queue<int> q3 = new Queue<int>();
            ListNode ans = null;
            int counter = 0;
            while (head != null)
            {
                int myval = head.val;
                if (counter % 2 == 0)
                {
                    q1.Enqueue(myval);
                }
                else
                {
                    q2.Enqueue(myval);
                }
                counter++;
                head = head.next;
            }
            while (q1.Count > 0 || q2.Count > 0)
            {
                if (q2.Count > 0)
                {
                    q3.Enqueue(q2.Peek());
                    q2.Dequeue();
                }
                if (q1.Count > 0)
                {
                    q3.Enqueue(q1.Peek());
                    q1.Dequeue();
                }
            }
            ListNode current = ans;
            while (q3.Count > 0)
            {
                ListNode link = new ListNode(q3.Peek());
                if (ans == null)
                {
                    ans = link;
                    current = ans;
                }
                else
                {
                    current.next = link;
                    current = current.next;
                }
                q3.Dequeue();
            }
            return ans;
        }
        //Title: 189. Rotate Array
        //Link: https://leetcode.com/problems/rotate-array
        //Tags: Array, Math, Two Pointers
        public static void Rotate(int[] nums, int k)
        {
            Queue<int> q1 = new Queue<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                q1.Enqueue(nums[i]);
            }
            int rotations = k % q1.Count();
            Queue<int> q2 = new Queue<int>(q1.Reverse());
            if (k != 0)
            {
                for (int i = 0; i < rotations; i++)
                {
                    int myval = q2.Peek();
                    q2.Dequeue();
                    q2.Enqueue(myval);
                }
            }
            Queue<int> q3 = new Queue<int>(q2.Reverse());
            int index = 0;
            while (q3.Count > 0)
            {
                nums[index] = q3.Peek();
                index++;
                q3.Dequeue();
            }
        }
        //Title: 260. Single Number III
        //Link: https://leetcode.com/problems/single-number-iii
        //Tags: Array, Bit Manipulation
        public static int[] SingleNumber2(int[] nums)
        {
            List<int> a = new List<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (!a.Contains(nums[i]))
                {
                    a.Add(nums[i]);
                }
                else
                {
                    a.Remove(nums[i]);
                }
            }
            int[] ans = new int[a.Count];
            int index = 0;
            for (int i = 0; i < a.Count; i++)
            {
                ans[i] = a[i];
                index++;
            }
            return ans;
        }
        //Title: 713. Subarray Product Less Than K
        //Link: https://leetcode.com/problems/subarray-product-less-than-k
        //Tags: Array, Sliding Window
        public static int NumSubarrayProductLessThanK(int[] nums, int k)
        {
            if (k <= 1) { return 0; }
            int counter = 0;
            int product = 1;
            for (int d = 0; d < nums.Length; d++)
            {
                for (int i = d; i < nums.Length; i++)
                {
                    product *= nums[i];
                    if (product < k)
                    {
                        counter++;
                    }
                    else
                    {
                        break;
                    }
                }
                product = 1;
            }
            return counter;
        }
        //Title: 2958. Length of Longest Subarray With at Most K Frequency
        //Link: https://leetcode.com/problems/length-of-longest-subarray-with-at-most-k-frequency
        //Tags: Array, Hash Table, Sliding Window
        public static int MaxSubarrayLength(int[] nums, int k)
        {
            Dictionary<int, int> a = new Dictionary<int, int>();
            Queue<int> q = new Queue<int>();
            int max = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (!a.ContainsKey(nums[i]))
                {
                    a.Add(nums[i], 1);
                }
                else
                {
                    if (a[nums[i]] + 1 > k)
                    {
                        while (q.Peek() != nums[i])
                        {
                            a[q.Peek()]--;
                            q.Dequeue();
                        }
                        q.Dequeue();
                    }
                    else
                    {
                        a[nums[i]]++;
                    }
                }
                q.Enqueue(nums[i]);
                max = Math.Max(max, q.Count);
            }
            return max;
        }
        //Title: 560. Subarray Sum Equals K
        //Link: https://leetcode.com/problems/subarray-sum-equals-k
        //Tags: Array, Hash Table, Prefix Sum
        public static int SubarraySum(int[] nums, int k)
        {
            int counter = 0;
            int sum = 0;
            for (int d = 0; d < nums.Length; d++)
            {
                for (int i = d; i < nums.Length; i++)
                {
                    sum += nums[i];
                    if (sum == k)
                    {
                        counter++;
                    }
                }
                sum = 0;
            }
            return counter;
        }
        //Title: 1823. Find the Winner of the Circular Game
        //Link: https://leetcode.com/problems/find-the-winner-of-the-circular-game
        //Tags: Array, Math, Recursion, Queue, Simulation
        public static int FindTheWinner(int n, int k)
        {
            Queue<int> q = new Queue<int>();
            for (int i = 1; i <= n; i++)
            {
                q.Enqueue(i);
            }
            while (q.Count() > 1)
            {
                for (int i = 1; i < k; i++)
                {
                    int val = q.Peek();
                    q.Dequeue();
                    q.Enqueue(val);
                }
                q.Dequeue();
            }
            return q.Peek();
        }
        //Title: 950. Reveal Cards In Increasing Order
        //Link: https://leetcode.com/problems/reveal-cards-in-increasing-order
        //Tags: Array, Queue, Sorting, Simulation
        public static int[] DeckRevealedIncreasing(int[] deck)
        {
            int[] ans = new int[deck.Length];
            Queue<int> q = new Queue<int>();
            Array.Sort(deck);
            Array.Reverse(deck);
            for (int i = 0; i < deck.Length; i++)
            {
                if (q.Count > 0)
                {
                    int val = q.Peek();
                    q.Dequeue();
                    q.Enqueue(val);
                }
                q.Enqueue(deck[i]);
            }
            int index = 0;
            Queue<int> q2 = new Queue<int>(q.Reverse());
            while (q2.Count > 0)
            {
                ans[index] = q2.Peek();
                index++;
                q2.Dequeue();
            }
            return ans;
        }
        //Title: 53. Maximum Subarray
        //Link: https://leetcode.com/problems/maximum-subarray
        //Tags: Array, Divide and Conquer, Dynamic Programming
        public static int MaxSubArray(int[] nums)
        {
            int sum = nums[0];
            int max = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                sum = Math.Max(nums[i], sum + nums[i]);
                max = Math.Max(max, sum);
            }
            return max;
        }
        //Title: 1996. The Number of Weak Characters in the Game
        //Link: https://leetcode.com/problems/the-number-of-weak-characters-in-the-game
        //Tags: Array, Stack, Greedy, Sorting, Monotonic Stack
        public static int NumberOfWeakCharacters(int[][] properties)
        {
            List<KeyValuePair<int, int>> a = new List<KeyValuePair<int, int>>();
            foreach (int[] b in properties)
            {
                a.Add(new KeyValuePair<int, int>(b[0], b[1]));
            }
            var sortedDict = from entry in a orderby entry.Key ascending, entry.Value descending select entry;
            Stack<KeyValuePair<int, int>> s = new Stack<KeyValuePair<int, int>>();
            foreach (KeyValuePair<int, int> b in sortedDict)
            {
                while (s.Count > 0 && b.Value > s.Peek().Value)
                {
                    s.Pop();
                }
                s.Push(b);
            }
            return properties.Length - s.Count;
        }
        //Title: 152. Maximum Product Subarray
        //Link: https://leetcode.com/problems/maximum-product-subarray
        //Tags: Array, Dynamic Programming
        public static int MaxProduct(int[] nums)
        {
            int currmaxproduct = nums[0];
            int prevmaxproduct = nums[0];
            int prevminproduct = nums[0];
            int max = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                currmaxproduct = Math.Max(Math.Max(prevmaxproduct * nums[i], prevminproduct * nums[i]), nums[i]);
                int currminproduct = Math.Min(Math.Min(prevmaxproduct * nums[i], prevminproduct * nums[i]), nums[i]);
                max = Math.Max(max, currmaxproduct);
                prevmaxproduct = currmaxproduct;
                prevminproduct = currminproduct;
            }
            return max;
        }
        //Title: 2348. Number of Zero-Filled Subarrays
        //Link: https://leetcode.com/problems/number-of-zero-filled-subarrays
        //Tags: Array, Math
        public static long ZeroFilledSubarray(int[] nums)
        {
            long counter = 0;
            bool zero = false;
            int curr = 0;
            List<int> a = new List<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 0)
                {
                    if (zero)
                    {
                        curr++;
                    }
                    else
                    {
                        zero = true;
                        curr = 1;
                    }
                }
                else
                {
                    if (zero)
                    {
                        zero = false;
                        a.Add(curr);
                        curr = 0;
                    }
                }
            }
            if (curr > 0)
            {
                a.Add(curr);
            }
            foreach (int i in a)
            {
                counter += (long)(i * (long)(i + 1) / 2);
            }
            return counter;
        }
        //Title: 2807. Insert Greatest Common Divisors in Linked List
        //Link: https://leetcode.com/problems/insert-greatest-common-divisors-in-linked-list
        //Tags: Linked List, Math, Number Theory
        public static ListNode InsertGreatestCommonDivisors(ListNode head)
        {
            Queue<int> q = new Queue<int>();
            ListNode ans = null;
            int lastval = 0;
            while (head != null)
            {
                int myval = head.val;
                if (lastval != 0)
                {
                    int divisor = GCD(lastval, myval);
                    q.Enqueue(divisor);
                }
                lastval = myval;
                q.Enqueue(myval);
                head = head.next;
            }
            ListNode current = ans;
            while (q.Count > 0)
            {
                ListNode link = new ListNode(q.Peek());
                if (ans == null)
                {
                    ans = link;
                    current = ans;
                }
                else
                {
                    current.next = link;
                    current = current.next;
                }
                q.Dequeue();
            }
            return ans;
        }
        public static int GCD(int a, int b)
        {
            while (a != 0 && b != 0)
            {
                if (a > b)
                    a %= b;
                else
                    b %= a;
            }
            return a | b;
        }
        //Title: 2433. Find The Original Array of Prefix Xor
        //Link: https://leetcode.com/problems/find-the-original-array-of-prefix-xor
        //Tags: Array, Bit Manipulation
        public static int[] FindArray(int[] pref)
        {
            int[] ans = new int[pref.Length];
            Array.Reverse(pref);
            int xor = pref[0];
            int index = 0;
            for (int i = 1; i < pref.Length; i++)
            {
                ans[index] = xor ^ pref[i];
                index++;
                xor = pref[i];
            }
            ans[index] = pref[pref.Length - 1];
            Array.Reverse(ans);
            return ans;
        }
        //Title: 1302. Deepest Leaves Sum
        //Link: https://leetcode.com/problems/deepest-leaves-sum
        //Tags: Tree, Depth-First Search, Breadth-First Search, Binary Tree
        public static int DeepestLeavesSum(TreeNode root)
        {
            Queue<TreeNode> q = new Queue<TreeNode>();
            List<List<int>> a = new List<List<int>>();
            int sum = 0;
            q.Enqueue(root);
            while (q.Count > 0)
            {
                int size = q.Count();
                List<int> b = new List<int>();
                for (int i = 0; i < size; i++)
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
                    b.Add(T.val);
                }
                a.Add(b);
            }
            foreach (int j in a[a.Count - 1])
            {
                sum += j;
            }
            return sum;
        }
        //Title: 1305. All Elements in Two Binary Search Trees
        //Link: https://leetcode.com/problems/all-elements-in-two-binary-search-trees
        //Tags: Tree, Depth-First Search, Binary Search Tree, Sorting, Binary Tree
        public static IList<int> GetAllElements(TreeNode root1, TreeNode root2)
        {
            List<int> a = new List<int>();
            Queue<TreeNode> q = new Queue<TreeNode>();
            if (root1 != null)
            {
                q.Enqueue(root1);
            }
            if (root2 != null)
            {
                q.Enqueue(root2);
            }
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
                a.Add(T.val);
            }
            a.Sort();
            return a;
        }
        //Title: 513. Find Bottom Left Tree Value
        //Link: https://leetcode.com/problems/find-bottom-left-tree-value
        //Tags: Tree, Depth-First Search, Breadth-First Search, Binary Tree
        public static int FindBottomLeftValue(TreeNode root)
        {
            Queue<TreeNode> q = new Queue<TreeNode>();
            List<List<int>> a = new List<List<int>>();
            int ans = 0;
            q.Enqueue(root);
            while (q.Count > 0)
            {
                int size = q.Count();
                List<int> b = new List<int>();
                for (int i = 0; i < size; i++)
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
                    b.Add(T.val);
                }
                a.Add(b);
            }
            foreach (int j in a[a.Count - 1])
            {
                ans = j;
                break;
            }
            return ans;
        }
        //Title: 230. Kth Smallest Element in a BST
        //Link: https://leetcode.com/problems/kth-smallest-element-in-a-bst
        //Tags: Tree, Depth-First Search, Binary Search Tree, Binary Tree
        public static int KthSmallest(TreeNode root, int k)
        {
            Queue<TreeNode> q = new Queue<TreeNode>();
            List<int> a = new List<int>();
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
                a.Add(T.val);
            }
            a.Sort();
            return a[k - 1];
        }
        //Title: 1161. Maximum Level Sum of a Binary Tree
        //Link: https://leetcode.com/problems/maximum-level-sum-of-a-binary-tree
        //Tags: Tree, Depth-First Search, Breadth-First Search, Binary Tree
        public static int MaxLevelSum(TreeNode root)
        {
            Queue<TreeNode> q = new Queue<TreeNode>();
            List<List<int>> a = new List<List<int>>();
            int maxsum = Int32.MinValue;
            int maxlevel = 0;
            q.Enqueue(root);
            while (q.Count > 0)
            {
                int size = q.Count();
                List<int> b = new List<int>();
                for (int i = 0; i < size; i++)
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
                    b.Add(T.val);
                }
                a.Add(b);
            }
            int level = 1;
            foreach (List<int> j in a)
            {
                int sum = 0;
                foreach (int i in j)
                {
                    sum += i;
                }
                if (sum > maxsum)
                {
                    maxsum = sum;
                    maxlevel = level;
                }
                level++;
            }
            return maxlevel;
        }
        //Title: 2482. Difference Between Ones and Zeros in Row and Column
        //Link: https://leetcode.com/problems/difference-between-ones-and-zeros-in-row-and-column
        //Tags: Array, Matrix, Simulation
        public static int[][] OnesMinusZeros(int[][] grid)
        {
            int[][] rowmap = new int[grid.Length][];
            int len = grid[0].Length;
            int[][] colmap = new int[len][];
            int rowindex = 0;
            int[][] ans = new int[grid.Length][];
            for (var x = 0; x < grid.Length; x++)
            {
                var inner = grid[x];
                var ilen = inner.Length;
                var newer = new int[ilen];
                Array.Copy(inner, newer, ilen);
                ans[x] = newer;
            }
            foreach (int[] row in grid)
            {
                int one = 0;
                int zero = 0;
                for (int i = 0; i < len; i++)
                {
                    if (row[i] == 0)
                    {
                        zero++;
                    }
                    else
                    {
                        one++;
                    }
                }
                rowmap[rowindex] = new int[] { one, zero };
                rowindex++;
            }
            for (int i = 0; i < len; i++)
            {
                int one = 0;
                int zero = 0;
                for (int j = 0; j < grid.Length; j++)
                {
                    if (grid[j][i] == 0)
                    {
                        zero++;
                    }
                    else
                    {
                        one++;
                    }
                }
                colmap[i] = new int[] { one, zero };
            }
            for (int i = 0; i < len; i++)
            {
                for (int j = 0; j < grid.Length; j++)
                {
                    ans[j][i] = rowmap[j][0] + colmap[i][0] - rowmap[j][1] - colmap[i][1];
                }
            }
            return ans;
        }
        //Title: 1441. Build an Array With Stack Operations
        //Link: https://leetcode.com/problems/build-an-array-with-stack-operations
        //Tags: Array, Stack, Simulation
        public static IList<string> BuildArray(int[] target, int n)
        {
            List<string> a = new List<string>();
            for (int i = 1; i <= target.Max(); i++)
            {
                a.Add("Push");
                if (!target.Contains(i))
                {
                    a.Add("Pop");
                }
            }
            return a;
        }
        //Title: 2442. Count Number of Distinct Integers After Reverse Operations
        //Link: https://leetcode.com/problems/count-number-of-distinct-integers-after-reverse-operations
        //Tags: Array, Hash Table, Math
        public static int CountDistinctIntegers(int[] nums)
        {
            Dictionary<int, int> a = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (!a.ContainsKey(nums[i]))
                {
                    a.Add(nums[i], 1);
                }
                else
                {
                    a[nums[i]]++;
                }
                char[] array = nums[i].ToString().ToCharArray();
                Array.Reverse(array);
                string backwards = new String(array);
                int digits = 0;
                int.TryParse(backwards, out digits);
                if (!a.ContainsKey(digits))
                {
                    a.Add(digits, 1);
                }
                else
                {
                    a[digits]++;
                }
            }
            return a.Count;
        }
        //Title: 80. Remove Duplicates from Sorted Array II
        //Link: https://leetcode.com/problems/remove-duplicates-from-sorted-array-ii
        //Tags: Array, Two Pointers
        public static int RemoveDuplicates(int[] nums)
        {
            Dictionary<int, int> a = new Dictionary<int, int>();
            int[] numcopy = new int[nums.Length];
            Array.Copy(nums, 0, numcopy, 0, nums.Length);
            int index = 0;
            for (int i = 0; i < numcopy.Length; i++)
            {
                if (!a.ContainsKey(numcopy[i]))
                {
                    a.Add(numcopy[i], 1);
                    nums[index] = numcopy[i];
                    index++;
                }
                else
                {
                    if (a[numcopy[i]] != 2)
                    {
                        a[numcopy[i]]++;
                        nums[index] = numcopy[i];
                        index++;
                    }
                }
            }
            int ans = 0;
            foreach (KeyValuePair<int, int> i in a)
            {
                ans += i.Value;
            }
            return ans;
        }
        //Title: 81. Search in Rotated Sorted Array II
        //Link: https://leetcode.com/problems/search-in-rotated-sorted-array-ii
        //Tags: Array, Binary Search
        public static bool SearchII(int[] nums, int target)
        {
            if (nums.Contains(target))
            {
                return true;
            }
            return false;
        }
        //Title: 2225. Find Players With Zero or One Losses
        //Link: https://leetcode.com/problems/find-players-with-zero-or-one-losses
        //Tags: Array, Hash Table, Sorting, Counting
        public static IList<IList<int>> FindWinners(int[][] matches)
        {
            Dictionary<int, int> a = new Dictionary<int, int>();
            List<IList<int>> b = new List<IList<int>>();
            List<int> c = new List<int>();
            List<int> d = new List<int>();
            foreach (int[] i in matches)
            {
                int w = i[0];
                int l = i[1];
                if (!a.ContainsKey(w))
                {
                    a.Add(w, 0);
                }
                if (!a.ContainsKey(l))
                {
                    a.Add(l, 1);
                }
                else
                {
                    a[l]++;
                }
            }
            foreach (KeyValuePair<int, int> i in a)
            {
                if (i.Value == 0)
                {
                    c.Add(i.Key);
                }
                if (i.Value == 1)
                {
                    d.Add(i.Key);
                }
            }
            c.Sort();
            d.Sort();
            b.Add(c);
            b.Add(d);
            return b;
        }
        //Title: 1268. Search Suggestions System
        //Link: https://leetcode.com/problems/search-suggestions-system
        //Tags: Array, String, Binary Search, Trie, Sorting, Heap(Priority Queue)
        public static IList<IList<string>> SuggestedProducts(string[] products, string searchWord)
        {
            List<IList<string>> a = new List<IList<string>>();
            Array.Sort(products);
            for (int j = 1; j <= searchWord.Length; j++)
            {
                List<string> b = new List<string>();
                var results = products.Where((x) => x.StartsWith(searchWord.Substring(0, j))).Take(3);
                foreach (string i in results)
                {
                    b.Add(i);
                }
                a.Add(b);
            }
            return a;
        }
        //Title: 2679. Sum in a Matrix
        //Link: https://leetcode.com/problems/sum-in-a-matrix
        //Tags: Array, Sorting, Heap(Priority Queue), Matrix, Simulation
        public static int MatrixSum(int[][] nums)
        {
            int score = 0;
            int xlen = nums[0].Length;
            int ylen = nums.Length;
            for (int d = 0; d < xlen; d++)
            {
                int colmax = 0;
                for (int i = 0; i < ylen; i++)
                {
                    int rowmax = 0;
                    for (int j = 0; j < xlen; j++)
                    {
                        if (nums[i][j] > rowmax)
                        {
                            rowmax = nums[i][j];
                        }
                    }
                    for (int j = 0; j < xlen; j++)
                    {
                        if (nums[i][j] == rowmax)
                        {
                            nums[i][j] = 0;
                            break;
                        }
                    }
                    if (rowmax > colmax)
                    {
                        colmax = rowmax;
                    }
                }
                score += colmax;
            }
            return score;
        }
        //Title: 912. Sort an Array
        //Link: https://leetcode.com/problems/sort-an-array
        //Tags: Array, Divide and Conquer, Sorting, Heap(Priority Queue), Merge Sort, Bucket Sort, Radix Sort, Counting Sort
        public static int[] SortArray(int[] nums)
        {
            SortedDictionary<int, int> a = new SortedDictionary<int, int>();
            int[] ans = new int[nums.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                if (!a.ContainsKey(nums[i]))
                {
                    a.Add(nums[i], 1);
                }
                else
                {
                    a[nums[i]]++;
                }
            }
            int index = 0;
            foreach (KeyValuePair<int, int> i in a)
            {
                for (int j = 0; j < i.Value; j++)
                {
                    ans[index] = i.Key;
                    index++;
                }
            }
            return ans;
        }
        //Title: 2343. Query Kth Smallest Trimmed Number
        //Link: https://leetcode.com/problems/query-kth-smallest-trimmed-number
        //Tags: Array, String, Divide and Conquer, Sorting, Heap(Priority Queue), Radix Sort, Quickselect
        public static int[] SmallestTrimmedNumbers(string[] nums, int[][] queries)
        {
            List<int> a = new List<int>();
            Dictionary<int, BigInteger[]> b = new Dictionary<int, BigInteger[]>();
            int[] ans = new int[queries.Length];
            foreach (int[] i in queries)
            {
                if (!a.Contains(i[1]))
                {
                    a.Add(i[1]);
                }
            }
            foreach (int i in a)
            {
                BigInteger[] c = new BigInteger[nums.Length];
                int indexa = 0;
                for (int j = 0; j < nums.Length; j++)
                {
                    BigInteger digits = 0;
                    BigInteger.TryParse(nums[j].Substring(nums[j].Length - i, i), out digits);
                    c[indexa] = digits;
                    indexa++;
                }
                b.Add(i, c);
            }
            int indexb = 0;
            foreach (int[] i in queries)
            {
                int x = i[0];
                int y = i[1];
                List<PreSortItem> c = new List<PreSortItem>();
                for (int j = 0; j < b[y].Length; j++)
                {
                    PreSortItem ps = new PreSortItem();
                    ps.Key = b[y][j];
                    ps.Index = j;
                    c.Add(ps);
                }
                var sortedDict = from entry in c orderby entry.Key ascending select entry;
                ans[indexb] = sortedDict.ElementAt(x - 1).Index;
                indexb++;
            }
            return ans;
        }
        //Title: 654. Maximum Binary Tree
        //Link: https://leetcode.com/problems/maximum-binary-tree
        //Tags: Array, Divide and Conquer, Stack, Tree, Monotonic Stack, Binary Tree
        public static TreeNode ConstructMaximumBinaryTree(int[] nums)
        {
            TreeNode root = null;
            root = InsertNode(root, nums);
            return root;
        }
        public static TreeNode InsertNode(TreeNode root, int[] vals)
        {
            int max = vals.Max();
            int maxindex = Array.IndexOf(vals, max);
            if (root == null)
            {
                root = new TreeNode(max);
            }
            if (maxindex > 0)
            {
                int[] a = new int[maxindex];
                for (int i = 0; i < maxindex; i++)
                {
                    a[i] = vals[i];
                }
                root.left = InsertNode(root.left, a);
            }
            if (maxindex != vals.Length - 1)
            {
                int lenb = vals.Length - 1 - maxindex;
                int[] b = new int[lenb];
                int index = 0;
                for (int i = maxindex + 1; i < vals.Length; i++)
                {
                    b[index] = vals[i];
                    index++;
                }
                root.right = InsertNode(root.right, b);
            }
            return root;
        }
        //Title: 102. Binary Tree Level Order Traversal
        //Link: https://leetcode.com/problems/binary-tree-level-order-traversal
        //Tags: Tree, Breadth-First Search, Binary Tree
        public static IList<IList<int>> LevelOrder(TreeNode root)
        {
            Queue<TreeNode> q = new Queue<TreeNode>();
            List<IList<int>> a = new List<IList<int>>();
            if (root == null) return a;
            q.Enqueue(root);
            while (q.Count > 0)
            {
                int size = q.Count();
                List<int> b = new List<int>();
                for (int i = 0; i < size; i++)
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
                    b.Add(T.val);
                }
                a.Add(b);
            }
            return a;
        }
        //Title: 240. Search a 2D Matrix II
        //Link: https://leetcode.com/problems/search-a-2d-matrix-ii
        //Tags: Array, Binary Search, Divide and Conquer, Matrix
        public static bool SearchMatrixII(int[][] matrix, int target)
        {
            foreach (int[] i in matrix)
            {
                if (i.Contains(target))
                {
                    return true;
                }
            }
            return false;
        }
        //Title: 33. Search in Rotated Sorted Array
        //Link: https://leetcode.com/problems/search-in-rotated-sorted-array
        //Tags: Array, Binary Search
        public static int Search(int[] nums, int target)
        {
            return Array.IndexOf(nums, target);
        }
        //Title: 153. Find Minimum in Rotated Sorted Array
        //Link: https://leetcode.com/problems/find-minimum-in-rotated-sorted-array
        //Tags: Array, Binary Search
        public static int FindMin(int[] nums)
        {
            return nums.Min();
        }
        //Title: 204. Count Primes
        //Link: https://leetcode.com/problems/count-primes
        //Tags: Array, Math, Enumeration, Number Theory, Sieve of Eratosthenes
        public static int CountPrimes(int n)
        {
            n = n - 1;
            int count = 0;
            bool[] primes = new bool[n + 1];
            for (int i = 0; i < primes.Length; i++)
            {
                primes[i] = true;
            }
            for (int i = 2; i < Math.Sqrt(n) + 1; i++)
            {
                if (primes[i - 1])
                {
                    for (int j = (int)Math.Pow(i, 2); j <= n; j += i)
                    {
                        primes[j - 1] = false;
                    }
                }
            }
            for (int i = 2; i < primes.Length; i++)
            {
                if (primes[i - 1])
                {
                    count++;
                }
            }
            return count;
        }
        //Title: 1817. Finding the Users Active Minutes
        //Link: https://leetcode.com/problems/finding-the-users-active-minutes
        //Tags: Array, Hash Table
        public static int[] FindingUsersActiveMinutes(int[][] logs, int k)
        {
            Dictionary<int, List<int>> a = new Dictionary<int, List<int>>();
            int[] ans = new int[k];
            foreach (int[] i in logs)
            {
                int user = i[0];
                int action = i[1];
                if (!a.ContainsKey(user))
                {
                    a.Add(user, new List<int> { action });
                }
                else
                {
                    if (!a[user].Contains(action))
                    {
                        a[user].Add(action);
                    }
                }
            }
            foreach (KeyValuePair<int, List<int>> i in a)
            {
                ans[i.Value.Count - 1]++;
            }
            return ans;
        }
        //Title: 1222. Queens That Can Attack the King
        //Link: https://leetcode.com/problems/queens-that-can-attack-the-king
        //Tags: Array, Matrix, Simulation
        public static IList<IList<int>> QueensAttacktheKing(int[][] queens, int[] king)
        {
            List<IList<int>> a = new List<IList<int>>();
            int[][] b = new int[8][];
            for (int i = 0; i < 8; i++) b[i] = new int[] { 0, 0, 0, 0, 0, 0, 0, 0 };
            int kingx = king[0];
            int kingy = king[1];
            b[kingx][kingy] = 1;
            foreach (int[] queen in queens) b[queen[0]][queen[1]] = 2;
            //right
            for (int i = kingx; i < 8; i++)
            {
                if (b[i][kingy] == 2)
                {
                    List<int> c = new List<int>();
                    c.Add(i);
                    c.Add(kingy);
                    a.Add(c);
                    break;
                }
            }
            //right up
            int rightupx = kingx;
            for (int i = kingy; i >= 0; i--)
            {
                if (rightupx > 7) break;
                if (b[rightupx][i] == 2)
                {
                    List<int> c = new List<int>();
                    c.Add(rightupx);
                    c.Add(i);
                    a.Add(c);
                    break;
                }
                rightupx++;
            }
            //right down
            int rightdownx = kingx;
            for (int i = kingy; i < 8; i++)
            {
                if (rightdownx > 7) break;
                if (b[rightdownx][i] == 2)
                {
                    List<int> c = new List<int>();
                    c.Add(rightdownx);
                    c.Add(i);
                    a.Add(c);
                    break;
                }
                rightdownx++;
            }
            //down
            for (int i = kingy; i < 8; i++)
            {
                if (b[kingx][i] == 2)
                {
                    List<int> c = new List<int>();
                    c.Add(kingx);
                    c.Add(i);
                    a.Add(c);
                    break;
                }
            }
            //left
            for (int i = kingx; i >= 0; i--)
            {
                if (b[i][kingy] == 2)
                {
                    List<int> c = new List<int>();
                    c.Add(i);
                    c.Add(kingy);
                    a.Add(c);
                    break;
                }
            }
            //left up
            int leftupx = kingx;
            for (int i = kingy; i >= 0; i--)
            {
                if (leftupx < 0) break;
                if (b[leftupx][i] == 2)
                {
                    List<int> c = new List<int>();
                    c.Add(leftupx);
                    c.Add(i);
                    a.Add(c);
                    break;
                }
                leftupx--;
            }
            //left down
            int leftdownx = kingx;
            for (int i = kingy; i < 8; i++)
            {
                if (leftdownx < 0) break;
                if (b[leftdownx][i] == 2)
                {
                    List<int> c = new List<int>();
                    c.Add(leftdownx);
                    c.Add(i);
                    a.Add(c);
                    break;
                }
                leftdownx--;
            }
            //up
            for (int i = kingy; i >= 0; i--)
            {
                if (b[kingx][i] == 2)
                {
                    List<int> c = new List<int>();
                    c.Add(kingx);
                    c.Add(i);
                    a.Add(c);
                    break;
                }
            }
            return a;
        }
        //Title: 2718. Sum of Matrix After Queries
        //Link: https://leetcode.com/problems/sum-of-matrix-after-queries
        //Tags: Array, Hash Table
        public static long MatrixSumQueries(int n, int[][] queries)
        {
            Dictionary<int, int> cols = new Dictionary<int, int>();
            Dictionary<int, int> rows = new Dictionary<int, int>();
            int colnum = 0;
            int rownum = 0;
            long ans = 0;
            for (int i = queries.Length - 1; i >= 0; i--)
            {
                int index = queries[i][1];
                int val = queries[i][2];
                if (queries[i][0] == 1)
                {
                    if (!cols.ContainsKey(index))
                    {
                        for (int j = 0; j < n - rownum; j++)
                        {
                            ans += val;
                        }
                        cols.Add(index, 1);
                        colnum++;
                    }
                }
                else
                {
                    if (!rows.ContainsKey(index))
                    {
                        for (int j = 0; j < n - colnum; j++)
                        {
                            ans += val;
                        }
                        rows.Add(index, 1);
                        rownum++;
                    }
                }
            }
            return ans;
        }
        //Title: 1282. Group the People Given the Group Size They Belong To
        //Link: https://leetcode.com/problems/group-the-people-given-the-group-size-they-belong-to
        //Tags: Array, Hash Table
        public static IList<IList<int>> GroupThePeople(int[] groupSizes)
        {
            Dictionary<int, List<int>> a = new Dictionary<int, List<int>>();
            List<IList<int>> b = new List<IList<int>>();
            for (int i = 0; i < groupSizes.Length; i++)
            {
                if (!a.ContainsKey(groupSizes[i]))
                {
                    a.Add(groupSizes[i], new List<int> { i });
                }
                else
                {
                    a[groupSizes[i]].Add(i);
                }
            }
            foreach (KeyValuePair<int, List<int>> i in a)
            {
                int counter = 0;
                int mult = i.Value.Count / i.Key;
                for (int j = 0; j < mult; j++)
                {
                    List<int> c = new List<int>();
                    for (int d = 0; d < i.Key; d++)
                    {
                        c.Add(a[i.Key][counter]);
                        counter++;
                    }
                    b.Add(c);
                }
            }
            return b;
        }
        //Title: 1630. Arithmetic Subarrays
        //Link: https://leetcode.com/problems/arithmetic-subarrays
        //Tags: Array, Hash Table, Sorting
        public static IList<bool> CheckArithmeticSubarrays(int[] nums, int[] l, int[] r)
        {
            List<bool> a = new List<bool>();
            for (int i = 0; i < l.Length; i++)
            {
                bool ans = true;
                List<int> diff = new List<int>();
                for (int j = l[i]; j <= r[i]; j++)
                {
                    diff.Add(nums[j]);
                }
                diff.Sort();
                List<int> vals = new List<int>();
                int start = diff[0];
                for (int j = 1; j < diff.Count; j++)
                {
                    int end = diff[j];
                    int minus = start - end;
                    if (!vals.Contains(minus))
                    {
                        vals.Add(minus);
                    }
                    start = end;
                }
                if (vals.Count > 1)
                {
                    ans = false;
                }
                a.Add(ans);
            }
            return a;
        }
        //Title: 1347. Minimum Number of Steps to Make Two Strings Anagram
        //Link: https://leetcode.com/problems/minimum-number-of-steps-to-make-two-strings-anagram
        //Tags: Hash Table, String, Counting
        public static int MinSteps(string s, string t)
        {
            Dictionary<char, int> a = new Dictionary<char, int>();
            int counter = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (!a.ContainsKey(s[i]))
                {
                    a.Add(s[i], 1);
                }
                else
                {
                    a[s[i]]++;
                }
            }
            for (int i = 0; i < t.Length; i++)
            {
                if (a.ContainsKey(t[i]))
                {
                    counter++;
                    a[t[i]]--;
                    if (a[t[i]] == 0)
                    {
                        a.Remove(t[i]);
                    }
                }
            }
            return s.Length - counter;
        }
        #endregion
    }
}