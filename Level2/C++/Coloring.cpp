#include <vector>
#include <iostream>
using namespace std;

int max_y;
int max_x;
int max_size_of_one_area;
int cc;

void Find(vector<vector<int>>& picture, int y, int x, int target)
{
	if (picture[y][x] != target)
		return;
	picture[y][x] = -target;
	cc += 1;
	if (y < max_y - 1)
	{
		Find(picture, y + 1, x, target);
	}
	if (x < max_x - 1)
	{
		Find(picture, y, x + 1, target);
	}
	if (0 < y)
	{
		Find(picture, y - 1, x, target);
	}
	if (0 < x)
	{
		Find(picture, y, x - 1, target);
	}
	return;
}

vector<int> solution(int m, int n, vector<vector<int>> picture) {
	int number_of_area = 0;
	max_size_of_one_area = 0;
	max_y = m;
	max_x = n;
	cc = 0;
	for (int y = 0; y < picture.size(); y++)
	{
		for (int x = 0; x < picture[0].size(); x++)
		{
			if (picture[y][x] > 0)
			{
				//for (int i = 0; i < m; i++) {                     //출력해서 잘나오는지 확인
				//    for (int j = 0; j < n; j++) {
				//        cout << (*(picture.begin() + i))[j];
				//    }
				//    cout << endl;
				//}
				//cout << endl;
				Find(picture, y, x, picture[y][x]);
				max_size_of_one_area = max(max_size_of_one_area, cc);
				cc = 0;
				number_of_area += 1;
			}
		}
	}

	vector<int> answer(2);
	answer[0] = number_of_area;
	answer[1] = max_size_of_one_area;
	return answer;
}