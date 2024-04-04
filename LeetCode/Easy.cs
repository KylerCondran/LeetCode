using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Numerics;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LeetCode
{
    public class Easy
    {
        #region "Easy"
        //Title: 1002. Find Common Characters
        //Link: https://leetcode.com/problems/find-common-characters
        //Tags: Array, Hash Table, String
        public static IList<string> CommonChars(string[] words)
        {
            List<Dictionary<char, int>> a = new List<Dictionary<char, int>>();
            List<char> everyletter = new List<char>();
            List<char> letterineach = new List<char>();
            List<string> ans = new List<string>();
            foreach (string word in words)
            {
                Dictionary<char, int> b = new Dictionary<char, int>();
                for (int i = 0; i < word.Length; i++)
                {
                    if (!everyletter.Contains(word[i]))
                    {
                        everyletter.Add(word[i]);
                    }
                    if (!b.ContainsKey(word[i]))
                    {
                        b.Add(word[i], 1);
                    }
                    else
                    {
                        b[word[i]]++;
                    }
                }
                a.Add(b);
            }
            foreach (char r in everyletter)
            {
                int count = 0;
                foreach (Dictionary<char, int> d in a)
                {
                    if (d.ContainsKey(r))
                    {
                        count++;
                    }
                }
                if (count == words.Length)
                {
                    letterineach.Add(r);
                }
            }
            foreach (char r in letterineach)
            {
                int mincount = Int32.MaxValue;
                foreach (Dictionary<char, int> d in a)
                {
                    if (d[r] < mincount)
                    {
                        mincount = d[r];
                    }
                }
                for (int i = 0; i < mincount; i++)
                {
                    ans.Add(r + "");
                }
            }
            return ans;
        }
        //Title: 929. Unique Email Addresses
        //Link: https://leetcode.com/problems/unique-email-addresses
        //Tags: Array, Hash Table, String
        public static int NumUniqueEmails(string[] emails)
        {
            List<string> valid = new List<string>();
            int counter = 0;
            foreach (string email in emails)
            {
                string[] esplit = email.Split('@');
                string local = esplit[0];
                string domain = esplit[1];
                local = local.Replace(".", "");
                string filteredlocal = "";
                for (int i = 0; i < local.Length; i++)
                {
                    if (local[i] == '+')
                    {
                        break;
                    }
                    else
                    {
                        filteredlocal += local[i];
                    }
                }
                if (domain.Substring(domain.Length - 4, 4) != ".com")
                {
                    break;
                }
                if (!valid.Contains(filteredlocal + "@" + domain))
                {
                    valid.Add(filteredlocal + "@" + domain);
                    counter++;
                }
            }
            return counter;
        }
        //Title: 917. Reverse Only Letters
        //Link: https://leetcode.com/problems/reverse-only-letters
        //Tags: Two Pointers, String
        public static string ReverseOnlyLetters(string s)
        {
            string p = "";
            string w = "";
            string final = "";
            int index = 0;
            char[] v = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
            for (int i = 0; i < s.Length; i++)
            {
                if (v.Contains(s[i]))
                {
                    p += '™';
                    w += s[i];
                }
                else
                {
                    p += s[i];
                }
            }
            char[] a = w.ToCharArray();
            Array.Reverse(a);
            string wb = new String(a);
            for (int i = 0; i < s.Length; i++)
            {
                if (p[i] == '™')
                {
                    final += wb[index];
                    index++;
                }
                else
                {
                    final += p[i];
                }
            }
            return final;
        }
        //Title: 884. Uncommon Words from Two Sentences
        //Link: https://leetcode.com/problems/uncommon-words-from-two-sentences
        //Tags: Hash Table, String
        public static string[] UncommonFromSentences(string s1, string s2)
        {
            Dictionary<string, int> a = new Dictionary<string, int>();
            Dictionary<string, int> b = new Dictionary<string, int>();
            List<string> final = new List<string>();
            string[] sone = s1.Split(' ');
            string[] stwo = s2.Split(' ');
            foreach (string word in sone)
            {
                if (!a.ContainsKey(word))
                {
                    a.Add(word, 1);
                }
                else
                {
                    a[word]++;
                }
            }
            foreach (string word in stwo)
            {
                if (!b.ContainsKey(word))
                {
                    b.Add(word, 1);
                }
                else
                {
                    b[word]++;
                }
            }
            foreach (KeyValuePair<string, int> e in a)
            {
                if (e.Value == 1 && !b.ContainsKey(e.Key))
                {
                    final.Add(e.Key);
                }
            }
            foreach (KeyValuePair<string, int> e in b)
            {
                if (e.Value == 1 && !a.ContainsKey(e.Key))
                {
                    final.Add(e.Key);
                }
            }
            int index = 0;
            string[] ans = new string[final.Count];
            foreach (string q in final)
            {
                ans[index] = q;
                index++;
            }
            return ans;
        }
        //Title: 796. Rotate String
        //Link: https://leetcode.com/problems/rotate-string
        //Tags: String, String Matching
        public static bool RotateString(string s, string goal)
        {
            for (int i = 0; i < s.Length; i++)
            {
                if (s == goal)
                {
                    return true;
                }
                s = s + s[0];
                s = s.Remove(0, 1);
            }
            return false;
        }
        //Title: 345. Reverse Vowels of a String
        //Link: https://leetcode.com/problems/reverse-vowels-of-a-string
        //Tags: Two Pointers, String
        public static string ReverseVowels(string s)
        {
            string p = "";
            string w = "";
            string final = "";
            int index = 0;
            char[] v = new char[] { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };
            for (int i = 0; i < s.Length; i++)
            {
                if (v.Contains(s[i]))
                {
                    p += '™';
                    w += s[i];
                }
                else
                {
                    p += s[i];
                }
            }
            char[] a = w.ToCharArray();
            Array.Reverse(a);
            string wb = new String(a);
            for (int i = 0; i < s.Length; i++)
            {
                if (p[i] == '™')
                {
                    final += wb[index];
                    index++;
                }
                else
                {
                    final += p[i];
                }
            }
            return final;
        }
        //Title: 824. Goat Latin
        //Link: https://leetcode.com/problems/goat-latin
        //Tags: String
        public static string ToGoatLatin(string sentence)
        {
            string[] a = sentence.Split(' ');
            char[] v = new char[] { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };
            string final = "";
            int counter = 1;
            foreach (string word in a)
            {
                if (v.Contains(word[0]))
                {
                    final += word + "ma";
                }
                else
                {
                    char x = word[0];
                    string temp = word;
                    temp = temp.Remove(0, 1);
                    temp = temp + x;
                    final += temp + "ma";
                }
                for (int i = 0; i < counter; i++)
                {
                    final += 'a';
                }
                final += ' ';
                counter++;
            }
            final = final.TrimEnd();
            return final;
        }
        //Title: 819. Most Common Word
        //Link: https://leetcode.com/problems/most-common-word
        //Tags: Array, Hash Table, String, Counting
        public static string MostCommonWord(string paragraph, string[] banned)
        {
            Dictionary<string, int> c = new Dictionary<string, int>();
            paragraph = paragraph.ToLower();
            char[] s = new char[] { '!', '?', '\'', ',', ';', '.', '"' };
            foreach (char b in s)
            {
                if (b == ',')
                {
                    paragraph = paragraph.Replace(b + "", " ");
                }
                else
                {
                    paragraph = paragraph.Replace(b + "", string.Empty);
                }
            }
            string[] a = paragraph.Split(' ');
            foreach (string word in a)
            {
                if (!c.ContainsKey(word))
                {
                    c.Add(word, 1);
                }
                else
                {
                    c[word]++;
                }
            }
            var sortedDict = from entry in c orderby entry.Value descending select entry;
            foreach (KeyValuePair<string, int> d in sortedDict)
            {
                if (!banned.Contains(d.Key) && !(d.Key == ""))
                {
                    return d.Key;
                }
            }
            return "";
        }
        //Title: 35. Search Insert Position
        //Link: https://leetcode.com/problems/search-insert-position
        //Tags: Array, Binary Search
        public static int SearchInsert(int[] nums, int target)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == target)
                {
                    return i;
                }
                else if (nums[i] > target)
                {
                    return i;
                }
            }
            return nums.Length;
        }
        //Title: 482. License Key Formatting
        //Link: https://leetcode.com/problems/license-key-formatting
        //Tags: String
        public static string LicenseKeyFormatting(string s, int k)
        {
            s = s.ToUpper();
            s = s.Replace("-", "");
            if (s == "")
            {
                return "";
            }
            string final = "";
            int counter = 0;
            for (int i = s.Length - 1; i >= 0; i--)
            {
                final += s[i];
                counter++;
                if (counter == k)
                {
                    final += "-";
                    counter = 0;
                }
            }
            char[] a = final.ToCharArray();
            Array.Reverse(a);
            string ans = new String(a);
            if (ans[0] == '-')
            {
                ans = ans.Remove(0, 1);
            }
            return ans;
        }
        //Title: 13. Roman to Integer
        //Link: https://leetcode.com/problems/roman-to-integer
        //Tags: Hash Table, Math, String
        public static int RomanToInt(string s)
        {
            int sum = 0;
            while (s.Length > 0)
            {
                switch (s[0])
                {
                    case 'M':
                        sum += 1000;
                        s = s.Remove(0, 1);
                        break;
                    case 'C':
                        if (s.Length > 1)
                        {
                            if (s[1] == 'M')
                            {
                                sum += 900;
                                s = s.Remove(0, 2);
                            }
                            else if (s[1] == 'D')
                            {
                                sum += 400;
                                s = s.Remove(0, 2);
                            }
                            else
                            {
                                sum += 100;
                                s = s.Remove(0, 1);
                            }
                        }
                        else
                        {
                            sum += 100;
                            s = s.Remove(0, 1);
                        }
                        break;
                    case 'X':
                        if (s.Length > 1)
                        {
                            if (s[1] == 'C')
                            {
                                sum += 90;
                                s = s.Remove(0, 2);
                            }
                            else if (s[1] == 'L')
                            {
                                sum += 40;
                                s = s.Remove(0, 2);
                            }
                            else
                            {
                                sum += 10;
                                s = s.Remove(0, 1);
                            }
                        }
                        else
                        {
                            sum += 10;
                            s = s.Remove(0, 1);
                        }

                        break;
                    case 'I':
                        if (s.Length > 1)
                        {
                            if (s[1] == 'X')
                            {
                                sum += 9;
                                s = s.Remove(0, 2);
                            }
                            else if (s[1] == 'V')
                            {
                                sum += 4;
                                s = s.Remove(0, 2);
                            }
                            else
                            {
                                sum += 1;
                                s = s.Remove(0, 1);
                            }
                        }
                        else
                        {
                            sum += 1;
                            s = s.Remove(0, 1);
                        }
                        break;
                    case 'V':
                        sum += 5;
                        s = s.Remove(0, 1);
                        break;
                    case 'D':
                        sum += 500;
                        s = s.Remove(0, 1);
                        break;
                    case 'L':
                        sum += 50;
                        s = s.Remove(0, 1);
                        break;
                }
            }
            return sum;
        }
        //Title: 349. Intersection of Two Arrays
        //Link: https://leetcode.com/problems/intersection-of-two-arrays
        //Tags: Array, Hash Table, Two Pointers, Binary Search, Sorting
        public static int[] Intersection(int[] nums1, int[] nums2)
        {
            List<int> a = new List<int>();
            List<int> b = new List<int>();
            for (int i = 0; i < nums1.Length; i++)
            {
                if (!(a.Contains(nums1[i])))
                {
                    a.Add(nums1[i]);
                }
            }
            for (int i = 0; i < nums2.Length; i++)
            {
                if (a.Contains(nums2[i]))
                {
                    if (!(b.Contains(nums2[i])))
                    {
                        b.Add(nums2[i]);
                    }
                }
            }
            int[] final = new int[b.Count];
            int index = 0;
            foreach (int c in b)
            {
                final[index] = c;
                index++;
            }
            return final;
        }
        //Title: 2798. Number of Employees Who Met the Target
        //Link: https://leetcode.com/problems/number-of-employees-who-met-the-target
        //Tags: Array
        public static int NumberOfEmployeesWhoMetTarget(int[] hours, int target)
        {
            int total = 0;
            for (int i = 0; i < hours.Length; i++)
            {
                if (hours[i] >= target)
                {
                    total++;
                }
            }
            return total;
        }
        public static int[] NumberOfLines(int[] widths, string s)
        {
            int lines = 1;
            int lastline = 0;
            for (int i = 0; i < s.Length; i++)
            {
                lastline += widths[i];
                if (lastline >= 100)
                {
                    lines++;
                    lastline = lastline - 100;
                }
            }
            int[] a = new int[2];
            a[0] = lines;
            a[1] = lastline;
            return a;
        }
        //Title: 191. Number of 1 Bits
        //Link: https://leetcode.com/problems/number-of-1-bits
        //Tags: Divide and Conquer, Bit Manipulation
        public static int HammingWeight(uint n)
        {
            string final = Convert.ToString(n, 2);
            final = final.Replace("0", "");
            return final.Length;
        }
        //Title: 1929. Concatenation of Array
        //Link: https://leetcode.com/problems/concatenation-of-array
        //Tags: Array, Simulation
        public static int[] GetConcatenation(int[] nums)
        {
            int[] a = new int[nums.Length * 2];
            int c = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                a[c] = nums[i];
                c++;
            }
            for (int i = 0; i < nums.Length; i++)
            {
                a[c] = nums[i];
                c++;
            }
            return a;
        }
        //Title: 2022. Convert 1D Array Into 2D Array
        //Link: https://leetcode.com/problems/convert-1d-array-into-2d-array
        //Tags: Array, Matrix, Simulation
        public static int[][] Construct2DArray(int[] original, int m, int n)
        {
            if (m * n != original.Length)
            {
                return new int[0][];
            }
            int[][] a = new int[m][];
            int counter = 0;
            for (int i = 0; i < m; i++)
            {
                List<int> b = new List<int>();
                for (int t = 0; t < n; t++)
                {
                    b.Add(original[counter]);
                    counter++;
                }
                a[i] = new int[b.Count];
                int index = 0;
                foreach (int g in b)
                {
                    a[i][index] = g;
                    index++;
                }
            }
            return a;
        }
        //Title: 2540. Minimum Common Value
        //Link: https://leetcode.com/problems/minimum-common-value
        //Tags: Array, Hash Table, Two Pointers, Binary Search
        public static int GetCommon(int[] nums1, int[] nums2)
        {
            List<int> a = new List<int>();
            for (int i = 0; i < nums1.Length; i++)
            {
                if (!(a.Contains(nums1[i])))
                {
                    a.Add(nums1[i]);
                }
            }
            int lowest = -1;
            for (int i = 0; i < nums2.Length; i++)
            {
                if (a.Contains(nums2[i]))
                {
                    if (lowest == -1)
                    {
                        lowest = nums2[i];
                    }
                    else if (nums2[i] < lowest)
                    {
                        lowest = nums2[i];
                    }
                }
            }
            return lowest;
        }
        //Title: 2042. Check if Numbers Are Ascending in a Sentence
        //Link: https://leetcode.com/problems/check-if-numbers-are-ascending-in-a-sentence
        //Tags: String
        public static bool AreNumbersAscending(string s)
        {
            string[] words = s.Split(' ');
            List<int> a = new List<int>();
            foreach (string word in words)
            {
                for (int i = 0; i < word.Length; i++)
                {
                    if (char.IsDigit(word[i]))
                    {
                        a.Add(Convert.ToInt32(word));
                        break;
                    }
                }
            }
            int index = 0;
            foreach (int b in a)
            {
                if (b > index)
                {
                    index = b;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
        //Title: 2215. Find the Difference of Two Arrays
        //Link: https://leetcode.com/problems/find-the-difference-of-two-arrays
        //Tags: Array, Hash Table
        public static IList<IList<int>> FindDifference(int[] nums1, int[] nums2)
        {
            List<IList<int>> a = new List<IList<int>>();
            List<int> b = new List<int>();
            List<int> c = new List<int>();
            List<int> d = new List<int>();
            List<int> e = new List<int>();

            for (int i = 0; i < nums1.Length; i++)
            {
                if (!(b.Contains(nums1[i])))
                {
                    b.Add(nums1[i]);
                }
            }
            for (int g = 0; g < nums2.Length; g++)
            {
                if (!(c.Contains(nums2[g])))
                {
                    c.Add(nums2[g]);
                }
            }

            foreach (int j in b)
            {
                if (!(c.Contains(j)))
                {
                    d.Add(j);
                }
            }

            foreach (int k in c)
            {
                if (!(b.Contains(k)))
                {
                    e.Add(k);
                }
            }

            a.Add(d);
            a.Add(e);
            return a;
        }
        //Title: 1979. Find Greatest Common Divisor of Array
        //Link: https://leetcode.com/problems/find-greatest-common-divisor-of-array
        //Tags: Array, Math, Number Theory
        public static int FindGCD(int[] nums)
        {
            int min = nums.Min();
            int max = nums.Max();
            int a = 0;
            for (int i = 1; i <= max; i++)
            {
                if (min % i == 0 && max % i == 0)
                {
                    a = i;
                }
            }
            return a;
        }
        //Title: 1486. XOR Operation in an Array
        //Link: https://leetcode.com/problems/xor-operation-in-an-array
        //Tags: Math, Bit Manipulation
        public static int XorOperation(int n, int start)
        {
            int[] a = new int[n];
            int sum = start;
            a[0] = start;
            for (int i = 1; i < n; i++)
            {
                a[i] = start + 2 * i;
            }
            for (int i = 1; i < n; i++)
            {
                sum ^= a[i];
            }
            return sum;
        }
        //Title: 2574. Left and Right Sum Differences
        //Link: https://leetcode.com/problems/left-and-right-sum-differences
        //Tags: Array, Prefix Sum
        public static int[] LeftRightDifference(int[] nums)
        {
            int[] L = new int[nums.Length];
            int[] R = new int[nums.Length];
            int[] a = new int[nums.Length];
            L[0] = 0;
            for (int i = 1; i < nums.Length; i++)
            {
                L[i] = L[i - 1] + nums[i - 1];
            }
            R[R.Length - 1] = 0;
            for (int i = nums.Length - 1; i > 0; i--)
            {
                R[i - 1] = R[i] + nums[i];
            }
            for (int i = 0; i < nums.Length; i++)
            {
                a[i] = Math.Abs(L[i] - R[i]);
            }
            return a;
        }
        //Title: 1720. Decode XORed Array
        //Link: https://leetcode.com/problems/decode-xored-array
        //Tags: Array, Bit Manipulation
        public static int[] Decode(int[] encoded, int first)
        {
            int[] a = new int[encoded.Length + 1];
            int counter = 0;
            a[0] = first;
            for (int i = 1; i < a.Length; i++)
            {
                a[i] = a[i - 1] ^ encoded[counter];
                counter++;
            }
            return a;
        }
        //Title: 121. Best Time to Buy and Sell Stock
        //Link: https://leetcode.com/problems/best-time-to-buy-and-sell-stock
        //Tags: Array, Dynamic Programming
        public static int MaxProfit(int[] prices)
        {
            int profit = 0;
            int minimum = 2147483647;
            for (int i = 0; i < prices.Length; i++)
            {
                minimum = Math.Min(minimum, prices[i]);
                profit = Math.Max(profit, prices[i] - minimum);
            }
            return profit;
        }
        //Title: 290. Word Pattern
        //Link: https://leetcode.com/problems/word-pattern
        //Tags: Hash Table, String
        public static bool WordPattern(string pattern, string s)
        {
            string[] words = s.Split(' ');
            Dictionary<char, string> a = new Dictionary<char, string>();
            if (pattern.Length != words.Length)
            {
                return false;
            }
            for (int i = 0; i < pattern.Length; i++)
            {
                if (!(a.ContainsKey(pattern[i])))
                {
                    if (!(a.ContainsValue(words[i])))
                    {
                        a.Add(pattern[i], words[i]);
                    }
                }
            }
            string test = "";
            for (int i = 0; i < pattern.Length; i++)
            {
                if (a.ContainsKey(pattern[i]))
                {
                    test = test + a[pattern[i]] + ' ';
                }
                else
                {
                    return false;
                }
            }
            test = test.TrimEnd();
            if (test == s)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //Title: 461. Hamming Distance
        //Link: https://leetcode.com/problems/hamming-distance
        //Tags: Bit Manipulation
        public static int HammingDistance(int x, int y)
        {
            string a = Convert.ToString(x, 2).PadLeft(90, '0');
            string b = Convert.ToString(y, 2).PadLeft(90, '0');
            int counter = 0;
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] != b[i])
                {
                    counter++;
                }
            }
            return counter;
        }
        //Title: 2283. Check if Number Has Equal Digit Count and Digit Value
        //Link: https://leetcode.com/problems/check-if-number-has-equal-digit-count-and-digit-value
        //Tags: Hash Table, String, Counting
        public static bool DigitCount(string num)
        {
            Dictionary<char, int> a = new Dictionary<char, int>();
            bool final = true;
            for (int i = 0; i < num.Length; i++)
            {
                if (!(a.ContainsKey(num[i])))
                {
                    a.Add(num[i], 1);
                }
                else
                {
                    a[num[i]]++;
                }
            }
            for (int i = 0; i < num.Length; i++)
            {
                if (!(a.ContainsKey(Convert.ToChar(i.ToString()))))
                {
                    if (!(Convert.ToInt32(num[i] + "") == 0))
                    {
                        return false;
                    }
                }
                else if (!(a[Convert.ToChar(i.ToString())] == Convert.ToInt32(num[i] + "")))
                {
                    return false;
                }
            }
            return final;
        }
        //Title: 27. Remove Element
        //Link: https://leetcode.com/problems/remove-element
        //Tags: Array, Two Pointers
        public static int RemoveElement(int[] nums, int val)
        {
            int bad = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == val)
                {
                    while (nums[i] == val)
                    {
                        bad++;
                        for (int index = i; index + 1 < nums.Length; index++)
                        {
                            nums[index] = nums[index + 1];
                        }
                        nums[nums.Length - 1] = -1;
                    }
                }
            }
            return nums.Length - bad;
        }
        //Title: 2194. Cells in a Range on an Excel Sheet
        //Link: https://leetcode.com/problems/cells-in-a-range-on-an-excel-sheet
        //Tags: String
        public static IList<string> CellsInRange(string s)
        {
            char a = s[0];
            char b = s[3];
            int c = 0;
            int d = 0;
            int.TryParse(s[1] + "", out c);
            int.TryParse(s[4] + "", out d);
            List<string> final = new List<string>();
            for (char i = a; i <= b; i++)
            {
                for (int t = c; t <= d; t++)
                {
                    final.Add(i.ToString() + t.ToString());
                }
            }
            return final;
        }
        //Title: 2085. Count Common Words With One Occurrence
        //Link: https://leetcode.com/problems/count-common-words-with-one-occurrence
        //Tags: Array, Hash Table, String, Counting
        public static int CountWords(string[] words1, string[] words2)
        {
            Dictionary<string, int> a = new Dictionary<string, int>();
            Dictionary<string, int> b = new Dictionary<string, int>();
            int counter = 0;
            for (int i = 0; i < words1.Length; i++)
            {
                if (!(a.ContainsKey(words1[i])))
                {
                    a.Add(words1[i], 1);
                }
                else
                {
                    a[words1[i]]++;
                }
            }
            for (int i = 0; i < words2.Length; i++)
            {
                if (!(b.ContainsKey(words2[i])))
                {
                    b.Add(words2[i], 1);
                }
                else
                {
                    b[words2[i]]++;
                }
            }
            List<string> e = new List<string>();
            List<string> f = new List<string>();
            foreach (KeyValuePair<string, int> c in a)
            {
                if (c.Value == 1)
                {
                    e.Add(c.Key);
                }
            }
            foreach (KeyValuePair<string, int> d in b)
            {
                if (d.Value == 1)
                {
                    f.Add(d.Key);
                }
            }
            foreach (string g in f)
            {
                if (e.Contains(g))
                {
                    counter++;
                }
            }
            return counter;
        }
        //Title: 258. Add Digits
        //Link: https://leetcode.com/problems/add-digits
        //Tags: Math, Simulation, Number Theory
        public static int AddDigits(int num)
        {
            string digits = num.ToString();
            while (digits.Length > 1)
            {
                int sum = 0;
                for (int t = 0; t < digits.Length; t++)
                {
                    int digit = 0;
                    int.TryParse(digits[t] + "", out digit);
                    sum += digit;
                }
                digits = sum.ToString();
            }
            int final = 0;
            int.TryParse(digits, out final);
            num = final;
            return num;
        }
        //Title: 2180. Count Integers With Even Digit Sum
        //Link: https://leetcode.com/problems/count-integers-with-even-digit-sum
        //Tags: Math, Simulation
        public static int CountEven(int num)
        {
            int counter = 0;
            for (int i = 1; i <= num; i++)
            {
                string digits = i.ToString();
                int sum = 0;
                for (int t = 0; t < digits.Length; t++)
                {
                    int digit = 0;
                    int.TryParse(digits[t] + "", out digit);
                    sum += digit;
                }
                if (sum % 2 == 0)
                {
                    counter++;
                }
            }
            return counter;
        }
        //Title: 693. Binary Number with Alternating Bits
        //Link: https://leetcode.com/problems/binary-number-with-alternating-bits
        //Tags: Bit Manipulation
        public static bool HasAlternatingBits(int n)
        {
            string a = Convert.ToString(n, 2);
            bool even = false;
            bool odd = false;
            if (a[0] == '1')
            {
                odd = true;
                even = false;
            }
            else
            {
                even = true;
                odd = false;
            }
            for (int i = 1; i < a.Length; i++)
            {
                if (odd)
                {
                    if (a[i] == '1')
                    {
                        return false;
                    }
                    else
                    {
                        even = true;
                        odd = false;
                    }
                }
                else
                {
                    if (a[i] == '0')
                    {
                        return false;
                    }
                    else
                    {
                        even = false;
                        odd = true;
                    }
                }
            }
            return true;
        }
        //Title: 1672. Richest Customer Wealth
        //Link: https://leetcode.com/problems/richest-customer-wealth
        //Tags: Array, Matrix
        public static int MaximumWealth(int[][] accounts)
        {
            int max = 0;
            foreach (int[] array in accounts)
            {
                int total = 0;
                foreach (int i in array)
                {
                    total += i;
                    if (total > max)
                    {
                        max = total;
                    }
                }
            }
            return max;
        }
        //Title: 2529. Maximum Count of Positive Integer and Negative Integer
        //Link: https://leetcode.com/problems/maximum-count-of-positive-integer-and-negative-integer
        //Tags: Array, Binary Search, Counting
        public static int MaximumCount(int[] nums)
        {
            int p = 0;
            int n = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] > 0)
                {
                    p++;
                }
                else if (nums[i] < 0)
                {
                    n++;
                }
            }
            if (p >= n)
            {
                return p;
            }
            else if (p <= n)
            {
                return n;
            }
            return -1;
        }
        //Title: 2011. Final Value of Variable After Performing Operations
        //Link: https://leetcode.com/problems/final-value-of-variable-after-performing-operations
        //Tags: Array, String, Simulation
        public static int FinalValueAfterOperations(string[] operations)
        {
            int r = 0;
            for (int i = 0; i < operations.Length; i++)
            {
                if (operations[i] == "++X" || operations[i] == "X++")
                {
                    r++;
                }
                else
                {
                    r--;
                }
            }
            return r;
        }
        //Title: 2154. Keep Multiplying Found Values by Two
        //Link: https://leetcode.com/problems/keep-multiplying-found-values-by-two
        //Tags: Array, Hash Table, Sorting, Simulation
        public static int FindFinalValue(int[] nums, int original)
        {
            bool found = true;
            int target = original;
            while (found)
            {
                found = false;
                for (int i = 0; i < nums.Length; i++)
                {
                    if (nums[i] == target)
                    {
                        target = target * 2;
                        found = true;
                    }
                }
            }
            return target;
        }
        //Title: 1732. Find the Highest Altitude
        //Link: https://leetcode.com/problems/find-the-highest-altitude
        //Tags: Array, Prefix Sum
        public static int LargestAltitude(int[] gain)
        {
            int most = 0;
            int alt = 0;
            for (int i = 0; i < gain.Length; i++)
            {
                alt += gain[i];
                if (alt > most)
                {
                    most = alt;
                }
            }
            return most;
        }
        //Title: 3005. Count Elements With Maximum Frequency
        //Link: https://leetcode.com/problems/count-elements-with-maximum-frequency
        //Tags: Array, Hash Table, Counting
        public static int MaxFrequencyElements(int[] nums)
        {
            int largest = 0;
            int counter = 0;
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
                if (b.Value > largest)
                {
                    largest = b.Value;
                }
            }
            foreach (KeyValuePair<int, int> d in a)
            {
                if (d.Value == largest)
                {
                    counter += d.Value;
                }
            }
            return counter;
        }
        //Title: 1678. Goal Parser Interpretation
        //Link: https://leetcode.com/problems/goal-parser-interpretation
        //Tags: String
        public static string Interpret(string command)
        {
            command = command.Replace("()", "o");
            command = command.Replace("(al)", "al");
            return command;
        }
        //Title: 2057. Smallest Index With Equal Value
        //Link: https://leetcode.com/problems/smallest-index-with-equal-value
        //Tags: Array
        public static int SmallestEqual(int[] nums)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                if (i % 10 == nums[i])
                {
                    return i;
                }
            }
            return -1;
        }
        //Title: 977. Squares of a Sorted Array
        //Link: https://leetcode.com/problems/squares-of-a-sorted-array
        //Tags: Array, Two Pointers, Sorting
        public static int[] SortedSquares(int[] nums)
        {
            List<int> a = new List<int>();
            int[] b = new int[nums.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                int ans = (int)Math.Pow(nums[i], 2);
                a.Add(ans);
            }
            a.Sort();
            int counter = 0;
            foreach (int c in a)
            {
                b[counter] = c;
                counter++;
            }
            return b;
        }
        //Title: 2570. Merge Two 2D Arrays by Summing Values
        //Link: https://leetcode.com/problems/merge-two-2d-arrays-by-summing-values
        //Tags: Array, Hash Table, Two Pointers
        public static int[][] MergeArrays(int[][] nums1, int[][] nums2)
        {
            SortedDictionary<int, int> a = new SortedDictionary<int, int>();
            foreach (int[] b in nums1)
            {
                int id = b[0];
                int digit = b[1];
                a.Add(id, digit);
            }
            foreach (int[] c in nums2)
            {
                int id = c[0];
                int digit = c[1];
                if (!(a.ContainsKey(id)))
                {
                    a.Add(id, digit);
                }
                else
                {
                    a[id] += digit;
                }
            }
            int[][] ans = new int[a.Count][];
            int counter = 0;
            foreach (KeyValuePair<int, int> e in a)
            {
                ans[counter] = new int[] { e.Key, e.Value };
                counter++;
            }
            return ans;
        }
        //Title: 2108. Find First Palindromic String in the Array
        //Link: https://leetcode.com/problems/find-first-palindromic-string-in-the-array
        //Tags: Array, Two Pointers, String
        public static string FirstPalindrome(string[] words)
        {
            for (int i = 0; i < words.Length; i++)
            {
                string final = "";
                final = words[i];
                char[] charArray = words[i].ToCharArray();
                Array.Reverse(charArray);
                string backwards = new string(charArray);
                if (backwards == final)
                {
                    return words[i];
                }
            }
            return "";
        }
        //Title: 2206. Divide Array Into Equal Pairs
        //Link: https://leetcode.com/problems/divide-array-into-equal-pairs
        //Tags: Array, Hash Table, Bit Manipulation, Counting
        public static bool DivideArray(int[] nums)
        {
            Array.Sort(nums);
            int pairs = nums.Length / 2;
            bool equalpair = true;
            int step = 0;
            for (int i = 0; i < pairs; i++)
            {
                if (!(nums[step] == nums[step + 1]))
                {
                    equalpair = false;
                }
                step += 2;
            }
            if (equalpair)
            {
                return true;
            }
            return false;
        }
        //Title: 1880. Check if Word Equals Summation of Two Words
        //Link: https://leetcode.com/problems/check-if-word-equals-summation-of-two-words
        //Tags: String
        public static bool IsSumEqual(string firstWord, string secondWord, string targetWord)
        {
            Dictionary<char, string> a = new Dictionary<char, string>();
            int counter = 0;
            for (char i = 'a'; i <= 'z'; i++)
            {
                a.Add(i, counter.ToString());
                counter++;
            }
            string first = "";
            for (int i = 0; i < firstWord.Length; i++)
            {
                first += a[firstWord[i]];
            }
            string second = "";
            for (int i = 0; i < secondWord.Length; i++)
            {
                second += a[secondWord[i]];
            }
            string target = "";
            for (int i = 0; i < targetWord.Length; i++)
            {
                target += a[targetWord[i]];
            }
            int fd = 0;
            int sd = 0;
            int td = 0;
            int.TryParse(first, out fd);
            int.TryParse(second, out sd);
            int.TryParse(target, out td);
            if (fd + sd == td)
            {
                return true;
            }
            return false;
        }
        //Title: 944. Delete Columns to Make Sorted
        //Link: https://leetcode.com/problems/delete-columns-to-make-sorted
        //Tags: Array, String
        public static int MinDeletionSize(string[] strs)
        {
            int counter = 0;
            int length = strs[0].Length;
            string[] a = new string[length];
            for (int i = 0; i < length; i++)
            {
                string final = "";
                foreach (string word in strs)
                {
                    final += word[i];
                }
                a[i] = final;
            }
            foreach (string word in a)
            {
                bool forward = true;
                char f = word[0];
                for (int i = 1; i < word.Length; i++)
                {
                    if (!(word[i] >= f))
                    {
                        forward = false;
                    }
                    f = word[i];
                }
                if (forward == false)
                {
                    counter++;
                }
            }
            return counter;
        }
        //Title: 2032. Two Out of Three
        //Link: https://leetcode.com/problems/two-out-of-three
        //Tags: Array, Hash Table, Bit Manipulation
        public static IList<int> TwoOutOfThree(int[] nums1, int[] nums2, int[] nums3)
        {
            Dictionary<int, int> a = new Dictionary<int, int>();
            for (int i = 0; i < nums1.Length; i++)
            {
                if (!(a.ContainsKey(nums1[i])))
                {
                    a.Add(nums1[i], 1);
                }
            }
            List<int> b = new List<int>();
            for (int i = 0; i < nums2.Length; i++)
            {
                if (!(b.Contains(nums2[i])))
                {
                    b.Add(nums2[i]);
                }
            }
            foreach (int i in b)
            {
                if (!(a.ContainsKey(i)))
                {
                    a.Add(i, 1);
                }
                else if (a[i] == 1)
                {
                    a[i]++;
                }
            }
            List<int> c = new List<int>();
            for (int i = 0; i < nums3.Length; i++)
            {
                if (!(c.Contains(nums3[i])))
                {
                    c.Add(nums3[i]);
                }
            }
            foreach (int i in c)
            {
                if (!(a.ContainsKey(i)))
                {
                    a.Add(i, 1);
                }
                else if (a[i] == 2 || a[i] == 1)
                {
                    a[i]++;
                }
            }
            List<int> d = new List<int>();
            foreach (KeyValuePair<int, int> e in a)
            {
                if (e.Value > 1)
                {
                    d.Add(e.Key);
                }
            }
            return d;
        }
        //Title: 1304. Find N Unique Integers Sum up to Zero
        //Link: https://leetcode.com/problems/find-n-unique-integers-sum-up-to-zero
        //Tags: Array, Math
        public static int[] SumZero(int n)
        {
            int[] a = new int[n];
            int counter = 1;
            if (n % 2 == 0)
            {
                for (int i = 0; i < n; i++)
                {
                    if (i % 2 == 0)
                    {
                        a[i] = counter;
                    }
                    else
                    {
                        a[i] = -counter;
                        counter++;
                    }
                }
            }
            else
            {
                a[0] = 0;
                for (int i = 1; i < n; i++)
                {
                    if (i % 2 == 0)
                    {
                        a[i] = counter;
                        counter++;
                    }
                    else
                    {
                        a[i] = -counter;
                    }
                }
            }
            return a;
        }
        //Title: 2733. Neither Minimum nor Maximum
        //Link: https://leetcode.com/problems/neither-minimum-nor-maximum
        //Tags: Array, Sorting
        public static int FindNonMinOrMax(int[] nums)
        {
            int max = nums.Max();
            int min = nums.Min();
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != max && nums[i] != min)
                {
                    return nums[i];
                }
            }
            return -1;
        }
        //Title: 1207. Unique Number of Occurrences
        //Link: https://leetcode.com/problems/unique-number-of-occurrences
        //Tags: Array, Hash Table
        public static bool UniqueOccurrences(int[] arr)
        {
            Dictionary<int, int> a = new Dictionary<int, int>();
            List<int> c = new List<int>();
            for (int i = 0; i < arr.Length; i++)
            {
                if (!(a.ContainsKey(arr[i])))
                {
                    a.Add(arr[i], 1);
                }
                else
                {
                    a[arr[i]]++;
                }
            }
            foreach (KeyValuePair<int, int> b in a)
            {
                if (!(c.Contains(b.Value)))
                {
                    c.Add(b.Value);
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
        //Title: 1295. Find Numbers with Even Number of Digits
        //Link: https://leetcode.com/problems/find-numbers-with-even-number-of-digits
        //Tags: Array
        public static int FindNumbers(int[] nums)
        {
            int counter = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                string digits = nums[i].ToString();
                if (digits.Length % 2 == 0)
                {
                    counter++;
                }
            }
            return counter;
        }
        //Title: 771. Jewels and Stones
        //Link: https://leetcode.com/problems/jewels-and-stones
        //Tags: Hash Table, String
        public static int NumJewelsInStones(string jewels, string stones)
        {
            List<char> a = new List<char>();
            int b = 0;
            for (int i = 0; i < jewels.Length; i++)
            {
                a.Add(jewels[i]);
            }
            for (int i = 0; i < stones.Length; i++)
            {
                if (a.Contains(stones[i]))
                {
                    b++;
                }
            }
            return b;
        }
        //Title: 1748. Sum of Unique Elements
        //Link: https://leetcode.com/problems/sum-of-unique-elements
        //Tags: Array, Hash Table, Counting
        public static int SumOfUnique(int[] nums)
        {
            Dictionary<int, int> a = new Dictionary<int, int>();
            int sum = 0;
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
                    sum += b.Key;
                }
            }
            return sum;
        }
        //Title: 728. Self Dividing Numbers
        //Link: https://leetcode.com/problems/self-dividing-numbers
        //Tags: Math
        public static IList<int> SelfDividingNumbers(int left, int right)
        {
            List<int> a = new List<int>();
            for (int i = left; i <= right; i++)
            {
                string digits = i.ToString();
                bool sdv = true;
                for (int t = 0; t < digits.Length; t++)
                {
                    int digit = 0;
                    int.TryParse(digits[t] + "", out digit);
                    if (digit == 0)
                    {
                        sdv = false;
                        break;
                    }
                    if (i % digit != 0)
                    {
                        sdv = false;
                    }
                }
                if (sdv)
                {
                    a.Add(i);
                }
            }
            return a;
        }
        //Title: 2651. Calculate Delayed Arrival Time
        //Link: https://leetcode.com/problems/calculate-delayed-arrival-time
        //Tags: Math
        public static int FindDelayedArrivalTime(int arrivalTime, int delayedTime)
        {
            int time = arrivalTime + delayedTime;
            if (time >= 24)
            {
                time = time % 24;
            }
            return time;
        }
        //Title: 2553. Separate the Digits in an Array
        //Link: https://leetcode.com/problems/separate-the-digits-in-an-array
        //Tags: Array, Simulation
        public static int[] SeparateDigits(int[] nums)
        {
            List<string> a = new List<string>();
            for (int i = 0; i < nums.Length; i++)
            {
                string digits = nums[i].ToString();
                for (int t = 0; t < digits.Length; t++)
                {
                    a.Add(digits[t] + "");
                }
            }
            int[] ans = new int[a.Count];
            int counter = 0;
            foreach (string word in a)
            {
                int digit = 0;
                int.TryParse(word, out digit);
                ans[counter] = digit;
                counter++;
            }
            return ans;
        }
        //Title: 2427. Number of Common Factors
        //Link: https://leetcode.com/problems/number-of-common-factors
        //Tags: Math, Enumeration, Number Theory
        public static int CommonFactors(int a, int b)
        {
            int counter = 0;
            List<int> fac = new List<int>();
            for (int i = 1; i <= a; i++)
            {
                if (a % i == 0)
                {
                    fac.Add(i);
                }
            }
            for (int i = 1; i <= b; i++)
            {
                if (b % i == 0)
                {
                    if (fac.Contains(i))
                    {
                        counter++;
                    }
                }
            }
            return counter;
        }
        //Title: 1614. Maximum Nesting Depth of the Parentheses
        //Link: https://leetcode.com/problems/maximum-nesting-depth-of-the-parentheses
        //Tags: String, Stack
        public static int MaxDepth(string s)
        {
            int max = 0;
            int curr = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(')
                {
                    curr++;
                    if (curr > max)
                    {
                        max = curr;
                    }
                }
                else if (s[i] == ')')
                {
                    curr--;
                }
            }
            return max;
        }
        //Title: 2656. Maximum Sum With Exactly K Elements 
        //Link: https://leetcode.com/problems/maximum-sum-with-exactly-k-elements
        //Tags: Array, Greedy
        public static int MaximizeSum(int[] nums, int k)
        {
            int largest = 0;
            int count = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] > largest)
                {
                    largest = nums[i];
                }
            }
            for (int i = 0; i < k; i++)
            {
                count += largest;
                largest = largest + 1;
            }
            return count;
        }
        //Title: 2315. Count Asterisks
        //Link: https://leetcode.com/problems/count-asterisks
        //Tags: String
        public static int CountAsterisks(string s)
        {
            int counter = 0;
            bool active = false;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '*' && active == false)
                {
                    counter++;
                }
                else if (s[i] == '|')
                {
                    if (active == false)
                    {
                        active = true;
                    }
                    else
                    {
                        active = false;
                    }
                }
            }
            return counter;
        }
        //Title: 1480. Running Sum of 1d Array
        //Link: https://leetcode.com/problems/running-sum-of-1d-array
        //Tags: Array, Prefix Sum
        public static int[] RunningSum(int[] nums)
        {
            int[] a = new int[nums.Length];
            a[0] = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                a[i] = nums[i] + a[i - 1];
            }
            return a;
        }
        //Title: 2894. Divisible and Non-divisible Sums Difference
        //Link: https://leetcode.com/problems/divisible-and-non-divisible-sums-difference
        //Tags: Math
        public static int DifferenceOfSums(int n, int m)
        {
            int a = 0;
            int b = 0;
            for (int i = 1; i <= n; i++)
            {
                if (i % m != 0)
                {
                    a += i;
                }
                else
                {
                    b += i;
                }
            }
            int final = a - b;
            return final;
        }
        //Title: 3065. Minimum Operations to Exceed Threshold Value I
        //Link: https://leetcode.com/problems/minimum-operations-to-exceed-threshold-value-i
        //Tags: Array
        public static int MinOperations(int[] nums, int k)
        {
            int counter = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] < k)
                {
                    counter++;
                }
            }
            return counter;
        }
        //Title: 2535. Difference Between Element Sum and Digit Sum of an Array
        //Link: https://leetcode.com/problems/difference-between-element-sum-and-digit-sum-of-an-array
        //Tags: Array, Math
        public static int DifferenceOfSum(int[] nums)
        {
            int esum = 0;
            int dsum = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                esum += nums[i];
                string digits = nums[i].ToString();
                for (int t = 0; t < digits.Length; t++)
                {
                    int digit = 0;
                    int.TryParse(digits[t] + "", out digit);
                    dsum += digit;
                }
            }
            return esum - dsum;
        }
        //Title: 1313. Decompress Run-Length Encoded List
        //Link: https://leetcode.com/problems/decompress-run-length-encoded-list
        //Tags: Array
        public static int[] DecompressRLElist(int[] nums)
        {
            int curr = 0;
            int freq = 0;
            List<int> a = new List<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (i % 2 == 0)
                {
                    freq = nums[i];
                }
                else
                {
                    curr = nums[i];
                    for (int t = 0; t < freq; t++)
                    {
                        a.Add(curr);
                    }
                }
            }
            int[] b = new int[a.Count];
            int counter = 0;
            foreach (int v in a)
            {
                b[counter] = v;
                counter++;
            }
            return b;
        }
        //Title: 2810. Faulty Keyboard
        //Link: https://leetcode.com/problems/faulty-keyboard
        //Tags: String, Simulation
        public static string FinalString(string s)
        {
            string final = "";
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == 'i')
                {
                    char[] charArray = final.ToCharArray();
                    Array.Reverse(charArray);
                    string backwards = new string(charArray);
                    final = backwards;
                }
                else
                {
                    final += s[i];
                }
            }
            return final;
        }
        //Title: 1221. Split a String in Balanced Strings
        //Link: https://leetcode.com/problems/split-a-string-in-balanced-strings
        //Tags: String, Greedy, Counting
        public static int BalancedStringSplit(string s)
        {
            int r = 0;
            int l = 0;
            int counter = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == 'R')
                {
                    r++;
                }
                else if (s[i] == 'L')
                {
                    l++;
                }
                if (r > 0 && l > 0 && r == l)
                {
                    counter++;
                }
            }
            return counter;
        }
        //Title: 1920. Build Array from Permutation
        //Link: https://leetcode.com/problems/build-array-from-permutation
        //Tags: Array, Simulation
        public static int[] BuildArray(int[] nums)
        {
            int[] a = new int[nums.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                a[i] = nums[nums[i]];
            }
            return a;
        }
        //Title: 1844. Replace All Digits with Characters
        //Link: https://leetcode.com/problems/replace-all-digits-with-characters
        //Tags: String
        public static string ReplaceDigits(string s)
        {
            string final = "";
            for (int i = 0; i < s.Length; i++)
            {
                if (char.IsDigit(s[i]))
                {
                    int digit = 0;
                    int.TryParse(s[i] + "", out digit);
                    final += (char)(s[i - 1] + digit);
                }
                else
                {
                    final += s[i];
                }
            }
            return final;
        }
        //Title: 1523. Count Odd Numbers in an Interval Range
        //Link: https://leetcode.com/problems/count-odd-numbers-in-an-interval-range
        //Tags: Math
        public static int CountOdds(int low, int high)
        {
            int total = 0;
            for (int i = low; i <= high; i++)
            {
                if (!(i % 2 == 0))
                {
                    total += 1;
                }
            }
            return total;
        }
        //Title: 2544. Alternating Digit Sum
        //Link: https://leetcode.com/problems/alternating-digit-sum
        //Tags: Math
        public static int AlternateDigitSum(int n)
        {
            string digits = n.ToString();
            int counter = 0;
            int sum = 0;
            for (int i = 0; i < digits.Length; i++)
            {
                int a = 0;
                int.TryParse(digits[i] + "", out a);
                if (counter % 2 == 0)
                {
                    sum += a;
                }
                else
                {
                    sum -= a;
                }
                counter++;
            }
            return sum;
        }
        //Title: 2169. Count Operations to Obtain Zero
        //Link: https://leetcode.com/problems/count-operations-to-obtain-zero
        //Tags: Math, Simulation
        public static int CountOperations(int num1, int num2)
        {
            int counter = 0;
            while (num1 != 0 && num2 != 0)
            {
                if (num1 >= num2)
                {
                    num1 = num1 - num2;
                    counter++;
                }
                else
                {
                    num2 = num2 - num1;
                    counter++;
                }
            }
            return counter;
        }
        //Title: 509. Fibonacci Number
        //Link: https://leetcode.com/problems/fibonacci-number
        //Tags: Math, Dynamic Programming, Recursion, Memoization
        public static int Fib(int n)
        {
            if (n == 0)
            {
                return 0;
            }
            else if (n == 1)
            {
                return 1;
            }
            int[] a = new int[n + 1];
            a[0] = 0;
            a[1] = 1;
            if (a.Length > 2)
            {
                for (int i = 2; i <= n; i++)
                {
                    a[i] = a[i - 1] + a[i - 2];
                }
                return a[n];
            }
            else if (a.Length == 2)
            {
                return 1;
            }
            return -1;
        }
        //Title: 338. Counting Bits
        //Link: https://leetcode.com/problems/counting-bits
        //Tags: Dynamic Programming, Bit Manipulation
        public static int[] CountBits(int n)
        {
            int[] ans = new int[n + 1];
            for (int i = 0; i <= n; i++)
            {
                string binary = Convert.ToString(i, 2);
                int counter = 0;
                for (int t = 0; t < binary.Length; t++)
                {
                    if (binary[t] == '1')
                    {
                        counter++;
                    }
                }
                ans[i] = counter;
            }
            return ans;
        }
        //Title: 1323. Maximum 69 Number
        //Link: https://leetcode.com/problems/maximum-69-number
        //Tags: Math, Greedy
        public static int Maximum69Number(int num)
        {
            string digits = num.ToString();
            string built = "";
            int counter = 0;
            for (int i = 0; i < digits.Length; i++)
            {
                if (digits[i] == '6' && counter == 0)
                {
                    built += '9';
                    counter++;
                }
                else
                {
                    built += digits[i];
                }
            }
            int final = 0;
            int.TryParse(built, out final);
            return final;
        }
        //Title: 1342. Number of Steps to Reduce a Number to Zero
        //Link: https://leetcode.com/problems/number-of-steps-to-reduce-a-number-to-zero
        //Tags: Math, Bit Manipulation
        public static int NumberOfSteps(int num)
        {
            int counter = 0;
            while (num != 0)
            {
                if (num % 2 == 0)
                {
                    num = num / 2;
                    counter++;
                }
                else
                {
                    num = num - 1;
                    counter++;
                }
            }
            return counter;
        }
        //Title: 2235. Add Two Integers
        //Link: https://leetcode.com/problems/add-two-integers
        //Tags: Math
        public static int Sum(int num1, int num2)
        {
            return num1 + num2;
        }
        //Title: 2652. Sum Multiples
        //Link: https://leetcode.com/problems/sum-multiples
        //Tags: Math
        public static int SumOfMultiples(int n)
        {
            int sum = 0;
            for (int i = 1; i <= n; i++)
            {
                if (i % 3 == 0)
                {
                    sum += i;
                }
                else if (i % 5 == 0)
                {
                    sum += i;
                }
                else if (i % 7 == 0)
                {
                    sum += i;
                }
            }
            return sum;
        }
        //Title: 1512. Number of Good Pairs
        //Link: https://leetcode.com/problems/number-of-good-pairs
        //Tags: Array, Hash Table, Math, Counting
        public static int NumIdenticalPairs(int[] nums)
        {
            int counter = 0;
            int index = 1;
            foreach (int a in nums)
            {
                for (int i = 0 + index; i < nums.Length; i++)
                {
                    if (a == nums[i])
                    {
                        counter++;
                    }
                }
                index++;
            }
            return counter;
        }
        //Title: 2496. Maximum Value of a String in an Array
        //Link: https://leetcode.com/problems/maximum-value-of-a-string-in-an-array
        //Tags: Array, String
        public static int MaximumValue(string[] strs)
        {
            int longest = 0;
            foreach (string word in strs)
            {
                bool alldigits = true;
                for (int i = 0; i < word.Length; i++)
                {
                    if (!(char.IsDigit(word[i])))
                    {
                        alldigits = false;
                    }
                }
                if (alldigits)
                {
                    int digits = 0;
                    int.TryParse(word, out digits);
                    if (digits > longest)
                    {
                        longest = digits;
                    }
                }
                else
                {
                    int length = word.Length;
                    if (length > longest)
                    {
                        longest = length;
                    }
                }
            }
            return longest;
        }
        //Title: 2053. Kth Distinct String in an Array
        //Link: https://leetcode.com/problems/kth-distinct-string-in-an-array
        //Tags: Array, Hash Table, String, Counting
        public static string KthDistinct(string[] arr, int k)
        {
            int counter = 1;
            Dictionary<string, int> a = new Dictionary<string, int>();
            for (int i = 0; i < arr.Length; i++)
            {
                if (!(a.ContainsKey(arr[i])))
                {
                    a.Add(arr[i], 1);
                }
                else
                {
                    a[arr[i]]++;
                }
            }
            foreach (KeyValuePair<string, int> b in a)
            {
                if (b.Value == 1)
                {
                    if (counter == k)
                    {
                        return b.Key;
                    }
                    else
                    {
                        counter++;
                    }
                }
            }
            return "";
        }
        //Title: 2469. Convert the Temperature
        //Link: https://leetcode.com/problems/convert-the-temperature
        //Tags: Math
        public static double[] ConvertTemperature(double celsius)
        {
            double[] a = new double[2];
            double kelvin = celsius + 273.15;
            double fahrenheit = celsius * 1.80 + 32.00;
            a[0] = kelvin;
            a[1] = fahrenheit;
            return a;
        }
        //Title: 2520. Count the Digits That Divide a Number
        //Link: https://leetcode.com/problems/count-the-digits-that-divide-a-number
        //Tags: Math
        public static int CountDigits(int num)
        {
            string digits = "";
            digits = num.ToString();
            int counter = 0;
            for (int i = 0; i < digits.Length; i++)
            {
                int temp = 0;
                int.TryParse(digits[i].ToString(), out temp);
                if (num % temp == 0)
                {
                    counter += 1;
                }
            }
            return counter;
        }
        //Title: 2586. Count the Number of Vowel Strings in Range
        //Link: https://leetcode.com/problems/count-the-number-of-vowel-strings-in-range
        //Tags: Array, String
        public static int VowelStrings(string[] words, int left, int right)
        {
            int counter = 0;
            for (int i = left; i <= right; i++)
            {
                char first = words[i][0];
                char last = words[i][words[i].Length - 1];
                bool firstie = false;
                bool secondie = false;
                if (first == 'a' || first == 'e' || first == 'i' || first == 'o' || first == 'u')
                {
                    firstie = true;
                }
                if (last == 'a' || last == 'e' || last == 'i' || last == 'o' || last == 'u')
                {
                    secondie = true;
                }
                if (firstie && secondie)
                {
                    counter++;
                }
            }
            return counter;
        }
        //Title: 3019. Number of Changing Keys
        //Link: https://leetcode.com/problems/number-of-changing-keys
        //Tags: String
        public static int CountKeyChanges(string s)
        {
            s = s.ToLower();
            char a = s[0];
            int counter = 0;
            for (int i = 1; i < s.Length; i++)
            {
                if (a != s[i])
                {
                    counter++;
                }
                a = s[i];
            }
            return counter;
        }
        //Title: 804. Unique Morse Code Words
        //Link: https://leetcode.com/problems/unique-morse-code-words
        //Tags: Array, Hash Table, String
        public static int UniqueMorseRepresentations(string[] words)
        {
            Dictionary<char, string> a = new Dictionary<char, string>();
            string[] b = new string[] { ".-", "-...", "-.-.", "-..", ".", "..-.", "--.", "....", "..", ".---", "-.-", ".-..", "--", "-.", "---", ".--.", "--.-", ".-.", "...", "-", "..-", "...-", ".--", "-..-", "-.--", "--.." };
            List<string> c = new List<string>();
            int counter = 0;
            for (char i = 'a'; i <= 'z'; i++)
            {
                a.Add(i, b[counter]);
                counter++;
            }
            foreach (string word in words)
            {
                string morse = "";
                for (int i = 0; i < word.Length; i++)
                {
                    morse += a[word[i]];
                }
                if (!(c.Contains(morse)))
                {
                    c.Add(morse);
                }
            }
            return c.Count();
        }
        //Title: 1528. Shuffle String
        //Link: https://leetcode.com/problems/shuffle-string
        //Tags: Array, String
        public static string RestoreString(string s, int[] indices)
        {
            string final = "";
            Dictionary<int, char> a = new Dictionary<int, char>();
            for (int i = 0; i < s.Length; i++)
            {
                a.Add(indices[i], s[i]);
            }
            for (int i = 0; i < s.Length; i++)
            {
                final += a[i];
            }
            return final;
        }
        //Title: 1859. Sorting the Sentence
        //Link: https://leetcode.com/problems/sorting-the-sentence
        //Tags: String, Sorting
        public static string SortSentence(string s)
        {
            string[] a = s.Split(' ');
            string final = "";
            SortedDictionary<string, string> b = new SortedDictionary<string, string>();
            for (int i = 0; i < a.Length; i++)
            {
                b.Add(a[i].Substring(a[i].Length - 1, 1), a[i].Substring(0, a[i].Length - 1));
            }
            foreach (KeyValuePair<string, string> c in b)
            {
                final += c.Value + ' ';
            }
            final = final.Substring(0, final.Length - 1);
            return final;
        }
        //Title: 1281. Subtract the Product and Sum of Digits of an Integer
        //Link: https://leetcode.com/problems/subtract-the-product-and-sum-of-digits-of-an-integer
        //Tags: Math
        public static int SubtractProductAndSum(int n)
        {
            string intstring = n.ToString();
            int product = 0;
            Int32.TryParse(intstring[0].ToString(), out product);
            int sum = 0;
            Int32.TryParse(intstring[0].ToString(), out sum);
            for (int i = 1; i < intstring.Length; i++)
            {
                int a = 0;
                Int32.TryParse(intstring[i].ToString(), out a);
                product *= a;
                sum += a;
            }
            return product - sum;
        }
        //Title: 1287. Element Appearing More Than 25% In Sorted Array
        //Link: https://leetcode.com/problems/element-appearing-more-than-25-in-sorted-array
        //Tags: Array
        public static int FindSpecialInteger(int[] arr)
        {
            Dictionary<int, int> a = new Dictionary<int, int>();
            double threshhold = arr.Length * 0.25;
            foreach (int d in arr)
            {
                if (!(a.ContainsKey(d)))
                {
                    a.Add(d, 1);
                }
                else
                {
                    a[d]++;
                }
            }
            foreach (KeyValuePair<int, int> i in a)
            {
                if (i.Value > threshhold)
                {
                    return i.Key;
                }
            }
            return 1;
        }
        //Title: 1047. Remove All Adjacent Duplicates In String
        //Link: https://leetcode.com/problems/remove-all-adjacent-duplicates-in-string
        //Tags: String, Stack
        public static string RemoveDuplicates(string s)
        {
            string final = s;
            bool foundamatch = true;
            int first = 0;
            int second = 1;
            while (foundamatch)
            {
                if (final[first] == final[second])
                {
                    final = final.Remove(first, 2);
                    first = 0;
                    second = 1;
                }
                else
                {
                    first++;
                    second++;
                }
                if (second >= final.Length)
                {
                    foundamatch = false;
                }
            }
            return final;
        }
        //Title: 1108. Defanging an IP Address
        //Link: https://leetcode.com/problems/defanging-an-ip-address
        //Tags: String
        public static string DefangIPaddr(string address)
        {
            string final = "";
            for (int i = 0; i < address.Length; i++)
            {
                if (address[i] == '.')
                {
                    final += "[.]";
                }
                else
                {
                    final += address[i];
                }
            }
            return final;
        }
        //Title: 1491. Average Salary Excluding the Minimum and Maximum Salary
        //Link: https://leetcode.com/problems/average-salary-excluding-the-minimum-and-maximum-salary
        //Tags: Array, Sorting
        public static double Average(int[] salary)
        {
            int total = 0;
            int count = 0;
            Array.Sort(salary);
            for (int i = 1; i < salary.Length - 1; i++)
            {
                total += salary[i];
                count++;
            }
            double result = (double)total / count;
            return result;
        }
        //Title: 2351. First Letter to Appear Twice
        //Link: https://leetcode.com/problems/first-letter-to-appear-twice
        //Tags: Hash Table, String, Bit Manipulation, Counting
        public static char RepeatedCharacter(string s)
        {
            List<char> a = new List<char>();
            for (int i = 0; i < s.Length; i++)
            {
                if (!(a.Contains(s[i])))
                {
                    a.Add(s[i]);
                }
                else
                {
                    return s[i];
                }
            }
            return 'a';
        }
        //Title: 1374. Generate a String With Characters That Have Odd Counts
        //Link: https://leetcode.com/problems/generate-a-string-with-characters-that-have-odd-counts
        //Tags: String
        public static string GenerateTheString(int n)
        {
            string final = "";
            if (n % 2 == 0)
            {
                for (int i = 0; i < n - 1; i++)
                {
                    final += 'a';
                }
                final += 'b';
            }
            else
            {
                for (int i = 0; i < n; i++)
                {
                    final += 'a';
                }
            }
            return final;
        }
        //Title: 1816. Truncate Sentence
        //Link: https://leetcode.com/problems/truncate-sentence
        //Tags: Array, String
        public static string TruncateSentence(string s, int k)
        {
            string[] a = new string[15];
            a = s.Split(' ');
            string b = "";
            for (int i = 0; i < k; i++)
            {
                b = b + a[i] + " ";
            }
            b = b.Substring(0, b.Length - 1);
            return b;
        }
        //Title: 2185. Counting Words With a Given Prefix
        //Link: https://leetcode.com/problems/counting-words-with-a-given-prefix
        //Tags: Array, String, String Matching
        public static int PrefixCount(string[] words, string pref)
        {
            int counter = 0;
            foreach (string word in words)
            {
                if (word.Length < pref.Length)
                {
                    continue;
                }
                string test = word.Substring(0, pref.Length);
                if (test == pref)
                {
                    counter++;
                }
            }
            return counter;
        }
        //Title: 2710. Remove Trailing Zeros From a String
        //Link: https://leetcode.com/problems/remove-trailing-zeros-from-a-string
        //Tags: String
        public static string RemoveTrailingZeros(string num)
        {
            while (num[num.Length - 1] == '0')
            {
                num = num.Substring(0, num.Length - 1);
            }
            return num;
        }
        //Title: 1309. Decrypt String from Alphabet to Integer Mapping
        //Link: https://leetcode.com/problems/decrypt-string-from-alphabet-to-integer-mapping
        //Tags: String
        public static string FreqAlphabets(string s)
        {
            string final = s;
            int counter = 1;
            Dictionary<int, char> a = new Dictionary<int, char>();
            Dictionary<string, char> b = new Dictionary<string, char>();
            for (char i = 'a'; i <= 'i'; i++)
            {
                a.Add(counter, i);
                counter++;
            }
            counter = 10;
            for (char i = 'j'; i <= 'z'; i++)
            {
                b.Add(counter.ToString() + '#', i);
                counter++;
            }
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '#')
                {
                    final = final.Replace(s.Substring(i - 2, 3), "" + b[s.Substring(i - 2, 3)]);
                }
            }
            for (int i = 0; i < final.Length; i++)
            {
                if (char.IsDigit(final[i]))
                {
                    char temp = final[i];
                    int digit = int.Parse(temp.ToString());
                    final = final.Replace(temp.ToString(), "" + a[digit]);
                }
            }
            return final;
        }
        //Title: 136. Single Number
        //Link: https://leetcode.com/problems/single-number
        //Tags: Array, Bit Manipulation
        public static int SingleNumber(int[] nums)
        {
            List<int> a = new List<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (a.Contains(nums[i]))
                {
                    a.Remove(nums[i]);
                }
                else
                {
                    a.Add(nums[i]);
                }
            }
            return a[0];
        }
        //Title: 169. Majority Element
        //Link: https://leetcode.com/problems/majority-element
        //Tags: Array, Hash Table, Divide and Conquer, Sorting, Counting
        public static int MajorityElement(int[] nums)
        {
            DataTable countTable = new DataTable("CountTable");
            DataColumn number = new DataColumn("number") { DataType = Type.GetType("System.Int32") };
            DataColumn count = new DataColumn("count") { DataType = Type.GetType("System.Int32") };
            countTable.Columns.Add(number);
            countTable.Columns.Add(count);
            countTable.PrimaryKey = new[] { countTable.Columns["number"] };
            foreach (int x in nums)
            {
                if (countTable.Rows.Contains(x))
                {
                    DataRow myRow1 = countTable.Rows.Find(x);
                    myRow1["count"] = Convert.ToInt32(myRow1["count"]) + 1;
                }
                else
                {
                    DataRow row1 = countTable.NewRow();
                    row1["number"] = x;
                    row1["count"] = 1;
                    countTable.Rows.Add(row1);
                }
            }

            countTable.DefaultView.Sort = "count DESC";
            countTable = countTable.DefaultView.ToTable();
            return (int)countTable.Rows[0]["number"];
        }
        //Title: 2744. Find Maximum Number of String Pairs
        //Link: https://leetcode.com/problems/find-maximum-number-of-string-pairs
        //Tags: Array, Hash Table, String, Simulation
        public static int MaximumNumberOfStringPairs(string[] words)
        {
            int counter = 0;
            for (int i = 0; i < words.Length; i++)
            {
                for (int t = i + 1; t < words.Length; t++)
                {
                    char[] array = words[t].ToCharArray();
                    Array.Reverse(array);
                    string backwards = new String(array);
                    if (backwards == words[i])
                    {
                        counter++;
                    }
                }
            }
            return counter;
        }
        //Title: 9. Palindrome Number
        //Link: https://leetcode.com/problems/palindrome-number
        //Tags: Math
        public static bool IsPalindrome(int x)
        {
            if (x < 0)
            {
                return false;
            }
            string number = x.ToString();
            char[] charArray = number.ToCharArray();
            Array.Reverse(charArray);
            string backwards = new string(charArray);
            if (number == backwards)
            {
                return true;
            }
            return false;
        }
        //Title: 125. Valid Palindrome
        //Link: https://leetcode.com/problems/valid-palindrome
        //Tags: Two Pointers, String
        public static bool IsPalindrome(string s)
        {
            s = s.ToLower();
            string final = "";
            List<char> a = new List<char>();
            char[] alpha = new char[36] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            for (int i = 0; i < alpha.Length; i++)
            {
                a.Add(alpha[i]);
            }
            for (int i = 0; i < s.Length; i++)
            {
                if (a.Contains(s[i]))
                {
                    final += s[i];
                }
            }
            char[] charArray = final.ToCharArray();
            Array.Reverse(charArray);
            string backwards = new string(charArray);
            if (backwards == final)
            {
                return true;
            }
            return false;
        }
        //Title: 1160. Find Words That Can Be Formed by Characters
        //Link: https://leetcode.com/problems/find-words-that-can-be-formed-by-characters
        //Tags: Array, Hash Table, String
        public static int CountCharacters(string[] words, string chars)
        {
            int counter = 0;
            foreach (string word in words)
            {
                List<char> charlist = new List<char>();
                for (int i = 0; i < chars.Length; i++)
                {
                    charlist.Add(chars[i]);
                }
                bool wordparsed = true;
                for (int i = 0; i < word.Length; i++)
                {
                    if (charlist.Contains(word[i]))
                    {
                        charlist.Remove(word[i]);
                    }
                    else
                    {
                        wordparsed = false;
                        break;
                    }
                }
                if (wordparsed)
                {
                    counter += word.Length;
                }
            }
            return counter;
        }
        //Title: 1812. Determine Color of a Chessboard Square
        //Link: https://leetcode.com/problems/determine-color-of-a-chessboard-square
        //Tags: Math, String
        public static bool SquareIsWhite(string coordinates)
        {
            bool startblack = false;
            string letter = "";
            letter = coordinates.Substring(0, 1);
            if (letter == "a" || letter == "c" || letter == "e" || letter == "g")
            {
                startblack = true;
            }
            else
            {
                startblack = false;
            }
            int digit = 0;
            int.TryParse(coordinates.Substring(1, 1), out digit);
            if (digit % 2 == 0)
            {
                if (startblack)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                if (startblack)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
        //Title: 1935. Maximum Number of Words You Can Type
        //Link: https://leetcode.com/problems/maximum-number-of-words-you-can-type
        //Tags: Hash Table, String
        public static int CanBeTypedWords(string text, string brokenLetters)
        {
            List<char> a = new List<char>();
            int counter = 0;
            for (int i = 0; i < brokenLetters.Length; i++)
            {
                a.Add(brokenLetters[i]);
            }
            string[] words = text.Split(' ');
            foreach (string word in words)
            {
                bool cantype = true;
                for (int i = 0; i < word.Length; i++)
                {
                    if (a.Contains(word[i]))
                    {
                        cantype = false;
                        break;
                    }
                }
                if (cantype)
                {
                    counter++;
                }
            }
            return counter;
        }
        //Title: 2418. Sort the People
        //Link: https://leetcode.com/problems/sort-the-people
        //Tags: Array, Hash Table, String, Sorting
        public static string[] SortPeople(string[] names, int[] heights)
        {
            string[] answer = new string[names.Length];
            SortedDictionary<int, string> a = new SortedDictionary<int, string>();
            for (int i = 0; i < heights.Length; i++)
            {
                a.Add(heights[i], names[i]);
            }
            int counter = 0;
            foreach (KeyValuePair<int, string> b in a)
            {
                answer[counter] = b.Value;
                counter++;
            }
            Array.Reverse(answer);
            return answer;
        }
        //Title: 2000. Reverse Prefix of Word
        //Link: https://leetcode.com/problems/reverse-prefix-of-word
        //Tags: Two Pointers, String
        public static string ReversePrefix(string word, char ch)
        {
            string final = "";
            bool firstoccurance = true;
            for (int i = 0; i < word.Length; i++)
            {
                if (word[i] == ch && firstoccurance)
                {
                    firstoccurance = false;
                    final += word[i];
                    char[] charArray = final.ToCharArray();
                    Array.Reverse(charArray);
                    string backwards = new string(charArray);
                    final = backwards;
                }
                else
                {
                    final += word[i];
                }
            }
            return final;
        }
        //Title: 2124. Check if All A's Appears Before All B's
        //Link: https://leetcode.com/problems/check-if-all-as-appears-before-all-bs
        //Tags: String
        public static bool CheckString(string s)
        {
            bool hitb = false;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == 'b')
                {
                    hitb = true;
                }
                else if (s[i] == 'a')
                {
                    if (hitb)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        //Title: 2255. Count Prefixes of a Given String
        //Link: https://leetcode.com/problems/count-prefixes-of-a-given-string
        //Tags: Array, String
        public static int CountPrefixes(string[] words, string s)
        {
            int counter = 0;
            foreach (string word in words)
            {
                if (word.Length > s.Length)
                {
                    continue;
                }
                bool isprefix = true;
                for (int i = 0; i < word.Length; i++)
                {
                    if (word[i] != s[i])
                    {
                        isprefix = false;
                        break;
                    }
                }
                if (isprefix)
                {
                    counter++;
                }
            }
            return counter;
        }
        //Title: 1704. Determine if String Halves Are Alike
        //Link: https://leetcode.com/problems/determine-if-string-halves-are-alike
        //Tags: String, Counting
        public static bool HalvesAreAlike(string s)
        {
            string half1 = "";
            string half2 = "";
            string vowels = "aeiouAEIOU";
            List<char> a = new List<char>();
            for (int i = 0; i < vowels.Length; i++)
            {
                a.Add(vowels[i]);
            }
            for (int i = 0; i < s.Length / 2; i++)
            {
                half1 += s[i];
            }
            for (int i = s.Length / 2; i < s.Length; i++)
            {
                half2 += s[i];
            }
            int half1count = 0;
            int half2count = 0;
            for (int i = 0; i < half1.Length; i++)
            {
                if (a.Contains(half1[i]))
                {
                    half1count++;
                }
            }
            for (int i = 0; i < half2.Length; i++)
            {
                if (a.Contains(half2[i]))
                {
                    half2count++;
                }
            }
            if (half1count == half2count)
            {
                return true;
            }
            return false;
        }
        //Title: 1967. Number of Strings That Appear as Substrings in Word
        //Link: https://leetcode.com/problems/number-of-strings-that-appear-as-substrings-in-word
        //Tags: String
        public static int NumOfStrings(string[] patterns, string word)
        {
            int counter = 0;
            for (int i = 0; i < patterns.Length; i++)
            {
                if (word.Contains(patterns[i]))
                {
                    counter++;
                }
            }
            return counter;
        }
        //Title: 2114. Maximum Number of Words Found in Sentences
        //Link: https://leetcode.com/problems/maximum-number-of-words-found-in-sentences
        //Tags: Array, String
        public static int MostWordsFound(string[] sentences)
        {
            int max = 0;
            foreach (string a in sentences)
            {
                int total = 0;
                string[] b = a.Split(' ');
                total = b.Count();
                if (total > max)
                {
                    max = total;
                }
            }
            return max;
        }
        //Title: 2769. Find the Maximum Achievable Number
        //Link: https://leetcode.com/problems/find-the-maximum-achievable-number
        //Tags: Math
        public static int TheMaximumAchievableX(int num, int t)
        {
            return (t * 2 + num);
        }
        //Title: 2788. Split Strings by Separator
        //Link: https://leetcode.com/problems/split-strings-by-separator
        //Tags: Array, String
        public static IList<string> SplitWordsBySeparator(IList<string> words, char separator)
        {
            List<string> a = new List<string>();
            List<string> b = new List<string>();
            foreach (string word in words)
            {
                string[] brokeup = word.Split(separator);
                foreach (string split in brokeup)
                {
                    a.Add(split);
                }
            }
            foreach (string final in a)
            {
                if (final != "")
                {
                    b.Add(final);
                }
            }
            return b;
        }
        //Title: 412. Fizz Buzz
        //Link: https://leetcode.com/problems/fizz-buzz
        //Tags: Math, String, Simulation
        public static IList<string> FizzBuzz(int n)
        {
            string[] a = new string[n];
            int counter = 1;
            for (int i = 0; i < n; i++)
            {
                if (counter % 3 == 0 && counter % 5 == 0)
                {
                    a[i] = "FizzBuzz";
                    counter++;
                }
                else if (counter % 3 == 0)
                {
                    a[i] = "Fizz";
                    counter++;
                }
                else if (counter % 5 == 0)
                {
                    a[i] = "Buzz";
                    counter++;
                }
                else
                {
                    a[i] = counter.ToString();
                    counter++;
                }
            }
            return a;
        }
        //Title: 1941. Check if All Characters Have Equal Number of Occurrences
        //Link: https://leetcode.com/problems/check-if-all-characters-have-equal-number-of-occurrences
        //Tags: Hash Table, String, Counting
        public static bool AreOccurrencesEqual(string s)
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
            int occ = a[s[0]];
            foreach (KeyValuePair<char, int> t in a)
            {
                if (t.Value != occ)
                {
                    return false;
                }
            }
            return true;
        }
        //Title: 2278. Percentage of Letter in String
        //Link: https://leetcode.com/problems/percentage-of-letter-in-string
        //Tags: String
        public static int PercentageLetter(string s, char letter)
        {
            int counter = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == letter)
                {
                    counter++;
                }
            }
            double preround = (double)(100 * counter) / s.Length;
            preround = Math.Floor(preround);
            int percent = (int)preround;
            return percent;
        }
        //Title: 2678. Number of Senior Citizens
        //Link: https://leetcode.com/problems/number-of-senior-citizens
        //Tags: Array, String
        public static int CountSeniors(string[] details)
        {
            int counter = 0;
            foreach (string deet in details)
            {
                string agestring = "";
                agestring = deet.Substring(11, 2);
                int age = 0;
                int.TryParse(agestring, out age);
                if (age > 60)
                {
                    counter++;
                }
            }
            return counter;
        }
        //Title: 387. First Unique Character in a String
        //Link: https://leetcode.com/problems/first-unique-character-in-a-string
        //Tags: Hash Table, String, Queue, Counting
        public static int FirstUniqChar(string s)
        {
            List<char> b = new List<char>();
            char a = ' ';
            int counter = 1;
            for (int i = 0; i < s.Length; i++)
            {
                a = s[i];
                if (b.Contains(a))
                {
                    counter++;
                    continue;
                }
                bool nonrepeat = true;
                for (int t = counter; t < s.Length; t++)
                {
                    if (s[t] == a)
                    {
                        nonrepeat = false;
                        b.Add(a);
                        break;
                    }
                }
                if (nonrepeat)
                {
                    return i;
                }
                counter++;
            }
            return -1;
        }
        //Title: 434. Number of Segments in a String
        //Link: https://leetcode.com/problems/number-of-segments-in-a-string
        //Tags: String
        public static int CountSegments(string s)
        {
            bool meat = false;
            int counter = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] != ' ')
                {
                    if (meat == false)
                    {
                        counter++;
                    }
                    meat = true;
                }
                else
                {
                    meat = false;
                }
            }
            return counter;
        }
        //Title: 205. Isomorphic Strings
        //Link: https://leetcode.com/problems/isomorphic-strings
        //Tags: Hash Table, String
        public static bool IsIsomorphic(string s, string t)
        {
            Dictionary<char, string> a = new Dictionary<char, string>();
            Dictionary<char, string> b = new Dictionary<char, string>();
            string first = "";
            int f1 = 0;
            string second = "";
            int s1 = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (!(a.ContainsKey(s[i])))
                {
                    a.Add(s[i], f1.ToString());
                    first += f1.ToString() + '-';
                    f1++;
                }
                else
                {
                    first += a[s[i]] + '-';
                }
            }
            for (int i = 0; i < t.Length; i++)
            {
                if (!(b.ContainsKey(t[i])))
                {
                    b.Add(t[i], s1.ToString());
                    second += s1.ToString() + '-';
                    s1++;
                }
                else
                {
                    second += b[t[i]] + '-';
                }
            }
            if (first == second)
            {
                return true;
            }
            return false;
        }
        //Title: 557. Reverse Words in a String III
        //Link: https://leetcode.com/problems/reverse-words-in-a-string-iii
        //Tags: Two Pointers, String
        public static string ReverseWords(string s)
        {
            string[] a = new string[100];
            string final = "";
            a = s.Split(' ');
            for (int i = 0; i < a.Length; i++)
            {
                string curr = "";
                curr = a[i];
                char[] charArray = a[i].ToCharArray();
                Array.Reverse(charArray);
                string backwards = new string(charArray);
                final += backwards + " ";
            }
            final = final.Substring(0, final.Length - 1);
            return final;
        }
        //Title: 344. Reverse String
        //Link: https://leetcode.com/problems/reverse-string
        //Tags: Two Pointers, String
        public static void ReverseString(char[] s)
        {
            char[] a = new char[s.Length];
            int counter = 0;
            for (int i = s.Length; i > 0; i--)
            {
                a[counter] = s[i - 1];
                counter++;
            }
            for (int i = 0; i < s.Length; i++)
            {
                s[i] = a[i];
            }
        }
        //Title: 1832. Check if the Sentence Is Pangram
        //Link: https://leetcode.com/problems/check-if-the-sentence-is-pangram
        //Tags: Hash Table, String
        public static bool CheckIfPangram(string sentence)
        {
            List<char> a = new List<char>();
            for (int i = 0; i < sentence.Length; i++)
            {
                if (!(a.Contains(sentence[i])))
                {
                    a.Add(sentence[i]);
                }
            }
            if (a.Count() == 26)
            {
                return true;
            }
            return false;
        }
        //Title: 1431. Kids With the Greatest Number of Candies
        //Link: https://leetcode.com/problems/kids-with-the-greatest-number-of-candies
        //Tags: Array
        public static IList<bool> KidsWithCandies(int[] candies, int extraCandies)
        {
            List<bool> a = new List<bool>();
            int most = 0;
            for (int i = 0; i < candies.Length; i++)
            {
                if (candies[i] > most)
                {
                    most = candies[i];
                }
            }
            for (int i = 0; i < candies.Length; i++)
            {
                if (candies[i] + extraCandies >= most)
                {
                    a.Add(true);
                }
                else
                {
                    a.Add(false);
                }
            }
            return a;
        }
        //Title: 2325. Decode the Message
        //Link: https://leetcode.com/problems/decode-the-message
        //Tags: Hash Table, String
        public static string DecodeMessage(string key, string message)
        {
            Dictionary<char, char> a = new Dictionary<char, char>();
            int counter = 0;
            string final = "";
            char[] alpha = new char[26] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };

            for (int i = 0; i < key.Length; i++)
            {
                if (key[i] == ' ')
                {
                }
                else if (!(a.ContainsKey(key[i])))
                {
                    a.Add(key[i], alpha[counter]);
                    counter++;
                }
            }
            for (int i = 0; i < message.Length; i++)
            {
                if (message[i] == ' ')
                {
                    final += ' ';
                }
                else
                {
                    final += a[message[i]];
                }
            }
            return final;
        }
        //Title: 2974. Minimum Number Game
        //Link: https://leetcode.com/problems/minimum-number-game
        //Tags: Array, Sorting, Heap(Priority Queue), Simulation
        public static int[] NumberGame(int[] nums)
        {
            int[] a = new int[nums.Length];
            int[] alice = new int[nums.Length / 2];
            int[] bob = new int[nums.Length / 2];
            int alicecounter = 0;
            int bobcounter = 0;
            Array.Sort(nums);
            for (int i = 0; i < nums.Length; i++)
            {
                if (i % 2 != 0)
                {
                    bob[bobcounter] = nums[i];
                    bobcounter++;
                }
                else
                {
                    alice[alicecounter] = nums[i];
                    alicecounter++;
                }
            }
            alicecounter = 0;
            bobcounter = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (i % 2 != 0)
                {
                    a[i] = alice[alicecounter];
                    alicecounter++;
                }
                else
                {
                    a[i] = bob[bobcounter];
                    bobcounter++;
                }
            }
            return a;
        }
        //Title: 1470. Shuffle the Array
        //Link: https://leetcode.com/problems/shuffle-the-array
        //Tags: Array
        public static int[] Shuffle(int[] nums, int n)
        {
            int[] a = new int[nums.Length];
            int[] b = new int[nums.Length / 2];
            int[] c = new int[nums.Length / 2];
            int d = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (i < nums.Length / 2)
                {
                    b[i] = nums[i];
                }
                else
                {
                    c[d] = nums[i];
                    d++;
                }
            }
            int e = 0;
            int f = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (i % 2 == 0)
                {
                    a[i] = b[e];
                    e++;
                }
                else
                {
                    a[i] = c[f];
                    f++;
                }
            }
            return a;
        }
        //Title: 2942. Find Words Containing Character
        //Link: https://leetcode.com/problems/find-words-containing-character
        //Tags: Array, String
        public static IList<int> FindWordsContaining(string[] words, char x)
        {
            int index = 0;
            List<int> a = new List<int>();
            foreach (string i in words)
            {
                bool found = false;
                for (int g = 0; g < i.Length; g++)
                {
                    if (i[g] == x)
                    {
                        found = true;
                    }
                }
                if (found == true)
                {
                    a.Add(index);
                }
                index++;
            }
            return a;
        }
        //Title: 3046. Split the Array
        //Link: https://leetcode.com/problems/split-the-array
        //Tags: Array, Hash Table, Counting
        public static bool IsPossibleToSplit(int[] nums)
        {
            Dictionary<int, int> countinglist = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (countinglist.ContainsKey(nums[i]))
                {
                    countinglist[nums[i]]++;
                }
                else
                {
                    countinglist.Add(nums[i], 1);
                }
            }
            foreach (KeyValuePair<int, int> a in countinglist)
            {
                if (a.Value > 2)
                {
                    return false;
                }
            }
            return true;
        }
        //Title: 709. To Lower Case
        //Link: https://leetcode.com/problems/to-lower-case
        //Tags: String
        public static string ToLowerCase(string s)
        {
            return s.ToLower();
        }
        //Title: 1365. How Many Numbers Are Smaller Than the Current Number
        //Link: https://leetcode.com/problems/how-many-numbers-are-smaller-than-the-current-number
        //Tags: Array, Hash Table, Sorting, Counting
        public static int[] SmallerNumbersThanCurrent(int[] nums)
        {
            int[] a = new int[nums.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                int y = nums[i];
                int count = 0;
                for (int t = 0; t < nums.Length; t++)
                {
                    if (nums[t] < y)
                    {
                        count++;
                    }
                }
                a[i] = count;
            }
            return a;
        }
        //Title: 2119. A Number After a Double Reversal
        //Link: https://leetcode.com/problems/a-number-after-a-double-reversal
        //Tags: Math
        public static bool IsSameAfterReversals(int num)
        {
            string a = num.ToString();
            if (a.Length == 1)
            {
                return true;
            }
            if (a[a.Length - 1] == '0')
            {
                return false;
            }
            return true;
        }
        //Title: 2413. Smallest Even Multiple
        //Link: https://leetcode.com/problems/smallest-even-multiple
        //Tags: Math, Number Theory
        public static int SmallestEvenMultiple(int n)
        {
            if (n % 2 == 0)
            {
                return n;
            }
            int a = n + 1;
            int exp1 = a % 2;
            int exp2 = a % n;
            while (a % n != 0 || a % 2 != 0)
            {
                a++;
            }
            return a;
        }
        //Title: 1684. Count the Number of Consistent Strings
        //Link: https://leetcode.com/problems/count-the-number-of-consistent-strings
        //Tags: Array, Hash Table, String, Bit Manipulation
        public static int CountConsistentStrings(string allowed, string[] words)
        {
            List<char> a = new List<char>();
            int counter = 0;
            for (int i = 0; i < allowed.Length; i++)
            {
                if (!(a.Contains(allowed[i])))
                {
                    a.Add(allowed[i]);
                }
            }
            foreach (string word in words)
            {
                bool pass = true;
                for (int i = 0; i < word.Length; i++)
                {
                    if (!(a.Contains(word[i])))
                    {
                        pass = false;
                        break;
                    }
                }
                if (pass)
                {
                    counter++;
                }
            }
            return counter;
        }
        //Title: 2828. Check if a String Is an Acronym of Words
        //Link: https://leetcode.com/problems/check-if-a-string-is-an-acronym-of-words
        //Tags: Array, String
        public static bool IsAcronym(IList<string> words, string s)
        {
            if (words.Count != s.Length)
            {
                return false;
            }
            bool testall = true;
            int counter = 0;
            foreach (string word in words)
            {
                if (!(word[0] == s[counter]))
                {
                    testall = false;
                }
                counter++;
            }
            return testall;
        }
        //Title: 520. Detect Capital
        //Link: https://leetcode.com/problems/detect-capital
        //Tags: String
        public static bool DetectCapitalUse(string word)
        {
            List<char> a = new List<char>();
            List<char> b = new List<char>();
            string caps = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string lower = "abcdefghijklmnopqrstuvwxyz";
            for (int i = 0; i < caps.Length; i++)
            {
                a.Add(caps[i]);
            }
            for (int i = 0; i < lower.Length; i++)
            {
                b.Add(lower[i]);
            }
            bool ALLCAPS = true;
            for (int i = 0; i < word.Length; i++)
            {
                if (b.Contains(word[i]))
                {
                    ALLCAPS = false;
                    break;
                }
            }
            bool alllower = true;
            for (int i = 0; i < word.Length; i++)
            {
                if (a.Contains(word[i]))
                {
                    alllower = false;
                    break;
                }
            }
            bool firstcap = true;
            if (b.Contains(word[0]))
            {
                firstcap = false;
            }
            for (int i = 1; i < word.Length; i++)
            {
                if (a.Contains(word[i]))
                {
                    firstcap = false;
                    break;
                }
            }
            if (ALLCAPS || alllower || firstcap)
            {
                return true;
            }
            return false;
        }
        //Title: 500. Keyboard Row
        //Link: https://leetcode.com/problems/keyboard-row
        //Tags: Array, Hash Table, String
        public static string[] FindWords(string[] words)
        {
            string[] a = new string[words.Length];
            Dictionary<char, int> b = new Dictionary<char, int>();
            string row1 = "qwertyuiop";
            string row2 = "asdfghjkl";
            string row3 = "zxcvbnm";
            int counter = 0;
            for (int i = 0; i < row1.Length; i++)
            {
                b.Add(row1[i], 1);
            }
            for (int i = 0; i < row2.Length; i++)
            {
                b.Add(row2[i], 2);
            }
            for (int i = 0; i < row3.Length; i++)
            {
                b.Add(row3[i], 3);
            }
            foreach (string word in words)
            {
                int rowdeterminer = b[char.ToLower(word[0])];
                bool keyrow = true;
                for (int i = 0; i < word.Length; i++)
                {
                    if (b[char.ToLower(word[i])] != rowdeterminer)
                    {
                        keyrow = false;
                    }
                }
                if (keyrow)
                {
                    a[counter] = word;
                    counter++;
                }
            }
            string[] answer = new string[counter];
            for (int i = 0; i < counter; i++)
            {
                answer[i] = a[i];
            }
            return answer;
        }
        //Title: 1502. Can Make Arithmetic Progression From Sequence
        //Link: https://leetcode.com/problems/can-make-arithmetic-progression-from-sequence
        //Tags: Array, Sorting
        public static bool CanMakeArithmeticProgression(int[] arr)
        {
            Array.Sort(arr);
            int prog = 0;
            prog = arr[1] - arr[0];
            for (int i = 2; i < arr.Length; i++)
            {
                if (!(arr[i] - arr[i - 1] == prog))
                {
                    return false;
                }
            }
            return true;
        }
        //Title: 242. Valid Anagram
        //Link: https://leetcode.com/problems/valid-anagram
        //Tags: Hash Table, String, Sorting
        public static bool IsAnagram(string s, string t)
        {
            if (s == null || t == null || s.Length != t.Length)
            {
                return false;
            }

            int[] count = new int[26];

            for (int i = 0; i < s.Length; i++)
            {
                count[s[i] - 'a']++;
                count[t[i] - 'a']--;
            }

            foreach (int value in count)
            {
                if (value != 0)
                {
                    return false;
                }
            }

            return true;
        }
        //Title: 860. Lemonade Change
        //Link: https://leetcode.com/problems/lemonade-change
        //Tags: Array, Greedy
        public static bool LemonadeChange(int[] bills)
        {
            int fives = 0;
            int tens = 0;
            int twenties = 0;
            for (int i = 0; i < bills.Length; i++)
            {
                if (bills[i] == 5)
                {
                    fives += 1;
                }
                else if (bills[i] == 10)
                {
                    if (fives > 0)
                    {
                        fives -= 1;
                        tens += 1;
                    }
                    else
                    {
                        return false;
                    }
                }
                else if (bills[i] == 20)
                {
                    if (tens > 0 && fives > 0)
                    {
                        tens -= 1;
                        fives -= 1;
                        twenties += 1;
                    }
                    else if (fives > 2)
                    {
                        fives -= 3;
                        twenties += 1;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        //Title: 1822. Sign of the Product of an Array
        //Link: https://leetcode.com/problems/sign-of-the-product-of-an-array
        //Tags: Array, Math
        public static int ArraySign(int[] nums)
        {
            int currentnum = 0;
            bool polarity = false;
            if (nums[0] > 0)
            {
                polarity = true;
            }
            else if (nums[0] < 0)
            {
                polarity = false;
            }
            else if (nums[0] == 0)
            {
                return signFunc(0);
            }
            for (int i = 1; i < nums.Length; i++)
            {
                currentnum = nums[i];
                if (nums[i] == 0)
                {
                    return signFunc(0);
                }
                if (nums[i] > 0)
                {
                    if (polarity)
                    {
                        polarity = true;
                    }
                    else
                    {
                        polarity = false;
                    }
                }
                else if (nums[i] < 0)
                {
                    if (polarity)
                    {
                        polarity = false;
                    }
                    else
                    {
                        polarity = true;
                    }
                }
            }
            if (polarity)
            {
                return signFunc(1);
            }
            else
            {
                return signFunc(-1);
            }
        }
        //Title: 1773. Count Items Matching a Rule
        //Link: https://leetcode.com/problems/count-items-matching-a-rule
        //Tags: Array, String
        public static int CountMatches(IList<IList<string>> items, string ruleKey, string ruleValue)
        {
            int counter = 0;
            int rule = 0;
            switch (ruleKey)
            {
                case "type":
                    rule = 0;
                    break;
                case "color":
                    rule = 1;
                    break;
                case "name":
                    rule = 2;
                    break;
            }
            foreach (var item in items)
            {
                if (item[rule] == ruleValue)
                {
                    counter++;
                }
            }
            return counter;
        }
        public static int signFunc(int x)
        {
            if (x > 0)
            {
                return 1;
            }
            else if (x < 0)
            {
                return -1;
            }
            else if (x == 0)
            {
                return 0;
            }
            return 900;
        }
        //Title: 283. Move Zeroes
        //Link: https://leetcode.com/problems/move-zeroes
        //Tags: Array, Two Pointers
        public static void MoveZeroes(int[] nums)
        {

            int left = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != 0)
                {
                    (nums[left], nums[i]) = (nums[i], nums[left]);
                    left++;
                }
            }
        }
        //Title: 1768. Merge Strings Alternately
        //Link: https://leetcode.com/problems/merge-strings-alternately
        //Tags: Two Pointers, String
        public static string MergeAlternately(string word1, string word2)
        {
            string final = "";
            bool c = true;
            int d = 0;
            int e = 0;
            for (int i = 0; i < word1.Length + word2.Length; i++)
            {
                if (c == true && d < word1.Length)
                {
                    final += word1[d];
                    d++;
                    if (e < word2.Length)
                    {
                        c = false;
                    }
                }
                else if (c == false && e < word2.Length)
                {
                    final += word2[e];
                    e++;
                    if (d < word1.Length)
                    {
                        c = true;
                    }
                }
            }
            return final;
        }
        //Title: 28. Find the Index of the First Occurrence in a String
        //Link: https://leetcode.com/problems/find-the-index-of-the-first-occurrence-in-a-string
        //Tags: Two Pointers, String, String Matching
        public static int StrStr(string haystack, string needle)
        {
            int len = haystack.Length, n = needle.Length;
            for (int i = 0; i < haystack.Length; i++)
            {
                for (int j = 0; j < n && i + j < len; j++)
                {
                    if (needle[j] != haystack[i + j])
                    {
                        break;
                    }
                    if (j == n - 1)
                    {
                        return i;
                    }
                }
            }
            return -1;
        }
        //Title: 1662. Check If Two String Arrays are Equivalent
        //Link: https://leetcode.com/problems/check-if-two-string-arrays-are-equivalent
        //Tags: Array, String
        public static bool ArrayStringsAreEqual(string[] word1, string[] word2)
        {
            string a = "";
            string b = "";
            foreach (string i in word1)
            {
                a += i;
            }
            foreach (string t in word2)
            {
                b += t;
            }
            return a == b ? true : false;
        }
        //Title: 1716. Calculate Money in Leetcode Bank
        //Link: https://leetcode.com/problems/calculate-money-in-leetcode-bank
        //Tags: Math
        public static int TotalMoney(int n)
        {
            int e = 0;
            int d = 1;
            int increment = 0;
            int total = 0;
            for (int i = 0; i < n; i++)
            {
                total += d + increment;
                increment++;
                e++;
                if (e == 7)
                {
                    increment = 0;
                    d++;
                    e = 0;
                }
            }
            return total;
        }
        //Title: 844. Backspace String Compare
        //Link: https://leetcode.com/problems/backspace-string-compare
        //Tags: Two Pointers, String, Stack, Simulation
        public static bool BackspaceCompare(string s, string t)
        {
            string a = "";
            string b = "";
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '#')
                {
                    if (a.Length > 0)
                    {
                        a = a.Remove(a.Length - 1);
                    }
                }
                else
                {
                    a += s[i];
                }
            }
            for (int j = 0; j < t.Length; j++)
            {
                if (t[j] == '#')
                {
                    if (b.Length > 0)
                    {
                        b = b.Remove(b.Length - 1);
                    }
                }
                else
                {
                    b += t[j];
                }
            }
            return a == b ? true : false;
        }
        //Title: 896. Monotonic Array
        //Link: https://leetcode.com/problems/monotonic-array
        //Tags: Array
        public static bool IsMonotonic(int[] nums)
        {
            bool a = true;
            bool b = true;
            for (int i = 0; i < nums.Length; i++)
            {
                if (i > 0)
                {
                    if (!(nums[i] >= nums[i - 1]))
                    {
                        a = false;
                    }
                    if (!(nums[i] <= nums[i - 1]))
                    {
                        b = false;
                    }
                }
            }
            if (a || b)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //Title: 905. Sort Array By Parity
        //Link: https://leetcode.com/problems/sort-array-by-parity
        //Tags: Array, Two Pointers, Sorting
        public static int[] SortArrayByParity(int[] nums)
        {
            var p = 0;
            for (var i = 0; i < nums.Length; i++)
            {
                if (nums[i] % 2 == 0)
                {
                    (nums[p], nums[i]) = (nums[i], nums[p]);
                    p++;
                }
            }

            return nums;
        }
        //Title: 342. Power of Four
        //Link: https://leetcode.com/problems/power-of-four
        //Tags: Math, Bit Manipulation, Recursion
        public bool IsPowerOfFour(int n)
        {
            if (n == 0)
                return false;
            int num = n;
            while (num != 1)
            {
                if (num % 4 != 0)
                    return false;
                num = num / 4;
            }
            return true;
        }
        //Title: 389. Find the Difference
        //Link: https://leetcode.com/problems/find-the-difference
        //Tags: Hash Table, String, Bit Manipulation, Sorting
        public static char FindTheDifference(string s, string t)
        {
            int first = 0;
            int second = 0;
            for (int i = 0; i < s.Length && i < t.Length; i++)
            {
                first += s[i];
                second += t[i];
            }
            for (int i = t.Length; i < s.Length; i++)
            {
                first += s[i];
            }
            for (int i = s.Length; i < t.Length; i++)
            {
                second += t[i];
            }
            return (char)(Math.Abs(first - second));
        }
        //Title: 268. Missing Number
        //Link: https://leetcode.com/problems/missing-number
        //Tags: Array, Hash Table, Math, Binary Search, Bit Manipulation, Sorting
        public static int MissingNumber(int[] nums)
        {
            int n = nums.Length;
            int expectedSum = n * (n + 1) / 2;
            int actualSum = 0;

            foreach (int num in nums)
            {
                actualSum += num;
            }

            return expectedSum - actualSum;
        }
        //Title: 231. Power of Two
        //Link: https://leetcode.com/problems/power-of-two
        //Tags: Math, Bit Manipulation, Recursion
        public static bool IsPowerOfTwo(int n)
        {
            if (n == 0)
                return false;
            int num = n;
            while (num != 1)
            {
                if (num % 2 != 0)
                    return false;
                num = num / 2;
            }
            return true;
        }
        //Title: 1. Two Sum
        //Link: https://leetcode.com/problems/two-sum
        //Tags: Array, Hash Table
        public static int[] TwoSum(int[] nums, int target)
        {
            Dictionary<int, int> seen = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                int temp = target - nums[i];

                if (seen.ContainsKey(temp))
                {
                    return new int[] { seen[temp], i };
                }
                seen[nums[i]] = i;
            }
            return null;
        }
        //Title: 20. Valid Parentheses
        //Link: https://leetcode.com/problems/valid-parentheses
        //Tags: String, Stack
        public static bool IsValid(string s)
        {
            Stack<char> st = new Stack<char>();
            int i = 0;
            char c;
            while (i < s.Length)
            {
                c = s[i];
                if (c == '}')
                {
                    if (st.Count == 0 || st.Pop() != '{')
                    {
                        return false;
                    }
                }
                else if (c == ']')
                {
                    if (st.Count == 0 || st.Pop() != '[')
                    {
                        return false;
                    }
                }
                else if (c == ')')
                {
                    if (st.Count == 0 || st.Pop() != '(')
                    {
                        return false;
                    }
                }
                else
                {
                    st.Push(c);
                }
                i++;
            }
            return st.Count == 0;
        }
        //Title: 58. Length of Last Word
        //Link: https://leetcode.com/problems/length-of-last-word
        //Tags: String
        public int LengthOfLastWord(string s)
        {
            s = Regex.Replace(s, "  ", " ");
            if (s.Substring(s.Length - 1) == " ")
            {
                s = s.Substring(0, s.Length - 1);
            }
            s = s.Trim();
            string[] splitarray = s.Split(' ');
            return splitarray[splitarray.Length - 1].Length;
        }
        //Title: 66. Plus One
        //Link: https://leetcode.com/problems/plus-one/
        //Tags: Array, Math
        public static int[] PlusOne(int[] digits)
        {
            int[] a = digits;
            Array.Reverse(a);
            if (a[0] == 9)
            {
                for (int i = 0; i < a.Length; i++)
                {
                    if (a[i] == 9)
                    {
                        a[i] = 0;
                        if (i == a.Length - 1)
                        {
                            int[] b = new int[a.Length + 1];
                            a.CopyTo(b, 0);
                            b[b.Length - 1] = 1;
                            Array.Reverse(b);
                            return b;
                        }
                    }
                    else
                    {
                        a[i] += 1;
                        break;
                    }
                }
            }
            else
            {
                a[0] += 1;
            }
            Array.Reverse(a);
            return a;
        }
        //Title: 118. Pascal's Triangle
        //Link: https://leetcode.com/problems/pascals-triangle
        //Tags: Array, Dynamic Programming
        public IList<IList<int>> Generate(int numRows)
        {
            List<IList<int>> list = new List<IList<int>>();
            for (int i = 0; i < numRows; i++)
            {
                int[] a = new int[i + 1];
                for (int p = 0; p < i + 1; p++)
                {
                    if (p == 0)
                    {
                        a[p] = 1;
                    }
                    else if (p == i)
                    {
                        a[p] = 1;
                    }
                    else
                    {
                        a[p] = list[i - 1][p - 1] + list[i - 1][p];
                    }
                }
                list.Add(a);
            }
            return list;
        }
        //Title: 119. Pascal's Triangle II
        //Link: https://leetcode.com/problems/pascals-triangle-ii
        //Tags: Array, Dynamic Programming
        public IList<int> GetRow(int rowIndex)
        {
            List<IList<int>> list = new List<IList<int>>();
            rowIndex += 1;
            for (int i = 0; i < rowIndex; i++)
            {
                int[] a = new int[i + 1];
                for (int p = 0; p < i + 1; p++)
                {
                    if (p == 0)
                    {
                        a[p] = 1;
                    }
                    else if (p == i)
                    {
                        a[p] = 1;
                    }
                    else
                    {
                        a[p] = list[i - 1][p - 1] + list[i - 1][p];
                    }
                }
                list.Add(a);
            }
            return list[rowIndex - 1];
        }
        //Title: 14. Longest Common Prefix
        //Link: https://leetcode.com/problems/longest-common-prefix
        //Tags: String, Trie
        public static string LongestCommonPrefix(string[] strs)
        {
            if (strs[0] == "") { return ""; }
            string finalstring = "";
            int y = 0;
            string tempchar = strs[0].Substring(0, 1);
            bool j = true;
            for (int i = 0; i < strs[0].Length; i++)
            {
                foreach (string x in strs)
                {
                    if (y < x.Length)
                    {
                        if (x.Substring(y, 1) != tempchar)
                        {
                            j = false;
                        }
                    }
                    else
                    {
                        j = false;
                    }
                }
                if (j)
                {
                    finalstring += strs[0].Substring(y, 1);
                }
                else
                {
                    return finalstring;
                }
                j = true;
                if (y < strs[0].Length - 1)
                {
                    y += 1;
                    tempchar = strs[0].Substring(y, 1);
                }
            }
            return finalstring;
        }
        //Title: 383. Ransom Note
        //Link: https://leetcode.com/problems/ransom-note
        //Tags: Hash Table, String, Counting
        public static bool CanConstruct(string ransomNote, string magazine)
        {
            List<char> a = new List<char>();
            for (int i = 0; i < magazine.Length; i++)
            {
                a.Add(magazine[i]);
            }
            for (int i = 0; i < ransomNote.Length; i++)
            {
                if (a.Contains(ransomNote[i]))
                {
                    a.Remove(ransomNote[i]);
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
        //Title: 2299. Strong Password Checker II
        //Link: https://leetcode.com/problems/strong-password-checker-ii
        //Tags: String
        public static bool StrongPasswordCheckerII(string password)
        {
            if (password.Length < 8)
            {
                return false;
            }
            bool lower = false;
            bool upper = false;
            bool digit = false;
            bool special = false;
            char last = '|';
            char[] v = new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
            char[] u = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
            char[] w = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            char[] x = new char[] { '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '-', '+' };
            for (int i = 0; i < password.Length; i++)
            {
                if (password[i] == last)
                {
                    return false;
                }
                else if (v.Contains(password[i]))
                {
                    upper = true;
                }
                else if (u.Contains(password[i]))
                {
                    lower = true;
                }
                else if (w.Contains(password[i]))
                {
                    digit = true;
                }
                else if (x.Contains(password[i]))
                {
                    special = true;
                }
                last = password[i];
            }
            if (lower == false || upper == false || digit == false || special == false)
            {
                return false;
            }
            return true;
        }
        //Title: 2133. Check if Every Row and Column Contains All Numbers
        //Link: https://leetcode.com/problems/check-if-every-row-and-column-contains-all-numbers
        //Tags: Array, Hash Table, Matrix
        public static bool CheckValid(int[][] matrix)
        {
            int len = matrix.Length;
            foreach (int[] a in matrix)
            {
                List<int> b = new List<int>();
                for (int i = 0; i < len; i++)
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
                for (int i = 1; i <= len; i++)
                {
                    if (!b.Contains(i))
                    {
                        return false;
                    }
                }
            }
            for (int i = 0; i < len; i++)
            {
                List<int> c = new List<int>();
                for (int t = 0; t < len; t++)
                {
                    if (!c.Contains(matrix[t][i]))
                    {
                        c.Add(matrix[t][i]);
                    }
                    else
                    {
                        return false;
                    }
                }
                for (int t = 1; t <= len; t++)
                {
                    if (!c.Contains(t))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        //Title: 1290. Convert Binary Number in a Linked List to Integer
        //Link: https://leetcode.com/problems/convert-binary-number-in-a-linked-list-to-integer
        //Tags: Linked List, Math
        public static int GetDecimalValue(ListNode head)
        {
            string num = "";
            while (head != null)
            {
                num += head.val.ToString();
                head = head.next;
            }
            return Convert.ToInt32(num, 2);
        }
        //Title: 206. Reverse Linked List
        //Link: https://leetcode.com/problems/reverse-linked-list
        //Tags: Linked List, Recursion
        public static ListNode ReverseList(ListNode head)
        {
            List<int> a = new List<int>();
            ListNode b = null;
            while (head != null)
            {
                a.Add(head.val);
                head = head.next;
            }
            for (int i = a.Count - 1; i >= 0; i--)
            {
                AddLink(ref b, a[i]);
            }
            return b;
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
        //Title: 21. Merge Two Sorted Lists
        //Link: https://leetcode.com/problems/merge-two-sorted-lists
        //Tags: Linked List, Recursion
        public static ListNode MergeTwoLists(ListNode list1, ListNode list2)
        {
            SortedDictionary<int, int> a = new SortedDictionary<int, int>();
            ListNode head = null;
            while (list1 != null)
            {
                int listval = list1.val;
                if (!a.ContainsKey(listval))
                {
                    a.Add(listval, 1);
                }
                else
                {
                    a[listval]++;
                }
                list1 = list1.next;
            }
            while (list2 != null)
            {
                int listval = list2.val;
                if (!a.ContainsKey(listval))
                {
                    a.Add(listval, 1);
                }
                else
                {
                    a[listval]++;
                }
                list2 = list2.next;
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
        //Title: 83. Remove Duplicates from Sorted List
        //Link: https://leetcode.com/problems/remove-duplicates-from-sorted-list
        //Tags: Linked List
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
            foreach (KeyValuePair<int, int> b in a)
            {
                AddLink(ref ans, b.Key);
            }
            return ans;
        }
        //Title: 203. Remove Linked List Elements
        //Link: https://leetcode.com/problems/remove-linked-list-elements
        //Tags: Linked List, Recursion
        public static ListNode RemoveElements(ListNode head, int val)
        {
            List<int> a = new List<int>();
            ListNode b = null;
            while (head != null)
            {
                int nodeval = head.val;
                if (nodeval != val)
                {
                    a.Add(nodeval);
                }
                head = head.next;
            }
            for (int i = 0; i < a.Count; i++)
            {
                AddLink(ref b, a[i]);
            }
            return b;
        }
        //Title: 414. Third Maximum Number
        //Link: https://leetcode.com/problems/third-maximum-number
        //Tags: Array, Sorting
        public static int ThirdMax(int[] nums)
        {
            SortedList<int, int> a = new SortedList<int, int>(new ReverseSortComparer());
            for (int i = 0; i < nums.Length; i++)
            {
                if (!a.ContainsKey(nums[i]))
                {
                    a.Add(nums[i], 1);
                }
            }
            if (a.Count < 3)
            {
                return a.Keys[0];
            }
            else
            {
                return a.Keys[2];
            }
        }
        //Title: 876. Middle of the Linked List
        //Link: https://leetcode.com/problems/middle-of-the-linked-list
        //Tags: Linked List, Two Pointers
        public static ListNode MiddleNode(ListNode head)
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
            if (counter % 2 == 0)
            {
                half = counter / 2;
            }
            else
            {
                half = (((counter + 1) / 2) - 1);
            }
            for (int i = 0; i < half; i++)
            {
                q.Dequeue();
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
        //Title: 168. Excel Sheet Column Title
        //Link: https://leetcode.com/problems/excel-sheet-column-title
        //Tags: Math, String
        public static string ConvertToTitle(int columnNumber)
        {
            int a = 0, b = 0, c = 0, d = 0, e = 0, f = 0, g = 0;
            string final = "";
            char[] v = new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
            while (columnNumber > 26)
            {
                f++;
                columnNumber -= 26;
                if (f == 27)
                {
                    e++;
                    f = 1;
                }
                if (e == 27)
                {
                    d++;
                    e = 1;
                }
                if (d == 27)
                {
                    c++;
                    d = 1;
                }
                if (c == 27)
                {
                    b++;
                    c = 1;
                }
                if (b == 27)
                {
                    a++;
                    b = 1;
                }
            }
            g = columnNumber;
            if (a > 0)
            {
                final += v[a - 1];
            }
            if (b > 0)
            {
                final += v[b - 1];
            }
            if (c > 0)
            {
                final += v[c - 1];
            }
            if (d > 0)
            {
                final += v[d - 1];
            }
            if (e > 0)
            {
                final += v[e - 1];
            }
            if (f > 0)
            {
                final += v[f - 1];
            }
            if (g > 0)
            {
                final += v[g - 1];
            }
            return final;
        }
        //Title: 171. Excel Sheet Column Number
        //Link: https://leetcode.com/problems/excel-sheet-column-number
        //Tags: Math, String
        public static int TitleToNumber(string columnTitle)
        {
            char[] v = new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
            int len = columnTitle.Length - 1;
            int total = 0;
            for (int i = 0; i < columnTitle.Length; i++)
            {
                int f1 = Array.IndexOf(v, columnTitle[i]) + 1;
                int f2 = (int)Math.Pow(26, len);
                total += (f1) * (f2);
                len -= 1;
            }
            return total;
        }
        //Title: 938. Range Sum of BST
        //Link: https://leetcode.com/problems/range-sum-of-bst
        //Tags: Tree, Depth-First Search, Binary Search Tree, Binary Tree
        public static int RangeSumBST(TreeNode root, int low, int high)
        {
            Queue<TreeNode> q = new Queue<TreeNode>();
            List<int> a = new List<int>();
            int sum = 0;
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
            foreach (int i in a)
            {
                if (low <= i && i <= high)
                {
                    sum += i;
                }
            }
            return sum;
        }
        //Title: 2236. Root Equals Sum of Children
        //Link: https://leetcode.com/problems/root-equals-sum-of-children
        //Tags: Tree, Binary Tree
        public static bool CheckTree(TreeNode root)
        {
            if (root.left.val + root.right.val == root.val)
            {
                return true;
            }
            return false;
        }
        //Title: 104. Maximum Depth of Binary Tree
        //Link: https://leetcode.com/problems/maximum-depth-of-binary-tree
        //Tags: Tree, Depth-First Search, Breadth-First Search, Binary Tree
        public static int MaxDepth(TreeNode root)
        {
            if (root == null) return 0;
            Queue<TreeNode> q = new Queue<TreeNode>();
            List<List<int>> a = new List<List<int>>();
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
            return a.Count;
        }
        //Title: 637. Average of Levels in Binary Tree
        //Link: https://leetcode.com/problems/average-of-levels-in-binary-tree
        //Tags: Tree, Depth-First Search, Breadth-First Search, Binary Tree
        public static IList<double> AverageOfLevels(TreeNode root)
        {
            Queue<TreeNode> q = new Queue<TreeNode>();
            List<List<int>> a = new List<List<int>>();
            List<double> c = new List<double>();
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
            foreach (List<int> j in a)
            {
                long sum = 0;
                foreach (int i in j)
                {
                    sum += i;
                }
                c.Add((double)sum / (double)j.Count);
            }
            return c;
        }
        //Title: 222. Count Complete Tree Nodes
        //Link: https://leetcode.com/problems/count-complete-tree-nodes
        //Tags: Binary Search, Bit Manipulation, Tree, Binary Tree
        public static int CountNodes(TreeNode root)
        {
            if (root == null) return 0;
            int counter = 0;
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
                counter++;
            }
            return counter;
        }
        //Title: 88. Merge Sorted Array
        //Link: https://leetcode.com/problems/merge-sorted-array
        //Tags: Array, Two Pointers, Sorting
        public static void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            List<int> a = new List<int>();
            for (int i = 0; i < m; i++)
            {
                a.Add(nums1[i]);
            }
            for (int i = 0; i < n; i++)
            {
                a.Add(nums2[i]);
            }
            a.Sort();
            int index = 0;
            foreach (int i in a)
            {
                nums1[index] = i;
                index++;
            }
        }
        #endregion
    }
}