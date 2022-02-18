//#include <gl/glut.h>
#include "glut.h"
// Вывод изображения на экран
void Display()
{
	glClear(GL_COLOR_BUFFER_BIT);
	glColor3f(0, 1, 0);
	glBegin(GL_LINES);
	glVertex2d(0, 0);
	glVertex2d(0.5, 0.0);
	glEnd();

	// Обновление окна
	glutPostRedisplay();
	glutSwapBuffers();
}

void main()
{
	// Задаём параметры окна
	glutInitDisplayMode(GLUT_RGBA | GLUT_DOUBLE);
	// Задаём размеры окна
	glutInitWindowSize(480, 480);
	// Задаём позицию окна
	glutInitWindowPosition(100, 100);
	// Создание окна
	glutCreateWindow(" ");
	glClearColor(0.9, 0.5, 0.75, 1);
	// Задаём функцию обратного вызова изображения на экран
	glutDisplayFunc(Display);
	// Отображение окна
	glutMainLoop();
}