//GL_AMBIENT - интенсивность рассеянного света
//GL_DIFFUSE - интенсивность диффузного света
//GL_SPECULAR - интенсивность отражённого (зеркального) света
#include "glut.h"

GLUquadricObj* theqw;
GLfloat lightposition[] = { 0, 0, 10, 0 };
GLfloat ModelAmbient[] = { 1, 1, 1, 1 };
GLfloat white_light[] = { 1, 0, 0, 1 };
void init()
{
	glClearColor(0, 0, 0, 1);
	theqw = gluNewQuadric();
	glEnable(GL_DEPTH_TEST);

	//glEnable(GL_COLOR_MATERIAL);

	glLightfv(GL_LIGHT0, GL_AMBIENT, white_light);
	glLightfv(GL_LIGHT0, GL_DIFFUSE, white_light);
	glLightfv(GL_LIGHT0, GL_SPECULAR, white_light);
	glLightModelfv(GL_LIGHT_MODEL_AMBIENT, ModelAmbient);

	glLightfv(GL_LIGHT0, GL_POSITION, lightposition);
	glEnable(GL_LIGHTING);
	glEnable(GL_LIGHT0);
	glMatrixMode(GL_PROJECTION);
	glLoadIdentity();
	glFrustum(-5, 5, -5, 5, 5, 15);
	glMatrixMode(GL_MODELVIEW);
	glFrontFace(GL_CW);
}
float r = 1;
void Display()
{
	r += 0.1;
	glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);
	//glColor3f(1, 0, 0);
	glPushMatrix();
	glTranslated(0, 0, -10);
	glRotated(r, 5, 5, 5);
	glutSolidTeapot(4);
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
	glutDisplayFunc(Display);

	glutMainLoop();
}