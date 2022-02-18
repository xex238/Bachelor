#include "glut.h"
#include <string>
#include <iostream>
#include <ostream>
using namespace std;

GLUnurbsObj* nobj;

// 8 опорных точек
const int n = 7;
GLfloat ctlarray[n + 1][2] =
{ {-0.9, 0.0},
{-0.75, 0.6},
{-0.6, 0.0},
{-0.45, 0.6},
{-0.3, 0.0},
{-0.15, 0.6},
{0.0, 0.0},
{0.15, 0.6} };

// 16 точек
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
{-0.15, 0.6, 1.0, 1.0},
{0.0, 0.0, 0.0, 1.0},
{0.0, 0.0, 1.0, 1.0},
{0.15, 0.6, 0.0, 1.0},
{0.15, 0.6, 1.0, 1.0} };

// 16 точек
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
{-0.15, 0.6, 1.0},
{0.0, 0.0, 0.0},
{0.0, 0.0, 1.0},
{0.15, 0.6, 0.0},
{0.15, 0.6, 1.0} };

float* knot_2 = new float[4]{ 0.0, 0.0, 1.0, 1.0 }; // Верный knot
float* knot_22 = new float[4]{ 0.0, 0.0, 1.0, 1.0 };
float* knot_3 = new float[15]{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 };
float* knot_31 = new float[15]{ 0, 0, 0, 0, 0, 0, 0, 1, 2, 2, 2, 2, 2, 2, 2 };
float* knot_32 = new float[16]{ 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1 };
float* knot_4 = new float[11]{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
float* knot_41 = new float[11]{ 0, 0, 1, 2, 3, 4, 5, 6, 7, 8, 8 };

void init()
{
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
	//gluNurbsSurface(nobj, 15, knot_31, 4, knot_2, 4 * 2, 4, &ctlarray_surface[0][0], 7, 2, GL_MAP2_VERTEX_4);
	//gluNurbsSurface(nobj, 16, knot_32, 4, knot_2, 4 * 2, 4, &ctlarray_surface[0][0], 8, 2, GL_MAP2_VERTEX_4); // Верная отрисовка
	gluNurbsSurface(nobj, 16, knot_32, 4, knot_22, 4 * 2, 4, &ctlarray_surface[0][0], 8, 2, GL_MAP2_VERTEX_4); // Неверная отрисовка
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