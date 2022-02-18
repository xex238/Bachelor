#include "glut.h"
#include <string>
#include <iostream>
#include <ostream>
using namespace std;

void Get_knot(string type_of_function, const int k, const int n)
{
	int* knot = new int[k + n + 1];
	if (type_of_function == "periodic")
	{
		for (int i = 0; i < k + n + 1; i++)
		{
			knot[i] = i;
		}
	}
	if (type_of_function == "uniform")
	{
		for (int i = 0; i < k + n + 1; i++)
		{
			if ((i >= 1) && (i <= k))
			{
				knot[i] = 0;
			}
			if ((i >= k + 1) && (i <= n + 1))
			{
				knot[i] = i - k;
			}
			if ((i >= n + 2) && (i <= n + k + 1))
			{
				knot[i] = n - k + 2;
			}
		}
	}
	cout << "knot = " << endl;
	cout << "Размер массива knot = " << sizeof(knot) << endl;
}

void Solve()
{
	int k = 5;
	int n = 7;
	string type_of_function = "periodic";
	Get_knot(type_of_function, k, n);
}

void init()
{
	//if you need to do smth before Display() will be called
}

void Display()
{
	glClear(GL_COLOR_BUFFER_BIT);
	glColor3f(0, 0, 1);
	glPointSize(2.0);


	glBegin(GL_POINTS);

	//if you put some operation between [glBegin(GL_POINTS);] and [glEnd();], it will be repeated in infinite loop
	//so if you need smth once, don't put it here!!!!!

	//glVertex2d(x, y);

	glEnd();

	glutPostRedisplay();
	glutSwapBuffers();
}

int main()
{
	Solve();

	//glutInitDisplayMode(GLUT_RGBA | GLUT_DOUBLE);
	//glutInitWindowSize(480, 480);

	//glutInitWindowPosition(100, 100);
	//glutCreateWindow(" ");
	//glClearColor(1, 1, 1, 1);
	//init();
	//glutDisplayFunc(Display);
	//glutMainLoop();
	//return 0;
}