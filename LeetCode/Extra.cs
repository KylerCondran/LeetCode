using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class ReverseSortComparer : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            return y.CompareTo(x);
        }
    }
    public class ReverseSortLongComparer : IComparer<long>
    {
        public int Compare(long x, long y)
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
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }
    public class PreSortItem
    {
        public BigInteger Key { get; set; }
        public int Index { get; set; }
    }
    public class BookRange
    {
        public int start { get; set; }
        public int end { get; set; }
    }
    public sealed class Pair : IEquatable<Pair>
    {
        public int A { get; }
        public int B { get; }

        public Pair(int a, int b)
        {
            A = a;
            B = b;
        }

        public bool Equals(Pair other)
        {
            if (other is null) return false;
            return A == other.A && B == other.B;
        }

        public override bool Equals(object obj) => Equals(obj as Pair);

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + A.GetHashCode();
                hash = hash * 23 + B.GetHashCode();
                return hash;
            }
        }
    }
}