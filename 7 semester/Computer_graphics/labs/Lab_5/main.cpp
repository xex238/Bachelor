#include "glut.h"
GLUnurbsObj* theNurb;
// массив точек определ€ющего многоугольника
GLfloat ctlarray[][4] = { {-1.0, -0.7, 0.0,1.0},
				 {-0.5, 0.7, 0.0,1.0},
				 {0.0, -0.7, 0.0,1.0},
				 {0.5, 0.7, 0.0,1.0},
				 {1.0, -0.7, 0.0,1.0} };
GLfloat ctlarray2[][4] = { {-0.45, 0.0, 0.0, 1.0},
{0.0, 0.779, 0.0, 1.0},
{0.45, 0.0, 0.0, 1.0} };
GLfloat ctlarray22[][4] = { {0.0, -0.779, 0.0, 1.0},
{-0.9, -0.779, 0.0, 1.0},
{-0.45, 0.0, 0.0, 1.0} };
GLfloat ctlarray32[][4] = { {0.0, -0.779, 0.0, 1.0},
{0.9, -0.779, 0.0, 1.0},
{0.45, 0.0, 0.0, 1.0} };
void init(void)
{
	glClearColor(1.0, 1.0, 1.0, 1);
	//  gluNewNurbsRenderer Ц создает NURBS объект 
	theNurb = gluNewNurbsRenderer();
	//  установка свойства неравномерного рационального B-сплайна
	gluNurbsProperty(theNurb, GLU_SAMPLING_TOLERANCE, 25.0);
}
void Display()
{
	//  ћассив, содержащий значени€ открытого равномерного узлового вектора 
	GLfloat knot[] = { 0.0,0.0,0.0,1.0,2.0,3.0,3.0,3.0 };
	GLfloat knot1[] = { 0.0,0.0,1.0,2.0,3.0,4.0,4.0 };
	GLfloat knot2[] = { 0, 0, 0, 1, 1, 1 };
	GLfloat knot3[] = { 0, 1, 2, 3, 4, 5 };
	GLfloat knot4[] = { 0, 1, 2, 3, 4 };
	glClear(GL_COLOR_BUFFER_BIT);
	glLineWidth(1.0);
	glPointSize(5.0);
	glColor3f(0.0, 0.5, 1.0);

	glBegin(GL_POINTS);
	for (int i = 0; i < 3; i++)
	{
		glVertex3f(ctlarray2[i][0], ctlarray2[i][1], ctlarray2[i][2]);
	}
	glEnd();
	//gluNurbsCurve(theNurb, 7, knot1, 4, &ctlarray[0][0], 2, GL_MAP1_VERTEX_4);
	glColor3f(0.0, 1.0, 0.1);
	glLineWidth(2.0);
	//  theNurb Ц NURBS объект,  8 Ц количество элементов в массиве knot,
	//  knot Ц массив содержащий значени€ узлового вектора,
	//  4 Ц количество чисел(координат) дл€ описани€ контрольной точки (точки 
	//  определ€ющего многоугольника) здесь точка содержит однородную координату
	//  параметр ctlarray Ц указывает  на массив контрольных точек
	//  3 Ц степень  NURBS кривой плюс единица
	//  GL_MAP1_VERTEX_4 Ц тип Ѕезье вычислител€ дл€ рациональных контрольных точек
	//gluNurbsCurve(theNurb, 8, knot, 4, &ctlarray[0][0], 3, GL_MAP1_VERTEX_4);
	//glColor3f(0.1, 1.0, 0.0);
	//ctlarray[2][0] = 0.0 * 0.25; ctlarray[2][1] = -0.7 * 0.25;
	//ctlarray[2][2] = 0.0 * 0.25; ctlarray[2][3] = 1.0 * 0.25;
	//gluNurbsCurve(theNurb, 8, knot, 4, &ctlarray[0][0], 3, GL_MAP1_VERTEX_4);
	//ctlarray[2][0] = 0.0 * 5; ctlarray[2][1] = -0.7 * 5;
	//ctlarray[2][2] = 0.0 * 5; ctlarray[2][3] = 1.0 * 5;
	//gluNurbsCurve(theNurb, 8, knot, 4, &ctlarray[0][0], 3, GL_MAP1_VERTEX_4);
	//ctlarray[2][0] = 0.0 * 0; ctlarray[2][1] = -0.7 * 0;
	//ctlarray[2][2] = 0.0 * 0; ctlarray[2][3] = 1.0 * 0;
	//gluNurbsCurve(theNurb, 8, knot, 4, &ctlarray[0][0], 3, GL_MAP1_VERTEX_4);

	gluNurbsCurve(theNurb, 6, knot2, 4, &ctlarray2[0][0], 3, GL_MAP1_VERTEX_4);
	glColor3f(1.0, 1.0, 0.0);
	gluNurbsCurve(theNurb, 6, knot3, 4, &ctlarray2[0][0], 3, GL_MAP1_VERTEX_4);
	//glColor3f(0.1, 1.0, 1.0);
	//gluNurbsCurve(theNurb, 5, knot4, 4, &ctlarray2[0][0], 2, GL_MAP1_VERTEX_4);

	ctlarray2[1][0] = ctlarray2[1][0] * 0.5;
	ctlarray2[1][1] = ctlarray2[1][1] * 0.5;
	ctlarray2[1][2] = ctlarray2[1][2] * 0.5;
	ctlarray2[1][3] = ctlarray2[1][3] * 0.5;


	gluNurbsCurve(theNurb, 6, knot2, 4, &ctlarray2[0][0], 3, GL_MAP1_VERTEX_4);

	ctlarray2[1][0] = ctlarray2[1][0] * 0.0;
	ctlarray2[1][1] = ctlarray2[1][1] * 0.0;
	ctlarray2[1][2] = ctlarray2[1][2] * 0.0;
	ctlarray2[1][3] = ctlarray2[1][3] * 0.0;


	gluNurbsCurve(theNurb, 6, knot2, 4, &ctlarray2[0][0], 3, GL_MAP1_VERTEX_4);
	GLfloat ctlarray3[][4] = { {-0.45, 0.0, 0.0, 1.0},
{0.0, 0.779, 0.0, 1.0},
{0.45, 0.0, 0.0, 1.0} };

	
	ctlarray3[0][0] = ctlarray3[0][0] * 0.0;
	ctlarray3[0][1] = ctlarray3[0][1] * 0.0;
	ctlarray3[0][2] = ctlarray3[0][2] * 0.0;
	ctlarray3[0][3] = ctlarray3[0][3] * 0.0;


	gluNurbsCurve(theNurb, 6, knot2, 4, &ctlarray3[0][0], 3, GL_MAP1_VERTEX_4);

	GLfloat ctlarray2[][4] = { {-0.45, 0.0, 0.0, 1.0},
{0.0, 0.779, 0.0, 1.0},
{0.45, 0.0, 0.0, 1.0} };

	ctlarray2[2][0] = ctlarray2[2][0] * 0.0;
	ctlarray2[2][1] = ctlarray2[2][1] * 0.0;
	ctlarray2[2][2] = ctlarray2[2][2] * 0.0;
	ctlarray2[2][3] = ctlarray2[2][3] * 0.0;


	gluNurbsCurve(theNurb, 6, knot2, 4, &ctlarray2[0][0], 3, GL_MAP1_VERTEX_4);


	/////2
	glBegin(GL_POINTS);
	for (int i = 0; i < 3; i++)
	{
		glVertex3f(ctlarray22[i][0], ctlarray22[i][1], ctlarray22[i][2]);
	}
	glEnd();
	/*GLfloat ctlarray22[][4] = { {-0.9, -0.45, 0.0, 1.0},
{-0.45, 0.0, 0.0, 1.0},
{0.0, -0.9, 0.0, 1.0} };*/

	gluNurbsCurve(theNurb, 6, knot2, 4, &ctlarray22[0][0], 3, GL_MAP1_VERTEX_4);
	glColor3f(1.0, 1.0, 0.0);
	gluNurbsCurve(theNurb, 6, knot3, 4, &ctlarray22[0][0], 3, GL_MAP1_VERTEX_4);
	//glColor3f(0.1, 1.0, 1.0);
	//gluNurbsCurve(theNurb, 5, knot4, 4, &ctlarray2[0][0], 2, GL_MAP1_VERTEX_4);

	ctlarray22[1][0] = ctlarray22[1][0] * 0.5;
	ctlarray22[1][1] = ctlarray22[1][1] * 0.5;
	ctlarray22[1][2] = ctlarray22[1][2] * 0.5;
	ctlarray22[1][3] = ctlarray22[1][3] * 0.5;


	gluNurbsCurve(theNurb, 6, knot2, 4, &ctlarray22[0][0], 3, GL_MAP1_VERTEX_4);

	ctlarray22[1][0] = ctlarray22[1][0] * 0.0;
	ctlarray22[1][1] = ctlarray22[1][1] * 0.0;
	ctlarray22[1][2] = ctlarray22[1][2] * 0.0;
	ctlarray22[1][3] = ctlarray22[1][3] * 0.0;


	gluNurbsCurve(theNurb, 6, knot2, 4, &ctlarray22[0][0], 3, GL_MAP1_VERTEX_4);
	GLfloat ctlarray23[][4] = { {0.0, -0.779, 0.0, 1.0},
{-0.9, -0.779, 0.0, 1.0},
{-0.45, 0.0, 0.0, 1.0} };


	ctlarray23[0][0] = ctlarray23[0][0] * 0.0;
	ctlarray23[0][1] = ctlarray23[0][1] * 0.0;
	ctlarray23[0][2] = ctlarray23[0][2] * 0.0;
	ctlarray23[0][3] = ctlarray23[0][3] * 0.0;


	gluNurbsCurve(theNurb, 6, knot2, 4, &ctlarray23[0][0], 3, GL_MAP1_VERTEX_4);

	GLfloat ctlarray22[][4] = { {0.0, -0.779, 0.0, 1.0},
{-0.9, -0.779, 0.0, 1.0},
{-0.45, 0.0, 0.0, 1.0} };

	ctlarray22[2][0] = ctlarray22[2][0] * 0.0;
	ctlarray22[2][1] = ctlarray22[2][1] * 0.0;
	ctlarray22[2][2] = ctlarray22[2][2] * 0.0;
	ctlarray22[2][3] = ctlarray22[2][3] * 0.0;


	gluNurbsCurve(theNurb, 6, knot2, 4, &ctlarray22[0][0], 3, GL_MAP1_VERTEX_4);

	/////3
	glBegin(GL_POINTS);
	for (int i = 0; i < 3; i++)
	{
		glVertex3f(ctlarray22[i][0], ctlarray22[i][1], ctlarray22[i][2]);
	}
	glEnd();
	/*GLfloat ctlarray22[][4] = { {-0.9, -0.45, 0.0, 1.0},
{-0.45, 0.0, 0.0, 1.0},
{0.0, -0.9, 0.0, 1.0} };*/

	gluNurbsCurve(theNurb, 6, knot2, 4, &ctlarray32[0][0], 3, GL_MAP1_VERTEX_4);
	glColor3f(1.0, 1.0, 0.0);
	gluNurbsCurve(theNurb, 6, knot3, 4, &ctlarray32[0][0], 3, GL_MAP1_VERTEX_4);
	//glColor3f(0.1, 1.0, 1.0);
	//gluNurbsCurve(theNurb, 5, knot4, 4, &ctlarray2[0][0], 2, GL_MAP1_VERTEX_4);

	ctlarray32[1][0] = ctlarray32[1][0] * 0.5;
	ctlarray32[1][1] = ctlarray32[1][1] * 0.5;
	ctlarray32[1][2] = ctlarray32[1][2] * 0.5;
	ctlarray32[1][3] = ctlarray32[1][3] * 0.5;


	gluNurbsCurve(theNurb, 6, knot2, 4, &ctlarray32[0][0], 3, GL_MAP1_VERTEX_4);

	ctlarray32[1][0] = ctlarray32[1][0] * 0.0;
	ctlarray32[1][1] = ctlarray32[1][1] * 0.0;
	ctlarray32[1][2] = ctlarray32[1][2] * 0.0;
	ctlarray32[1][3] = ctlarray32[1][3] * 0.0;
	


	gluNurbsCurve(theNurb, 6, knot2, 4, &ctlarray32[0][0], 3, GL_MAP1_VERTEX_4);
	GLfloat ctlarray33[][4] = { {0.0, -0.779, 0.0, 1.0},
{0.9, -0.779, 0.0, 1.0},
{0.45, 0.0, 0.0, 1.0} };


	ctlarray33[0][0] = ctlarray33[0][0] * 0.0;
	ctlarray33[0][1] = ctlarray33[0][1] * 0.0;
	ctlarray33[0][2] = ctlarray33[0][2] * 0.0;
	ctlarray33[0][3] = ctlarray33[0][3] * 0.0;


	gluNurbsCurve(theNurb, 6, knot2, 4, &ctlarray33[0][0], 3, GL_MAP1_VERTEX_4);

	GLfloat ctlarray32[][4] = { {0.0, -0.779, 0.0, 1.0},
{0.9, -0.779, 0.0, 1.0},
{0.45, 0.0, 0.0, 1.0} };

	ctlarray32[2][0] = ctlarray32[2][0] * 0.0;
	ctlarray32[2][1] = ctlarray32[2][1] * 0.0;
	ctlarray32[2][2] = ctlarray32[2][2] * 0.0;
	ctlarray32[2][3] = ctlarray32[2][3] * 0.0;


	gluNurbsCurve(theNurb, 6, knot2, 4, &ctlarray32[0][0], 3, GL_MAP1_VERTEX_4);

	//gluNurbsCurve(theNurb, 8, knot, 4, &ctlarray[0][0], 3, GL_MAP1_VERTEX_4);
	//ctlarray[2][0] = 0.0 * 5; ctlarray[2][1] = -0.7 * 5;
	//ctlarray[2][2] = 0.0 * 5; ctlarray[2][3] = 1.0 * 5;
	//gluNurbsCurve(theNurb, 8, knot, 4, &ctlarray[0][0], 3, GL_MAP1_VERTEX_4);
	//ctlarray[2][0] = 0.0 * 0; ctlarray[2][1] = -0.7 * 0;
	//ctlarray[2][2] = 0.0 * 0; ctlarray[2][3] = 1.0 * 0;
	//gluNurbsCurve(theNurb, 8, knot, 4, &ctlarray[0][0], 3, GL_MAP1_VERTEX_4);

	glFlush();
}
void main(int arcg, char** arcv)
{
	glutInit(&arcg, arcv);
	glutInitDisplayMode(GLUT_RGBA | GLUT_SINGLE);
	glutInitWindowSize(480, 480);
	glutInitWindowPosition(100, 100);
	glutCreateWindow("  ");
	init();
	glutDisplayFunc(Display);
	glutMainLoop();
}
