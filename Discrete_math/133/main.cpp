#include "Line.h"
#include <math.h>
#include <iostream>
using namespace std;

int Length_calculation(int N)
{
	int length{ 0 };
	for (int i = 1; i <= N; i++)
	{
		length += pow(2, i);
	}
	return length + 1;
}

int main()
{
	int N{ 0 };
	cout << "Enter the length of the route:" << endl;
	cin >> N;
	Line line = Line(Length_calculation(2*N));
	line.Filling();
	line.Print();
	cout << "The starting point is A. Let us find the number of closed routes of length " << 2*N << ":" << endl;
	cout << line.Find_cycle(2*N) << endl;
}
