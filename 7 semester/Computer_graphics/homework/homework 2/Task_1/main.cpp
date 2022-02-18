//#include <gl/glut.h>
#include "glut.h"
// ����� ����������� �� �����
void Display()
{
	glClear(GL_COLOR_BUFFER_BIT);
	glColor3f(0, 1, 0);
	glPointSize(5); // ��� ��������� ����� - ������� ������� �����
	glLineWidth(2); // ��� ��������� ����� - ������ �����
	glPolygonMode(GL_FRONT_AND_BACK, GL_LINE); // ��� ��������� ������������ - ��������� ������ ���������
	//glEnable(GL_LINE_STIPPLE);
	glBegin(GL_QUADS);

	// ��������� ����� (GL_POINTS)
	//glColor3d(1, 0, 0);
	//glVertex2d(0, 0);
	//glVertex2d(-0.5, -0.5);

	// 2d ����� (GL_LINES)
	//glVertex2d(0, 0.5);
	//glVertex2d(0.5, 0.0);

	// 3d ����� � ������� ������ (GL_LINES)
	//glColor3d(1, 1, 1);
	//glVertex3d(0, 0, 0);
	//glColor3d(0, 0, 0);
	//glVertex3d(0.5, 0.5, 0.5);

	glVertex2d(0, 0);
	glVertex2d(0.5, 0);
	glVertex2d(0.5, 0.5);
	glVertex2d(0, 0.5);

	glEnd();

	// ���������� ����
	glutPostRedisplay();
	glutSwapBuffers();
}

void main(int argc, char** argv)
{
	glutInit(&argc, argv);
	// ����� ��������� ����
	glutInitDisplayMode(GLUT_RGBA | GLUT_DOUBLE);
	// ����� ������� ����
	glutInitWindowSize(480, 480);
	// ����� ������� ����
	glutInitWindowPosition(100, 100);
	// �������� ����
	glutCreateWindow("");
	glClearColor(0.9, 0.5, 0.75, 1);
	// ����� ������� ��������� ������ ����������� �� �����
	glutDisplayFunc(Display);
	// ����������� ����
	glutMainLoop();
}