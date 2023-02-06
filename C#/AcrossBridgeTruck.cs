using System;

namespace CodingTest_LeeDongChan
{
	public class AcrossBridgeTruck
	{
        public int solution(int bridge_length, int weight, int[] truck_weights)
        {
            int answer = 0;
            int bridgeWeight = 0;
            Queue<int> queue = new Queue<int>();
            for (int i = 0; i < truck_weights.Length; i++)
            {
                if (queue.Count >= bridge_length)
                    bridgeWeight -= queue.Dequeue();
                if (bridgeWeight + truck_weights[i] <= weight)
                {
                    queue.Enqueue(truck_weights[i]);
                    bridgeWeight += truck_weights[i];
                    answer += 1;
                }
                else
                {
                    while (queue.Count < bridge_length)
                    {
                        queue.Enqueue(0);
                        answer += 1;
                    }
                    i -= 1;
                }
            }
            answer += bridge_length;
            return answer;
        }
    }                                                                         
}																				
