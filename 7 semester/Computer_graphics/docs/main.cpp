#include <gl/glut.h>
#include <stdio.h>

GLUnurbsObj* nObj;

GLfloat ctlarray[][4] = {
	{ -0.6, -0.2, 0,1 },
	{ -0.6, -0.2, 1,1 },
	{ -0.4,  0.2, 0,1 },
	{ -0.4,  0.2, 1,1 },
	{ -0.2, -0.2, 0,1 },
	{ -0.2, -0.2, 1,1 },
	{  0.0,  0.2, 0,1 },
	{  0.0,  0.2, 1,1 },
	{  0.2, -0.2, 0,1 },
	{  0.2, -0.2, 1,1 },
	{  0.4,  0.2, 0,1 },
	{  0.4,  0.2, 1,1 },
	{  0.6, -0.2, 0,1 },
	{  0.6, -0.2, 1,1 }
};

void init()
{
	glClearColor(1, 1, 1, 1);
	nObj = gluNewNurbsRenderer();
	gluNurbsProperty(nObj, GLU_SAMPLING_TOLERANCE, 25);
}

void display()
{
	// k=6
	float knot1[] = { 0,0,0,0,0,0,1,2,2,2,2,2,2 };
	float knot2[] = { 0,0,1,1 };
	glClear(GL_COLOR_BUFFER_BIT);
	glLineWidth(1.0);
	glPointSize(4.0);
	glRotatef(1, 1.0, 1.0, 0.0);
	glColor3f(0.48, 0.64, 0.6);

	/*glBegin(GL_POINTS);
	for (int i{ 0 }; i < 7; ++i)
	{
		glVertex3f(ctlarray[i][0], ctlarray[i][1], ctlarray[i][2]);
	}
	glEnd();*/



	/*glColor3f(1, 0, 0);
	glLineWidth(2.0);*/
	//gluNurbsCurve(nObj, 13, knot1, 3, &ctlarray[0][0], 6, GL_MAP1_VERTEX_3);
	gluBeginSurface(nObj);
	gluNurbsSurface(nObj, 13, knot1, 4, knot2, 4*2, 4, &ctlarray[0][0], 6, 2, GL_MAP2_VERTEX_4);
	gluEndSurface(nObj);

	glutPostRedisplay();
	glutSwapBuffers();
}

int main()
{
	glutInitDisplayMode(GLUT_RGBA | GLUT_DOUBLE);
	glutInitWindowSize(960, 960);
	glutInitWindowPosition(1, 1);
	glutCreateWindow("7");
	init();
	glutDisplayFunc(display);
	glutMainLoop();

	return 0;
}