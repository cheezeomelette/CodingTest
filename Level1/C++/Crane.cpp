#include <vector>
#include <stack>
using namespace std;

int solution(vector<vector<int>> board, vector<int> moves) {
    int answer = 0;
    int a = board[0][1];
    stack<int> st;

    for (int i = 0; i < moves.size(); i++)
    {
        for (int j = 0; j < board.size(); j++)
        {
            int val = board[j][moves[i] - 1];
            if (val != 0)
            {
                if (st.size() == 0)
                    st.push(val);
                else if (val == st.top())
                {
                    answer += 2;
                    st.pop();
                }
                else
                {
                    st.push(val);
                }
                board[j][moves[i] - 1] = 0;
                break;
            }
        }
    }
    return answer;
}