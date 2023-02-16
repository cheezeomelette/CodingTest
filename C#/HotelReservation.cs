using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTest_LeeDongChan
{
	class HotelReservation
	{
		/// <summary>
		/// 1. 예약시간을 문자열에서 int값으로 변환한다.
		/// 2. 예약시간이 0시부터 24시까지 제한되어 있기 때문에 시간을 분단위로 통일해서 정리한다.
		/// 3. 정리한 예약시간을 예약 시작시간 기준으로 오름차순 정렬한다.
		/// 4. 예약된 방의 종료시간+10(청소시간)을 저장하는 리스트를 만들고
		/// 5. 예약된 방의 종료시간보다 시작시간이 늦다면 예약을 등록한다.
		/// 6. 예약된 방 리스트의 개수를 출력한다.
		/// </summary>

		public int solution(string[,] book_time)
		{
			int answer = 0;
			// 1. 예약시간을 문자열에서 int값으로 변환한다.
			int[][] parseData = ParseData(book_time);

			// 3. 정리한 예약시간을 예약 시작시간 기준으로 오름차순 정렬한다.
			int[][] sortData = parseData.OrderBy(bookTime => bookTime[0]).ToArray();
			// 4. 예약된 방의 종료시간+10(청소시간)을 저장하는 리스트를 만들고
			List<int> reservationList = new List<int>();

			for(int i = 0; i < sortData.Length; i++)
			{
				if (reservationList.Count == 0)
				{
					reservationList.Add(sortData[i][1] + 10);
					continue;
				}

				bool isUpdate = false;
				for (int j = 0; j < reservationList.Count; j++)
				{
					// 5. 예약된 방의 종료시간보다 시작시간이 늦다면 예약을 등록한다.
					if (reservationList[j] <= sortData[i][0])
					{
						reservationList[j] = sortData[i][1] + 10;
						isUpdate = true;
						break;
					}
				}
				if(!isUpdate)
				{
					reservationList.Add(sortData[i][1] + 10);
				}
			}
			// 6. 예약된 방 리스트의 개수를 출력한다.
			answer = reservationList.Count;
			return answer;
		}

		private int[][] ParseData(string[,] book_time)
		{
			List<int[]> list = new List<int[]>();

			for(int i = 0; i < book_time.GetLength(0); i++)
			{
				// 1. 예약시간을 문자열에서 int값으로 변환한다.
				string[] parseStartTime = book_time[i, 0].Split(':');
				string[] parseEndTime = book_time[i, 1].Split(':');
				// 2. 예약시간이 0시부터 24시까지 제한되어 있기 때문에 시간을 분단위로 통일해서 정리한다.
				int startTime = int.Parse(parseStartTime[0]) * 60 + int.Parse(parseStartTime[1]);
				int endTime = int.Parse(parseEndTime[0]) * 60 + int.Parse(parseEndTime[1]);
				list.Add(new int[2] {startTime,endTime});
			}

			return list.ToArray();
		}
	}
}
