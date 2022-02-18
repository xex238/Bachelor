#include <stdio.h>
#include <windows.h>
#include <gl/glut.h>

/*

GLUnurbsObj* nobj;  //ПРАВЕЛЬНАЯ ПРЯМАЯ ПО ТОЧКАМ
GLfloat ctlarray[][4] = {
						 { -0.9, -0.2,  0.0, 1 },
						 { -0.9, -0.2,  1.0, 1 },
						 { -0.7,  0.2,  0.0, 1 },
						 { -0.7,  0.2,  1.0, 1 },
						 { -0.5, -0.2,  0.0, 1 },
						 { -0.5, -0.2,  1.0, 1 },
						 { -0.3,  0.2,  0.0, 1 },
						 { -0.3,  0.2,  1.0, 1 },
						 { -0.1, -0.2,  0.0, 1 },
						 { -0.1, -0.2,  1.0, 1 },
						 {  0.1,  0.2,  0.0, 1 },
						 { 0.1,   0.2,  1.0, 1 },
						 {	0.3, -0.2,  0.0, 1 },
						 { 0.3,  -0.2,  1.0, 1 },
						 {  0.5,  0.2,  0.0, 1 }, 
						 {  0.5,  0.2,  1.0, 1 }
												 };

void init()
{
	glClearColor(1, 1, 1, 1);
	nobj = gluNewNurbsRenderer();
	gluGetNurbsProperty(nobj, GLU_SAMPLING_TOLERANCE, new GLfloat(25.0));

}
void Display()
{
	GLfloat knot[] = { 0.0, 0.0, 0.0, 1.0, 2.0, 3.0, 4.0, 5.0, 6.0, 6.0,  6.0 };
	GLfloat knot1[] = { 0.0, 0.0, 1.0, 1.0 };
	//GLfloat knot2[] = { 0.0, 0.0, 1.0, 2.0, 3.0, 3.0 };
	//GLfloat knot4[] = { 0.0, 0.0, 0.0, 0.0, 1.0, 1.0, 1.0, 1.0 };
	//GLfloat knot5[] = { 0.0, 0.0, 0.0, 0.0, 1.0, 1.0, 1.0, 1.0};
	
	glClear(GL_COLOR_BUFFER_BIT);
	glLineWidth(3.0);
	glPointSize(4.0);
	glRotatef(1, 1.0, 1.0, 0.0);
	glColor3f(0, 0.3, 1);
	gluNurbsCurve(nobj, 11, knot, 3, &ctlarray[0][0], 3, GL_MAP1_VERTEX_3); //плавная кривая
	gluNurbsCurve(nobj, 4, knot1, 3, &ctlarray[0][0], 2, GL_MAP1_VERTEX_3);
	
	//gluNurbsCurve(nobj, 6, knot2, 3, &ctlarray[0][0], 2, GL_MAP1_VERTEX_3); // ломанная кривая
	//gluNurbsCurve(nobj, 8, knot4, 7, &ctlarray[0][0], 4, GL_MAP1_VERTEX_3); //очень плавная прямая	
	//gluNurbsCurve(nobj, 11, knot, 7, &ctlarray[0][0], 4, GL_MAP1_VERTEX_3); 

	//gluNurbsCurve(nobj, 11, knot5, 8, &ctlarray[0][0], 5, GL_MAP1_VERTEX_3);
	
	
	gluBeginSurface(nObj);
	gluNurbsSurface(nObj, 13, knot1, 4, knot2, 4 * 2, 4, &ctlarray[0][0], 6, 2, GL_MAP2_VERTEX_4);
	gluEndSurface(nObj);
	glPointSize(4.0);
	glColor3f(0.0, 0.0, 1);
	glBegin(GL_POINTS);
	for (int i = 0; i < 8; i++)
	{
		glVertex3f(ctlarray[i][0], ctlarray[i][1], ctlarray[i][2]);
	}
	glEnd();
	glFlush();
}
void main()
{
	glutInitDisplayMode(GLUT_RGBA | GLUT_SINGLE);
	glutInitWindowSize(480, 480);
	glutInitWindowPosition(100, 100);
	glutCreateWindow("  ");
	init();
	glutDisplayFunc(Display);
	glutMainLoop();
}


*/


GLfloat ctlarray[][4] = {
	{ -0.6, -0.2, 0,1 },
	{ -0.6, -0.2, 1,1 },
	{ -0.4,  0.2, 0,1 },
	{ -0.4,  0.2, 1,1 },
	{ -0.2, -0.2, 0,1 },
	{ -0.2, -0.2, 1,1 },
	{ 0.0,  0.2, 0,1 },
	{ 0.0,  0.2, 1,1 },
	{ 0.2, -0.2, 0,1 },
	{ 0.2, -0.2, 1,1 },
	{ 0.4,  0.2, 0,1 },
	{ 0.4,  0.2, 1,1 },
	{ 0.6, -0.2, 0,1 },
	{ 0.6, -0.2, 1,1 }
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
	gluNurbsSurface(nObj, 13, knot1, 4, knot2, 4 * 2, 4, &ctlarray[0][0], 6, 2, GL_MAP2_VERTEX_4);
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
