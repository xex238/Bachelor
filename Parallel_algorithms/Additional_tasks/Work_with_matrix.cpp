#include "Work_with_matrix.h"

work_with_matrix::work_with_matrix(double** matrix, int lenght)
{
	size = lenght;

	double_matrix = new double*[size];

	for (int i = 0; i < size; i++)
	{
		double_matrix[i] = new double[size];
	}

	for (int i = 0; i < size; i++)
	{
		for (int j = 0; j < size; j++)
		{
			double_matrix[i][j] = matrix[i][j];
		}
	}
}
void work_with_matrix::Matrix_multiplication_serial()
{
	double start_time{ 0.0 };
	double end_time{ 0.0 };
	start_time = clock();

	double** new_mas = new double*[size];

	for (int i = 0; i < size; i++)
	{
		new_mas[i] = new double[size];
	}

	for (int i = 0; i < size; i++)
	{
		for (int j = 0; j < size; j++)
		{
			new_mas[i][j] = 0;
		}
	}

	cout << "Matrix multiplication serial is start" << endl;

	for (int i = 0; i < size; i++)
	{
		//cout << i << endl;
		for (int j = 0; j < size; j++)
		{
			for (int k = 0; k < size; k++)
			{
				new_mas[i][j] = new_mas[i][j] + double_matrix[i][k] * double_matrix[k][j];
			}
		}
	}

	cout << "Matrix multiplication serial is end" << endl;

	end_time = clock();

	cout << "Execution time of the program: " << (end_time - start_time) / CLOCKS_PER_SEC << " seconds" << endl;
	cout << endl;

	//Write_into_csv(new_mas, size, "result_serial.csv");
	Write_first_string_into_console(new_mas);
	//Write_all_matrix_into_console(new_mas);

	//cout << "new_mas[0][0] = " << new_mas[0][0] << endl;
}
void work_with_matrix::Matrix_multiplication_parallel()
{
	double start_time{ 0.0 };
	double end_time{ 0.0 };
	start_time = clock();

	double** new_mas = new double*[size];

	for (int i = 0; i < size; i++)
	{
		new_mas[i] = new double[size];
	}

	for (int i = 0; i < size; i++)
	{
		for (int j = 0; j < size; j++)
		{
			new_mas[i][j] = 0;
		}
	}

	cout << "Matrix multiplication parallel is start" << endl;
#pragma omp parallel for
	{
		for (int i = 0; i < size; i++)
		{
			//cout << i << endl;
			for (int j = 0; j < size; j++)
			{
				for (int k = 0; k < size; k++)
				{
					new_mas[i][j] = new_mas[i][j] + double_matrix[i][k] * double_matrix[k][j];
				}
			}
		}
	}

	cout << "Matrix multiplication parallel is end" << endl;

	end_time = clock();

	cout << "Execution time of the program: " << (end_time - start_time) / CLOCKS_PER_SEC << " seconds" << endl;

	//Write_into_csv(new_mas, size, "result_parallel.csv");
	Write_first_string_into_console(new_mas);
	//Write_all_matrix_into_console(new_mas);

	//cout << "new_mas[0][0] = " << new_mas[0][0] << endl;
}
void work_with_matrix::Write_into_csv(string name_of_file)
{
	string result_string = "";
	ostringstream strs;

	for (int i = 0; i < size; i++)
	{
		for (int j = 0; j < size; j++)
		{
			strs << double_matrix[i][j];
			double x = double_matrix[i][j];
			result_string = result_string + strs.str() + ",";
		}
	}

	cout << "File is creating..." << endl;

	ofstream out1(name_of_file);
	out1 << result_string << endl;
	out1.close();
	cout << "File was created" << endl;
}
void work_with_matrix::Write_all_matrix_into_console()
{
	for (int i = 0; i < size; i++)
	{
		for (int j = 0; j < size; j++)
		{
			cout << double_matrix[i][j] << " ";
		}
		cout << endl;
	}
}
void work_with_matrix::Write_all_matrix_into_console(double ** matrix)
{
	for (int i = 0; i < size; i++)
	{
		for (int j = 0; j < size; j++)
		{
			cout << matrix[i][j] << " ";
		}
		cout << endl;
	}
}
void work_with_matrix::Write_first_string_into_console(double** matrix)
{
	// Вывод первой строки в консоль
	cout << "first string of the program" << endl;
	for (int i = 0; i < size; i++)
	{
		cout << "matrix[" << i << "][0] = " << matrix[0][i] << endl;
	}
}
void work_with_matrix::From_vector_to_double()
{
	double_matrix = new double*[size];

	for (int i = 0; i < size; i++)
	{
		double_matrix[i] = new double[size];
	}

	for (int i = 0; i < size; i++)
	{
		for (int j = 0; j < size; j++)
		{
			double_matrix[i][j] = vector_matrix[i][j];
		}
	}
}
bool work_with_matrix::Open_file(string file_name)
{
	cout << "Start processing a file" << endl;

	double begin_time{ 0 };
	double end_time{ 0 };
	begin_time = clock();

	ifstream ifs(file_name.c_str());
	if (!ifs)
	{
		cerr << "No file with name: " << file_name << endl;
		return false;
	}

	string line;
	while (ifs.good())
	{
		getline(ifs, line);
		replace(line.begin(), line.end(), ',', ' ');
		stringstream ss(line);
		string current;
		vector<double> temp;
		while (ss >> current)
		{
			try
			{
				const double d = stod(current);
				temp.push_back(d);
			}
			catch (const exception& e)
			{
				return false;
			}
		}
		vector_matrix.push_back(temp);
	}
	ifs.close();
	end_time = clock();
	cout << "End processing a file" << endl;
	cout << "Time of processing a file is " << (float)(end_time - begin_time) / CLOCKS_PER_SEC << " seconds" << endl;
	cout << endl;

	size = vector_matrix.size() - 1;
	From_vector_to_double();

	return true;
}