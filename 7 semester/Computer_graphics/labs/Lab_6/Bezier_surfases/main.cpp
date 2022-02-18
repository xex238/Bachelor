// Поверхность Безье
#include "glut.h"
#include <string>
#include <iostream>
#include <ostream>
#include <math.h>
#include <stdio.h>
using namespace std;

// Полигональная сетка
const int n = 3;
const int m = 3;

GLfloat B[][4][2] = {
	{ { -0.75, -0.75 },{ -0.75, -0.25 },{ -0.75, 0.25 },{ -0.75, 0.75 } } ,
	{ { -0.25, -0.75 },{ -0.25, -0.25 },{ -0.25, 0.25 },{ -0.25, 0.75 } },
	{ { 0.25, -0.75 },{ 0.25, -0.25 },{ 0.25, 0.25 },{ 0.25, 0.75 } },
	{ { 0.0, 0.0 },{ 0.75, -0.25 },{ 0.75, 0.25 },{ 0.75, 0.75 } }
};

double B_sum = 0;

double u_step = 0.01;
double w_step = 0.01;

double** J = new double* [1 / u_step + 1];
double** K = new double* [1 / w_step + 1];

double** Q = new double* [1 / u_step + 1];

double*** P = new double** [1 / u_step + 1];

// Вычисление факториала
int factorial(int x)
{
	if (x == 0)
		return 1;
	return x * factorial(x - 1);
}

// Вычисление значения для P_u_w для x
double get_P_u_w_x(double u, double w)
{
	double* mas_1 = new double[4];
	mas_1[0] = pow(1 - u, 3);
	mas_1[1] = 3 * pow(1 - u, 2) * u;
	mas_1[2] = 3 * (1 - u) * u * u;
	mas_1[3] = pow(u, 3);

	double* mas_2 = new double[4];
	mas_2[0] = pow(1 - w, 3);
	mas_2[1] = 3 * pow(1 - w, 2) * w;
	mas_2[2] = 3 * (1 - w) * w * w;
	mas_2[3] = pow(w, 3);

	double* helper_mas = new double[4];

	for (int i = 0; i < 4; i++)
	{
		helper_mas[i] = 0;
		for (int j = 0; j < 4; j++)
		{
			helper_mas[i] = helper_mas[i] + mas_1[j] * B[j][i][0];
		}
	}

	double P_u_w = 0;
	for (int i = 0; i < 4; i++)
	{
		P_u_w = P_u_w + helper_mas[i] * mas_2[i];
	}
	return P_u_w;
}

// Вычисление значения для P_u_w для y
double get_P_u_w_y(double u, double w)
{
	double* mas_1 = new double[4];
	mas_1[0] = pow(1 - u, 3);
	mas_1[1] = 3 * pow(1 - u, 2) * u;
	mas_1[2] = 3 * (1 - u) * u * u;
	mas_1[3] = pow(u, 3);

	double* mas_2 = new double[4];
	mas_2[0] = pow(1 - w, 3);
	mas_2[1] = 3 * pow(1 - w, 2) * w;
	mas_2[2] = 3 * (1 - w) * w * w;
	mas_2[3] = pow(w, 3);

	double* helper_mas = new double[4];

	for (int i = 0; i < 4; i++)
	{
		helper_mas[i] = 0;
		for (int j = 0; j < 4; j++)
		{
			helper_mas[i] = helper_mas[i] + mas_1[j] * B[j][i][1];
		}
	}

	double P_u_w = 0;
	for (int i = 0; i < 4; i++)
	{
		P_u_w = P_u_w + helper_mas[i] * mas_2[i];
	}
	return P_u_w;
}

void init()
{
	// Инициализируем массив J
	int counter = 0;
	for (double u = 0; u <= 1; u = u + u_step)
	{
		J[counter] = new double[n + 1];
		counter++;
	}

	// Инициализируем массив K
	counter = 0;
	for (double w = 0; w <= 1; w = w + w_step)
	{
		K[counter] = new double[m + 1];
		counter++;
	}

	// Заполнение матрицы J
	counter = 0;
	for (double u = 0; u <= 1; u = u + u_step)
	{
		for (int i = 0; i <= n; i++)
		{
			J[counter][i] = factorial(n) * pow(u, i) * pow(1 - u, n - i) / (factorial(i) * factorial(n - i));
		}
		counter++;
	}

	// Заполнение матрицы K
	counter = 0;
	for (double w = 0; w <= 1; w = w + w_step)
	{
		for (int j = 0; j <= m; j++)
		{
			K[counter][j] = factorial(m) * pow(w, j) * pow(1 - w, m - j) / (factorial(j) * factorial(m - j));
		}
	}

	// Подсчёт значений для P
	counter = 0;
	for (double u = 0; u <= 1; u = u + u_step)
	{
		P[counter] = new double* [1 / w_step + 1];
		int counter_2 = 0;
		for (double w = 0; w <= 1; w = w + w_step)
		{
			P[counter][counter_2] = new double[2];
			P[counter][counter_2][0] = get_P_u_w_x(u, w);
			P[counter][counter_2][1] = get_P_u_w_y(u, w);
			counter_2++;
		}
		counter++;
	}
}

void Display()
{
	glClear(GL_COLOR_BUFFER_BIT);

	glPointSize(3.0);
	glColor3f(0, 1, 0);
	glBegin(GL_POINTS);

	int counter = 0;
	for (double u = 0; u <= 1; u = u + u_step)
	{
		int counter_2 = 0;
		for (double w = 0; w <= 1; w = w + w_step)
		{
			glVertex3d(P[counter][counter_2][0], P[counter][counter_2][1], 0);
			counter_2++;
		}
		counter++;
	}

	glEnd();
	glFlush();

	glutPostRedisplay();
	glutSwapBuffers();
}

int main(int arcg, char** arcv)
{
	init();
	glutInit(&arcg, arcv);

	glutInitDisplayMode(GLUT_RGBA | GLUT_DOUBLE);
	glutInitWindowSize(960, 480);

	glutInitWindowPosition(100, 100);
	glutCreateWindow(" ");
	glClearColor(1, 1, 1, 1);
	glutDisplayFunc(Display);
	glutMainLoop();
}