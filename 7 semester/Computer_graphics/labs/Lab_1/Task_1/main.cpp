//#include <gl/glut.h>
#include "glut.h"
// Вывод изображения на экран
void Display()
{
	glClear(GL_COLOR_BUFFER_BIT);
	glColor3f(0, 1, 0);
	glPointSize(5); // При отрисовке точек - задание размера точек
	glLineWidth(2); // При отрисовке линий - ширина линии
	glPolygonMode(GL_FRONT_AND_BACK, GL_LINE); // При отрисовке треугольника - отрисовка только очертаний
	//glEnable(GL_LINE_STIPPLE);
	glBegin(GL_QUADS);

	// Отрисовка точек (GL_POINTS)
	//glColor3d(1, 0, 0);
	//glVertex2d(0, 0);
	//glVertex2d(-0.5, -0.5);

	// 2d линия (GL_LINES)
	//glVertex2d(0, 0.5);
	//glVertex2d(0.5, 0.0);

	// 3d линия с заменой цветов (GL_LINES)
	//glColor3d(1, 1, 1);
	//glVertex3d(0, 0, 0);
	//glColor3d(0, 0, 0);
	//glVertex3d(0.5, 0.5, 0.5);

	glVertex2d(0, 0);
	glVertex2d(0.5, 0);
	glVertex2d(0.5, 0.5);
	glVertex2d(0, 0.5);

	glEnd();

	// Обновление окна
	glutPostRedisplay();
	glutSwapBuffers();
}

void main(int argc, char** argv)
{
	glutInit(&argc, argv);
	// Задаём параметры окна
	glutInitDisplayMode(GLUT_RGBA | GLUT_DOUBLE);
	// Задаём размеры окна
	glutInitWindowSize(480, 480);
	// Задаём позицию окна
	glutInitWindowPosition(100, 100);
	// Создание окна
	glutCreateWindow("");
	glClearColor(0.9, 0.5, 0.75, 1);
	// Задаём функцию обратного вызова изображения на экран
	glutDisplayFunc(Display);
	// Отображение окна
	glutMainLoop();
}