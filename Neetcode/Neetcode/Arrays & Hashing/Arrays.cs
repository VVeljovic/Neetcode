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

    }
}
