//#include<gl/glut.h>
#include "glut.h"

void Draw_cube(int x, int y, int z, int length)
{
	// Рисуем заднюю грань
	glBegin(GL_LINE_STRIP);
	glVertex3f(x, y, z);
	glVertex3f(x + length, y, z);
	glVertex3f(x + length, y + length, z);
	glVertex3f(x, y + length, z);
	glVertex3f(x, y, z);
	glEnd();

	// Рисуем переднюю грань
	glBegin(GL_LINE_STRIP);
	glVertex3f(x, y, z + length);
	glVertex3f(x + length, y, z + length);
	glVertex3f(x + length, y + length, z + length);
	glVertex3f(x, y + length, z + length);
	glVertex3f(x, y, z + length);
	glEnd();

	// Рисуем недостающие рёбра
	glBegin(GL_LINES);
	glVertex3f(x, y, z);
	glVertex3f(x, y, z + length);

	glVertex3f(x + length, y, z);
	glVertex3f(x + length, y, z + length);

	glVertex3f(x + length, y + length, z);
	glVertex3f(x + length, y + length, z + length);

	glVertex3f(x, y + length, z);
	glVertex3f(x, y + length, z + length);
	glEnd();
}

void Draw_cube(int length)
{
	// Рисуем заднюю грань
	glBegin(GL_LINE_STRIP);
	glVertex3f(0, 0, 0);
	glVertex3f(length, 0, 0);
	glVertex3f(length, length, 0);
	glVertex3f(0, length, 0);
	glVertex3f(0, 0, 0);
	glEnd();

	// Рисуем переднюю грань
	glBegin(GL_LINE_STRIP);
	glVertex3f(0, 0, length);
	glVertex3f(length, 0, length);
	glVertex3f(length, length, length);
	glVertex3f(0, length, length);
	glVertex3f(0, 0, length);
	glEnd();

	// Рисуем недостающие рёбра
	glBegin(GL_LINES);
	glVertex3f(0, 0, 0);
	glVertex3f(0, 0, length);

	glVertex3f(length, 0, 0);
	glVertex3f(length, 0, length);

	glVertex3f(length, length, 0);
	glVertex3f(length, length, length);

	glVertex3f(0, length, 0);
	glVertex3f(0, length, length);
	glEnd();
}

void Display()
{
	glClear(GL_COLOR_BUFFER_BIT);
	glColor3f(1, 1, 0);
	glRotatef(20, 1, 1, 0); // Поворот(градус, ось x, ось y, ось z) (1, 1, 0)
	//glRotated(25, 1, 1, 0);

	Draw_cube(0, 0, 0, 50);

	glRotatef(-20, 1, 1, 0);
	glRotatef(-20, 1, 1, 0);
	Draw_cube(-50, 0, 0, 50); // (вправо, вверх, вперёд)

	//glutPostRedisplay();
	glutSwapBuffers();
}

void main(int argc, char** argv)
{
	glutInit(&argc, argv);
	glutInitDisplayMode(GLUT_RGBA | GLUT_DOUBLE);
	glutInitWindowSize(480, 480);
	glutInitWindowPosition(100, 100);
	glutCreateWindow(" ");
	glClearColor(1, 0.5, 0.75, 0);
	glLoadIdentity(); // Рекомендуется использовать
	glOrtho(-100, 100, -100, 100, -100, 100); // Установка максимальных и минимальных координат
	//glOrtho(-75, 75, -75, 75, -75, 75); // Установка максимальных и минимальных координат
	glutDisplayFunc(Display);
	glutMainLoop();
}