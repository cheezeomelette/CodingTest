#include <string>
#include <iostream>
#include <math.h>
using namespace std;

string solution(int n) {
	string answer = "";
	//3진법으로 바꾸고 2의x승으로 나타낸다 
	while (n > 0)
	{
		n -= 1;
		int i = n % 3;
		double num = pow(2, i);
		n /= 3;
		answer.insert(answer.begin(), int(num) + '0');
	}
	return answer;
}