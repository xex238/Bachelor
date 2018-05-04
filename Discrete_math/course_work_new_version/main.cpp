#include <iostream>
#include "cows_and_bulls.h"
using namespace std;

int main()
{
	int count_of_numbers{ 0 };
	cout << "Enter count of numbers" << endl;
	cin >> count_of_numbers;

	while ((count_of_numbers <= 3) || (count_of_numbers > 10))
	{
		cout << "Your data is wrong. Try again" << endl;
		cin >> count_of_numbers;
	}

	Cows_and_bulls cb = Cows_and_bulls(count_of_numbers);

	while (!cb.Pick_step())
	{

	}
}
