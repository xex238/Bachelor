using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3_b
{
    class Program
    {
        // Реализация метода Гаусса
        static double[] Gayss_method(double[,] A, double[] b)
        {
            double[] result_vector = new double[b.Length];

            for (int i = 0; i < result_vector.Length; i++)
            {
                result_vector[i] = 0;
            }

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

            //Console.WriteLine("Матрица после перестановок в методе Гаусса");
            //Print_matrix(A, A.GetLength(0), "");

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

                int counter = 0;
                //Console.WriteLine("Ответ:");
                for (int i = 0; i < A.GetLength(0); i++)
                {
                    for (int j = 0; j < A.GetLength(0); j++)
                    {
                        if (coefficients[j] == i)
                        {
                            //Console.WriteLine("x{0} = {1:N6} ", i + 1, result[j]);
                            result_vector[counter] = result[j];
                            counter++;
                            break;
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("Определитель системы уравнений равен нулю. Решение системы невозможно");
            }
            return result_vector;
        }
        // Вывод массива на экран
        public static void Print_mas(double[] mas, string s)
        {
            Console.WriteLine(s);
            for (int i=0; i<mas.Length; i++)
            {
                Console.Write("{0:N3} ", mas[i]);
            }
            Console.WriteLine();
        }
        // Вывод на экран квадратной матрицы
        public static void Print_matrix(double[,] matrix, int length, string s)
        {
            Console.WriteLine(s);
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    Console.Write("{0:N3}    ", matrix[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        //public static double F_1(double x)
        //{
        //    return x * x;
        //}
        //public static double Integral_computing(double a, double b, int count_polinoms)
        //{
        //    double result = 0;
        //    for (double i = a; i < b; i = i + 0.1)
        //    {
        //        result += i * F_1(i);
        //    }
        //    return result;
        //}
        // Вычисление интеграла от полинома
        public static double Integral_from_polynom(double a, double b, double[] polunom_vector)
        {
            //Print_mas(polunom_vector, "При вычислении интеграла polunom_vector = ");

            double[] helper_polunom = new double[polunom_vector.Length + 1];
            helper_polunom[helper_polunom.Length - 1] = 0;
            int k = 1;
            for (int i = helper_polunom.Length - 2; i >= 0; i--)
            {
                helper_polunom[i] = polunom_vector[i] / k;
                k++;
            }
            //Print_mas(helper_polunom, "Вспомогательный полином");
            double result = 0;
            k = 0;
            for (int i = helper_polunom.Length - 1; i >= 0; i--)
            {
                result += helper_polunom[i] * (Math.Pow(b, k) - Math.Pow(a, k));
                //Console.WriteLine("result = {0}", result);
                k++;
            }
            //Console.WriteLine("Интеграл равен: {0}", result);
            return result;
        }
        public static double[] Diff_from_polynom(double[] vector)
        {
            double[] result = new double[vector.Length - 1];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = vector[i] * (vector.Length - 1 - i);
            }
            return result;
        }
        public static double Counting_value(double[,] matrix, int line, double x)
        {
            double result = 0;
            for (int i = line; i >= 0; i--)
            {
                result += matrix[line, i] * Math.Pow(x, i);
            }
            return result;
        }
        // Умножение вектора на вектор
        public static double[] Multiplication_vector(double[] vector_1, double[] vector_2)
        {
            double[] result = new double[vector_1.Length + vector_2.Length - 1];

            for (int i = 0; i < result.Length; i++)
            {
                result[i] = 0;
            }

            for (int i = 0; i < result.Length; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    try
                    {
                        result[i] += vector_1[j] * vector_2[i - j];
                    }
                    catch (Exception)
                    {

                    }
                }
            }
            //Print_mas(result, "Результат перемножения двух многочленов");
            return result;
        }
        // Умножение вектора на число
        public static double[] Multiplication_vector_on_number(double[] vector, double number)
        {
            double[] helper_vector = new double[vector.Length];
            for (int i = 0; i < vector.Length; i++)
            {
                helper_vector[i] = vector[i] * number;
            }
            return helper_vector;
        }
        // Повышение степени полинома
        public static double[] Increasing_degree(double[] vector, int degree)
        {
            double[] helper_polynom = new double[vector.Length + degree];
            for (int i = 0; i < vector.Length; i++)
            {
                helper_polynom[i] = vector[i];
            }
            for (int i = vector.Length; i < helper_polynom.Length; i++)
            {
                helper_polynom[i] = 0;
            }
            return helper_polynom;
        }
        // Сложение двух полиномов
        public static double[] Sum_polynom(double[] sum_polynom, double[] helper_vector)
        {
            double[] result = new double[sum_polynom.Length];

            for (int k = 0; k < result.Length; k++)
            {
                result[k] = 0;
            }

            int i = 0;
            while (helper_vector.Length - 1 - i >= 0)
            {
                result[result.Length - 1 - i] = sum_polynom[sum_polynom.Length - 1 - i] + helper_vector[helper_vector.Length - 1 - i];
                i++;
            }
            while(sum_polynom.Length - 1 - i >= 0)
            {
                result[result.Length - 1 - i] = sum_polynom[sum_polynom.Length - 1 - i];
                i++;
            }

            return result;
        }
        // Генерация ортогональных полиномов
        public static double[,] Generate_polynom(double a, double b, int count_polynoms)
        {
            double solve_integral = 0;
            double[,] result_matrix = new double[count_polynoms, count_polynoms];
            result_matrix[0, 0] = 1;
            for (int i = 1; i < count_polynoms; i++)
            {
                result_matrix[i, i] = 1;
                double[] sum_polynom = new double[i];

                for (int j = 0; j < sum_polynom.Length; j++)
                {
                    sum_polynom[j] = 0;
                }

                // Находим энный член полинома
                for (int k = i - 1; k >= 0; k--)
                {
                    double[] helper_vector = new double[k + 1];
                    // Находим fn(x)
                    for (int j = k; j >= 0; j--)
                    {
                        helper_vector[k - j] = result_matrix[k, j];
                    }
                    //Print_mas(helper_vector, "Перед всеми операциями helper_vector = ");
                    solve_integral = -Integral_from_polynom(a, b, Increasing_degree(helper_vector, i)) / Integral_from_polynom(a, b, Multiplication_vector(helper_vector, helper_vector));
                    helper_vector = Multiplication_vector_on_number(helper_vector, solve_integral);
                    sum_polynom = Sum_polynom(sum_polynom, helper_vector);
                    //Console.WriteLine("k = {0}", k);
                    //Console.WriteLine("solve_integral = {0}", solve_integral);
                    //Print_mas(helper_vector, "helper_vector = ");
                    //Print_mas(sum_polynom, "sum_polynom = ");
                }
                for (int k = i - 1; k >= 0; k--)
                {
                    result_matrix[i, k] = sum_polynom[i - 1 - k];
                }
            }

            Print_matrix(result_matrix, count_polynoms, "Вывод матрицы с коэффициентами ортогональных полиномов на экран");
            return result_matrix;
        }
        public static void LSM(double[] x, double[] y, double a, double b)
        {
            double[,] polynoms_matrix = new double[x.Length, x.Length];
            polynoms_matrix = Generate_polynom(a, b, x.Length);
            double[,] SLAY_matrix = new double[x.Length, x.Length];
            double[] SLAY_vector = new double[x.Length];

            for (int i = 0; i < x.Length; i++)
            {
                for (int j = 0; j < x.Length; j++)
                {
                    SLAY_matrix[i, j] = 0;
                }
                SLAY_vector[i] = 0;
            }

            for (int i=0; i<x.Length; i++)
            {
                for (int j=0; j<x.Length; j++)
                {
                    for (int k=0; k<x.Length; k++)
                    {
                        SLAY_matrix[i, j] += Counting_value(polynoms_matrix, j, x[k]) * Counting_value(polynoms_matrix, i, x[k]);
                    }
                    SLAY_vector[i] += y[j] * Counting_value(polynoms_matrix, i, x[j]);
                }
            }

            Print_matrix(SLAY_matrix, x.Length, "SLAY_matrix:");
            Print_mas(SLAY_vector, "SLAY_vector");

            double[] coefficients_vector = Gayss_method(SLAY_matrix, SLAY_vector);

            // polynom_matrix надо покоординатно умножить на coefficients_vector

            for (int i = 0; i < coefficients_vector.Length; i++)
            {
                for (int j=0; j<=i; j++)
                {
                    polynoms_matrix[i, j] *= coefficients_vector[i];
                }
            }

            double[] result_vector = new double[coefficients_vector.Length];

            for (int i=0; i<result_vector.Length; i++)
            {
                result_vector[i] = 0;
            }

            for (int i = 0; i < result_vector.Length; i++)
            {
                for (int j = 0; j < result_vector.Length; j++)
                {
                    result_vector[i] += polynoms_matrix[j, i];
                }
            }

            Print_mas(result_vector, "Ответ:");
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

            LSM(x, y, 1, 3);
        }
    }
}
