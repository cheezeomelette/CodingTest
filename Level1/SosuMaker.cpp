//#include<iostream>
//#include<vector>
//using namespace std;
//
//int solution(vector<int> nums) 
//{
//    int answer = 0;
//
//    for (int i = 0; i < nums.size()-2; i++)
//    {
//        for (int j = i + 1; j < nums.size() - 1; j++)
//        {
//            for (int k = j + 1; k < nums.size(); k++)
//            {
//                int num = nums[i] + nums[j] + nums[k];
//                bool isSosu = true;
//                for (int a = 2; a * a <= num; a++)
//                {
//                    if (num % a == 0)
//                    {
//                        isSosu = false;
//                        break;
//                    }
//                }
//                if (isSosu)
//                    answer++;
//            }
//        }
//    }
//    return answer;
//}
