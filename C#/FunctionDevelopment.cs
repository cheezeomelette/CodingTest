using System;

namespace CodingTest_LeeDongChan
{
	public class FunctionDevelopment
	{
        public int[] solution(int[] progresses, int[] speeds)
        {
            List<int> answer = new List<int>();
            int day = 0;
            int complete = 0;

            for (int i = 0; i < progresses.Length; i++)
            {
                if (progresses[i] + speeds[i] * day >= 100)
                {
                    complete++;
                    continue;
                }
                else if (progresses[i] + speeds[i] * day < 100 && complete == 0)
                {
                    day = (int)MathF.Ceiling((100 - progresses[i]) / (float)speeds[i]);
                    complete++;
                }
                else
                {
                    answer.Add(complete);
                    complete = 0;
                    day = (int)MathF.Ceiling((100 - progresses[i]) / (float)speeds[i]);
                    complete++;
                }
            }
            answer.Add(complete);
            return answer.ToArray();
        }
    }                                                                         
}																				
