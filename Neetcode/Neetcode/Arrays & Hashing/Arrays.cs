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


    }
}
