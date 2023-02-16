using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CodingTest_LeeDongChan
{
	class DefenceGame
	{
		/// <summary>
		/// 프리패스권을 가장 효율적으로 사용하는 방법을 묻는 문제다.
		/// 우선순위 큐를 사용해 어려운 난이도 중 가장 쉬운놈을 뱉는 식으로 만들면 될것 같다.
		/// 
		/// 1. 우선순위 큐를 생성하고 k개만큼 우선순위 큐에 먼저 넣는다.
		/// 2. 우선순위 큐에서 가장작은 값보다 큰값이 들어오면 서로 바꿔준다.
		/// 3. 현재라운드를 깼는지 확인한다.
		/// </summary>
		/// <param name="n"></param>
		/// <param name="k"></param>
		/// <param name="enemy"></param>
		/// <returns></returns>
		
		public class Node
		{
			int data;
			Node prev;
			Node next;

		}
		public class priorityQ
		{
			Node[] nodes;
		}
		public int solution(int n, int k, int[] enemy)
		{
			int answer = 0;
			int defenceAfterCount = n;
			List<int> kList = new List<int>();
			PriorityQueue<int, int> priorityQueue = new PriorityQueue<int, int>();

			for(int i = 0; i < enemy.Length; i++)
			{
				int enemyCount = enemy[i];

				// 1. k개만큼 우선순위 큐에 먼저 넣어둔다.
				if (priorityQueue.Count < k)
				{
					priorityQueue.Enqueue(enemyCount, enemyCount);
					answer += 1;
					continue;
				}
				// 2. 우선순위 큐에서 가장작은 값보다 큰값이 들어오면 서로 바꿔준다.
				else if (priorityQueue.Peek() < enemyCount)
				{
					enemyCount = priorityQueue.EnqueueDequeue(enemyCount, enemyCount);
				}

				// 3. 현재라운드를 깼는지 확인한다.
				defenceAfterCount -= enemyCount;
				if (defenceAfterCount < 0)
				{
					break;
				}
				else if (defenceAfterCount == 0)
				{
					answer += 1;
					break;
				}
				answer += 1;
			}

			return answer;
		}

		public int solution2(int n, int k, int[] enemy)
		{
			int answer = 0;
			int defenceAfterCount = n;
			List<int> kList = new List<int>();

			for (int i = 0; i < enemy.Length; i++)
			{
				int enemyCount = enemy[i];

				// 1. k개만큼 우선순위 큐에 먼저 넣어둔다.
				if (kList.Count < k)
				{
					kList.Add(enemyCount);
					answer += 1;
					continue;
				}
				int min = kList.OrderBy(x => x).First();
				// 2. 우선순위 큐에서 가장작은 값보다 큰값이 들어오면 서로 바꿔준다.
				if (min < enemyCount)
				{
					kList.Add(enemyCount);
					enemyCount = min;
					kList.Remove(min);
				}

				// 3. 현재라운드를 깼는지 확인한다.
				defenceAfterCount -= enemyCount;
				if (defenceAfterCount < 0)
				{
					break;
				}
				else if (defenceAfterCount == 0)
				{
					answer += 1;
					break;
				}
				answer += 1;
			}

			return answer;
		}

		class PriorityQueue
		{
			// 힙 트리는 배열로 관리할 수 있다.
			List<int> _heap = new List<int>();

			public void Push(int data)
			{
				// 힙의 맨 끝에 새로운 데이터를 삽입한다.
				_heap.Add(data);

				int now = _heap.Count - 1;  // 추가한 노드의 위치. 힙의 맨 끝에서 시작.

				// 위로 도장 깨기 시작
				while (now > 0)
				{
					int parent = (now - 1) / 2;  // 부모 노드
					if (_heap[now] > _heap[parent])  // 부모 노드와 비교
						break;

					// 두 값을 서로 자리 바꿈
					int temp = _heap[now];
					_heap[now] = _heap[parent];
					_heap[parent] = temp;

					// 검사 위치로 이동한다.
					now = parent;
				}
			}

			public int Pop()  // 최소값(루트)을 뽑아낸다.
			{
				// 반환할 데이터를 따로 저장
				int ret = _heap[0];

				// 마지막 데이터를 루트로 이동시킨다.
				int lastIndex = _heap.Count - 1;
				_heap[0] = _heap[lastIndex];
				_heap.RemoveAt(lastIndex);
				lastIndex--;

				// 아래로 도장 깨기 시작
				int now = 0;
				while (true)
				{
					int left = 2 * now + 1;
					int right = 2 * now + 2;

					int next = now;
					// 왼쪽 값이 현재값보다 크면, 왼쪽으로 이동
					if (left <= lastIndex && _heap[next] > _heap[left])
						next = left;
					// 오른쪽 값이 현재값(왼쪽 이동 포함)보다 크면, 오른쪽으로 이동
					if (right <= lastIndex && _heap[next] > _heap[right])
						next = right;

					// 왼쪽/오른쪽 모두 현재값보다 작으면 종료
					if (next == now)
						break;

					// 두 값 서로 자리 바꿈
					int temp = _heap[now];
					_heap[now] = _heap[next];
					_heap[next] = temp;

					// 검사 위치로 이동한다.
					now = next;
				}
				

				return ret;
			}

			public int Peek()
			{
				return _heap[0];
			}
			public int Count()
			{
				return _heap.Count;
			}
		}

		public int solution3(int n, int k, int[] enemy)
		{
			int answer = 0;
			int defenceAfterCount = n;
			PriorityQueue priorityQueue = new PriorityQueue();

			for (int i = 0; i < enemy.Length; i++)
			{
				int enemyCount = enemy[i];

				// 1. k개만큼 우선순위 큐에 먼저 넣어둔다.
				if (priorityQueue.Count() < k)
				{
					priorityQueue.Push(enemyCount);
					answer += 1;
					continue;
				}
				int min = priorityQueue.Peek();
				// 2. 우선순위 큐에서 가장작은 값보다 큰값이 들어오면 서로 바꿔준다.
				if (min < enemyCount)
				{
					priorityQueue.Push(enemyCount);
					enemyCount = priorityQueue.Pop();
				}

				// 3. 현재라운드를 깼는지 확인한다.
				defenceAfterCount -= enemyCount;
				if (defenceAfterCount < 0)
				{
					break;
				}
				else if (defenceAfterCount == 0)
				{
					answer += 1;
					break;
				}
				answer += 1;
			}

			return answer;
		}

	}
}
