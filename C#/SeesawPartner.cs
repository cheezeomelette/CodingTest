using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTest_LeeDongChan
{
	class SeesawPartner
	{
		/// <summary>
		/// 1. 중복을 제거하기 위해 몸무게를 key 중복 개수를 value로 하는 dictionary 생성한다.
		/// 2. key값을 선회하면서 key값의 4/3배, 3/2배, 2배 값이 dictionary에 있는지 확인하고 만약 있다면 각 weight의 value값을 곱해서 answer에 추가한다.
		/// 3. 같은 weight의 사람끼리 선택하는 경우를 추가한다.
		/// </summary>

		public long solution(int[] weights)
		{
			long answer = 0;

			// 1. 중복을 제거하기 위해 몸무게를 key 중복 개수를 value로 하는 dictionary 생성한다.
			Dictionary<int, int> weightPeople = new Dictionary<int, int>();
			foreach(int weight in weights)
			{
				if (weightPeople.ContainsKey(weight))
					weightPeople[weight] += 1;
				else
					weightPeople[weight] = 1;
			}

			foreach(int weight in weightPeople.Keys)
			{
				long count = weightPeople[weight];
				
				// 2. key값을 선회하면서 key값의 4/3배, 3/2배, 2배 값이 dictionary에 있는지 확인한다.
				if (weight % 3 == 0 && weightPeople.ContainsKey(weight * 4 / 3))
					answer += count * weightPeople[weight * 4 / 3];
				if(weight % 2 == 0 && weightPeople.ContainsKey(weight * 3 / 2))
					answer += count * weightPeople[weight * 3 / 2];
				if(weightPeople.ContainsKey(weight * 2))
					answer += count * weightPeople[weight * 2];

				// 3. 같은 weight의 사람끼리 선택하는 경우를 추가한다.
				answer += count * (count - 1) / 2;
			}
			return answer;
		}
	}
}
