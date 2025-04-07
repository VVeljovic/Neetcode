
var nums = new int[] { 3,0,1,0 };
var k = 1;

TopKFrequent(nums, k);
int[] TopKFrequent(int[] nums, int k)
{
    var numbersWithFreq = nums.GroupBy(x => x).ToDictionary(g => g.Key, g =>g.Count());

    var priorQueue = new PriorityQueue<int, int>();
    foreach(var kvp in numbersWithFreq)
    {
        if(priorQueue.Count < k)
        {
            priorQueue.Enqueue(kvp.Key, kvp.Value);
        }


        else 
        {
            if(priorQueue.TryPeek(out var el, out var prior))
            {
                if(kvp.Value > prior)
                {
                    priorQueue.Dequeue();

                    priorQueue.Enqueue(kvp.Key, kvp.Value);
                }
            }
        }
    }

    var result = new int[priorQueue.Count];
    var len = priorQueue.Count;
    for (var item = 0; item < len; item ++)
    {
        result[item] = priorQueue.Dequeue();
    }
    return result;
}