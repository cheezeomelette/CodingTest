using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTest_LeeDongChan
{
	public class SmallSubstring
	{
		public int solution(string t, string p)
		{
			int answer = 0;
			string compareStr;

			for (int i = 0; i < t.Length - p.Length + 1; i++)
			{
				compareStr = t.Substring(i, p.Length);
				if (Compare(compareStr, p))
					answer++;
			}
			return answer;
		}

		private bool Compare(string comp, string stand)
		{
			for (int i = 0; i < comp.Length; i++)
			{
				if (comp[i] < stand[i])
					return true;
				else if (comp[i] == stand[i])
					continue;
				else
					return false;
			}
			return true;
		}
	}
}
