#include "glut.h"
//#include <iostream>

double mat[4][4] = {
{0.5, 0, 0, 0.346},
{0, 1, 0, 0},
{0.866, 0, 0, -0.2},
{0, -0.7, 0, 1} };

double cub[8][4] = {
{0, 0, 0, 1},
{0.5, 0, 0, 1},
{0.5, 0, 0.5, 1},
{0, 0, 0.5, 1},
{0, 0.5, 0, 1},
{0.5, 0.5, 0, 1},
{0.5, 0.5, 0.5, 1},
{0, 0.5, 0.5, 1},
};

int mult(double* a, double* b, double* c, int count) {
	for (int i = 0; i < count; ++i)
		for (int j = 0; j < 4; ++j)
			*(a + i * 4 + j) = 0;

	for (int i = 0; i < count; i++)
		for (int j = 0; j < 4; ++j)
			for (int k = 0; k < 4; ++k)
				*(a + i * 4 + j) += (*(b + i * 4 + k)) * (*(c + k * 4 + j));
	for (int i = 0; i < count; ++i)
		for (int j = 0; j < 4; ++j)
			*(a + i * 4 + j) /= *(a + i * 4 + 3);

	return 0;
}

void Display(void) {
	int point[] = { 0,4,0,1,5,1,2,6,2,3,7,3,0,4,5,6,7,4 };
	int jk = 18;

	double c1[8][4] = { 0 };
	double shod[3][4] = { {1,0,0,0},
	{0,1,0,0},
	{0,0,1,0} };
	double shod1[3][4];
	mult(*c1, *cub, *mat, 8);
	mult(*shod1, *shod, *mat, 3);
	glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);

	for (int i = 0; i < 8; ++i)
		for (int j = 0; j < 4; ++j) {

			c1[i][j] /= 3.2;
			c1[i][j] += 0.4;
			if (i < 3) {
				shod1[i][j] /= 3.2;
				shod1[i][j] += 0.4;
			}
		}

	glClearColor(0, 0, 0, 1);

	glColor3f(255, 255, 255);
	glBegin(GL_LINES);

	for (int i = 0; i < jk; ++i) {
		glVertex2f(c1[point[i]][0], c1[point[i]][1]);
		glVertex2f(c1[point[(i + 1) % jk]][0], c1[point[(i + 1) % jk]][1]);
	}

	for (int i = 0; i < 8; ++i) {
		glVertex2f(shod1[0][0], shod1[0][1]);
		glVertex2f(c1[i][0], c1[i][1]);
		glVertex2f(shod1[2][0], shod1[2][1]);
		glVertex2f(c1[i][0], c1[i][1]);
	}

	glEnd();

	glFinish();
}

int main(int arcg, char** arcv)
{
	glutInit(&arcg, arcv);
	glutInitDisplayMode(GLUT_SINGLE | GLUT_RGB);
	glutInitWindowSize(480, 480);
	glutInitWindowPosition(300, 200);
	glutCreateWindow(" ");
	glutDisplayFunc(Display);
	glutMainLoop();

	return 0;
}