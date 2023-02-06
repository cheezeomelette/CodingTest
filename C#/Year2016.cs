using System;

namespace CodingTest_LeeDongChan
{
	public class Year2016
	{
		public string solution(int a, int b)
		{
			DateTime dateTime = new DateTime(2016, a, b);                       // dateTime을 생성할 때 생성자에 2016년 a월 b일로 초기화함
			return dateTime.DayOfWeek.ToString().Substring(0, 3).ToUpper();     // dateTime.DayOfWeek를 문자열로 출력하면 Tuesday가 출력된다.
		}                                                                       // 우리가 원하는 TUE를 만들기 위해 Substring으로 0번째 인덱스부터 3글자만 자른다.
	}                                                                           // ToUpper()로 소문자를 대문자로 바꿔서 리턴한다.
}																				
