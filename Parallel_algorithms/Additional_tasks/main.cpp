#include <vector>
#include <iostream>
#include <fstream>
#include <string>
#include <sstream>
#include <algorithm>
#include <iostream>
#include <ctime>
using namespace std;

void Matrix_multiplication_serial(vector<vector<double>> values)
{
	double start_time{ 0.0 };
	double end_time{ 0.0 };
	start_time = clock();

	double** new_mas = new double*[values.size() + 1];

	for (int i = 0; i < values.size(); i++)
	{
		new_mas[i] = new double[values.size() + 1];
	}

	for (int i = 0; i < values.size(); i++)
	{
		for (int j = 0; j < values[i].size(); j++)
		{
			new_mas[i][j] = 0;
		}
	}

	cout << "Computing is start" << endl;

	for (int i = 0; i < 1000; i++) /*Parallel.For(0, length, (i) = >*/
	{
		cout << i << endl;
		for (int j = 0; j < 1000; j++) //Parallel.For(0, length, (j) =>
		{
			for (int k = 0; k < 1000; k++) //Parallel.For(0, length, (k) =>
			{
				new_mas[i][j] = new_mas[i][j] + values[i][k] * values[k][j];
			}//);
		}//);
	}//);

	cout << "Computing is end" << endl;

	end_time = clock();

	cout << "Execution time of the program: " << (end_time - start_time) / CLOCKS_PER_SEC << " seconds" << endl;

	//string result_string = "";
	//for (int i=0; i<length; i++)
	//{
	//    for (int j=0; j<length; j++)
	//    {
	//        result_string = result_string + new_mas[i, j].ToString() + ",";
	//    }
	//}

	//File.WriteAllText("result.csv", result_string);
	cout << "first string of the program" << endl;
	for (int i = 0; i < values.size(); i++)
	{
		cout << new_mas[i][0] << endl;
	}
}

void Matrix_multiplication_parallel(vector<vector<double>> values)
{
	double start_time{ 0.0 };
	double end_time{ 0.0 };
	start_time = clock();

	double** new_mas = new double*[values.size() + 1];

	for (int i = 0; i < values.size(); i++)
	{
		new_mas[i] = new double[values.size() + 1];
	}

	for (int i = 0; i < values.size(); i++)
	{
		for (int j = 0; j < values[i].size(); j++)
		{
			new_mas[i][j] = 0;
		}
	}

	cout << "Computing is start" << endl;

	for (int i = 0; i < 1000; i++) /*Parallel.For(0, length, (i) = >*/
	{
		cout << i << endl;
		for (int j = 0; j < 1000; j++) //Parallel.For(0, length, (j) =>
		{
			for (int k = 0; k < 1000; k++) //Parallel.For(0, length, (k) =>
			{
				new_mas[i][j] = new_mas[i][j] + values[i][k] * values[k][j];
			}//);
		}//);
	}//);

	cout << "Computing is end" << endl;

	end_time = clock();

	cout << "Execution time of the program: " << (end_time - start_time) / CLOCKS_PER_SEC << " seconds" << endl;

	//string result_string = "";
	//for (int i=0; i<length; i++)
	//{
	//    for (int j=0; j<length; j++)
	//    {
	//        result_string = result_string + new_mas[i, j].ToString() + ",";
	//    }
	//}

	//File.WriteAllText("result.csv", result_string);
	cout << "first string of the program" << endl;
	for (int i = 0; i < values.size(); i++)
	{
		cout << new_mas[i][0] << endl;
	}
}

int main()
{
	const string fname = "matrix.csv";
	ifstream ifs(fname.c_str());
	if (!ifs)
	{
		cerr << "No file with name: " << fname << endl;
		return 1;
	}
	vector<vector<double>> values;
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
			}
		}
		values.push_back(temp);
	}
	ifs.close();

	// Вывод значений на экран

	//for (const auto& vec : values)
	//{
	//	for (const auto& v : vec)
	//	{
	//		cout << v << " ";
	//	}
	//	cout << endl;
	//}

	// Более понятный вывод значений на экран

	//for (int i = 0; i < values.size(); i++)
	//{
	//	for (int j = 0; j < values[i].size(); j++)
	//	{
	//		cout << values[i][j] << " ";
	//	}
	//	cout << endl;
	//}

	cout << "values.size() = " << values.size() << endl;

	// Выполняем перемножение матриц в отдельном методе
	Matrix_multiplication_serial(values);

	system("pause");
}