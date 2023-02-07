using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTest_LeeDongChan
{
	class CreateStarNode
	{
		/// <summary>
		/// 1. n개 직선 배열에서 2개 조합
		/// 2. 평행한지 확인 후 계속
		/// 3. 정수인지 체크하기
		/// 4. 직선의 교점 구하기
		/// 
		/// 5. 교점의 최대 x, y 최소 x, y 구하기
		/// 6. 최대 최소를 바탕으로 배열 생성
		/// 7. 교점이 있으면 * 없으면 .
		/// </summary>

		struct Cordinate
		{
			public int x;
			public int y;
			public Cordinate(int x, int y)
			{
				this.x = x;
				this.y = y;
			}
		}
		public string[] solution(int[,] line)
		{
			string[] answer = new string[] { };
			List<Cordinate> crossNode = new List<Cordinate>();
			int minX = int.MaxValue;
			int minY = int.MaxValue;
			int maxX = int.MinValue;
			int maxY = int.MinValue;

			// 1. n개 직선 배열에서 2개 조합
			for (int i = 0; i < line.GetLength(0) - 1; i++)
			{
				for (int j = i + 1; j < line.GetLength(0); j++)
				{
					// 2. 평행한지 확인 후 계속
					int denominator = line[i, 0] * line[j, 1] - line[i, 1] * line[j, 0];
					if (denominator == 0)
						continue;
					int numeratorA = line[i, 1] * line[j, 2] - line[i, 2] * line[j, 1];
					int numeratorB = line[i, 2] * line[j, 0] - line[i, 0] * line[j, 2];

					// 3. 정수인지 체크하기
					if (numeratorA % denominator != 0 || numeratorB % denominator != 0)
						continue;

					// 4.직선의 교점 구하기
					int x = numeratorA / denominator;
					int y = numeratorB / denominator;
					crossNode.Add(new Cordinate(x, y));

					// 5. 교점의 최대 x, y 최소 x, y 구하기
					minX = Math.Min(x, minX);
					minY = Math.Min(y, minY);
					maxX = Math.Max(x, maxX);
					maxY = Math.Max(y, maxY);
				}
			}

			// 6. 최대 최소를 바탕으로 배열 생성
			List<string> plotList = new();
			StringBuilder builder = new StringBuilder();
			for (int y = maxY; y > minY - 1; y--)
			{
				for(int x = minX; x < maxX + 1; x++)
				{
					// 7. 교점이 있으면 * 없으면 .
					char point = crossNode.Contains(new(x, y)) ? '*' : '.' ;
					builder.Append(point);
				}
				plotList.Add(builder.ToString());
				builder.Clear();
			}

			answer = plotList.ToArray();
			return answer;
		}


	}
}
