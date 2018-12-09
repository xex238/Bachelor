using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Добавить проверку на не равенство нулю определителя
// GetLength(0) - строки
// GetLength(1) - столбцы

namespace Version_1._0
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
                    Console.Write("{0:N3} ", a[i, j]);
                }
                Console.WriteLine();
            }
        }
        // Вывод вектора на экран
        static void Print_vector(float[] a, string s)
        {
            Console.WriteLine(s);
            for (int i=0; i<a.Length; i++)
            {
                Console.Write("{0:N3} ", a[i]);
            }
            Console.WriteLine();
        }
        // Проверка возможности открыть файл
        static bool Try_open_file(string filename)
        {
            try
            {
                float [,] myArray = Read_matrix(filename);
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
                Console.WriteLine("Ой. Что-то пошло не так :с");
                return false;
            }
            return true;
        }
        // Проверка определителя на равенство нулю
        static bool Check_determinate(float [,] a, float e)
        {
            for (int step = 0; step < a.GetLength(0) - 1; step++)
            {
                for (int i = step + 1; i < a.GetLength(0); i++)
                {
                    float important_number = -a[i, step] / a[step, step];
                    for (int j = step; j < a.GetLength(1); j++)
                    {
                        a[i, j] = a[step, j] * important_number + a[i, j];
                    }
                }
            }

            for (int i = 0; i < a.GetLength(1); i++)
            {
                if (Math.Abs(a[i, i]) < e)
                {
                    return true;
                }
            }
            return false;
        }
        // Реализация метода Гаусса
        static void Gayss_method(string file_name_matrix, string file_name_vector, float e)
        {
            if ((Try_open_file(file_name_matrix)) && (Try_open_file(file_name_vector)))
            {
                float[,] A = Read_matrix(file_name_matrix);
                float[,] bb = Read_matrix(file_name_vector);

                float[] b = new float[bb.GetLength(1)];
                for (int i = 0; i < bb.GetLength(1); i++)
                {
                    b[i] = bb[0, i];
                }

                Print_matrix(A, "Это начальная матрица А:");
                Print_vector(b, "Это начальный вектор b:");

                int[] coefficients = new int[A.GetLength(0)];

                for (int i=0; i<coefficients.GetLength(0); i++)
                {
                    coefficients[i] = i;
                }

                for (int step = 0; step < A.GetLength(0) - 1; step++)
                {
                    //// Где-то здесь ошибка

                    //float max = A[step, step];
                    //int i_max = step;
                    //int j_max = step;
                    //for (int i = step; i < A.GetLength(0); i++)
                    //{
                    //    for (int j = step; j < A.GetLength(1); j++)
                    //    {
                    //        if (Math.Abs(A[i, j]) > max)
                    //        {
                    //            i_max = i;
                    //            j_max = j;
                    //            max = Math.Abs(A[i, j]);
                    //        }
                    //    }
                    //}

                    //// Перестановка строк и столбцов
                    //float helper = 0;
                    //helper = coefficients[step];
                    //coefficients[step] = coefficients[j_max];
                    //coefficients[j_max] = (int)helper;

                    //helper = b[step];
                    //b[step] = b[i_max];
                    //b[i_max] = helper;

                    //for (int i = step; i < A.GetLength(1); i++)
                    //{
                    //    helper = A[step, i];
                    //    A[step, i] = A[i_max, i];
                    //    A[i_max, i] = helper;
                    //}
                    //for (int i = step; i < A.GetLength(0); i++)
                    //{
                    //    helper = A[i, step];
                    //    A[i, step] = A[i, j_max];
                    //    A[i, j_max] = helper;
                    //}

                    //// Итерации метода Гаусса
                    //for (int i = step + 1; i < A.GetLength(0); i++)
                    //{
                    //    float important_number = -A[i, step] / A[step, step];
                    //    for (int j = step; j < A.GetLength(1); j++)
                    //    {
                    //        A[i, j] = A[step, j] * important_number + A[i, j];
                    //    }
                    //    b[i] = b[step] * important_number + b[i];
                    //}
                    //Print_matrix(A, "Матрица после преобразований Гаусса");
                    //Print_vector(b, "Вектор b");











                    Console.WriteLine("Матрица до перестановки");
                    Print_matrix(A, "");

                    //double max = A[step, step];
                    int i_max = step;
                    //int j_max = step;
                    for (int i = step; i < A.GetLength(0); i++)
                    {
                        if (Math.Abs(A[i, step]) != 0)
                        {
                            i_max = i;
                            //max = Math.Abs(A[i, step]);
                            break;
                        }
                    }

                    //// Перестановка строк и столбцов
                    float helper = 0;
                    //helper = coefficients[step];
                    //coefficients[step] = coefficients[j_max];
                    //coefficients[j_max] = (int)helper;

                    helper = b[step];
                    b[step] = b[i_max];
                    b[i_max] = helper;

                    //for (int i = step; i < A.GetLength(1); i++)
                    //{
                    //    helper = A[step, i];
                    //    A[step, i] = A[i_max, i];
                    //    A[i_max, i] = helper;
                    //}
                    if (i_max != step)
                    {
                        for (int i = step; i < A.GetLength(0); i++)
                        {
                            helper = A[step, i];
                            A[step, i] = A[i_max, i];
                            A[i_max, i] = helper;
                        }
                    }

                    Console.WriteLine("Матрица после перестановки");
                    Print_matrix(A, "");

                    // Итерации метода Гаусса
                    for (int i = step + 1; i < A.GetLength(0); i++)
                    {
                        float important_number = -A[i, step] / A[step, step];
                        for (int j = step; j < A.GetLength(1); j++)
                        {
                            A[i, j] = A[step, j] * important_number + A[i, j];
                        }
                        b[i] = b[step] * important_number + b[i];
                    }
                }

                // Проверка определителя на равенство нулю, используя элементы главной диагонали
                bool determinant = false;
                for (int i = 0; i<A.GetLength(1); i++)
                {
                    if (Math.Abs(A[i, i]) < e)
                    {
                        determinant = true;
                        break;
                    }
                }

                if (!determinant)
                {
                    // Поиск решения (вычисление "иксов")
                    float[] result = new float[A.GetLength(1)];
                    for (int i = 0; i < A.GetLength(1); i++)
                    {
                        result[i] = 0;
                    }

                    for (int i = A.GetLength(1) - 1; i >= 0; i--)
                    {
                        float sum = 0;
                        for (int j = 0; j < A.GetLength(1); j++)
                        {
                            sum = sum + (A[i, j] * result[j]);
                        }
                        result[i] = (b[i] - sum) / A[i, i];
                    }

                    Console.WriteLine("Ответ:");
                    for (int i=0; i<A.GetLength(0); i++)
                    {
                        for (int j=0; j<A.GetLength(0); j++)
                        {
                            if (coefficients[j]==i)
                            {
                                Console.WriteLine("x{0} = {1:N3} ", i + 1, result[j]);
                                break;
                            }
                        }
                    }

                }
                else
                {
                    Console.WriteLine("Определитель системы уравнений равен нулю. Решение системы невозможно");
                }
            }
        }
        // Реализация метода Зейделя
        static void Zeidel_method(string file_name_matrix, string file_name_vector, float e)
        {
            if ((Try_open_file(file_name_matrix)) && (Try_open_file(file_name_vector)))
            {
                float[,] A = Read_matrix(file_name_matrix);
                float[,] bb = Read_matrix(file_name_vector);

                float[] b = new float[bb.GetLength(1)];
                for (int i = 0; i < bb.GetLength(1); i++)
                {
                    b[i] = bb[0, i];
                }

                Console.WriteLine("Введите ограничение на количество итераций в методе Зейделя:");
                int max_size = int.Parse(Console.ReadLine());

                Print_matrix(A, "Это начальная матрица А:");
                Print_vector(b, "Это начальный вектор b:");

                float[,] copy_A = (float[,])A.Clone();

                if (!Check_determinate(copy_A, e))
                {
                    // Приведение матрицы к нужному виду
                    for (int i = 0; i < A.GetLength(0); i++)
                    {
                        for (int j = 0; j < A.GetLength(1); j++)
                        {
                            if (i != j)
                            {
                                A[i, j] = -A[i, j] / A[i, i];
                            }
                        }
                        b[i] = b[i] / A[i, i];
                        A[i, i] = 0;
                    }

                    float[,] result_matrix = new float[A.GetLength(1) + 1, max_size];
                    for (int i = 0; i < A.GetLength(1) + 1; i++)
                    {
                        result_matrix[i, 0] = 0;
                    }

                    int x = 1;
                    do
                    {
                        for (int i = 0; i < A.GetLength(1); i++)
                        {
                            for (int j = 0; j < A.GetLength(0); j++)
                            {
                                if (j > i)
                                {
                                    result_matrix[i, x] = result_matrix[i, x] + A[i, j] * result_matrix[j, x - 1];
                                }
                                else
                                {
                                    result_matrix[i, x] = result_matrix[i, x] + A[i, j] * result_matrix[j, x];
                                }
                            }
                            result_matrix[i, x] += b[i];
                        }
                        float max = Math.Abs(result_matrix[0, x]);
                        for (int i = 1; i < A.GetLength(1); i++)
                        {
                            if (Math.Abs(result_matrix[i, x]) > max)
                            {
                                max = Math.Abs(result_matrix[i, x]);
                            }
                        }
                        result_matrix[A.GetLength(1), x] = max;
                        x++;
                        if (x == max_size)
                        {
                            Console.WriteLine("Количество проведённых итераций равно максимальному значению. Вычисления останавливаются.");
                            return;
                        }
                    } while (Math.Abs(result_matrix[A.GetLength(1), x - 1] - result_matrix[A.GetLength(1), x - 2]) > e);

                    Console.WriteLine("Ответ:");
                    for (int i = 0; i < A.GetLength(1); i++)
                    {
                        Console.WriteLine("x{0} = {1:N6}", i + 1, result_matrix[i, x - 1]);
                    }
                }
                else
                {
                    Console.WriteLine("Определитель матрицы равен нулю. Решение невозможно.");
                }
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Введите значение е (эпсилон)");
            float e = float.Parse(Console.ReadLine());

            Console.WriteLine("Решение системы модифицированным методом Гаусса");
            Gayss_method("matrix_A.txt", "vector_b.txt", e);
            Console.WriteLine("Решение системы методом Зейделя");
            Zeidel_method("matrix_A.txt", "vector_b.txt", e);
        }
    }
}
