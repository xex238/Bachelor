//#include<gl/glut.h>
#include "glut.h"
// ������ ������� Display
//void Display()
//{
//	glClear(GL_COLOR_BUFFER_BIT);
//	glColor3f(1, 1, 0);
//	glLoadIdentity(); // ������������� ������������
//	glTranslatef(0.001, 0, 0);
//	glutWireSphere(1.0, 30, 30);
//	glutPostRedisplay();
//	glutSwapBuffers();
//}

// ����� ������� Display
void Display()
{
	glClear(GL_COLOR_BUFFER_BIT);
	glColor3f(1, 1, 0);
	glPushMatrix(); // �� ������������� ������������ (�������� � ���� ������� �������)
	glTranslatef(0.3, 0, 0);
	glutWireSphere(1.0, 30, 30);
	glPopMatrix(); // �� ������������� ������������ (�������� �� ����� ���������� ���� �������)
	glutPostRedisplay();
	glutSwapBuffers();
}

void main(int argc, char** argv)
{
	glutInit(&argc, argv);
	glutInitDisplayMode(GLUT_RGBA | GLUT_DOUBLE);
	glutInitWindowSize(480, 480);
	glutInitWindowPosition(100, 100);
	glutCreateWindow(" ");
	glClearColor(0.9, 0.5, 0.75, 1);
	glutDisplayFunc(Display);
	glutMainLoop();
}