#include <iostream>
using namespace std;

char small_shift(char a, int n)
{
    
    int sm = (int)a + n;

    if (sm > 'z')
    {
        sm -= 26;
    }
    return (char)sm;
}

char big_shift(char A, int n)
{
    A += n;
    if (A > 'Z')
    {
        A -= 26;
    }

    return A;
}

string solution(string s, int n) {
    string answer = "";

    for (int i = 0; i < s.size(); i++)
    {
        if (s[i] >= 'a' && s[i] <= 'z')
            answer += small_shift(s[i], n);
        else if (s[i] >= 'A' && s[i] <= 'Z')
            answer += big_shift(s[i], n);
        else
            answer += s[i];
    }
    return answer;
}

int main()
{
    cout << solution("zZ", 25);
}