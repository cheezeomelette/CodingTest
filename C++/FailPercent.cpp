#include<map>
#include<algorithm>
#include <vector>
#include <iostream>
using namespace std;

bool cmp(const pair<int, float>& a, const pair<int, float>& b) {
	if (a.second == b.second) return a.first < b.first;
	return a.second > b.second;
}

vector<int> solution(int N, vector<int> stages)
{
	vector<int> answer;
	map<int, int> intPair;
	map<int, float> percentPair;

	int count = stages.size();
	for (int i = 0; i < N; i++)
	{
		intPair[i + 1] = 0;
	}
	for (int i = 0; i < stages.size(); i++)
	{
		if (stages[i] <= N)
			intPair[stages[i]] += 1;
	}
	for (int i = 0; i < N; i++)
	{
		if (count == 0)
		{
			percentPair[i + 1] = 0;
			continue;
		}

		percentPair[i + 1] = (float)intPair[i + 1] / count;
		count -= intPair[i + 1];
	}
	vector<pair<int, float>> percent(percentPair.begin(), percentPair.end());
	sort(percent.begin(), percent.end(), cmp);

	for (int i = 0; i < percent.size(); i++)
	{
		answer.push_back(percent[i].first);
	}
	return answer;
}