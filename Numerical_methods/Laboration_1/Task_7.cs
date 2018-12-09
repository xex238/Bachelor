using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Version_2._0
{
    class Program
    {
        // Обработка матрицы
        static float[,] Read_matrix(string filename)
        {
            StreamReader file = new StreamReader(filename);
            string s = file.ReadToEnd();
            file.Close();
            string[] line = s.Split('\n');
            string[] column = line[0].Split(' ');
            float[,] a = new float[line.Length, column.Length];
            float t = 0;
            for (int i = 0; i < line.Length; i++)
            {
                column = line[i].Split(' ');
                for (int j = 0; j < column.Length; j++)
                {
                    t = Convert.ToSingle(column[j]);
                    a[i, j] = t;
                }
            }

            return a;
        }
        // Вывод матрицы на экран
        static void Print_matrix(float[,] a, string s)
        {
            Console.WriteLine(s);
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    Console.Write("{0:N5} ", a[i, j]);
                }
                Console.WriteLine();
            }
        }
        // Проверка возможности открыть файл
        static bool Try_open_file(string filename)
        {
            try
            {
                float[,] myArray = Read_matrix(filename);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Файл не найден");
                return false;
            }
            catch (FormatException)
            {
                Console.WriteLine("Неверное значение данных");
                return false;
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Выход за границы массива");
                return false;
            }
            catch (Exception)
            {
                Console.WriteLine("Упс, что-то пошло не так :с");
                return false;
            }
            return true;
        }
        static float[,] Matrix_multiplication(float [,] H_T, float[,] A, float[,] H)
        {
            float[,] result_matrix_1 = new float[A.GetLength(0), A.GetLength(0)];

            for (int i=0; i<A.GetLength(0); i++)
            {
                for (int j=0; j< A.GetLength(0); j++)
                {
                    result_matrix_1[i, j] = 0;
                }
            }

            for (int i=0; i<A.GetLength(0); i++)
            {
                for (int j=0; j<A.GetLength(0); j++)
                {
                    for (int k=0; k<A.GetLength(0); k++)
                    {
                        result_matrix_1[i, j] = result_matrix_1[i, j] + H_T[i, k] * A[k, j];
                    }
                }
            }

            float[,] result_matrix_2 = new float[A.GetLength(0), A.GetLength(0)];

            for (int i = 0; i < A.GetLength(0); i++)
            {
                for (int j = 0; j < A.GetLength(0); j++)
                {
                    result_matrix_2[i, j] = 0;
                }
            }

            for (int i = 0; i < A.GetLength(0); i++)
            {
                for (int j = 0; j < A.GetLength(0); j++)
                {
                    for (int k = 0; k < A.GetLength(0); k++)
                    {
                        result_matrix_2[i, j] = result_matrix_2[i, j] + result_matrix_1[i, k] * H[k, j];
                    }
                }
            }
            return result_matrix_2;
        }
        static float[,] Matrix_multiplication(float [,] A1, float [,] A2)
        {
            float[,] result_matrix = new float[A1.GetLength(0), A1.GetLength(0)];

            for (int i = 0; i < A1.GetLength(0); i++)
            {
                for (int j = 0; j < A1.GetLength(0); j++)
                {
                    result_matrix[i, j] = 0;
                }
            }

            for (int i = 0; i < A1.GetLength(0); i++)
            {
                for (int j = 0; j < A1.GetLength(0); j++)
                {
                    for (int k = 0; k < A1.GetLength(0); k++)
                    {
                        result_matrix[i, j] = result_matrix[i, j] + A1[i, k] * A2[k, j];
                    }
                }
            }

            return result_matrix;
        }
        static void Rotation_method (string file_name_matrix)
        {
            if (Try_open_file(file_name_matrix))
            {
                float[,] A = Read_matrix(file_name_matrix);

                Console.WriteLine("Введите значение е (эпсилон)");
                float e = float.Parse(Console.ReadLine());

                Print_matrix(A, "Это начальная матрица А:");

                // Начало программы
                float[,] H = new float[A.GetLength(0), A.GetLength(0)];
                float[,] H_T = new float[A.GetLength(0), A.GetLength(0)];
                float[,] result_vector_matrix = new float[A.GetLength(0), A.GetLength(0)];

                for (int i=0; i< A.GetLength(0); i++)
                {
                    for (int j=0; j< A.GetLength(0); j++)
                    {
                        if (i==j)
                        {
                            result_vector_matrix[i, j] = 1;
                        }
                        else
                        {
                            result_vector_matrix[i, j] = 0;
                        }
                    }
                }

                float sin_a = 0;
                float cos_a = 0;

                float max = 0;
                int i_max = 0;
                int j_max = 0;
                for (int i=0; i<A.GetLength(0); i++)
                {
                    for (int j=i+1; j<A.GetLength(0); j++)
                    {
                        if (Math.Abs(A[i,j])>max)
                        {
                            max = Math.Abs(A[i, j]);
                            i_max = i;
                            j_max = j;
                        }
                    }
                }
                int z = 0;
                while (max>e)
                {
                    z = z + 1;

                    sin_a = (float)Math.Sin(0.5 * Math.Atan(2 * A[i_max, j_max] / (A[i_max, i_max] - A[j_max, j_max])));
                    cos_a = (float)Math.Cos(0.5 * Math.Atan(2 * A[i_max, j_max] / (A[i_max, i_max] - A[j_max, j_max])));

                    for (int i=0; i<H.GetLength(0); i++)
                    {
                        for (int j=0; j<H.GetLength(0); j++)
                        {
                            if (i==j)
                            {
                                H[i, j] = 1;
                            }
                            else
                            {
                                H[i, j] = 0;
                            }
                        }
                    }
                    H[i_max, i_max] = cos_a;
                    H[j_max, j_max] = cos_a;
                    H[i_max, j_max] = -sin_a;
                    H[j_max, i_max] = sin_a;

                    H_T = (float[,])H.Clone();
                    H_T[i_max, j_max] = -H_T[i_max, j_max];
                    H_T[j_max, i_max] = -H_T[j_max, i_max];

                    A = Matrix_multiplication(H_T, A, H);

                    max = 0;
                    i_max = 0;
                    j_max = 0;
                    for (int i = 0; i < A.GetLength(0); i++)
                    {
                        for (int j = i + 1; j < A.GetLength(0); j++)
                        {
                            if (Math.Abs(A[i, j]) > max)
                            {
                                max = Math.Abs(A[i, j]);
                                i_max = i;
                                j_max = j;
                            }
                        }
                    }
                    result_vector_matrix = Matrix_multiplication(result_vector_matrix, H);
                }
                Print_matrix(result_vector_matrix, "Окончательная матрица с собственными векторами:");
                Print_matrix(A, "Окончательный результат");

                Console.WriteLine("Собственные значения и вектора:");
                for (int i=0; i<A.GetLength(0); i++)
                {
                    Console.WriteLine("Собственное значение №{0} = {1:N5}", i + 1, A[i, i]);
                    Console.Write("Собственный вектор X{0} = [", i + 1);
                    for (int j=0; j<A.GetLength(0); j++)
                    {
                        if (j + 1 != A.GetLength(0))
                            Console.Write("{0:N5}; ", result_vector_matrix[j, i]);
                        else
                            Console.WriteLine("{0:N5}]", result_vector_matrix[j, i]);
                    }
                }

                Console.WriteLine("Количество итераций - {0}", z);
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Нахождение собственных чисел и векторов методом вращения");
            Rotation_method("matrix_C.txt");
        }
    }
}
