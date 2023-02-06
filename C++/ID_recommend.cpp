recommend#include <string>
#include <vector>
#include <algorithm>
#include <iostream>
using namespace std;

int index;

string solution(string new_id) {
    string answer = "";
    for (int i = 0; i < new_id.size(); i++)
    {
        char c = new_id[i];
        if (c >= 'A' && c <= 'Z')
            new_id[i] = c - ('A' - 'a');
    }
    for (int i = 0; i < new_id.size(); )
    {
        if ((new_id[i] >= 'a' && new_id[i] <= 'z') || (new_id[i] >= '0' && new_id[i] <= '9') || new_id[i] == '-' || new_id[i] == '_' || new_id[i] == '.')
        {
            i++;
            continue;
        }
        else
            new_id.erase(new_id.begin() + i);
    }
    for (int i = 1; i < new_id.size();)
    {
        if (new_id[i - 1] == '.' && new_id[i] == '.')
        {
            new_id.erase(new_id.begin() + i);
        }
        else
            i++;
    }

    if (new_id.length() > 0)
        if (new_id.front() == '.') new_id.erase(new_id.begin());

    if (new_id.length() > 0)
        if (answer[answer.length() - 1] == '.')
            answer.erase(answer.end() - 1);

    if (new_id.length() == 0)
        new_id = "a";

    if (new_id.length() >= 16) {
        while (new_id.length() != 15) {
            new_id.erase(new_id.begin() + 15);
        }
    }
    if (new_id.back() == '.') new_id.erase(new_id.end() - 1);

    if (new_id.length() <= 2) {
        while (new_id.length() != 3) {
            new_id += new_id.back();
        }
    }
    answer = new_id;
    return answer;
}
