#include "glut.h"
#include <string>
#include <iostream>
#include <ostream>
using namespace std;

// 8 опорных точек
const int n = 7;
GLfloat ctlarray[n + 1][2] = { {-0.9, 0.0},
{-0.75, 0.6},
{-0.6, 0.0},
{-0.45, 0.6},
{-0.3, 0.0},
{-0.15, 0.6},
{0.0, 0.0},
{0.15, 0.6} };
// P(t)

const int k = 5;

// Количество строк n + 1
// Количество столбцов n_matrix_count_columns
double** N_matrix;
string type_of_function = "periodic"; // Тип базисной функции
//string type_of_function = "uniform";

double t_min = k - 1;
double t_max = n + 1;
double t_step = 0.01;
int n_matrix_count_lines = n + 1;
// Значения случайных цветов для отрисовки вспомогательных функций N
float** color_random_numbers = new float*[n_matrix_count_lines - 1];
const int n_matrix_count_columns = (t_max - t_min) / t_step;

// [n_matrix_count_columns][n + 1][2]
GLfloat** ctlarray_2 = new GLfloat*[n_matrix_count_columns];

double* t_mas = new double[n_matrix_count_columns];

int knot_size = k + n + 1;
double* knot = new double[knot_size];

// Линейная нормализация в пределах [0; 1]
void Linear_normalization_1()
{
	double max = t_mas[0];
	double min = t_mas[0];
	for (int i = 0; i < n_matrix_count_columns; i++)
	{
		if (t_mas[i] > max)
		{
			max = t_mas[i];
		}
		if (t_mas[i] < min)
		{
			min = t_mas[i];
		}
	}
	for (int i = 0; i < n_matrix_count_columns; i++)
	{
		t_mas[i] = (t_mas[i] - min) / (max - min);
	}
}

// Линейная нормализация в пределах [-1; 1]
void Linear_normalization_2()
{
	double max = t_mas[0];
	double min = t_mas[0];
	for (int i = 0; i < n_matrix_count_columns; i++)
	{
		if (t_mas[i] > max)
		{
			max = t_mas[i];
		}
		if (t_mas[i] < min)
		{
			min = t_mas[i];
		}
	}
	for (int i = 0; i < n_matrix_count_columns; i++)
	{
		t_mas[i] = 2 * ((t_mas[i] - min) / (max - min)) - 1;
	}
}

// x(i) - элементы вектора knot
// Получить значение N от заданных i, k и t
double N_i_k(const int i, const int k, const double t)
{
	if (k == 1)
	{
		if ((t >= knot[i]) && (t <= knot[i + 1]))
		{
			return 1;
		}
		else
		{
			return 0;
		}
	}
	else if(k > 1)
	{
		if ((knot[i + k - 1] - knot[i] != 0) && (knot[i + k] - knot[i + 1] != 0))
		{
			return ((((t - knot[i]) * N_i_k(i, k - 1, t)) / (knot[i + k - 1] - knot[i])) + (((knot[i + k] - t) * N_i_k(i + 1, k - 1, t)) / (knot[i + k] - knot[i + 1])));
		}
		else if ((knot[i + k - 1] - knot[i] == 0) && (knot[i + k] - knot[i + 1] == 0))
		{
			return 0;
		}
		else if (knot[i + k - 1] - knot[i] == 0)
		{
			return ((knot[i + k] - t) * N_i_k(i + 1, k - 1, t)) / (knot[i + k] - knot[i + 1]);
		}
		else if (knot[i + k] - knot[i + 1] == 0)
		{
			return ((t - knot[i]) * N_i_k(i, k - 1, t)) / (knot[i + k - 1] - knot[i]);
		}
	}
}

// Функция для генерации значений узлового вектора
double* Get_knot()
{
	if (type_of_function == "periodic")
	{
		for (int i = 0; i < knot_size; i++)
		{
			knot[i] = i;
		}
	}
	if (type_of_function == "uniform")
	{
		for (int i = 0; i < knot_size; i++)
		{
			if ((i >= 0) && (i <= k - 1))
			{
				knot[i] = 0;
			}
			if ((i >= k) && (i <= n))
			{
				knot[i] = i - k + 1;
			}
			if ((i >= n + 1) && (i <= n + k))
			{
				knot[i] = n - k + 2;
			}
		}
	}
	cout << "knot = " << endl;
	for (int i = 0; i < knot_size; i++)
	{
		cout << knot[i] << " ";
	}
	cout << endl;
	return knot;
}

double* Solve(int i)
{
	double* N = new double[n_matrix_count_columns];
	int counter = 0;
	for (double t = t_min; t <= t_max; t = t + t_step)
	{
		N[counter] = N_i_k(i - 1, k, t);
		counter++;
	}
	return N;
}

void init()
{
	// Генерируем значения узлового вектора
	knot = Get_knot();

	// Генерируем значения для t
	int counter = 0;
	for (double i = t_min; i < t_max; i = i + t_step)
	{
		t_mas[counter] = i;
		counter++;
	}

	// Линейная нормализация в пределах [-1; 1]
	Linear_normalization_2();
	//cout << "After normalization t_mas = " << endl;
	//for (int i = 0; i < n_matrix_count_columns; i++)
	//{
	//	cout << t_mas[i] << " ";
	//}
	//cout << endl;

	// Генерируем значения матрицы для N_i_k
	N_matrix = new double* [n + 1];
	for (int i = 1; i < n + 1; i++)
	{
		N_matrix[i - 1] = Solve(i);
	}

	// Генерация значений P(t)
	for (int i = 0; i < n_matrix_count_columns; i++)
	{
		ctlarray_2[i] = new GLfloat[2];
	}

	GLfloat x;
	GLfloat y;
	for (int i = 0; i < n_matrix_count_columns; i++)
	{
		x = 0;
		y = 0;
		for (int j = 0; j < n; j++)
		{
			x = x + ctlarray[j][0] * N_matrix[j][i];
			y = y + ctlarray[j][1] * N_matrix[j][i];
		}
		ctlarray_2[i][0] = x;
		ctlarray_2[i][1] = y;
	}

	for (int i = 0; i < n; i++)
	{
		ctlarray_2[i][0] = ctlarray[i][0] * N_matrix[i][counter];
		ctlarray_2[i][1] = ctlarray[i][0] * N_matrix[i][counter];
	}

	// Сдвигаем значения матрицы на 0,9 вниз
	for (int i = 0; i < n_matrix_count_lines - 1; i++)
	{
		for (int j = 0; j < n_matrix_count_columns; j++)
		{
			N_matrix[i][j] = N_matrix[i][j] - 0.9;
		}
	}

	// Выводим матрицу N_i_k на экран
	//cout << "N_matrix[0] = " << endl;
	//for (int i = 0; i < n_matrix_count_columns; i++)
	//{
	//	cout << N_matrix[1][i] << " ";
	//}

	// Случайная генерация цветов для базисных векторов
	for (int i = 0; i < n_matrix_count_lines - 1; i++)
	{
		color_random_numbers[i] = new float[3];
		color_random_numbers[i][0] = rand() / (float)RAND_MAX;
		color_random_numbers[i][1] = rand() / (float)RAND_MAX;
		color_random_numbers[i][2] = rand() / (float)RAND_MAX;
	}
}

void Display()
{
	glClear(GL_COLOR_BUFFER_BIT);

	glColor3f(0, 0, 1);
	glPointSize(4.0);
	glBegin(GL_POINTS);

	// Вывод на экран опорных точек
	for (int i = 0; i < n + 1; i++)
	{
		glVertex2d(ctlarray[i][0], ctlarray[i][1]);
	}
	glEnd();
	
	glColor3f(0, 1, 0);
	glPointSize(2.0);
	glBegin(GL_POINTS);

	// Вывод на экран базисных векторов
	for (int i = 0; i < n_matrix_count_lines - 1; i++)
	{
		glColor3f(color_random_numbers[i][0], color_random_numbers[i][1], color_random_numbers[i][2]);
		for (int j = 0; j < n_matrix_count_columns; j++)
		{
			glVertex2d(t_mas[j], N_matrix[i][j]);
		}
	}
	glEnd();

	glColor3f(1, 0, 0);
	glPointSize(3.0);
	glBegin(GL_POINTS);

	// Вывод на экран В-сплайна
	for (int i = 0; i < n_matrix_count_columns; i++)
	{
		glVertex2d(ctlarray_2[i][0], ctlarray_2[i][1]);
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