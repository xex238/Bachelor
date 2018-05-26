#include "Work_with_matrix.h"
using namespace std;


int main()
{
	// Ñ÷èòûâàíèå ìàòðèöû ñ ôàéëà
	const string file_name = "matrix.csv";
	bool result;

	work_with_matrix work_1 = work_with_matrix();
	result = work_1.Open_file(file_name);

	if (!result)
	{
		cout << "An error occurred while opening the file" << endl;
		return 0;
	}

	// Ñ÷èòûâàíèå ñâîåé ìàòðèöû
	//int size{ 3 };
	//double** mat = new double*[3];

	//for (int i = 0; i < 3; i++)
	//{
	//	mat[i] = new double[3];
	//}
	//for (int i = 0; i < 3; i++)
	//{
	//	for (int j = 0; j < 3; j++)
	//	{
	//		mat[i][j] = rand() % 10;
	//	}
	//}

	//work_with_matrix work_2 = work_with_matrix(mat, size);

	// Âûïîëíÿåì ïåðåìíîæåíèå ïåðâîé ìàòðèöû â îòäåëüíîì ìåòîäå
	work_1.Matrix_multiplication_serial();
	work_1.Matrix_multiplication_parallel();

	// Âûïîëíÿåì ïåðåìíîæåíèå âòîðîé ìàòðèöû â îòäåëüíîì ìåòîäå
	//work_2.Write_all_matrix_into_console();
	//work_2.Matrix_multiplication_serial();
	//work_2.Matrix_multiplication_parallel();

	system("pause");
}
