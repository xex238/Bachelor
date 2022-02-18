// #include<gl/glut.h>
#include "glut.h"
// ����������� ��������� � ������ nobj, ������� ��������� �� ��������� LUnurbsObj
GLUnurbsObj* nobj;
// ������ ����� ������������� ��������������
//GLfloat ctlarray[][3] = { { -0.9, -0.8, 0.0 },{ -0.2, 0.8, 0.0 },{ 0.2, -0.5, 0.0 },{ 0.9, 0.8, 0.0 } };
//GLfloat ctlarray2[][3] = { { -0.9, -0.8, 0.0 },{ -0.2, 0.8, 0.0 },{ -0.2, 0.8, 0.0 },{ 0.2, -0.5, 0.0 },{ 0.9, 0.8, 0.0 } };
//GLfloat ctlarray3[][3] = { { -0.9, -0.8, 0.0 },{ -0.2, 0.8, 0.0 },{ -0.2, 0.8, 0.0 },{ -0.2, 0.8, 0.0 },{ 0.2, -0.5, 0.0 },{ 0.9, 0.8, 0.0 } };

// ���������� 11 �����
GLfloat ctlarray0[][3] = { { -0.9, -0.9, 0.0 },
							{ -0.7, -0.3, 0.0 },
							{ -0.5, -0.7, 0.0 },
							{ -0.2, -0.1, 0.0 },
							{ -0.1, 0.1, 0.0 },
							{ 0.0, -0.2, 0.0 }, // ������ ������ �����
							{ 0.4, 0.5, 0.0 },
							{ 0.5, 0.0, 0.0 },
							{ 0.7, 0.2, 0.0 },
							{ 0.8, -0.6, 0.0 },
							{ 0.9, -0.2, 0.0 } };

GLfloat ctlarray01[][3] = { { -0.9, -0.9, 0.0 },
{ -0.7, -0.3, 0.0 },
{ -0.5, -0.7, 0.0 },
{ -0.2, -0.1, 0.0 },
{ -0.1, 0.1, 0.0 },
{ 0.0, -0.7, 0.0 }, // ������ ������ �����
{ 0.4, 0.5, 0.0 },
{ 0.5, 0.0, 0.0 },
{ 0.7, 0.2, 0.0 },
{ 0.8, -0.6, 0.0 },
{ 0.9, -0.2, 0.0 } };

GLfloat ctlarray02[][3] = { { -0.9, -0.9, 0.0 },
{ -0.7, -0.3, 0.0 },
{ -0.5, -0.7, 0.0 },
{ -0.2, -0.1, 0.0 },
{ -0.1, 0.1, 0.0 },
{ 0.0, 0.3, 0.0 }, // ������ ������ �����
{ 0.4, 0.5, 0.0 },
{ 0.5, 0.0, 0.0 },
{ 0.7, 0.2, 0.0 },
{ 0.8, -0.6, 0.0 },
{ 0.9, -0.2, 0.0 } };

void init(void)
{
	glClearColor(1, 1, 1, 1);
	// �������� NURBS-������
	nobj = gluNewNurbsRenderer();
	gluNurbsProperty(nobj, GLU_SAMPLING_TOLERANCE, 25.0);
}

void Display()
{
	// ������, ���������� �������� ��������� ������������ �������� �������
	//GLfloat knot2[] = { 0.0, 0.0, 0.0, 1.0, 2.0, 2.0, 2.0 };
	//GLfloat knot1[] = { 0.0, 0.0, 1.0, 2.0, 3.0, 3.0};
	//GLfloat knot3[] = { 0.0, 0.0, 0.0, 0.0, 1.0, 1.0, 1.0, 1.0 };

	//GLfloat knot53[] = { 0.0, 0.0, 0.0, 0.0, 1.0, 2.0, 2.0, 2.0, 2.0 };
	//GLfloat knot63[] = { 0.0, 0.0, 0.0, 0.0, 1.0, 2.0, 3.0, 3.0, 3.0, 3.0};
	GLfloat knot0[] = { 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 1.0, 2.0, 3.0, 4.0, 4.0, 4.0, 4.0, 4.0, 4.0, 4.0, 4.0 };
	GLfloat knot2[] = { 0.0, 0.0, 1.0, 2.0, 3.0, 4.0, 5.0, 6.0, 7.0, 8.0, 9.0, 10.0, 10.0 };

	//GLfloat knot02[] = { 0.0, 1.0, 2.0, 3.0, 4.0, 5.0, 6.0 };
	//GLfloat knot01[] = { 0.0, 1.0, 2.0, 3.0, 4.0, 5.0 };
	//GLfloat knot03[] = { 0.0, 1.0, 2.0, 3.0, 4.0, 5.0, 6.0, 7.0 };

	glClear(GL_COLOR_BUFFER_BIT);
	glLineWidth(3.0);
	//glColor3f(0, 0, 1);
	//// ��������� ����������� NURBS ������
	//gluNurbsCurve(nobj, 7, knot2, 3, &ctlarray[0][0], 3, GL_MAP1_VERTEX_3);
	//glColor3f(0, 1, 0);
	//// ��������� ����������� NURBS ������
	//gluNurbsCurve(nobj, 6, knot1, 3, &ctlarray[0][0], 2, GL_MAP1_VERTEX_3);
	//glColor3f(1, 0, 0);
	//// ��������� ����������� NURBS ������
	//gluNurbsCurve(nobj, 8, knot3, 3, &ctlarray[0][0], 4, GL_MAP1_VERTEX_3);


	//glColor3f(1, 1, 0);
	//// ��������� ����������� NURBS ������
	//gluNurbsCurve(nobj, 9, knot53, 3, &ctlarray2[0][0], 4, GL_MAP1_VERTEX_3);

	glColor3f(1, 0, 0);
	// ��������� ����������� NURBS ������
	gluNurbsCurve(nobj, 19, knot0, 3, &ctlarray0[0][0], 8, GL_MAP1_VERTEX_3);

	glColor3f(1, 1, 0);
	// ��������� ����������� NURBS ������
	gluNurbsCurve(nobj, 13, knot2, 3, &ctlarray0[0][0], 2, GL_MAP1_VERTEX_3);

	glColor3f(0, 1, 0);
	// ��������� ����������� NURBS ������
	gluNurbsCurve(nobj, 19, knot0, 3, &ctlarray01[0][0], 8, GL_MAP1_VERTEX_3);

	glColor3f(1, 1, 0);
	// ��������� ����������� NURBS ������
	gluNurbsCurve(nobj, 13, knot2, 3, &ctlarray01[0][0], 2, GL_MAP1_VERTEX_3);

	glColor3f(0, 0, 1);
	// ��������� ����������� NURBS ������
	gluNurbsCurve(nobj, 19, knot0, 3, &ctlarray02[0][0], 8, GL_MAP1_VERTEX_3);

	glColor3f(1, 1, 0);
	// ��������� ����������� NURBS ������
	gluNurbsCurve(nobj, 13, knot2, 3, &ctlarray02[0][0], 2, GL_MAP1_VERTEX_3);

	//glColor3f(1, 1, 0);
	//// ��������� ����������� NURBS ������
	//gluNurbsCurve(nobj, 7, knot02, 3, &ctlarray[0][0], 3, GL_MAP1_VERTEX_3);
	//glColor3f(0, 1, 1);
	//// ��������� ����������� NURBS ������
	//gluNurbsCurve(nobj, 6, knot01, 3, &ctlarray[0][0], 2, GL_MAP1_VERTEX_3);
	//glColor3f(1, 0, 1);
	//// ��������� ����������� NURBS ������
	//gluNurbsCurve(nobj, 8, knot03, 3, &ctlarray[0][0], 4, GL_MAP1_VERTEX_3);

	glPointSize(4.0);
	glColor3f(1.0, 0.0, 0);
	glBegin(GL_POINTS);
	for (int i = 0; i < 11; i++)
	{
		glVertex3f(ctlarray0[i][0], ctlarray0[i][1], ctlarray0[i][2]);
	}
	glColor3f(0.0, 1.0, 0.0);
	glVertex3f(ctlarray01[5][0], ctlarray01[5][1], ctlarray01[5][2]);
	glColor3f(0.0, 0.0, 1.0);
	glVertex3f(ctlarray02[5][0], ctlarray02[5][1], ctlarray02[5][2]);
	glEnd();
	glFlush();
}

void main(int argc, char** argv)
{
	glutInit(&argc, argv);
	glutInitDisplayMode(GLUT_RGBA | GLUT_SINGLE);
	glutInitWindowSize(480, 480);
	glutInitWindowPosition(100, 100);
	glutCreateWindow(" ");
	init();
	glutDisplayFunc(Display);
	glutMainLoop();
}