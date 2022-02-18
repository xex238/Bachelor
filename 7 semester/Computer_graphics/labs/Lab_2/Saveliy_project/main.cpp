#include <iostream>
#include <ostream>

using namespace std;

int main()
{
	double s = 0.93;
	for (int i = 0; i <= 100; i++)
	{
		s = s * 1.023;
	}
	cout << s;
}