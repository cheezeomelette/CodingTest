#include<map>
#include <vector>
using namespace std;

int solution(vector<int> nums)
{
    int answer = 0;
    map<int, int> poketmon;

    for (int i = 0; i < nums.size(); i++)
    {
        if (poketmon.find(nums[i]) == poketmon.end())
        {
            poketmon.insert(nums[i], 1);
        }
        else
        {
            poketmon[nums[i]] += 1;
        }
    }
    answer = (poketmon.size() >= nums.size() / 2) ? (nums.size() / 2) : poketmon.size();


    return answer;
}