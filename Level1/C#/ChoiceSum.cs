using System.Collections.Generic;
using System.Linq;

namespace CodingTest_LeeDongChan
{
	class ChoiceSum
	{
		public int[] solution(int[] numbers)
		{
			List<int> list = new List<int>();				
			for (int i = 0; i < numbers.Length - 1; i++)
			{
				for (int j = i+1; j < numbers.Length; j++)      // 배열에서 2개의 수를 선택하는 모든 경우의 수
				{
					list.Add(numbers[i] + numbers[j]);			// list에 2개의 수를 더한 값을 추가한다
				}
			}

			list.Sort();										// 오름차순으로 정렬
			return list.Distinct().ToArray();					// 중복을 제거하고 int[]형식으로 리턴
		}
	}
}
