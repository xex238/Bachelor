#include "glut.h"
#include <string>
#include <iostream>
#include <ostream>
using namespace std;

// Для Безье 4 точки
const int n = 4;
GLfloat ctlarray[n + 1][2] = { {-0.9, 0.0},
{-0.6, -0.5},
{-0.3, 0.7},
{-0.2, 0.3} };

double t_step = 0.001;
double* t_mas = new double[1 / t_step];

double** J_matrix = new double* [1 / t_step];
double* P_x = new double[1 / t_step];
double* P_y = new double[1 / t_step];

// Вычисление факториала
int factorial(int x)
{
	if (x == 0)
		return 1;
	return x * factorial(x - 1);
}

void init()
{
	int counter = 0;
	for (double t = 0; t < 1; t = t + t_step)
	{
		t_mas[counter] = t;
		J_matrix[counter] = new double[n];
		counter++;
	}

	for (int i = 0; i < 1 / t_step; i++)
	{
		for (int j = 0; j < n; j++)
		{
			J_matrix[i][j] = factorial(n - 1) * pow(t_mas[i], j) * pow(1 - t_mas[i], n - 1 - j) / (factorial(j) * factorial(n - 1 - j));
		}
	}

	for (int i = 0; i < 1 / t_step; i++)
	{
		double value_x = 0;
		double value_y = 0;
		for (int j = 0; j < n; j++)
		{
			value_x += ctlarray[j][0] * J_matrix[i][j];
			value_y += ctlarray[j][1] * J_matrix[i][j];
		}
		P_x[i] = value_x;
		P_y[i] = value_y;
	}
}

void Display()
{
	glClear(GL_COLOR_BUFFER_BIT);

	glColor3f(0, 0, 1);
	glPointSize(4.0);
	glBegin(GL_POINTS);

	// Вывод на экран опорных точек
	for (int i = 0; i < n; i++)
	{
		glVertex2d(ctlarray[i][0], ctlarray[i][1]);
	}
	glEnd();

	glPointSize(3.0);
	glColor3f(0, 1, 0);
	glBegin(GL_POINTS);

	// Вывод на экран опорных точек
	for (int i = 0; i < 1 / t_step; i++)
	{
		glVertex2d(P_x[i], P_y[i]);
	}
	glEnd();

	glutPostRedisplay();
	glutSwapBuffers();
}

int main(int arcg, char** arcv)
{
	glutInit(&arcg, arcv);

	glutInitDisplayMode(GLUT_RGBA | GLUT_DOUBLE);
	glutInitWindowSize(960, 480);

	glutInitWindowPosition(100, 100);
	glutCreateWindow(" ");
	glClearColor(1, 1, 1, 1);
	init();
	glutDisplayFunc(Display);
	glutMainLoop();
}