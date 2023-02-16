using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTest_LeeDongChan
{
	class PseudoCantorBitstring
	{
		/// <summary>
		/// 2 : 1 : 2 의 비율로 1 0 1이 반복적으로 나타나는 규칙이 있다.
		/// 시작 인덱스와 종료 인덱스 사이의 1의 갯수는 전체 1의 갯수에서 인덱스 바깥부분을 뺀 수와 같다.
		/// l/5의 에 들어있는 1의 갯수는 5의 n-1승 이다.
		/// 1. 시작부터 지정 구간까지 1의 개수를 구하는 재귀함수를 만든다.
		/// 1-1. 재귀함수가 끝나는 조건을 설정한다.
		/// 1-2. 비트열을 5^(n-1)로 나누어준다.(5등분)
		/// 1-3. 나누었을 때 중간은 0으로 채워져 있기 때문에 3이상은 1을 빼준다.(5등분 하면 중간이 0이고 좌우대칭으로 [n-1비트열][n-1비트열]0...0[n-1비트열][n-1비트열] 형식이다.)
		/// 1-4. 몫을 계산해 준다. [n-1비트열][n-1비트열]0...0[n-1비트열][n-1비트열] 형식이기 때문에 n-1비트열의 1 개수 * 몫
		/// 1-5. 나머지를 계산해 준다. [n-1비트열][n-1비트열]0...0[n-1비트열][n-1비트열] 에서 [n-1비트열]은 [n-2비트열][n-2비트열]0...0[n-2비트열][n-2비트열]과 같이 생겼다.
		/// 1-추가. 나머지를 계산할 때 나머지가 0밖에 없는 중간부분이라면 계산하지 않는다.
		/// 1-6. 몫과 나머지를 더해서 리턴한다.
		/// 2. 뒤에서 부터 지정구간까지 1의 개수를 구하는 재귀함수를 만든다.
		/// 2-1. 1번과 동일하게 진행해 주는데 비트열이 좌우 대칭인 특징이 있어서 좌우를 반전시켜 준다.
		/// 2-2. 좌우 반전을 했기 때문에 시작부터 지정 구간까지 1의 개수를 구하는 재귀함수를 사용해주면 된다.(사실, 1. 함수만 사용해도 된다. 가독성을 위해)
		/// 3. 전체 1의 개수에서 속하지 않은 1을 빼준다.
		/// </summary>
		/// <param name="n"> 거듭제곱 수 </param>
		/// <param name="l"> 시작 인덱스 </param>
		/// <param name="r"> 종료 인덱스 </param>
		/// <returns></returns>
		public int solution(int n, long l, long r)
		{
			int answer = 0;
			long allOneCount = (long)Math.Pow(4, n);

			long front = GetFrontCount(n, l - 1);
			long behind = GetBehindCount(n, r);
			// 3. 전체 1의 개수에서 속하지 않은 1을 빼준다.
			answer = (int)(allOneCount - (front + behind));
			return answer;
		}
		// 1. 지정 구간까지 1의 개수를 구하는 함수를 만든다.
		private long GetFrontCount(int n, long index)
		{
			// 1-1. 재귀함수가 끝나는 조건을 설정한다.
			if (n == 0 || index == 0)
				return 0;
			long eMinus = (long)Math.Pow(5, n - 1);
			// 1-2. 비트열을 5^(n-1)로 나누어준다.(5등분)
			int x = (int)(index / eMinus);
			int y = x;
			// 1-3. 나누었을 때 중간은 0으로 채워져 있기 때문에 3이상은 1을 빼준다.(5등분 하면 중간이 0이고 좌우대칭으로 [n-1비트열][n-1비트열]0...0[n-1비트열][n-1비트열] 형식이다.)
			if (y >= 3)
			{
				y -= 1;
			}
			// 1-4. 몫을 계산해 준다. [n-1비트열][n-1비트열]0...0[n-1비트열][n-1비트열] 형식이기 때문에 n-1비트열의 1 개수 * 몫
			long Quotient = (long)Math.Pow(4, n - 1) * y;
			long remainder = 0;
			// 1-추가. 나머지를 계산할 때 나머지가 0밖에 없는 중간부분이라면 계산하지 않는다.
			if (x != 2)
			{
				// 1-5. 나머지를 계산해 준다. [n-1비트열][n-1비트열]0...0[n-1비트열][n-1비트열] 에서 [n-1비트열]은 [n-2비트열][n-2비트열]0...0[n-2비트열][n-2비트열]과 같이 생겼다.
				remainder = GetFrontCount(n - 1, index % eMinus);
			}
			// 1-6. 몫과 나머지를 더해서 리턴한다.
			return Quotient + remainder;
		}

		// 2. 뒤에서 부터 지정구간까지 1의 개수를 구하는 재귀함수를 만든다.
		private long GetBehindCount(int n, long index)
		{
			if (n == 0)
				return 0;
			long eMinus = (long)Math.Pow(5, n - 1);
			// 2-1. 1번과 동일하게 진행해 주는데 비트열이 좌우 대칭인 특징이 있어서 좌우를 반전시켜 준다.
			index = (long)Math.Pow(5, n) - index;
			int x = (int)(index / eMinus);
			int y = x;
			if (y >= 3)
			{
				y -= 1;
			}

			long Quotient = (long)Math.Pow(4, n - 1) * y;
			long remainder = 0;
			if (x != 2)
			{
				// 2-2. 좌우 반전을 했기 때문에 시작부터 지정 구간까지 1의 개수를 구하는 재귀함수를 사용해주면 된다.(사실, 1. 함수만 사용해도 된다. 가독성을 위해)
				remainder = GetFrontCount(n - 1, index % eMinus);
			}

			return Quotient + remainder;
		}
	}
}
