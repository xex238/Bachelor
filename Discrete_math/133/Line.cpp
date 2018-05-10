#include <iostream>
#include "Line.h"
using namespace std;

Line::Line(int x) // Åñëè ìû çàäà¸ì òîëüêî äëèíó
{
	mas = new char[x];
	length = x;
	mas[0] = 'A';
}

Line::Line(int x, char y) // Åñëè ìû çàäà¸ì äëèíó è íà÷àëüíóþ áóêâó
{
	mas = new char[x];
	length = x;
	mas[0] = y;
}

void Line::Filling()
{
	for (int i = 0; i < (length - 1) / 2; i++)
	{
		if (mas[i] == 'A')
		{
			mas[2 * i + 1] = 'B';
			mas[2 * i + 2] = 'C';
			continue;
		}
		if ((mas[i] == 'B') || (mas[i] == 'C'))
		{
			mas[2 * i + 1] = 'A';
			mas[2 * i + 2] = ' ';
			continue;
		}
		if (mas[i] == ' ')
		{
			mas[2 * i + 1] = ' ';
			mas[2 * i + 2] = ' ';
		}
	}
}

void Line::Print()
{
	cout << "This is main massiv:" << endl;
	for (int i = 0; i < length; i++)
	{
		cout << mas[i];
	}
	cout << endl;
}

int Line::Find_cycle(int x)
{
	int from{ 0 };
	int to{ 0 };
	int count{ 0 };
	for (int i = 0; i < x; i++)
	{
		from = from + pow(2, i);
	}
	to = from + pow(2, x) - 1;
	for (int i = from; i < to; i++)
	{
		if (mas[0] == mas[i])
		{
			count++;
		}
	}
	return count;
}
