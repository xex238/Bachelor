// #include<gl/glut.h>
#include "glut.h"
// Объявляется указатель с именем nobj, который указывает на структуру LUnurbsObj
GLUnurbsObj* nobj;
// Массив точек определяющего многоугольника
GLfloat ctlarray[][3] = { {-0.9, -0.8, 0.0}, {-0.2, 0.8, 0.0}, {0.2, -0.5, 0.0}, {0.9, 0.8, 0.0} };
void init(void)
{
	glClearColor(1, 1, 1, 1);
	// Создаётся NURBS-объект
	nobj = gluNewNurbsRenderer();
	gluNurbsProperty(nobj, GLU_SAMPLING_TOLERANCE, 25.0);
}

void Display()
{
	// Массив, содержащий значения открытого равномерного узлового вектора
	GLfloat knot[] = { 0.0, 0.0, 0.0, 1.0, 2.0, 2.0, 2.0 };
	glClear(GL_COLOR_BUFFER_BIT);
	glLineWidth(3.0);
	glColor3f(0, 0.3, 1);
	// Генерация отображений NURBS кривой
	gluNurbsCurve(nobj, 7, knot, 3, &ctlarray[0][0], 3, GL_MAP1_VERTEX_3);
	glPointSize(4.0);
	glColor3f(0.0, 0.0, 1);
	glBegin(GL_POINTS);
	for (int i = 0; i < 4; i++)
	{
		glVertex3f(ctlarray[i][0], ctlarray[i][1], ctlarray[i][2]);
	}
	glEnd();
	glFlush();
}

void main(int argc, char **argv)
{
	glutInit(&argc, argv);
	glutInitDisplayMode(GLUT_RGBA | GLUT_SINGLE);
	glutInitWindowSize(480, 480);
	glutInitWindowPosition(100, 100);
	glutCreateWindow(" ");
	init();
	glutDisplayFunc(Display);
	glutMainLoop();
}