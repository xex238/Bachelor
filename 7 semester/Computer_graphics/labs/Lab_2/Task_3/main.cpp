#include "glut.h"
#include "stdio.h"

GLUquadricObj* theqw;
//GLfloat lightposition[] = { 13, 0, -5, 0 };
void init()
{
	glClearColor(0.1, 0.98, 0.3, 1);
	theqw = gluNewQuadric();
	glEnable(GL_DEPTH_TEST);

	glEnable(GL_COLOR_MATERIAL);
	//glLightfv(GL_LIGHT0, GL_POSITION, lightposition);
	glEnable(GL_LIGHTING);
	glEnable(GL_LIGHT0);
	glMatrixMode(GL_PROJECTION);
	glLoadIdentity();
	glOrtho(-5, 5, -5, 5, 5, 15);
	glMatrixMode(GL_MODELVIEW);
}

void Display()
{
	glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);
	glColor3f(1, 0, 0);
	glPushMatrix();
	glTranslated(0, 0, -16);
	glRotatef(45.0, 1.0, 1.0, 1.0);
	glutSolidTeapot(3);
	glPopMatrix();
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
	//glLoadIdentity();
	glutDisplayFunc(Display);
	glutMainLoop();
}