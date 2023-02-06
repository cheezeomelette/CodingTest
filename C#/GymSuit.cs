using System;

namespace CodingTest_LeeDongChan
{
    public class GymSuit
    {
        public int solution(int n, int[] lost, int[] reserve)
        {
            int answer = 0;
            int count = 0;
            for (int i = 0; i < lost.Length; i++)
            {
                for (int j = 0; j < reserve.Length; j++)
                {
                    if (lost[i] == reserve[j])
                    {
                        lost[i] = -100;
                        reserve[j] = -10;
                        count += 1;
                        break;
                    }
                }
            }
            Array.Sort(lost);
            Array.Sort(reserve);
            for (int i = 0; i < lost.Length; i++)
            {
                for (int j = 0; j < reserve.Length; j++)
                {
                    if (lost[i] - reserve[j] >= -1 && lost[i] - reserve[j] <= 1)
                    {
                        count += 1;
                        reserve[j] = -10;
                        break;
                    }
                }
            }
            answer = n - (lost.Length - count);
            return answer;
        }
    }

}
