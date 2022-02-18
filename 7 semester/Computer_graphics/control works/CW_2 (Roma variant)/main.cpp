#include "glut.h"
#include <string>
#include <iostream>
#include <ostream>
using namespace std;

GLUnurbsObj* nobj;

const int n = 5;
const int k = 5;

// 6 опорных точек
GLfloat ctlarray[][2] =
{ {-0.9, 0.0},
{-0.75, 0.6},
{-0.6, 0.0},
{-0.45, 0.6},
{-0.3, 0.0},
{-0.15, 0.6} };

// 12 точек
GLfloat ctlarray_surface[][4] =
{ {-0.9, 0.0, 0.0, 1.0},
{-0.9, 0.0, 1.0, 1.0},
{-0.75, 0.6, 0.0, 1.0},
{-0.75, 0.6, 1.0, 1.0},
{-0.6, 0.0, 0.0, 1.0},
{-0.6, 0.0, 1.0, 1.0},
{-0.45, 0.6, 0.0, 1.0},
{-0.45, 0.6, 1.0, 1.0},
{-0.3, 0.0, 0.0, 1.0},
{-0.3, 0.0, 1.0, 1.0},
{-0.15, 0.6, 0.0, 1.0},
{-0.15, 0.6, 1.0, 1.0} };

// 12 точек
GLfloat ctlarray_surface2[][3] =
{ {-0.9, 0.0, 0.0},
{-0.9, 0.0, 1.0},
{-0.75, 0.6, 0.0},
{-0.75, 0.6, 1.0},
{-0.6, 0.0, 0.0},
{-0.6, 0.0, 1.0},
{-0.45, 0.6, 0.0},
{-0.45, 0.6, 1.0},
{-0.3, 0.0, 0.0},
{-0.3, 0.0, 1.0},
{-0.15, 0.6, 0.0},
{-0.15, 0.6, 1.0} };

// knot.Length = n + k + 1
float* knot_2 = new float[4]{ 0.0, 0.0, 1.0, 1.0 };
float* Roma_knot_2 = new float[3]{ 0.0, 1.0, 2.0 };
float* knot_3 = new float[15]{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 };
float* knot_31 = new float[15]{ 0, 0, 0, 0, 0, 0, 0, 1, 2, 2, 2, 2, 2, 2, 2 };
float* knot_32 = new float[16]{ 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1 };
float* knot_4 = new float[11]{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
float* knot_41 = new float[11]{ 0, 0, 1, 2, 3, 4, 5, 6, 7, 8, 8 };

float* Roma_knot_1;

void Get_knot(string type_of_function, float*& knot)
{
	//float* knot = new float[k + n + 1];
	knot = new float[n + k + 1];
	if (type_of_function == "periodic")
	{
		for (int i = 0; i < k + n + 1; i++)
		{
			knot[i] = i;
		}
	}
	if (type_of_function == "uniform")
	{
		for (int i = 1; i <= k + n + 1; i++)
		{
			if ((i >= 1) && (i <= k))
			{
				knot[i - 1] = 0;
			}
			if ((i >= k + 1) && (i <= n + 1))
			{
				knot[i - 1] = i - k;
			}
			if ((i >= n + 2) && (i <= n + k + 1))
			{
				knot[i - 1] = n - k + 2;
			}
		}
	}
	cout << "knot = " << endl;
	cout << "Array size knot = " << sizeof(knot) << endl;
}

void init()
{
	Get_knot("uniform", Roma_knot_1);
	for (int i = 0; i < n + k + 1; i++)
	{
		cout << Roma_knot_1[i] << " ";
	}
	cout << endl;

	// Инициализация NURBS-кривой
	nobj = gluNewNurbsRenderer();
	gluGetNurbsProperty(nobj, GLU_SAMPLING_TOLERANCE, new GLfloat(25.0));
}

void Display()
{
	glClear(GL_COLOR_BUFFER_BIT);

	glRotatef(0.1, 0.5, 0.4, 0);

	// Отрисовка кривой в пространстве
	glColor3f(1.0, 0.0, 0.0);
	gluBeginSurface(nobj);
	//gluNurbsSurface(nobj, 15, knot_31, 4, knot_2, 4 * 2, 4, &ctlarray_surface[0][0], 7, 2, GL_MAP2_VERTEX_4); // Неправильный вариант
	//gluNurbsSurface(nobj, 16, knot_32, 4, knot_2, 4 * 2, 4, &ctlarray_surface[0][0], 8, 2, GL_MAP2_VERTEX_4); // Мой правильный вариант
	gluNurbsSurface(nobj, 12, Roma_knot_1, 4, knot_2, 3 * 2, 4, &ctlarray_surface[0][0], 6, 2, GL_MAP2_VERTEX_4); // Ромин вариант
	gluEndSurface(nobj);

	//// Отрисовка ломаных кривых в пространстве
	//glColor3f(0.0, 0.0, 1.0);
	//gluBeginSurface(nobj);
	//gluNurbsSurface(nobj, 10, knot_41, 4, knot_2, 4 * 2, 4, &ctlarray_surface[0][0], 2, 2, GL_MAP2_VERTEX_4);
	//gluEndSurface(nobj);

	glColor3f(0, 0, 1);
	glPointSize(4.0);
	glBegin(GL_POINTS);

	// Вывод на экран опорных точек
	for (int i = 0; i < n + 1; i++)
	{
		glVertex2d(ctlarray[i][0], ctlarray[i][1]);
	}
	glEnd();

	glutPostRedisplay();
	glutSwapBuffers();
}

int main(int arcg, char** arcv)
{
	glutInit(&arcg, arcv);
	init();

	glutInitDisplayMode(GLUT_RGBA | GLUT_DOUBLE);
	glutInitWindowSize(960, 480);

	glutInitWindowPosition(100, 100);
	glutCreateWindow(" ");
	glClearColor(1, 1, 1, 1);
	glutDisplayFunc(Display);
	glutMainLoop();
}