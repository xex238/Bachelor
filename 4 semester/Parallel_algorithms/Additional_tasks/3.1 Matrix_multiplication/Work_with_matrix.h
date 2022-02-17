#include <string>
#include <fstream>
#include <sstream>
#include <algorithm>
#include <iostream>
#include <ctime>
#include <omp.h>
#include <vector>
using namespace std;

#ifndef Work_with_matrix_
#define Work_with_matrix_

class work_with_matrix
{
public:
	work_with_matrix() = default;
	work_with_matrix(double** matrix, int lenght);
	~work_with_matrix() = default;
	void Matrix_multiplication_serial();
	void Matrix_multiplication_parallel();
	void Write_into_csv(string name_of_file);
	void Write_all_matrix_into_console();
	void Write_all_matrix_into_console(double** matrix);
	void Write_first_string_into_console(double** matrix);
	void From_vector_to_double();
	bool Open_file(string file_name);
private:
	int size{ 0 };
	vector<vector<double>> vector_matrix;
	double** double_matrix;
};

#endif // !
