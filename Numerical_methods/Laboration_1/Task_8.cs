using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        // Вывод матрицы с ответами на экран
        static void Print_computing_matrix(float[,] a, string s)
        {
            Console.WriteLine(s);
            for (int i=0; i<a.GetLength(0); i++)
            {
                Console.WriteLine("x{0} = {1:N3}", i+1, a[i, 0]);
            }
        }
        // Вывод вектора на экран
        static void Print_vector(float[] a, string s)
        {
            Console.WriteLine(s);
            for (int i = 0; i < a.Length; i++)
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
            return true;
        }
        // Проверка определителя на равенство нулю
        static bool Check_determinate(float[,] a, float e)
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

            bool determinant = false;
            for (int i = 0; i < a.GetLength(1); i++)
            {
                if (Math.Abs(a[i, i]) < e)
                {
                    determinant = true;
                    break;
                }
            }
            return determinant;
        }
        // Поиск максимального собственного значения матрицы
        static void Max_iegenvalue(float[,] A, float e)
        {
            float[,] matrix_with_computing = new float[100, A.GetLength(0) + 1];
            float[] vector_y = new float[A.GetLength(0)];
            float normalin = 0;

            for (int i=0; i<100; i++)
            {
                for (int j=0; j <= A.GetLength(0); j++)
                {
                    matrix_with_computing[i, j] = 0;
                }
            }

            matrix_with_computing[0, 0] = 1;

            int step = 0;

            do
            {
                for (int i = 0; i < A.GetLength(0); i++)
                {
                    for (int j = 0; j < A.GetLength(0); j++)
                    {
                        vector_y[i] = vector_y[i] + A[i, j] * matrix_with_computing[step, j];
                    }
                }

                for (int i=0; i<A.GetLength(0); i++)
                {
                    matrix_with_computing[step + 1, A.GetLength(0)] = matrix_with_computing[step + 1, A.GetLength(0)] + vector_y[i] * matrix_with_computing[step, i];
                }

                for (int i=0; i<vector_y.GetLength(0); i++)
                {
                    normalin = normalin + vector_y[i] * vector_y[i];
                }

                normalin = (float)Math.Sqrt(normalin);

                for (int i=0; i<A.GetLength(0); i++)
                {
                    matrix_with_computing[step + 1, i] = vector_y[i] / normalin;
                }

                if (step == 98)
                {
                    Console.WriteLine("Переполнение");
                    return;
                }

                for (int i=0; i<A.GetLength(0); i++)
                {
                    vector_y[i] = 0;
                }
                normalin = 0;

                step++;
            } while ((Math.Abs(matrix_with_computing[step, A.GetLength(0)] - matrix_with_computing[step-1, A.GetLength(0)])) > e);

            //for (int i = 0; i < 100; i++)
            //{
            //    for (int j = 0; j < A.GetLength(0) + 1; j++)
            //    {
            //        Console.Write("{0:N3} ", matrix_with_computing[i, j]);
            //    }
            //    Console.WriteLine();
            //}

            Console.WriteLine("Максимальное собственное число обратной матрицы и, соответственно, минимальное число исходной матрицы, равно {0:N3}", 1/matrix_with_computing[step, A.GetLength(0)]);
            Console.WriteLine("Собственный вектор равен:");
            for (int i = 0; i < A.GetLength(0); i++)
            {
                Console.WriteLine("{0:N3}", matrix_with_computing[step, i]);
            }
        }
        // Умножение матрицы на вектор
        static float[,] Matrix_multiplication(float[,] A, float[] B)
        {
            float[,] result_matrix = new float[A.GetLength(1), 1];

            for (int i=0; i<A.GetLength(0); i++)
            {
                result_matrix[i, 0] = 0;
                for (int j=0; j<A.GetLength(0); j++)
                {
                    result_matrix[i, 0] = result_matrix[i, 0] + A[i, j] * B[j];
                }
            }

            return result_matrix;
        }
        // Решение матрицы методом Холецкого
        static void Holetskiy_method(float[,] A, float[] B)
        {
            float[,] new_A = new float[A.GetLength(0), A.GetLength(1)];
            float[,] new_A_T = new float[A.GetLength(0), A.GetLength(1)];

            for (int i = 0; i < A.GetLength(0); i++)
            {
                for (int j = 0; j < A.GetLength(0); j++)
                {
                    new_A[i, j] = 0;
                    new_A_T[i, j] = 0;
                }
            }

            for (int i = 0; i < A.GetLength(0); i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    new_A[i, j] = A[i, j];
                    if (i == j)
                    {
                        for (int k = 0; k < j; k++)
                        {
                            new_A[i, j] = new_A[i, j] - new_A[i, k] * new_A[i, k];
                        }
                        new_A[i, j] = (float)Math.Sqrt(new_A[i, j]);
                    }
                    else
                    {
                        for (int k = 0; k < j; k++)
                        {
                            new_A[i, j] = new_A[i, j] - new_A[i, k] * new_A[j, k];
                        }
                        new_A[i, j] = new_A[i, j] / new_A[j, j];
                    }
                }
            }

            // Ищем транспонированную матрицу
            for (int i = 0; i < new_A_T.GetLength(0); i++)
            {
                for (int j = i; j < new_A_T.GetLength(0); j++)
                {
                    new_A_T[i, j] = new_A[j, i];
                }
            }

            //Print_matrix(new_A, "Матрица L:");
            //Print_matrix(new_A_T, "Матрица L(T):");

            for (int step = 0; step < new_A.GetLength(0) - 1; step++)
            {
                for (int i = step + 1; i < new_A.GetLength(0); i++)
                {
                    float important_number = -new_A[i, step] / new_A[step, step];
                    for (int j = step; j < new_A.GetLength(1); j++)
                    {
                        new_A[i, j] = new_A[step, j] * important_number + new_A[i, j];
                    }
                    B[i] = B[step] * important_number + B[i];
                }
            }

            for (int i=0; i<A.GetLength(0); i++)
            {
                B[i] = B[i] / new_A[i, i];
                new_A[i, i] = new_A[i, i] / new_A[i, i];
            }

            //Print_matrix(new_A, "Получившаяся матрица");
            //Print_vector(B, "Получившийся вектор");

            for (int step = new_A_T.GetLength(0) - 1; step > 0; step--)
            {
                for (int i = step - 1; i >= 0; i--)
                {
                    float important_number = -new_A_T[i, step] / new_A_T[step, step];
                    for (int j = step; j >= 0; j--)
                    {
                        new_A_T[i, j] = new_A_T[step, j] * important_number + new_A_T[i, j];
                    }
                    B[i] = B[step] * important_number + B[i];
                }
            }

            for (int i = 0; i < new_A_T.GetLength(0); i++)
            {
                B[i] = B[i] / new_A_T[i, i];
                new_A_T[i, i] = new_A_T[i, i] / new_A_T[i, i];
            }

            //Print_matrix(new_A_T, "Решение системы методом квадратных корней (методом Холецкого). Получившаяся матрица");
            //Print_vector(B, "Решение системы методом квадратных корней (методом Холецкого). Получившийся вектор");

            Console.WriteLine("Решение системы методом квадратных корней (методом Холецкого):");
            for (int i=0; i<B.GetLength(0); i++)
            {
                Console.WriteLine("x{0} = {1:N3}", i + 1, B[i]);
            }
        }
        // Нахождение обратной матрицы с помощью LU-преобразования
        static void LU_decomposition(ref float[,] A, ref float[,] copy_A, ref float[,] invert_A, ref float e)
        {
            copy_A = (float[,])A.Clone();
            // Прямой метод Гаусса
            for (int step = 0; step < A.GetLength(0) - 1; step++)
            {
                for (int i = step + 1; i < A.GetLength(0); i++)
                {
                    float important_number = -A[i, step] / A[step, step];
                    for (int j = step; j < A.GetLength(1); j++)
                    {
                        A[i, j] = A[step, j] * important_number + A[i, j];
                    }
                    for (int j = 0; j < A.GetLength(0); j++)
                    {
                        invert_A[i, j] = invert_A[step, j] * important_number + invert_A[i, j];
                    }
                }
            }

            // Обратный метод Гаусса
            for (int step = A.GetLength(0) - 1; step > 0; step--)
            {
                for (int i = step - 1; i >= 0; i--)
                {
                    float important_number = -A[i, step] / A[step, step];
                    for (int j = step; j >= 0; j--)
                    {
                        A[i, j] = A[step, j] * important_number + A[i, j];
                    }
                    for (int j = 0; j < A.GetLength(0); j++)
                    {
                        invert_A[i, j] = invert_A[step, j] * important_number + invert_A[i, j];
                    }
                }
            }

            // Нормирование
            for (int i = 0; i < A.GetLength(0); i++)
            {
                for (int j = 0; j < A.GetLength(0); j++)
                {
                    invert_A[i, j] = invert_A[i, j] / A[i, i];
                }
                A[i, i] = A[i, i] / A[i, i];
            }

            A = (float[,])copy_A.Clone();

            // Обратная матрица через LU-разложение
            Print_matrix(invert_A, "Обратная матрица через LU-разложение:");
        }
        static void Main_function(string file_name_matrix, string file_name_vector)
        {
            if ((Try_open_file(file_name_matrix)) || (Try_open_file(file_name_vector)))
            {
                float[,] A = Read_matrix(file_name_matrix);
                float[,] bb = Read_matrix(file_name_vector);

                float[] b = new float[bb.GetLength(1)];
                for (int i = 0; i < bb.GetLength(1); i++)
                {
                    b[i] = bb[0, i];
                }

                Console.WriteLine("Введите значение е (эпсилон)");
                float e = float.Parse(Console.ReadLine());

                Print_matrix(A, "Это начальная матрица А:");
                Print_vector(b, "Это начальный вектор b:");

                float[,] copy_A = (float[,])A.Clone();
                float[,] invert_A = new float[A.GetLength(0), A.GetLength(0)];

                for (int i = 0; i < invert_A.GetLength(0); i++)
                {
                    for (int j = 0; j < invert_A.GetLength(0); j++)
                    {
                        if (i == j)
                        {
                            invert_A[i, j] = 1;
                        }
                        else
                        {
                            invert_A[i, j] = 0;
                        }
                    }
                }

                if (!Check_determinate(copy_A, e))
                {
                    // Нахождение обратной матрицы с помощью LU-разложения
                    LU_decomposition(ref A, ref copy_A, ref invert_A, ref e);

                    // Решение системы через обратную матрицу
                    Print_computing_matrix(Matrix_multiplication(invert_A, b), "Решение системы через обратную матрицу:");

                    // Решение системы методом квадратных корней (методом Холецкого)
                    Holetskiy_method(A, b);

                    // Поиск минимального собственного значения матрицы и его собственных векторов через обратную матрицу
                    Max_iegenvalue(invert_A, e);
                }
                else
                {
                    Console.WriteLine("Определитель равен нулю. Невозможно найти обратную матрицу");
                }
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Начало алгоритма:");
            // При проверке у Гопенгауза
            //Main_function("check_matrix.txt", "check_vector.txt");

            // Пример из учебника
            //Main_function("matrix.txt", "vector.txt");

            Main_function("matrix_2.txt", "vector_2.txt");
        }
    }
}
