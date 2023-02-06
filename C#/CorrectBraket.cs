using System;

namespace CodingTest_LeeDongChan
{
	public class CorrectBraket
	{
        public bool solution(string s)
        {
            bool answer = true;
            Stack<char> stack = new Stack<char>();
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(')
                    stack.Push(s[i]);
                else if (s[i] == ')')
                {
                    if (stack.Count > 0)
                        stack.Pop();
                    else return false;
                }

            }
            if (stack.Count > 0)
                return false;
            return answer;
        }
    }                                                                         
}																				
