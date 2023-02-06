using System.Linq;

namespace CodingTest_LeeDongChan
{
	class FindElseOneNumber
	{
		public int solution(int n)
		{
			int[] arr = Enumerable.Range(2, n - 1).ToArray();		// 순회를 돌기위한 배열 생성

			var ans = from num in arr				// arr에 있는 값들중
					  where n % num == 1			// n을 나눈 나머지값이 1인
					  select num;					// num을 선택해서 ans에 넣는다.

			return ans.Min();						// ans값들 중 가장 작은값을 return
		}
	}
}
