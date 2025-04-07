using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neetcode.Arrays___Hashing
{
    public sealed class Arrays
    {

        public bool HasDuplicate(int[] nums)
        {
            var dictionary = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (dictionary.TryAdd(nums[i], i))
                {

                }
                else
                {
                    return true;
                }
            }

            return false;
        }

        public bool IsAnagram(string s, string t)
        {
            if (s.Length != t.Length)
            {
                return false;
            }
            var dictionary = new Dictionary<char, int>();
            foreach (var character in s)
            {
                if (dictionary.TryAdd(character, 1))
                {

                }
                else
                {
                    dictionary[character] = dictionary[character] + 1;
                }
            }

            for (int i = 0; i < t.Length; i++)
            {
                var slovo = t[i];
                var oldLen = t.Length;
                t = new string(t.Where(x => x != slovo).ToArray());
                var newLen = t.Length;

                if (dictionary.TryGetValue(slovo, out var value))
                {

                    if (value != oldLen - newLen)
                        return false;
                }

                else
                {
                    return false;
                }
            }
            return true;
        }

        public int[] TwoSum(int[] nums, int target)
        {
            var dictionary = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                if (dictionary.TryGetValue(target - nums[i], out var index))
                {
                    return new int[] {index, i};
                }

                else
                {
                    dictionary.TryAdd(nums[i], i);
                }
            }

            return null;
        }

        public List<List<string>> GroupAnagrams(string[] strs)
        {
            var dict = new Dictionary<string, List<string>>();
            var result = new List<List<string>>();

            if (strs.Length == 1)
            {
                result.Add(strs.ToList());

                return result;
            }

            foreach (var str in strs)
            {
                var key = "";
                for (var letter = 'a'; letter <= 'z'; letter++)
                {
                    var number = str.Where(x => x == letter).Count();
                    key += letter + number.ToString();
                }

                if (dict.TryGetValue(key, out var list))
                {
                    list.Add(str);
                }
                else
                {
                    var list2 = new List<string>();
                    list2.Add(str);
                    dict[key] = list2;
                }
            }

            foreach (var k in dict)
            {
                result.Add(k.Value);
            }
            return result;
        }

        public int[] TopKFrequent(int[] nums, int k)
        {
            var numbersWithFreq = nums.GroupBy(x => x).ToDictionary(g => g.Key, g => g.Count());

            var priorQueue = new PriorityQueue<int, int>();
            foreach (var kvp in numbersWithFreq)
            {
                if (priorQueue.Count < k)
                {
                    priorQueue.Enqueue(kvp.Key, kvp.Value);
                }


                else
                {
                    if (priorQueue.TryPeek(out var el, out var prior))
                    {
                        if (kvp.Value > prior)
                        {
                            priorQueue.Dequeue();

                            priorQueue.Enqueue(kvp.Key, kvp.Value);
                        }
                    }
                }
            }

            var result = new int[priorQueue.Count];
            var len = priorQueue.Count;
            for (var item = 0; item < len; item++)
            {
                result[item] = priorQueue.Dequeue();
            }
            return result;
        }
    }
}
