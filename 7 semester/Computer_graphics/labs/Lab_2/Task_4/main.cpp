#include "glut.h"

GLUquadricObj* theqw;
GLfloat lightposition[] = { 0, 0, 10, 0 };
void init()
{
	glClearColor(0.1, 0.98, 0.3, 1);
	theqw = gluNewQuadric();
	glEnable(GL_DEPTH_TEST);

	glEnable(GL_COLOR_MATERIAL);
	glLightfv(GL_LIGHT0, GL_POSITION, &lightposition[0]);
	glEnable(GL_LIGHTING);
	glEnable(GL_LIGHT0);
	glMatrixMode(GL_PROJECTION);
	glLoadIdentity();
	glFrustum(-5, 5, -5, 5, 5, 15);
	glMatrixMode(GL_MODELVIEW);
}

void Display()
{
	glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);
	//glRotatef(1.0, 1.0, 1.0, 1.0);
	glColor3f(1, 0, 0);
	glPushMatrix();
	glTranslated(0, 0, -10);
	glRotatef(30.0, 1.0, 1.0, 0);
	glutSolidCube(5);
	//gluSphere(theqw, 2.5, 50, 50);
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