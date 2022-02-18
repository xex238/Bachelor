#include "glut.h"

GLUquadricObj* theqw;
GLfloat lightposition[] = { 13, 0, -5, 0 };
void init()
{
	glClearColor(0.1, 0.98, 0.3, 1);
	theqw = gluNewQuadric();
	glEnable(GL_DEPTH_TEST);

	glEnable(GL_COLOR_MATERIAL);
	glLightfv(GL_LIGHT0, GL_POSITION, lightposition);
	glEnable(GL_LIGHTING);
	glEnable(GL_LIGHT0);
}

void Display()
{
	glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);
	glRotatef(1.0, 1.0, 1.0, 1.0);
	glColor3f(1, 0, 0);
	glutSolidTeapot(0.3);
	glutPostRedisplay();
	glutSwapBuffers();
}

void main(int arcg, char** arcv)
{
	glutInit(&arcg, arcv);
	glutInitDisplayMode(GLUT_RGBA | GLUT_DOUBLE | GLUT_DEPTH);
	glutInitWindowSize(480, 480);
	glutInitWindowPosition(100, 100);
	glutCreateWindow("My_window");
	init();
	glutDisplayFunc(Display);
	glutMainLoop();
}