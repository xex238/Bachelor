#include "glut.h"

GLfloat ctlarray[3][2][4] = { 0.5, 0.0, -0.3, 1.0, 0.5, 0.0, 0.3, 1.0, 0.0, 0.866 * 0.55, -0.3 * 0.55, 1.0 * 0.55,
							0.0, 0.866 * 0.55, 0.3 * 0.55, 1.0 * 0.55, -0.5, 0.0, -0.3, 1.0, -0.5, 0.0, 0.3, 1.0 };
GLfloat TexP[] = { 1.0, 0.0, 0.0, 0.0 };
GLfloat TexP1[] = { 0.0, 1.0, 0.0, 0.0 };
GLfloat TexP2[] = { 0.0, 0.0, 1.0, 0.0 };
GLubyte TexI[] = { 255, 0, 0, 255, 0, 0, 255, 255, 0, 255, 255, 0, 0, 255, 0, 0, 255, 0, 0, 0, 255, 0, 0, 255 };
GLfloat texpts[2][2][2] = { 0, 0, 0, 2, 2, 0, 2, 2 };
GLUnurbsObj* theNurb;
GLUquadricObj* theqw;

void init()
{
	glClearColor(0.5, 0.75, 0.75, 1);
	theNurb = gluNewNurbsRenderer();
	theqw = gluNewQuadric();
	glEnable(GL_DEPTH_TEST);
	gluNurbsProperty(theNurb, GLU_SAMPLING_TOLERANCE, 25.0);
	glPixelStorei(GL_UNPACK_ALIGNMENT, 1);
	glTexParameterf(GL_TEXTURE_1D, GL_TEXTURE_MAG_FILTER, GL_LINEAR);
	glTexParameterf(GL_TEXTURE_1D, GL_TEXTURE_MIN_FILTER, GL_LINEAR);
	glTexImage1D(GL_TEXTURE_1D, 0, 3, 8, 0, GL_RGB, GL_UNSIGNED_BYTE, TexI);
	glTexEnvi(GL_TEXTURE_ENV, GL_TEXTURE_ENV_MODE, GL_DECAL);
	//gluQuadricTexture(theqw, true);
	glEnable(GL_TEXTURE_1D);
}

void Display()
{
	GLfloat knot[] = { 0.0, 0.0, 0.0, 1.0, 1.0, 1.0 };
	GLfloat knot1[] = { 0.0, 0.0, 1.0, 1.0 };
	glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);
	glRotatef(1.0, 1.0, 1.0, 1.0);
	glColor3f(1, 0, 0);
	glEnable(GL_TEXTURE_GEN_S);
	glTexGeni(GL_S, GL_TEXTURE_GEN_MODE, GL_OBJECT_LINEAR);
	glTexGenfv(GL_S, GL_OBJECT_PLANE, TexP1);

	//glMap2f(GL_MAP2_TEXTURE_COORD_1, 0, 1, 2, 2, 0, 1, 4, 2, &texpts[0][0][0]);
	//glEnable(GL_MAP2_TEXTURE_COORD_1);

	gluSphere(theqw, 0.3, 50, 50);
	//glutSolidTeapot(0.3);
	gluBeginSurface(theNurb);
	gluNurbsSurface(theNurb, 6, knot, 4, knot1, 2 * 4, 4, &ctlarray[0][0][0], 3, 2, GL_MAP2_VERTEX_4);
	gluEndSurface(theNurb);
	glutPostRedisplay();
	glutSwapBuffers();
}

void main(int argc, char** argv)
{
	glutInit(&argc, argv);
	glutInitDisplayMode(GLUT_RGBA | GLUT_DOUBLE | GLUT_DEPTH);
	glutInitWindowSize(480, 480);
	glutInitWindowPosition(100, 100);
	glutCreateWindow(" ");
	init();
	glutDisplayFunc(Display);
	glutMainLoop();
}