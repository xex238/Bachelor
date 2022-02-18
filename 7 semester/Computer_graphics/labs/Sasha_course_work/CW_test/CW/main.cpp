#include <stdlib.h>
#include <math.h>
#include <iostream>
#include <ostream>
#include "glut.h"
using namespace std;

#define PI_ 3.14159265358979323846

class Jitter
{
public:
	const int MAX_SAMPLES = 66;

	struct JitterPoint
	{
		float X;
		float Y;

		JitterPoint(float x, float y)
		{
			X = x;
			Y = y;
		}
	};

	int asdf[2] = { 1, 2 };
	JitterPoint j2[2] =
	{
			JitterPoint(0.246490f,  0.249999f),
			JitterPoint(-0.246490f, -0.249999f)
	};

	JitterPoint j3[3] =
	{
			JitterPoint(-0.373411f, -0.250550f),
			JitterPoint(0.256263f,  0.368119f),
			JitterPoint(0.117148f, -0.117570f)
	};

	JitterPoint j4[4] =
	{
			JitterPoint(-0.208147f,  0.353730f),
			JitterPoint(0.203849f, -0.353780f),
			JitterPoint(-0.292626f, -0.149945f),
			JitterPoint(0.296924f,  0.149994f)
	};

	JitterPoint j8[8] =
	{
			JitterPoint(-0.334818f,  0.435331f),
			JitterPoint(0.286438f, -0.393495f),
			JitterPoint(0.459462f,  0.141540f),
			JitterPoint(-0.414498f, -0.192829f),
			JitterPoint(-0.183790f,  0.082102f),
			JitterPoint(-0.079263f, -0.317383f),
			JitterPoint(0.102254f,  0.299133f),
			JitterPoint(0.164216f, -0.054399f)
	};

	JitterPoint j15[15] =
	{
			JitterPoint(0.285561f,  0.188437f),
			JitterPoint(0.360176f, -0.065688f),
			JitterPoint(-0.111751f,  0.275019f),
			JitterPoint(-0.055918f, -0.215197f),
			JitterPoint(-0.080231f, -0.470965f),
			JitterPoint(0.138721f,  0.409168f),
			JitterPoint(0.384120f,  0.458500f),
			JitterPoint(-0.454968f,  0.134088f),
			JitterPoint(0.179271f, -0.331196f),
			JitterPoint(-0.307049f, -0.364927f),
			JitterPoint(0.105354f, -0.010099f),
			JitterPoint(-0.154180f,  0.021794f),
			JitterPoint(-0.370135f, -0.116425f),
			JitterPoint(0.451636f, -0.300013f),
			JitterPoint(-0.370610f,  0.387504f)
	};

	JitterPoint j24[24] =
	{
			JitterPoint(0.030245f,  0.136384f),
			JitterPoint(0.018865f, -0.348867f),
			JitterPoint(-0.350114f, -0.472309f),
			JitterPoint(0.222181f,  0.149524f),
			JitterPoint(-0.393670f, -0.266873f),
			JitterPoint(0.404568f,  0.230436f),
			JitterPoint(0.098381f,  0.465337f),
			JitterPoint(0.462671f,  0.442116f),
			JitterPoint(0.400373f, -0.212720f),
			JitterPoint(-0.409988f,  0.263345f),
			JitterPoint(-0.115878f, -0.001981f),
			JitterPoint(0.348425f, -0.009237f),
			JitterPoint(-0.464016f,  0.066467f),
			JitterPoint(-0.138674f, -0.468006f),
			JitterPoint(0.144932f, -0.022780f),
			JitterPoint(-0.250195f,  0.150161f),
			JitterPoint(-0.181400f, -0.264219f),
			JitterPoint(0.196097f, -0.234139f),
			JitterPoint(-0.311082f, -0.078815f),
			JitterPoint(0.268379f,  0.366778f),
			JitterPoint(-0.040601f,  0.327109f),
			JitterPoint(-0.234392f,  0.354659f),
			JitterPoint(-0.003102f, -0.154402f),
			JitterPoint(0.297997f, -0.417965f)
	};

	JitterPoint j66[66] =
	{
			JitterPoint(0.266377f, -0.218171f),
			JitterPoint(-0.170919f, -0.429368f),
			JitterPoint(0.047356f, -0.387135f),
			JitterPoint(-0.430063f,  0.363413f),
			JitterPoint(-0.221638f, -0.313768f),
			JitterPoint(0.124758f, -0.197109f),
			JitterPoint(-0.400021f,  0.482195f),
			JitterPoint(0.247882f,  0.152010f),
			JitterPoint(-0.286709f, -0.470214f),
			JitterPoint(-0.426790f,  0.004977f),
			JitterPoint(-0.361249f, -0.104549f),
			JitterPoint(-0.040643f,  0.123453f),
			JitterPoint(-0.189296f,  0.438963f),
			JitterPoint(-0.453521f, -0.299889f),
			JitterPoint(0.408216f, -0.457699f),
			JitterPoint(0.328973f, -0.101914f),
			JitterPoint(-0.055540f, -0.477952f),
			JitterPoint(0.194421f,  0.453510f),
			JitterPoint(0.404051f,  0.224974f),
			JitterPoint(0.310136f,  0.419700f),
			JitterPoint(-0.021743f,  0.403898f),
			JitterPoint(-0.466210f,  0.248839f),
			JitterPoint(0.341369f,  0.081490f),
			JitterPoint(0.124156f, -0.016859f),
			JitterPoint(-0.461321f, -0.176661f),
			JitterPoint(0.013210f,  0.234401f),
			JitterPoint(0.174258f, -0.311854f),
			JitterPoint(0.294061f,  0.263364f),
			JitterPoint(-0.114836f,  0.328189f),
			JitterPoint(0.041206f, -0.106205f),
			JitterPoint(0.079227f,  0.345021f),
			JitterPoint(-0.109319f, -0.242380f),
			JitterPoint(0.425005f, -0.332397f),
			JitterPoint(0.009146f,  0.015098f),
			JitterPoint(-0.339084f, -0.355707f),
			JitterPoint(-0.224596f, -0.189548f),
			JitterPoint(0.083475f,  0.117028f),
			JitterPoint(0.295962f, -0.334699f),
			JitterPoint(0.452998f,  0.025397f),
			JitterPoint(0.206511f, -0.104668f),
			JitterPoint(0.447544f, -0.096004f),
			JitterPoint(-0.108006f, -0.002471f),
			JitterPoint(-0.380810f,  0.130036f),
			JitterPoint(-0.242440f,  0.186934f),
			JitterPoint(-0.200363f,  0.070863f),
			JitterPoint(-0.344844f, -0.230814f),
			JitterPoint(0.408660f,  0.345826f),
			JitterPoint(-0.233016f,  0.305203f),
			JitterPoint(0.158475f, -0.430762f),
			JitterPoint(0.486972f,  0.139163f),
			JitterPoint(-0.301610f,  0.009319f),
			JitterPoint(0.282245f, -0.458671f),
			JitterPoint(0.482046f,  0.443890f),
			JitterPoint(-0.121527f,  0.210223f),
			JitterPoint(-0.477606f, -0.424878f),
			JitterPoint(-0.083941f, -0.121440f),
			JitterPoint(-0.345773f,  0.253779f),
			JitterPoint(0.234646f,  0.034549f),
			JitterPoint(0.394102f, -0.210901f),
			JitterPoint(-0.312571f,  0.397656f),
			JitterPoint(0.200906f,  0.333293f),
			JitterPoint(0.018703f, -0.261792f),
			JitterPoint(-0.209349f, -0.065383f),
			JitterPoint(0.076248f,  0.478538f),
			JitterPoint(-0.073036f, -0.355064f),
			JitterPoint(0.145087f,  0.221726f)
	};
};

Jitter my_jitter;

// 10.2 - 10.3

void accFrustun(GLdouble left, GLdouble right, GLdouble bottom, GLdouble top, GLdouble zNear, GLdouble zFar, GLdouble pixdx, GLdouble pixdy, GLdouble eyedx, GLdouble eyedy, GLdouble focus)
{
	GLdouble xwsize, ywsize;
	GLdouble dx, dy;
	GLint viewport[4];

	glGetIntegerv(GL_VIEWPORT, viewport);
	xwsize = right - left;
	ywsize = top - bottom;
	dx = -(pixdx * xwsize / (GLdouble)viewport[2] + eyedx * zNear / focus);
	dy = -(pixdy * ywsize / (GLdouble)viewport[3] + eyedy * zNear / focus);

	glMatrixMode(GL_PROJECTION);
	glLoadIdentity();
	glFrustum(left + dx, right + dx, bottom + dy, top + dy, zNear, zFar);
	glMatrixMode(GL_MODELVIEW);
	glLoadIdentity();
	glTranslatef(-eyedx, -eyedy, 0.0);
}

void accPerspective(GLdouble fovy, GLdouble aspect, GLdouble zNear, GLdouble zFar, GLdouble pixdx, GLdouble pixdy, GLdouble eyedx, GLdouble eyedy, GLdouble focus)
{
	GLdouble fov2, left, right, bottom, top;
	fov2 = ((fovy * PI_) / 180.0) / 2.0;

	top = zNear / (cos(fov2) / sin(fov2));
	bottom = -top;
	right = top * aspect;
	left = -right;

	accFrustun(left, right, bottom, top, zNear, zFar, pixdx, pixdy, eyedx, eyedy, focus);
}

//void init(void)
//{
//	GLfloat nat_anbient[] = { 1.0, 1.0, 1.0, 1.0 };
//	GLfloat nat_specular[] = { 1.0, 1.0, 1.0, 1.0 };
//	GLfloat light_position[] = { 0.0, 0.0, 10.0, 1.0 };
//	GLfloat ln_ambient[] = { 0.2, 0.2, 0.2, 1.0 };
//
//	glMaterialfv(GL_FRONT, GL_AMBIENT, nat_anbient);
//	glMaterialfv(GL_FRONT, GL_SPECULAR, nat_specular);
//	glMaterialf(GL_FRONT, GL_SHININESS, 50.0);
//	glLightfv(GL_LIGHT0, GL_POSITION, light_position);
//	glLightModelfv(GL_LIGHT_MODEL_AMBIENT, ln_ambient);
//
//	glEnable(GL_LIGHTING);
//	glEnable(GL_LIGHT0);
//	glEnable(GL_DEPTH_TEST);
//	glShadeModel(GL_FLAT);
//
//	glClearColor(0.0, 0.0, 0.0, 0.0);
//	glClearAccum(0.0, 0.0, 0.0, 0.0);
//}
//
//void Display_objects(void)
//{
//	GLfloat torus_diffuse[] = { 0.7, 0.7, 0.0, 1.0 };
//	GLfloat cube_diffuse[] = { 0.0, 0.7, 0.7, 1.0 };
//	GLfloat sphere_diffuse[] = { 0.7, 0.0, 0.7, 1.0 };
//	GLfloat octa_diffuse[] = { 0.7, 0.4, 0.4, 1.0 };
//
//	glPushMatrix();
//	glTranslatef(0.0, 0.0, -5.0);
//	glRotatef(30.0, 1.0, 0.0, 0.0);
//
//	glPushMatrix();
//	glTranslatef(-0.80, 0.35, 0.0);
//	glRotatef(100.0, 1.0, 0.0, 0.0);
//	glMaterialfv(GL_FRONT, GL_DIFFUSE, torus_diffuse);
//	glutSolidTorus(0.275, 0.85, 16, 16);
//	glPopMatrix();
//
//	glPushMatrix();
//	glTranslatef(-0.75, -0.5, 0.0);
//	glRotatef(45.0, 0.0, 0.0, 1.0);
//	glRotatef(45.0, 1.0, 0.0, 0.0);
//	glMaterialfv(GL_FRONT, GL_DIFFUSE, cube_diffuse);
//	glutSolidCube(1.5);
//	glPopMatrix();
//
//	glPushMatrix();
//	glTranslatef(0.75, 0.6, 0.0);
//	glRotatef(30.0, 1.0, 0.0, 0.0);
//	glMaterialfv(GL_FRONT, GL_DIFFUSE, sphere_diffuse);
//	glutSolidSphere(1.0, 16, 16);
//	glPopMatrix();
//
//	glPushMatrix();
//	glTranslatef(0.70, -0.90, 0.25);
//	glMaterialfv(GL_FRONT, GL_DIFFUSE, octa_diffuse);
//	glutSolidOctahedron();
//	glPopMatrix();
//
//	glPopMatrix();
//
//	glFlush(); // Добавленная строка (работает в 10.2-10.3)
//}
//
//#define ACSIZE 8
//
////void Display(void)
////{
////	GLint viewport[4];
////	int jitter;
////
////	glGetIntegerv(GL_VIEWPORT, viewport);
////
////	glClear(GL_ACCUM_BUFFER_BIT);
////	for (jitter = 0; jitter < ACSIZE; jitter++)
////	{
////		glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);
////		accPerspective(50.0, (GLdouble)viewport[2] / (GLdouble)viewport[3], 1.0, 15.0, my_jitter.j8[jitter].X, my_jitter.j8[jitter].Y, 0.0, 0.0, 1.0); // Не j1, a j8
////		Display_objects();
////	}
////	glAccum(GL_RETURN, 1.0);
////	glFlush();
////}
////
////void Reshape(int w, int h)
////{
////	glViewport(0, 0, (GLsizei)w, (GLsizei)h);
////}
//
//// Главный цикл
//// Убедитесь в наличии запроса буфера накопления
//
//
//
//
//
//
//
//
//
//
//
//
//
//// "Дрожание" с помощью ортогональной проекции (10.4)
//
//void Display(void)
//{
//	GLint viewport[4];
//	int jitter;
//
//	glGetIntegerv(GL_VIEWPORT, viewport);
//	glClear(GL_ACCUM_BUFFER_BIT);
//	for (jitter = 0; jitter < ACSIZE; jitter++)
//	{
//		glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);
//		glPushMatrix();
//
//		// Заметьте, что 4.5 - это растояние в мировых координатах
//		// между левой и правой сторонами и между верхней и нижней.
//		// Эта формула преобразует движение пиксела от дробного значения
//		// к мировым координатам
//		glTranslatef(my_jitter.j8[jitter].X * 4.5 / viewport[2], my_jitter.j8[jitter].Y * 4.5 / viewport[3], 0.0);
//		Display_objects();
//		glPopMatrix();
//		glAccum(GL_ACCUM, 1.0 / ACSIZE);
//	}
//	glAccum(GL_RETURN, 1.0);
//	glFlush();
//}
//
//void Reshape(int w, int h)
//{
//	glViewport(0, 0, (GLsizei)w, (GLsizei)h);
//	glMatrixMode(GL_PROJECTION);
//	glLoadIdentity();
//	if (w <= h)
//	{
//		glOrtho(-2.25, 2.25, -2.25 * w / h, 2.25 * w / h, -10.0, 10.0);
//	}
//	else
//	{
//		glOrtho(-2.25 * w / h, 2.25 * w / h, -2.25, 2.25, -10.0, 10.0);
//	}
//	glMatrixMode(GL_MODELVIEW);
//	glLoadIdentity();
//}
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//int main(int argc, char** argv)
//{
//	glutInit(&argc, argv);
//	glutInitDisplayMode(GLUT_SINGLE | GLUT_RGB | GLUT_ACCUM | GLUT_DEPTH);
//	glutInitWindowSize(250, 250);
//	glutInitWindowPosition(100, 100);
//	glutCreateWindow(argv[0]);
//	init();
//	glutReshapeFunc(Reshape);
//	glutDisplayFunc(Display);
//	glutMainLoop();
//	return 0;
//}






// Имитация глубины резкости (10.5)

GLint teapotList = glGenLists(1); // Добавлено GLint

void init(void)
{
	cout << teapotList << endl;

	GLfloat ambient[] = { 0.0, 0.0, 0.0, 1.0 };
	GLfloat diffuse[] = { 1.0, 1.0, 1.0, 1.0 };
	GLfloat specular[] = { 1.0, 1.0, 1.0, 1.0 };
	GLfloat position[] = { 0.0, 3.0, 3.0, 0.0 };

	GLfloat lmodel_ambient[] = { 0.2, 0.2, 0.2, 1.0 };
	GLfloat local_view[] = { 0.0 };

	glLightfv(GL_LIGHT0, GL_AMBIENT, ambient);
	glLightfv(GL_LIGHT0, GL_DIFFUSE, diffuse);
	glLightfv(GL_LIGHT0, GL_POSITION, position);

	glLightModelfv(GL_LIGHT_MODEL_AMBIENT, lmodel_ambient);
	glLightModelfv(GL_LIGHT_MODEL_LOCAL_VIEWER, local_view);

	glFrontFace(GL_CW);
	glEnable(GL_LIGHTING);
	glEnable(GL_LIGHT0);
	glEnable(GL_AUTO_NORMAL);
	glEnable(GL_NORMALIZE);
	glEnable(GL_DEPTH_TEST);

	glClearColor(0.0, 0.0, 0.0, 0.0);
	glClearAccum(0.0, 0.0, 0.0, 0.0);

	// Список отображения для чайника
	//GLint teapotList = glGenLists(1); // Добавлено GLint
	glNewList(teapotList, GL_COMPILE);
	glutSolidTeapot(0.5);
	glEndList();
}

void Render_teapot(GLfloat x, GLfloat y, GLfloat z, GLfloat ambr, GLfloat ambg, GLfloat ambb, GLfloat difr, GLfloat difg, GLfloat difb, GLfloat specr, GLfloat specg, GLfloat specb, GLfloat shine)
{
	GLfloat mat[4];

	glPushMatrix();
	glTranslatef(x, y, z);

	mat[0] = ambr;
	mat[1] = ambg;
	mat[2] = ambb;
	mat[3] = 1.0;
	glMaterialfv(GL_FRONT, GL_AMBIENT, mat);

	mat[0] = difr;
	mat[1] = difg;
	mat[2] = difb;
	glMaterialfv(GL_FRONT, GL_DIFFUSE, mat);

	mat[0] = specr;
	mat[1] = specg;
	mat[2] = specb;
	glMaterialfv(GL_FRONT, GL_SPECULAR, mat);

	glMaterialf(GL_FRONT, GL_SHININESS, shine * 128.0);
	glCallList(teapotList);
	glPopMatrix();

	//glFlush(); // Добавленная строка (не работает)
}

void Display(void)
{
	int jitter = 0;
	GLint viewport[4];

	glGetIntegerv(GL_VIEWPORT, viewport);
	glClear(GL_ACCUM_BUFFER_BIT);

	for (jitter = 0; jitter < 8; jitter++)
	{
		glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);
		accPerspective(45.0, (GLdouble)viewport[2] / (GLdouble)viewport[3], 1.0, 15.0, 0.0, 0.0, 0.33 * my_jitter.j8[jitter].X, 0.33 * my_jitter.j8[jitter].Y, 5.0);

		// Рубиновый, золотой, серебряный, изумрудный и циановый чайники
		Render_teapot(-1.1, -0.5, -4.5, 0.1745, 0.01175, 0.01175, 0.61424, 0.04136, 0.04136, 0.727811, 0.626959, 0.626959, 0.6);
		Render_teapot(-0.5, -0.5, -5.0, 0.24725, 0.1995, 0.0745, 0.75164, 0.60648, 0.22648, 0.628281, 0.555802, 0.366065, 0.4);
		Render_teapot(0.2, -0.5, -5.5, 0.19225, 0.19225, 0.19225, 0.50754, 0.50754, 0.50754, 0.508273, 0.508273, 0.508273, 0.4);
		Render_teapot(1.0, -0.5, -6.0, 0.0215, 0.1745, 0.0215, 0.07568, 0.61424, 0.07568, 0.633, 0.727811, 0.633, 0.6);
		Render_teapot(1.8, -0.5, -6.5, 0.0, 0.1, 0.06, 0.0, 0.50980392, 0.50980392, 0.50196078, 0.50196078, 0.50196078, 0.25);

		glAccum(GL_ACCUM, 0.125);

		//glFlush(); // Добавленный код (не работает)
	}

	//// Добавленный код
	//glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);
	////accPerspective(45.0, (GLdouble)viewport[2] / (GLdouble)viewport[3], 1.0, 15.0, 0.0, 0.0, 0.33 * my_jitter.j8[jitter].X, 0.33 * my_jitter.j8[jitter].Y, 5.0);

	//// Рубиновый, золотой, серебряный, изумрудный и циановый чайники
	//Render_teapot(-1.1, -0.5, -4.5, 0.1745, 0.01175, 0.01175, 0.61424, 0.04136, 0.04136, 0.727811, 0.626959, 0.626959, 0.6);
	////Render_teapot(-0.5, -0.5, -5.0, 0.24725, 0.1995, 0.0745, 0.75164, 0.60648, 0.22648, 0.628281, 0.555802, 0.366065, 0.4);
	////Render_teapot(0.2, -0.5, -5.5, 0.19225, 0.19225, 0.19225, 0.50754, 0.50754, 0.50754, 0.508273, 0.508273, 0.508273, 0.4);
	////Render_teapot(1.0, -0.5, -6.0, 0.0215, 0.1745, 0.0215, 0.07568, 0.61424, 0.07568, 0.633, 0.727811, 0.633, 0.6);
	////Render_teapot(1.8, -0.5, -6.5, 0.0, 0.1, 0.06, 0.0, 0.50980392, 0.50980392, 0.50196078, 0.50196078, 0.50196078, 0.25);

	////glAccum(GL_ACCUM, 0.125);
	//// Конец добавленного кода

	glAccum(GL_RETURN, 1.0);
	glFlush();
}

void Reshape(int w, int h)
{
	glViewport(0, 0, (GLsizei)w, (GLsizei)h);
}

// Главный цикл
// Убедитесь в наличии запроса буфера накопления
int main(int argc, char** argv)
{
	glutInit(&argc, argv);
	glutInitDisplayMode(GLUT_SINGLE | GLUT_RGB | GLUT_ACCUM | GLUT_DEPTH);
	glutInitWindowSize(400, 400);
	glutInitWindowPosition(100, 100);
	glutCreateWindow(argv[0]);
	init();
	glutReshapeFunc(Reshape);
	glutDisplayFunc(Display);
	glutMainLoop();
	return 0;
}