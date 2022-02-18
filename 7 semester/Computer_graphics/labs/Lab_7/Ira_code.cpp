#include <gl/glut.h>

GLfloat X[][4] = { { 0, 0, 0, 1 },
{ 0.1, 0, 0, 1 },
{ 0.1, 0, 0.1, 1 },
{ 0, 0, 0.1, 1 },
{ 0, 0.1, 0, 1 },
{ 0.1, 0.1, 0, 1 },
{ 0.1, 0.1, 0.1, 1 },
{ 0, 0.1, 0.1, 1 } };

void init() {
	glClearColor(1, 1, 1, 1);
}

void Display() {
	glClear(GL_COLOR_BUFFER_BIT);
	glPointSize(4.0);
	glColor3f(0.5, 0.5, 0.5);

	//на -0.3 единиц вдоль z, на 60 градусов вокруг y
	/*GLfloat T[][4] = { { 0.5, 0, 0, 4.33 },
	{ 0, 1, 0, 0 },
	{ 0.866, 0, 0, -2.5 },
	{ 0, -0.3, 0, 1 } };*/

	////на -0.25 единиц вдоль z, на 30 градусов вокруг y
	GLfloat T[][4] = { { 0.866, 0, 0, 2.5 },
	{ 0, 1, 0, 0 },
	{ 0.5, 0, 0, -4.33 },
	{ 0, -0.25, 0, 1 } };

	GLfloat XT[][4] = { { 0,0,0,0},
	{ 0,0,0,0 },
	{ 0,0,0,0 },
	{ 0,0,0,0 },
	{ 0,0,0,0 },
	{ 0,0,0,0 },
	{ 0,0,0,0 },
	{ 0,0,0,0 }, };

	for (int i = 0; i < 8; i++)
	{
		for (int j = 0; j < 4; j++)
		{
			for (int k = 0; k < 4; k++)
			{
				XT[i][j] += X[i][k] * T[k][j];
			}
		}
	}
	for (int i = 0; i < 8; i++)
	{
		if (XT[i][3] != 1)
		{
			for (int j = 0; j < 4; j++)
			{
				XT[i][j] = XT[i][j] / XT[i][3];
			}
		}
	}
	glBegin(GL_POINTS);
	for (int i = 0; i < 8; i++)
	{
		glVertex3f(XT[i][0], XT[i][1], XT[i][2]);
	}
	glEnd();

	glLineWidth(2);
	for (int i = 0; i < 3; i++)
	{
		glBegin(GL_LINES);
		glColor3d(1, 0, 0);
		glVertex3d(XT[i][0], XT[i][1], XT[i][2]);
		glVertex3d(XT[i+1][0], XT[i+1][1], XT[i+1][2]);
		glVertex3d(XT[i + 4][0], XT[i + 4][1], XT[i + 4][2]);
		glVertex3d(XT[i + 5][0], XT[i + 5][1], XT[i + 5][2]);
		glVertex3d(XT[i][0], XT[i][1], XT[i][2]);
		glVertex3d(XT[i + 4][0], XT[i + 4][1], XT[i + 4][2]);
	}
	glBegin(GL_LINES);
	glColor3d(1, 0, 0);
	glVertex3d(XT[3][0], XT[3][1], XT[3][2]);
	glVertex3d(XT[0][0], XT[0][1], XT[0][2]);
	glVertex3d(XT[4][0], XT[4][1], XT[4][2]);
	glVertex3d(XT[7][0], XT[7][1], XT[7][2]);
	glEnd();

	GLfloat VP[][4] = { { 1, 0, 0, 0 },
	{ 0, 1, 0, 0 },
	{ 0, 0, 1, 0 }};
	GLfloat VPT[][4] = { { 0, 0, 0, 0 },
	{ 0, 0, 0, 0 },
	{ 0, 0, 0, 0 } };
	for (int i = 0; i < 3; i++)
	{
		for (int j = 0; j < 4; j++)
		{
			for (int k = 0; k < 4; k++)
			{
				VPT[i][j] += VP[i][k] * T[k][j];
			}
		}
	}
	for (int i = 0; i < 3; i++)
	{
		if (VPT[i][3] != 1)
		{
			for (int j = 0; j < 4; j++)
			{
				VPT[i][j] = VPT[i][j] / VPT[i][3];
			}
		}
	}
	glColor3f(0.5, 0.5, 0.5);
	glBegin(GL_POINTS);
	for (int i = 0; i < 3; i++)
	{
		glVertex3f(VPT[i][0], VPT[i][1], VPT[i][2]);
	}
	glEnd();

	glLineWidth(1);
	glBegin(GL_LINES);
	glColor3d(0, 0, 1);

	glVertex3d(XT[0][0], XT[0][1], XT[0][2]);
	glVertex3d(VPT[2][0], VPT[2][1], VPT[2][2]);
	glVertex3d(XT[1][0], XT[1][1], XT[1][2]);
	glVertex3d(VPT[2][0], VPT[2][1], VPT[2][2]);
	glVertex3d(XT[4][0], XT[4][1], XT[4][2]);
	glVertex3d(VPT[2][0], VPT[2][1], VPT[2][2]);
	glVertex3d(XT[5][0], XT[5][1], XT[5][2]);
	glVertex3d(VPT[2][0], VPT[2][1], VPT[2][2]);

	glVertex3d(XT[1][0], XT[1][1], XT[1][2]);
	glVertex3d(VPT[0][0], VPT[0][1], VPT[0][2]);
	glVertex3d(XT[2][0], XT[2][1], XT[2][2]);
	glVertex3d(VPT[0][0], VPT[0][1], VPT[0][2]);
	glVertex3d(XT[5][0], XT[5][1], XT[5][2]);
	glVertex3d(VPT[0][0], VPT[0][1], VPT[0][2]);
	glVertex3d(XT[6][0], XT[6][1], XT[6][2]);
	glVertex3d(VPT[0][0], VPT[0][1], VPT[0][2]);

	glEnd();
	glFlush();
}

void main() {
	glutInitDisplayMode(GLUT_RGBA | GLUT_SINGLE);
	glutInitWindowSize(480, 480);
	glutInitWindowPosition(100, 100);
	glutCreateWindow(" ");
	init();
	glutDisplayFunc(Display);
	glutMainLoop();
}