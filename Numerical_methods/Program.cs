using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Understanding_equations
{
    class For_equals
    {
        public string s;
        private int count_of_signs; // Количество операторов в строке
        private string[] operator_; // Хранится символьный тип оператора, например '*'
        private string[,] variables_using; // Хранятся переменные или значения, к которым применяется данный оператор (для вычислений)
        private string[,] variables_copy; // Хранятся переменные или значения, к которым применяется данный оператор (не для вычислений)
        private double[] result; // Хранится результат выполнения операции

        int count_of_parameters = 0; // Количество параметров в системе уравнений (в одном уравнении)
        string[] parameters; // Хранятся имена переменных
        double[] value; // Хранятся значения переменных

        private List<int> coordinate_left_brace = new List<int>();
        private List<int> coordinate_right_brace = new List<int>();

        // Cтандартный конструктор
        public For_equals(string equation_str, string parameters_str)
        {
            s = equation_str;
            count_of_signs = Counting_operations();
            operator_ = new string[count_of_signs];
            variables_using = new string[count_of_signs, 2];
            variables_copy = new string[count_of_signs, 2];
            result = new double[count_of_signs];

            for (int i = 0; i < count_of_signs; i++)
            {
                operator_[i] = "";
                variables_using[i, 0] = " ";
                variables_using[i, 1] = " ";
                variables_copy[i, 0] = " ";
                variables_copy[i, 0] = " ";
                result[i] = 0;
            }

            parameters = parameters_str.Split(new char[] { ' ' });
            count_of_parameters = parameters.Length;
            value = new double[count_of_parameters];

            for (int i = 0; i < count_of_parameters; i++)
            {
                value[i] = 0;
            }
        }
        // Добавление пробелов до и перед знаками
        public string Add_space()
        {
            s = s.Insert(0, " ");
            for (int i = 1; i < s.Length; i++)
            {
                if ((s[i] == '-') || (s[i] == '+') || (s[i] == '^') || (s[i] == '*') || (s[i] == '/'))
                {
                    s = s.Insert(i, " ");
                    s = s.Insert(i + 2, " ");
                    i = i + 2;
                }
                if (s[i] == '(')
                {
                    s = s.Insert(i + 1, " ");
                    i++;
                }
                if (s[i] == ')')
                {
                    s = s.Insert(i, " ");
                    i++;
                }
                if ((s[i] == 'n') && (s[i - 1] == 'i') && (s[i - 2] == 's') && (s[i + 1] != ' '))
                {
                    s = s.Insert(i + 1, " ");
                }
                if ((s[i] == 's') && (s[i - 1] == 'o') && (s[i - 2] == 'c') && (s[i + 1] != ' '))
                {
                    s = s.Insert(i + 1, " ");
                }
                if ((s[i] == 'g') && (s[i - 1] == 't') && (s[i + 1] != ' '))
                {
                    s = s.Insert(i + 1, " ");
                }
                if ((s[i] == 'g') && (s[i - 1] == 't') && (s[i - 2] == 'c') && (s[i + 1] != ' '))
                {
                    s = s.Insert(i + 1, " ");
                }
                if ((s[i] == 'g') && (s[i - 1] == 'l'))
                {
                    s = s.Insert(i + 1, " ");
                }
                if ((s[i] == 'n') && (s[i - 1] == 'l'))
                {
                    s = s.Insert(i + 1, " ");
                }
            }
            s = s.Insert(s.Length, " ");
            return s;
        }
        // Подсчёт и упорядочивание скобочек
        public void Work_with_brace()
        {
            int size_left_brace = 0;
            int size_right_brace = 0;
            Counting_left_and_right_braces(ref size_left_brace, ref size_right_brace);

            //Print_mas(coordinate_left_brace, "Коорединаты левых скобочек");
            //Print_mas(coordinate_right_brace, "Координаты правых скобочек");

            // Теперь надо отсортировать массивы так, чтобы операции, ограниченные скобками, выполнялись в заданном порядке
            int max;
            int i_max;
            int helper;
            for (int i = 0; i < coordinate_left_brace.Count - 1; i++)
            {
                max = coordinate_left_brace[i];
                i_max = i;
                for (int j = i; j < coordinate_left_brace.Count; j++)
                {
                    if ((coordinate_left_brace[j] > max) && (coordinate_left_brace[j] < coordinate_right_brace[i]))
                    {
                        max = coordinate_left_brace[j];
                        i_max = j;
                    }
                }
                helper = coordinate_left_brace[i];
                coordinate_left_brace[i] = coordinate_left_brace[i_max];
                coordinate_left_brace[i_max] = helper;
            }
            //Print_mas(coordinate_left_brace, "Правильные координаты левых скобочек");
            //Print_mas(coordinate_right_brace, "Правильные координаты правых скобочек");
        }
        // Заполнение массива с операторами и переменными
        public void Filling_mass()
        {
            int begin_coordinate = 0;
            int end_coordinate = 0;
            int value = 0;

            //Console.WriteLine("Длина уравнения равна {0}", s.Length);
            //Console.WriteLine("s = {0}", s);

            // Сначала проходимся по всем знакам в скобочках
            for (int i = 0; i < coordinate_left_brace.Count; i++)
            {
                // Сначала в скобочках ищем знак '^' и обрабатываем их
                for (int j = coordinate_left_brace[i]; j < coordinate_right_brace[i]; j++)
                {
                    if (s[j] == '^')
                    {
                        j = j - If_we_find_sign(begin_coordinate, end_coordinate, ref value, j, "^");
                    }
                    else if ((j >= 2) && (s[j] == 'n') && (s[j - 1] == 'i') && (s[j - 2] == 's'))
                    {
                        if ((j >= 5) && (s[j - 3] == 'c') && (s[j - 4] == 'r') && (s[j - 5] == 'a'))
                        {
                            j = j - If_we_find_sign(begin_coordinate, ref value, j, 6, "arcsin");
                        }
                        else
                        {
                            j = j - If_we_find_sign(begin_coordinate, ref value, j, 3, "sin");
                        }
                    }
                    else if ((j >= 2) && (s[j] == 's') && (s[j - 1] == 'o') && (s[j - 2] == 'c'))
                    {
                        if ((j >= 5) && (s[j - 3] == 'c') && (s[j - 4] == 'r') && (s[j - 5] == 'a'))
                        {
                            j = j - If_we_find_sign(begin_coordinate, ref value, j, 6, "arccos");
                        }
                        else
                        {
                            j = j - If_we_find_sign(begin_coordinate, ref value, j, 3, "cos");
                        }
                    }
                    else if ((j >= 1) && (s[j] == 'g') && (s[j - 1] == 't'))
                    {
                        if ((j >= 5) && (s[j - 2] == 'c') && (s[j - 3] == 'c') && (s[j - 4] == 'r') && (s[j - 5] == 'a'))
                        {
                            j = j - If_we_find_sign(begin_coordinate, ref value, j, 6, "arcctg");
                        }
                        else if ((j >= 4) && (s[j - 2] == 'c') && (s[j - 3] == 'r') && (s[j - 4] == 'a'))
                        {
                            j = j - If_we_find_sign(begin_coordinate, ref value, j, 5, "arctg");
                        }
                        else if ((j >= 2) && (s[j - 2] == 'c'))
                        {
                            j = j - If_we_find_sign(begin_coordinate, ref value, j, 3, "ctg");
                        }
                        else
                        {
                            j = j - If_we_find_sign(begin_coordinate, ref value, j, 2, "tg");
                        }
                    }
                    else if ((j >= 1) && (s[j] == 'g') && (s[j - 1] == 'l'))
                    {
                        j = j - If_we_find_sign(begin_coordinate, ref value, j, 2, "lg");
                    }
                    else if ((j >= 1) && (s[j] == 'n') && (s[j - 1] == 'l'))
                    {
                        j = j - If_we_find_sign(begin_coordinate, ref value, j, 2, "ln");
                    }
                    if (j < coordinate_left_brace[i])
                    {
                        j = coordinate_left_brace[i];
                    }
                }
                // Затем в этих же скобочках ищем знаки '*' или '/' и обрабатываем их
                for (int j = coordinate_left_brace[i]; j < coordinate_right_brace[i]; j++)
                {
                    if (s[j] == '*')
                    {
                        j = j - If_we_find_sign(begin_coordinate, end_coordinate, ref value, j, "*");
                    }
                    else if (s[j] == '/')
                    {
                        j = j - If_we_find_sign(begin_coordinate, end_coordinate, ref value, j, "/");
                    }
                    if (j < coordinate_left_brace[i])
                    {
                        j = coordinate_left_brace[i];
                    }
                }
                // После чего ищем знаки '+' или '-' и обрабатываем их
                for (int j = coordinate_left_brace[i]; j < coordinate_right_brace[i]; j++)
                {
                    if (s[j] == '+')
                    {
                        j = j - If_we_find_sign(begin_coordinate, end_coordinate, ref value, j, "+");
                    }
                    else if (s[j] == '-')
                    {
                        j = j - If_we_find_sign(begin_coordinate, end_coordinate, ref value, j, "-");
                    }
                    if (j < coordinate_left_brace[i])
                    {
                        j = coordinate_left_brace[i];
                    }
                }
                // Снятие скобочек
                Console.WriteLine("s = {0}", s);
                s = s.Remove(coordinate_right_brace[i] - 1, 2);
                Console.WriteLine("s = {0}", s);
                s = s.Remove(coordinate_left_brace[i], 2);
                //Console.WriteLine("coordinate_right_brace[i] - 3 = {0}", coordinate_right_brace[i] - 3);
                //Console.WriteLine("s.Length = {0}", s.Length);
                Console.WriteLine("s = {0}", s);
                Do_shift_brace(4, coordinate_right_brace[i] - 3);
                //Print_mas(coordinate_left_brace, "Новые координаты левых скобочек");
                //Print_mas(coordinate_right_brace, "Новые координаты правых скобочек");
                //Console.WriteLine("s = {0}", s);
            }
            //Console.WriteLine("s.Length = {0}", s.Length);

            // Теперь проходимя по всем знакам без скобочек
            // Сначала в скобочках ищем знак '^' и обрабатываем их
            for (int j = 0; j < s.Length; j++)
            {
                if (s[j] == '^')
                {
                    j = j - If_we_find_sign(begin_coordinate, end_coordinate, ref value, j, "^");
                }
                else if ((j >= 2) && (s[j] == 'n') && (s[j - 1] == 'i') && (s[j - 2] == 's'))
                {
                    if ((j >= 5) && (j >= 5) && (s[j - 3] == 'c') && (s[j - 4] == 'r') && (s[j - 5] == 'a'))
                    {
                        j = j - If_we_find_sign(begin_coordinate, ref value, j, 6, "arcsin");
                    }
                    else
                    {
                        j = j - If_we_find_sign(begin_coordinate, ref value, j, 3, "sin");
                    }
                }
                else if ((j >= 2) && (s[j] == 's') && (s[j - 1] == 'o') && (s[j - 2] == 'c'))
                {
                    if ((j >= 5) && (s[j - 3] == 'c') && (s[j - 4] == 'r') && (s[j - 5] == 'a'))
                    {
                        j = j - If_we_find_sign(begin_coordinate, ref value, j, 6, "arccos");
                    }
                    else
                    {
                        j = j - If_we_find_sign(begin_coordinate, ref value, j, 3, "cos");
                    }
                }
                else if ((j >= 1) && (s[j] == 'g') && (s[j - 1] == 't'))
                {
                    if ((j >= 5) && (s[j - 2] == 'c') && (s[j - 3] == 'c') && (s[j - 4] == 'r') && (s[j - 5] == 'a'))
                    {
                        j = j - If_we_find_sign(begin_coordinate, ref value, j, 6, "arcctg");
                    }
                    else if ((j >= 4) && (s[j - 2] == 'c') && (s[j - 3] == 'r') && (s[j - 4] == 'a'))
                    {
                        j = j - If_we_find_sign(begin_coordinate, ref value, j, 5, "arctg");
                    }
                    else if ((j >= 2) && (s[j - 2] == 'c'))
                    {
                        j = j - If_we_find_sign(begin_coordinate, ref value, j, 3, "ctg");
                    }
                    else
                    {
                        j = j - If_we_find_sign(begin_coordinate, ref value, j, 2, "tg");
                    }
                }
                else if ((j >= 1) && (s[j] == 'g') && (s[j - 1] == 'l'))
                {
                    j = j - If_we_find_sign(begin_coordinate, ref value, j, 2, "lg");
                }
                else if ((j >= 1) && (s[j] == 'n') && (s[j - 1] == 'l'))
                {
                    j = j - If_we_find_sign(begin_coordinate, ref value, j, 2, "ln");
                }
                if (j < 0)
                {
                    j = 0;
                }
            }

            // Затем в этих же скобочках ищем знаки '*' или '/' и обрабатываем их
            for (int j = 0; j < s.Length; j++)
            {
                if (s[j] == '*')
                {
                    j = j - If_we_find_sign(begin_coordinate, end_coordinate, ref value, j, "*");
                }
                else if (s[j] == '/')
                {
                    j = j - If_we_find_sign(begin_coordinate, end_coordinate, ref value, j, "/");
                }
                if (j < 0)
                {
                    j = 0;
                }
            }
            // После чего ищем знаки '+' или '-' и обрабатываем их
            for (int j = 0; j < s.Length; j++)
            {
                if (s[j] == '+')
                {
                    j = j - If_we_find_sign(begin_coordinate, end_coordinate, ref value, j, "+");
                }
                else if (s[j] == '-')
                {
                    j = j - If_we_find_sign(begin_coordinate, end_coordinate, ref value, j, "-");
                }
                if (j < 0)
                {
                    j = 0;
                }
            }

            for (int i = 0; i < count_of_signs; i++)
            {
                variables_copy[i, 0] = variables_using[i, 0];
                variables_copy[i, 1] = variables_using[i, 1];
            }

            Console.WriteLine("s = {0}", s);
        }
        public void Search_and_execute_sign(int begin_coordinate, int end_coordinate, ref int value, ref int begin, ref int end)
        {
            // Затем в этих же скобочках ищем знаки '*' или '/' и обрабатываем их
            for (int j = begin; j < end; j++)
            {
                if (s[j] == '*')
                {
                    j = j - If_we_find_sign(begin_coordinate, end_coordinate, ref value, j, "*");
                }
                else if (s[j] == '/')
                {
                    j = j - If_we_find_sign(begin_coordinate, end_coordinate, ref value, j, "/");
                }
                if (j < 0)
                {
                    j = 0;
                }
            }
            // После чего ищем знаки '+' или '-' и обрабатываем их
            for (int j = begin; j < end; j++)
            {
                if (s[j] == '+')
                {
                    j = j - If_we_find_sign(begin_coordinate, end_coordinate, ref value, j, "+");
                }
                else if (s[j] == '-')
                {
                    j = j - If_we_find_sign(begin_coordinate, end_coordinate, ref value, j, "-");
                }
                if (j < 0)
                {
                    j = 0;
                }
            }
        }
        // Вывод строки s на экран
        public void Print_s()
        {
            Console.WriteLine("s = {0}", s);
        }
        // Вывод массива на экран
        public void Print_mas(int[] x, string s)
        {
            Console.WriteLine(s);
            for (int i = 0; i < x.Length; i++)
            {
                Console.Write("{0} ", x[i]);
            }
            Console.WriteLine();
        }
        public void Print_mas(List<int> x, string s)
        {
            Console.WriteLine(s);
            for (int i = 0; i < x.Count; i++)
            {
                Console.Write("{0} ", x[i]);
            }
            Console.WriteLine();
        }
        public void Print_3_mas(string str)
        {
            Console.WriteLine(str);
            Console.WriteLine("operator_ variables[0] variables[1] result");
            for (int i = 0; i < operator_.Length; i++)
            {
                Console.WriteLine("{0} {1} {2} {3}", operator_[i], variables_using[i, 0], variables_using[i, 1], result[i]);
            }
        }
        // Подстановка значений переменных в массивы
        public void Substitution_of_Parameters()
        {
            for (int i = 0; i < count_of_signs; i++)
            {
                variables_using[i, 0] = variables_copy[i, 0];
                variables_using[i, 1] = variables_copy[i, 1];
            }

            for (int i = 0; i < count_of_signs; i++)
            {
                for (int j = 0; j < count_of_parameters; j++)
                {
                    if (variables_using[i, 0] == parameters[j])
                    {
                        variables_using[i, 0] = value[j].ToString();
                    }
                    if (variables_using[i, 1] == parameters[j])
                    {
                        variables_using[i, 1] = value[j].ToString();
                    }
                }
            }
        }
        // Выполнение операций
        public double Execute()
        {
            for (int i = 0; i < count_of_signs; i++)
            {
                if (variables_using[i, 0] == "e")
                {
                    variables_using[i, 0] = "2,718282";
                }
                if (variables_using[i, 0] == "pi")
                {
                    variables_using[i, 0] = "3,141593";
                }
                if (variables_using[i, 1] == "e")
                {
                    variables_using[i, 1] = "2,718282";
                }
                if (variables_using[i, 1] == "pi")
                {
                    variables_using[i, 1] = "3,141593";
                }
            }

            int helper_1 = 0;
            int helper_2 = 0;
            for (int i = 0; i < count_of_signs; i++)
            {
                if (variables_using[i, 0][0] == '[')
                {
                    helper_1 = int.Parse(variables_using[i, 0].Substring(1, variables_using[i, 0].IndexOf(']') - 1));
                    variables_using[i, 0] = result[helper_1].ToString();
                }
                if (variables_using[i, 1][0] == '[')
                {
                    helper_2 = int.Parse(variables_using[i, 1].Substring(1, variables_using[i, 1].IndexOf(']') - 1));
                    variables_using[i, 1] = result[helper_2].ToString();
                }

                if (operator_[i] == "^")
                {
                    result[i] = Math.Pow(double.Parse(variables_using[i, 0]), double.Parse(variables_using[i, 1]));
                }
                else if (operator_[i] == "*")
                {
                    result[i] = double.Parse(variables_using[i, 0]) * double.Parse(variables_using[i, 1]);
                }
                else if (operator_[i] == "/")
                {
                    result[i] = double.Parse(variables_using[i, 0]) / double.Parse(variables_using[i, 1]);
                }
                else if (operator_[i] == "+")
                {
                    result[i] = double.Parse(variables_using[i, 0]) + double.Parse(variables_using[i, 1]);
                }
                else if (operator_[i] == "-")
                {
                    result[i] = double.Parse(variables_using[i, 0]) - double.Parse(variables_using[i, 1]);
                }
                else if (operator_[i] == "sin")
                {
                    result[i] = Math.Sin(double.Parse(variables_using[i, 0]));
                }
                else if (operator_[i] == "cos")
                {
                    result[i] = Math.Cos(double.Parse(variables_using[i, 0]));
                }
                else if (operator_[i] == "tg")
                {
                    result[i] = Math.Tan(double.Parse(variables_using[i, 0]));
                }
                else if (operator_[i] == "ctg")
                {
                    result[i] = 1 / (Math.Tan(double.Parse(variables_using[i, 0])));
                }
                else if (operator_[i] == "arcsin")
                {
                    result[i] = Math.Asin(double.Parse(variables_using[i, 0]));
                }
                else if (operator_[i] == "arccos")
                {
                    result[i] = Math.Acos(double.Parse(variables_using[i, 0]));
                }
                else if (operator_[i] == "arctg")
                {
                    result[i] = Math.Atan(double.Parse(variables_using[i, 0]));
                }
                else if (operator_[i] == "arcctg")
                {
                    result[i] = Math.PI / 2 - Math.Atan(double.Parse(variables_using[i, 0]));
                }
                else if (operator_[i] == "ln")
                {
                    result[i] = Math.Log(double.Parse(variables_using[i, 0]));
                }
                else if (operator_[i] == "lg")
                {
                    result[i] = Math.Log10(double.Parse(variables_using[i, 0]));
                }
            }
            //Console.WriteLine("Ответ: {0}", result[count_of_signs - 1]);
            return result[count_of_signs - 1];
        }
        // Обработка поступившего уравнения
        public void Decide_first_time()
        {
            Add_space(); // Добавление пробелов до и перед знаками
            Print_s(); // Вывод строки s на экран

            Work_with_brace(); // Подсчёт и упорядочивание скобочек
            Filling_mass(); // Заполнение массива с операторами и переменными
            //Print_3_mas("Массивы после второго этапа преобразований"); // Вывод строки s на экран
        }
        // Вычисление значения уравнения(ий) с заданными параметрами
        public double Decide(double[] mas)
        {
            Change_mas_of_string(mas);

            Substitution_of_Parameters(); // Подстановка значений переменных в массивы
            //Print_3_mas("Массивы после третьего этапа преобразований"); // Вывод строки s на экран

            return Execute();
        }
        public double Decide(string[] mas)
        {
            Change_mas_of_string(mas);

            Substitution_of_Parameters(); // Подстановка значений переменных в массивы
            //Print_3_mas("Массивы после третьего этапа преобразований"); // Вывод строки s на экран

            return Execute();
        }
        // Замена значений переменных
        public void Change_mas_of_string(double[] mas)
        {
            for (int i = 0; i < count_of_parameters; i++)
            {
                value[i] = mas[i];
            }
            //Console.WriteLine("mas_of_string[0] = {0}", value[0]);
        }
        public void Change_mas_of_string(string[] mas)
        {
            for (int i = 0; i < count_of_parameters; i++)
            {
                value[i] = double.Parse(mas[i]);
            }
            //Console.WriteLine("mas_of_string[0] = {0}", value[0]);
        }
        // Поиск последнего пробела в строке
        private int Search_last_space(int first_number)
        {
            for (int i = first_number; i < s.Length; i++)
            {
                if (s[i] == ' ')
                {
                    return i;
                }
            }
            return s.Length;
        }
        // Поиск первого пробела в строке
        private int Search_first_space(int last_number)
        {
            int number = -1;
            for (int i = 0; i < last_number; i++)
            {
                if (s[i] == ' ')
                {
                    number = i;
                }
            }
            return number;
        }
        // Посчёт количества знаков в уравнении
        private int Counting_operations()
        {
            int lol = s.Length;
            int count_of_signs = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if ((s[i] == '-') || (s[i] == '+') || (s[i] == '^') || (s[i] == '*') || (s[i] == '/'))
                {
                    count_of_signs++;
                }
            }
            // Подсчитываем количество синусов в строке
            count_of_signs = count_of_signs + ((s.Length - s.Replace("sin", "").Length) / 3);
            count_of_signs = count_of_signs + ((s.Length - s.Replace("cos", "").Length) / 3);
            count_of_signs = count_of_signs + ((s.Length - s.Replace("tg", "").Length) / 2);
            count_of_signs = count_of_signs + ((s.Length - s.Replace("ln", "").Length) / 2);
            count_of_signs = count_of_signs + ((s.Length - s.Replace("lg", "").Length) / 2);
            return count_of_signs;
        }
        // Делаем сдвиг массива с координатами скобочек
        private void Do_shift_brace(int shift, int j)
        {
            for (int k = 0; k < coordinate_left_brace.Count; k++)
            {
                if (coordinate_left_brace[k] > j)
                {
                    coordinate_left_brace[k] = coordinate_left_brace[k] - shift;
                }
                if (coordinate_right_brace[k] > j)
                {
                    coordinate_right_brace[k] = coordinate_right_brace[k] - shift;
                }
            }
        }
        // Заполнение массивов информацией, если мы нашли знак
        private int If_we_find_sign(int begin_coordinate, ref int value, int j, int length, string sign)
        {
            begin_coordinate = Search_first_space(j + 2);

            operator_[value] = sign;
            variables_using[value, 0] = s.Substring(j + 2, j + 2 - begin_coordinate);

            s = s.Remove(j - length + 1, begin_coordinate - j + length + 1);
            string helper = value.ToString();
            value++;
            helper = "[" + helper + "]";
            s = s.Insert(j - length + 1, helper);

            // Необходимо изменить положение скобочек в строке
            int shift = (begin_coordinate - j + length - 1) - helper.Length;
            Do_shift_brace(shift, j);

            return shift;
        }
        private int If_we_find_sign(int begin_coordinate, int end_coordinate, ref int value, int j, string sign)
        {
            // До и после знака идёт пробел. Нужно найти ещё соседние пробелы справа и слева.
            begin_coordinate = Search_first_space(j - 2);
            end_coordinate = Search_last_space(j + 2);

            operator_[value] = sign;

            variables_using[value, 0] = s.Substring(begin_coordinate + 1, j - 2 - begin_coordinate);
            variables_using[value, 1] = s.Substring(j + 2, end_coordinate - j - 2);

            s = s.Remove(begin_coordinate + 1, end_coordinate - begin_coordinate - 1);
            string helper = value.ToString();
            value++;
            helper = "[" + helper + "]";
            s = s.Insert(begin_coordinate + 1, helper);

            // Необходимо изменить положение скобочек в строке
            int shift = (end_coordinate - begin_coordinate - 1) - helper.Length;
            // Проходимся по всем элементам массива, в котором хранятся координаты скобочек и, если элемент массива
            // больше текущего, то делаем сдвиг
            Do_shift_brace(shift, j);

            return shift;
        }
        // Считаем количество правых и левых скобочек
        private void Counting_left_and_right_braces(ref int size_left_brace, ref int size_right_brace)
        {
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(')
                {
                    size_left_brace++;
                    coordinate_left_brace.Add(i);
                }
                if (s[i] == ')')
                {
                    size_right_brace++;
                    coordinate_right_brace.Add(i);
                }
            }
        }
    }
    class Program
    {
        public static double Return_F1(double x)
        {
            return x * x - 16;
        }
        public static double Return_F11(double x)
        {
            return x * x - x - 16;
        }
        public static double Return_F2(double x)
        {
            return x * x - Math.Log(x) - 2 * Math.Cos(x) - 1;
        }
        public static double Return_F3(double x)
        {
            return x * x / 100;
        }
        public static double Return_F4(double x)
        {
            //return -(1 / 2 + x * x - Math.Cos(x));
            return x * x * x + 2;
        }
        // Решения СНУ через распознавание уравнения
        public static void Method_of_chord(string equation_str, string parameters_string, double a, double b)
        {
            Console.WriteLine("Решаем СНУ методом хорд");

            double e = 0;
            Console.WriteLine("Введите погрешность e:");
            e = double.Parse(Console.ReadLine());

            int k = 0;
            double[] parameters = new double[1];
            double c = 0;
            double helper_c = 0;
            double F_a = 0;
            double F_b = 0;
            double F_c = 0;
            For_equals example = new For_equals(equation_str, parameters_string);
            example.Decide_first_time();

            do
            {
                k++;
                parameters[0] = a;
                F_a = example.Decide(parameters);
                parameters[0] = b;
                F_b = example.Decide(parameters);
                helper_c = c;
                c = a - (F_a / (F_b - F_a)) * (b - a);
                parameters[0] = c;
                F_c = example.Decide(parameters);
                Console.WriteLine("F({0}) = {1}", a, F_a);
                Console.WriteLine("F({0}) = {1}", b, F_b);
                Console.WriteLine("F({0}) = {1}", c, F_c);
                Console.WriteLine();
                if (F_a * F_c < 0)
                {
                    b = c;
                }
                if (F_c * F_b < 0)
                {
                    a = c;
                }
            } while (Math.Abs(helper_c - c) > e);
            Console.WriteLine("В точке {0} функция F({0}) принимает значение {1}", c, F_c);
            Console.WriteLine("Количество итераций равно {0}", k);
        }
        public static void Simple_iteration_method(string equation_str, string parameters_string, double a)
        {
            Console.WriteLine("Решаем СНУ методом простых итераций");

            double e = 0;
            Console.WriteLine("Введите погрешность e:");
            e = double.Parse(Console.ReadLine());

            int k = 0;
            int limit_k = 0;
            Console.WriteLine("Введите предельное количество итераций:");
            limit_k = int.Parse(Console.ReadLine());
            double[] parameters = new double[1];
            double helper_a = 0;
            For_equals example = new For_equals(equation_str, parameters_string);
            example.Decide_first_time();

            do
            {
                k++;
                if (k > limit_k)
                {
                    Console.WriteLine("Достигнута предельная итерация. Решение с заданной точностью не найдено");
                    return;
                }
                helper_a = a;
                parameters[0] = a;
                a = example.Decide(parameters);
                Console.WriteLine("F({0}) = {1}", helper_a, a);
                if (a > Math.Pow(10, 50))
                {
                    Console.WriteLine("Метод расходится");
                    return;
                }
            } while (Math.Abs(a - helper_a) > e);
            Console.WriteLine("В точке {0} функция F({0}) принимает значение {1}", helper_a, a);
            Console.WriteLine("Количество итераций равно {0}", k);
        }
        public static void Vegstein_method(string equation_str, string parameters_string, double a)
        {
            Console.WriteLine("Решаем СНУ методом Вегстейна");

            double e = 0;
            Console.WriteLine("Введите погрешность e:");
            e = double.Parse(Console.ReadLine());

            int k = 0;
            int limit_k = 0;
            Console.WriteLine("Введите предельное количество итераций:");
            limit_k = int.Parse(Console.ReadLine());
            For_equals example = new For_equals(equation_str, parameters_string);
            example.Decide_first_time();
            double[] parameters_x0 = new double[1];
            double[] parameters_x1 = new double[1];
            double x0 = a;
            double x1 = Return_F1(x0);
            double y0 = x0;
            double y1 = x1;
            double y2;
            double x2;
            //Console.WriteLine("x = {0}", x);

            do
            {
                k++;
                if (k > limit_k)
                {
                    Console.WriteLine("Достигнута предельная итерация. Решение с заданной точностью не найдено");
                    return;
                }
                parameters_x0[0] = x1;
                y2 = example.Decide(parameters_x0);
                x2 = y2 - ((y2 - y1) * (y2 - x1)) / ((y2 - y1) - (x1 - x0));
                if (Math.Abs(y2 - y1) < e)
                {
                    break;
                }
                x0 = x1;
                y0 = y1;
                x1 = x2;
                y1 = y2;
            } while (true);
            Console.WriteLine("В точке {0} функция F({0}) принимает значение {1}", x2, Return_F11(y2));
            Console.WriteLine("Количество итераций равно {0}", k);
        }
        // Решения СНУ обычным методом
        public static void Method_of_chord(double a, double b)
        {
            Console.WriteLine("Решаем СНУ методом хорд");

            double e = 0;
            Console.WriteLine("Введите погрешность e:");
            e = double.Parse(Console.ReadLine());

            int k = 0;
            double c = 0;
            double helper_c = 0;
            double F_a = 0;
            double F_b = 0;
            double F_c = 0;

            do
            {
                k++;
                F_a = Return_F1(a);
                F_b = Return_F1(b);
                helper_c = c;
                c = a - (F_a / (F_b - F_a)) * (b - a);
                F_c = Return_F1(c);
                Console.WriteLine("F({0}) = {1}", a, F_a);
                Console.WriteLine("F({0}) = {1}", b, F_b);
                Console.WriteLine("F({0}) = {1}", c, F_c);
                Console.WriteLine();
                if (F_a * F_c < 0)
                {
                    b = c;
                }
                if (F_c * F_b < 0)
                {
                    a = c;
                }
            } while (Math.Abs(helper_c - c) > e);
            Console.WriteLine("В точке {0} функция F({0}) принимает значение {1}", c, F_c);
            Console.WriteLine("Количество итераций равно {0}", k);
        }
        public static void Simple_iteration_method(double a)
        {
            Console.WriteLine("Решаем СНУ методом простых итераций");

            double e = 0;
            Console.WriteLine("Введите погрешность e:");
            e = double.Parse(Console.ReadLine());

            int k = 0;
            int limit_k = 0;
            Console.WriteLine("Введите предельное количество итераций:");
            limit_k = int.Parse(Console.ReadLine());
            double helper_a = 0;

            do
            {
                k++;
                if (k > limit_k)
                {
                    Console.WriteLine("Достигнута предельная итерация. Решение с заданной точностью не найдено");
                    return;
                }
                helper_a = a;
                a = Return_F1(a);
                Console.WriteLine("F({0}) = {1}", helper_a, a);
                if (a > Math.Pow(10, 50))
                {
                    Console.WriteLine("Метод расходится");
                    return;
                }
            } while (Math.Abs(a - helper_a) > e);
            Console.WriteLine("В точке {0} функция F({0}) принимает значение {1}", helper_a, a);
            Console.WriteLine("Количество итераций равно {0}", k);
        }
        public static void Vegstein_method(double a)
        {
            Console.WriteLine("Решаем СНУ методом Вегстейна");

            double e = 0;
            Console.WriteLine("Введите погрешность e:");
            e = double.Parse(Console.ReadLine());

            int k = 0;
            int limit_k = 0;
            Console.WriteLine("Введите предельное количество итераций:");
            limit_k = int.Parse(Console.ReadLine());
            double x0 = a;
            double x1 = Return_F1(x0);
            double y0 = x0;
            double y1 = x1;
            double y2;
            double x2;

            do
            {
                k++;
                if (k > limit_k)
                {
                    Console.WriteLine("Достигнута предельная итерация. Решение с заданной точностью не найдено");
                    return;
                }
                y2 = Return_F1(x1);
                x2 = y2 - ((y2 - y1) * (y2 - x1)) / ((y2 - y1) - (x1 - x0));
                if (Math.Abs(y2 - y1) < e)
                {
                    break;
                }
                x0 = x1;
                y0 = y1;
                x1 = x2;
                y1 = y2;
            } while (true);
            Console.WriteLine("В точке {0} функция F({0}) принимает значение {1}", x2, Return_F11(y2));
            Console.WriteLine("Количество итераций равно {0}", k);
        }
        // Чтение матрицы с файла
        public static string Input(string open_string)
        {
            StreamReader file = new StreamReader(open_string);
            string s = file.ReadToEnd();
            file.Close();
            return s;
        }
        public static void Open_file(string filename)
        {
            try
            {
                string my_string = Input(filename);
                //Console.WriteLine("Исходная система уравнений: {0}", my_string);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Файл не найден");
            }
            catch (FormatException)
            {
                Console.WriteLine("Неверное значение данных");
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Выход за границы массива");
            }
        }
        static void Main(string[] args)
        {
            string equation_str = "x^2-16";
            string equation_str_2 = "x^2-ln(x)-2*cos(x)-1";
            string equation_str_3 = "x^2/100";
            string equation_str_4 = "0-(1/2+x^2-cos(x))";
            string parameters_string = "x";
            double[] parameters = new double[1];
            parameters[0] = 8;

            //Method_of_chord(equation_str, parameters_string, -8, 0);
            //Method_of_chord(equation_str, parameters_string, 0, 8);
            //Method_of_chord(equation_str_2, parameters_string, 1, 4);
            //Method_of_chord(-8, 0);

            //Simple_iteration_method(equation_str, parameters_string, 8);
            //Simple_iteration_method(equation_str_2, parameters_string, 4);

            //Simple_iteration_method(equation_str_3, parameters_string, 90);

            Vegstein_method(equation_str, parameters_string, 4);

            //Vegstein_method(4);

            //Open_file("string.txt");
        }
    }
}