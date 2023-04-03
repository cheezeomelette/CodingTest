using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTest_LeeDongChan
{
	class BilliardsPractice
	{
		/// <summary>
		/// 1. 두개의 공이 벽까지의 거리가 가장 짧은 벽을 선택
		/// 2. 예외처리
		/// 3. 두 공이 벽까지의 거리를 합한다.
		/// 4. 벽에 투영했을 때 공사이의 거리
		/// 6. 피타고라스 정리로 움직인 거리 구함
		/// 
		/// 알아야 하는 값
		/// 1. 두 공과 벽사이 거리
		/// 2. 두 공을 벽에 수직으로 붙였을 때 사이의 거리
		/// 
		/// 예외처리 
		/// 1. 가는 길에 공이 있을 경우 다른 벽을 쿠션으로 사용한다.
		/// </summary>
		public int[] solution(int m, int n, int startX, int startY, int[,] balls)
		{
			int[] answer = new int[] { };

			int startXToLeft = startX;
			int startXToRight = m  - startX;
			int startYToDown = startY;
			int startYToUp = n  - startY;

			List<int> ansList= new List<int>();
			for (int i = 0; i < balls.GetLength(0); i++)
			{
				int destX = balls[i, 0];
				int destY = balls[i, 1];

				int destXToLeft = destX;
				int destXToRight = m - destX;
				int destYToDown = destY;
				int destYToUp = n - destY;

				int minX = Math.Min(startXToLeft + destXToLeft, startXToRight + destXToRight);
				int minY = Math.Min(startYToDown + destYToDown, startYToUp + destYToUp);

				int left = (int)Math.Pow((startXToLeft + destXToLeft), 2) + (int)Math.Pow(startY - destY, 2);
				int right = (int)Math.Pow((startXToRight + destXToRight), 2) + (int)Math.Pow(startY - destY, 2);
				int down = (int)Math.Pow((startYToDown + destYToDown), 2) + (int)Math.Pow(startX - destX, 2);
				int up = (int)Math.Pow((startYToUp + destYToUp), 2) + (int)Math.Pow(startX - destX, 2);

				int ans;
				// 예외처리 
				if (destX == startX)
				{
					if (destY > startY)
						ans = Math.Min(Math.Min(left, right), down);
					else
						ans = Math.Min(Math.Min(left, right), up);
				}
				else if (destY == startY)
				{
					if (destX > startX)
						ans = Math.Min(Math.Min(up, down), left);
					else
						ans = Math.Min(Math.Min(up, down), right);
				}
				else
				{
					ans = Math.Min(Math.Min(left, right), Math.Min( up, down));
				}
				ansList.Add(ans);
			}
			answer = ansList.ToArray();
			return answer;
		}
	}
}
