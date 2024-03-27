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
    #endregion
}
