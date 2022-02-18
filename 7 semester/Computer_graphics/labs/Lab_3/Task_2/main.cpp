#include "glut.h"
GLUquadricObj* theqw;
void drawsphera()
{
	GLfloat koort[][2] = { {100, 140}, {120, 120}, {140, 100}, {160, 80} };
	for (int i = 0; i < 4; i++)
	{
		if (i == 0)
			glColor4f(1, 0, 0, 0.2);
		if (i == 1)
			glColor4f(0, 1, 1, 0.4);
		if (i == 2)
			glColor4f(0, 0, 1, 0.7);
		if (i == 3)
			glColor4f(0, 1, 0, 0.9);
		glPushMatrix();
		glTranslatef(koort[i][0], koort[i][1], -50);
		gluSphere(theqw, 40, 50, 50);
		glPopMatrix();
	}
}

void init()
{
	glClearColor(1.0, 1.0, 1.0, 1.0);
	GLfloat lightposition[] = { 0, 0, -100, 0 };
	theqw = gluNewQuadric();
	glEnable(GL_DEPTH_TEST);
	glLightfv(GL_LIGHT0, GL_POSITION, lightposition);
	glEnable(GL_LIGHTING);
	glEnable(GL_LIGHT0);
	glEnable(GL_COLOR_MATERIAL);
	glEnable(GL_BLEND);
	glBlendFunc(GL_SRC_ALPHA, GL_ONE_MINUS_SRC_ALPHA);
}

void Display()
{
	glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);
	glDepthMask(GL_FALSE);
	drawsphera();
	glDepthMask(GL_TRUE);
	glutPostRedisplay();
	glutSwapBuffers();
}

void reshape(int w, int h)
{
	glMatrixMode(GL_PROJECTION);
	glLoadIdentity();
	glOrtho(0, 240, 240, 0, 10, 240);
	glMatrixMode(GL_MODELVIEW);
}

void main(int argc, char** argv)
{
	glutInit(&argc, argv);
	glutInitDisplayMode(GLUT_RGBA | GLUT_DOUBLE | GLUT_DEPTH);
	glutInitWindowSize(240, 240);
	glutInitWindowPosition(100, 100);
	glutCreateWindow(" ");
	init();
	glutReshapeFunc(reshape);
	glutDisplayFunc(Display);
	glutMainLoop();
}