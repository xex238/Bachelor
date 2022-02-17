using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_7_b
{
    class Program
    {
        // Реализация метода Гаусса
        static void Gayss_method(double[,] A, double[] b)
        {
            Console.WriteLine("Введите погрешность");
            double e = double.Parse(Console.ReadLine());

            int[] coefficients = new int[A.GetLength(0)];

            for (int i = 0; i < coefficients.GetLength(0); i++)
            {
                coefficients[i] = i;
            }

            for (int step = 0; step < A.GetLength(0) - 1; step++)
            {
                //Console.WriteLine("Матрица до перестановки");
                //Print_matrix(A, A.GetLength(0));

                double max = A[step, step];
                int i_max = step;
                for (int i = step; i < A.GetLength(0); i++)
                {
                    if (Math.Abs(A[i, step]) != 0)
                    {
                        i_max = i;
                        break;
                    }
                }

                // Перестановка строк и столбцов
                double helper = 0;

                helper = b[step];
                b[step] = b[i_max];
                b[i_max] = helper;

                if (i_max != step)
                {
                    for (int i = step; i < A.GetLength(0); i++)
                    {
                        helper = A[step, i];
                        A[step, i] = A[i_max, i];
                        A[i_max, i] = helper;
                    }
                }

                // Итерации метода Гаусса
                for (int i = step + 1; i < A.GetLength(0); i++)
                {
                    double important_number = -A[i, step] / A[step, step];
                    for (int j = step; j < A.GetLength(1); j++)
                    {
                        A[i, j] = A[step, j] * important_number + A[i, j];
                    }
                    b[i] = b[step] * important_number + b[i];
                }
            }

            Console.WriteLine("Матрица после перестановок в методе Гаусса");
            Print_matrix(A, A.GetLength(0));

            // Проверка определителя на равенство нулю, используя элементы главной диагонали
            bool determinant = false;
            for (int i = 0; i < A.GetLength(1); i++)
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
                double[] result = new double[A.GetLength(1)];
                for (int i = 0; i < A.GetLength(1); i++)
                {
                    result[i] = 0;
                }

                for (int i = A.GetLength(1) - 1; i >= 0; i--)
                {
                    double sum = 0;
                    for (int j = 0; j < A.GetLength(1); j++)
                    {
                        sum = sum + (A[i, j] * result[j]);
                    }
                    result[i] = (b[i] - sum) / A[i, i];
                }

                Console.WriteLine("Ответ:");
                for (int i = 0; i < A.GetLength(0); i++)
                {
                    for (int j = 0; j < A.GetLength(0); j++)
                    {
                        if (coefficients[j] == i)
                        {
                            Console.WriteLine("x{0} = {1:N6} ", i + 1, result[j]);
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
        // Проверка определителя на равенство нулю
        static bool Check_determinate(double[,] a, double e)
        {
            for (int step = 0; step < a.GetLength(0) - 1; step++)
            {
                for (int i = step + 1; i < a.GetLength(0); i++)
                {
                    double important_number = -a[i, step] / a[step, step];
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
        // Реализация метода Зейделя (взято из 1-ой лабораторной работы)
        static void Zeidel_method(double[,] A, double[] b)
        {
            Console.WriteLine("Введите погрешность");
            double e = double.Parse(Console.ReadLine());

            Console.WriteLine("Введите ограничение на количество итераций в методе Зейделя:");
            int max_size = int.Parse(Console.ReadLine());

            double[,] copy_A = (double[,])A.Clone();

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

                double[,] result_matrix = new double[A.GetLength(1) + 1, max_size];
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
                    double max = Math.Abs(result_matrix[0, x]);
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
        // Решение СНУ методом Холецкого
        static void Holetskiy_method(double[,] A, double[] B)
        {
            Console.WriteLine("Введите погрешность");
            double e = double.Parse(Console.ReadLine());

            double[,] copy_A = (double[,])A.Clone();

            if (!Check_determinate(copy_A, e))
            {
                double[,] new_A = new double[A.GetLength(0), A.GetLength(1)];
                double[,] new_A_T = new double[A.GetLength(0), A.GetLength(1)];

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
                        double important_number = -new_A[i, step] / new_A[step, step];
                        for (int j = step; j < new_A.GetLength(1); j++)
                        {
                            new_A[i, j] = new_A[step, j] * important_number + new_A[i, j];
                        }
                        B[i] = B[step] * important_number + B[i];
                    }
                }

                for (int i = 0; i < A.GetLength(0); i++)
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
                        double important_number = -new_A_T[i, step] / new_A_T[step, step];
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
                for (int i = 0; i < B.GetLength(0); i++)
                {
                    Console.WriteLine("x{0} = {1:N3}", i + 1, B[i]);
                }
            }
            else
            {
                Console.WriteLine("Определитель матрицы равен нулю. Решение невозможно.");
            }
        }
        static void Print_matrix(double[,] x, int length)
        {
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    Console.Write("{0} ", x[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        static void Print_vector(double[] vector)
        {
            for (int i = 0; i < vector.Length; i++)
            {
                Console.Write("{0} ", vector[i]);
            }
            Console.WriteLine();
        }
        static double F_x(double x)
        {
            return (float)(x * x + x - Math.Pow(3, x - 1));
        }
        static double dF_x(double x, double delta)
        {
            return (F_x(x + delta) - F_x(x)) / delta;
        }
        static void Main(string[] args)
        {
            //double[] x = new double[3] { 1, 2, 2.5 };
            //double[] y = new double[3] { 1, 3, 3.5538 };

            //double[] x = new double[4] { 1, 2, 2.5, 3 };
            //double[] y = new double[4] { 1, 3, 3.5538, 3 };

            //double[] x = new double[5] { 1, 2, 2.5, 3, 4 };
            //double[] y = new double[5] { 1, 3, 3.5538, 3, -7 };

            double[] x = new double[6] { 1, 2, 2.5, 3, 4, 5 };
            double[] y = new double[6] { 1, 3, 3.5538, 3, -7, -51 };

            double[,] matrix = new double[(x.Length - 1) * 3, (x.Length - 1) * 3];

            int n = 0;
            for (int i = 0; i < 2 * (x.Length - 1); i = i + 2)
            {
                matrix[i, i / 2 * 3] = 1;
                matrix[i, i / 2 * 3 + 1] = x[n];
                matrix[i, i / 2 * 3 + 2] = x[n] * x[n];

                matrix[i + 1, i / 2 * 3] = 1;
                matrix[i + 1, i / 2 * 3 + 1] = x[n + 1];
                matrix[i + 1, i / 2 * 3 + 2] = x[n + 1] * x[n + 1];
                n++;
            }

            n = 0;

            for (int i = 2 * (x.Length - 1); i < (3 * (x.Length - 1)) - 1; i++)
            {
                matrix[i, n * 3 + 1] = 1;
                matrix[i, n * 3 + 2] = 2 * x[n + 1];

                matrix[i, n * 3 + 4] = -1;
                matrix[i, n * 3 + 5] = -2 * x[n + 1];
                n++;
            }


            matrix[(3 * (x.Length - 1)) - 1, 1] = 1;
            matrix[(3 * (x.Length - 1)) - 1, 2] = 2 * x[0];

            Print_matrix(matrix, 3 * (x.Length - 1));

            double[] vector = new double[3 * (x.Length - 1)];
            n = 0;

            for (int i = 0; i < 2 * (x.Length - 1); i = i + 2)
            {
                vector[i] = y[i / 2];
                vector[i + 1] = y[i / 2 + 1];
                n++;
            }

            for (int i = 3 * (x.Length - 2); i < (3 * (x.Length - 1)) - 1; i++)
            {
                vector[i] = 0;
            }

            vector[(3 * (x.Length - 1)) - 1] = dF_x(x[0], 0.00001);

            Print_vector(vector);

            //Zeidel_method(matrix_1, vector_1);
            Gayss_method(matrix, vector);
            //Holetskiy_method(matrix, vector);
        }
    }
}
