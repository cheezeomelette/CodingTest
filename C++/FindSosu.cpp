#include <vector>
using namespace std;

int solution(int n) {
    int answer = 0;

    vector<int> sosu;

    for (int i = 2; i <= n; i++)
    {
        bool isSosu = true;
        for (int j = 2; j * j <= i; j++)
        {
            if (i % j == 0)
            {
                isSosu = false;
                break;
            }
        }
        if (isSosu)
            sosu.push_back(i);
    }
    return sosu.size();
}