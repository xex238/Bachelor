//#include <conio.h>
//#include "windows.h"
#include <iostream>
#include <ctime>
#include "omp.h"
using namespace std;

void mSort_parallel(float* a, const long n)
{
	long i = 0;
	long j = n;
	float mid = a[n / 2];

	do
	{
		while (a[i] < mid) i++;
		while (a[j] > mid) j--;

		if (i <= j)
		{
			swap(a[i], a[j]);
			i++; j--;
		}
	} while (i <= j);

    #pragma omp parallel sections num_threads(2)
	{
        #pragma omp section
		{
			if (j > 0)
			{
				mSort_parallel(a, j);
			}
		}
        #pragma omp section
		{
			if (n > i)
			{
				mSort_parallel(a + i, n - i);
			}
		}
	}
}
void mSort_serial(float* a, const long n)
{
	long i = 0;
	long j = n;
	float mid = a[n / 2];

	do
	{
		while (a[i] < mid) i++;
		while (a[j] > mid) j--;

		if (i <= j)
		{
			swap(a[i], a[j]);
			i++; j--;
		}
	} while (i <= j);

	if (j > 0)
	{
		mSort_parallel(a, j);
	}
	if (n > i)
	{
		mSort_parallel(a + i, n - i);
	}
}

int main()
{
	const int n{ 1000000 };

	// float a[] = { 1, 4, 3, 5, 1, 2, 3, 5, 2, 10 };
	// float b[] = { 1.3, 4.3, 12.2, 23.6, 32.4 };
	float* c = new float[n];
	float* c_copy = new float[n];

	float start_time{ 0 };
	float end_time{ 0 };

	for (int i = 0; i < n; i++)
	{
		c[i] = rand() % 100;
	}
	c_copy = c;

	start_time = clock();
	mSort_parallel(c, n);
	end_time = clock();
	cout << "Time taken in millisecs with parallel computing: " << (end_time - start_time) << endl;

	//for (int i = 0; i < n; i++)
	//{
	//	cout << c[i] << " ";
	//}
	//cout << endl;

	c = c_copy;

	start_time = clock();
	mSort_serial(c, n);
	end_time = clock();
	cout << "Time taken in millisecs with serial computing: " << (end_time - start_time) << endl;

	//for (int i = 0; i < n; i++)
	//{
	//	cout << c[i] << " ";
	//}
	//cout << endl;

	cin.get();
	return 0;
}

