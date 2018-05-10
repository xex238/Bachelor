#ifndef Line_
#define Line_

class Line
{
public:
	Line(int x);
	Line(int x, char y);
	void Filling();
	void Print();
	int Find_cycle(int x);
private:
	char* mas;
	int length{ 0 };
};

#endif // !Line_
